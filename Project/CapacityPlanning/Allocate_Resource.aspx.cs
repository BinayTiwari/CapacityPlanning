using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class Allocate_Resource : System.Web.UI.Page
    {
        List<int> name = new List<int>();
        static string StartDate;
        static string EndDate;
        static List<string> skillID = new List<string>();
        static int roleID;
        static int requestDetailID;
       


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string id = Request.QueryString["RequestID"];

                lblResourceAllocation.Text = id;
                lblAccount.Text = Request.QueryString["AccountName"];
                lblProcessName.Text = Request.QueryString["ProcessName"];

                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];

                AllocateResourceBL displaydemand = new AllocateResourceBL();
                displaydemand.AllocateResourceByID(rptResourceAllocation, id, lstdetils[0].RolesID);

                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    float NoOfRes = 0;
                    float NoOfAllocate = 0;
                    Label lblNoOfResources = (Label)item.FindControl("lblNoOfResources");
                    Label lblAllocated = (Label)item.FindControl("Allocated");
                    Label lblRole = (Label)item.FindControl("RoleName");
                    NoOfRes = float.Parse(lblNoOfResources.Text);
                    NoOfAllocate = float.Parse(lblAllocated.Text);
                    if (NoOfRes == NoOfAllocate)
                    {
                        Button btn = (Button)item.FindControl("btnAlign");
                        btn.Enabled = false;
                    }
                    
                }
            }
        }
        protected void btnAllocate_Resource_Click(object sender, EventArgs e)
        {


            try
            {
                CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                myDIV.Style.Add("display", "block");
                Button theButton = sender as Button;
                requestDetailID = Convert.ToInt32(theButton.CommandArgument);

                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceDetails
                                 where p.RequestDetailID == requestDetailID
                                 select p).ToList();
                    roleID = query[0].ResourceTypeID;
                    StartDate = query[0].StartDate.ToShortDateString();
                    EndDate = query[0].EndDate.ToShortDateString();
                    skillID = query[0].SkillID.Split(',').ToList();
                    if(skillID.Count==1)
                    {
                        skillID.Clear();
                        skillID.Add(query[0].SkillID);
                        skillID.Add(query[0].SkillID);
                        skillID.Add(query[0].SkillID);
                    }
                }

                RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
                Label lblNoOfResources = (Label)item.FindControl("lblNoOfResources");


                float utilization = 0;
                if (float.Parse(lblNoOfResources.Text) < 1)
                {
                    utilization = float.Parse(lblNoOfResources.Text);
                }
                else
                {
                    utilization = 1;
                }

                ViewState["utilization"] = utilization;
                lblStartDate.Text = StartDate;
                lblEndDate.Text = EndDate;
                if (lstdetils[0].RolesID == 20 || lstdetils[0].RolesID == 25)
                {
                    //AccordingToRoleSearch();
                    SearchAvailability();
                }
                else
                {
                    SearchAvailability();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void rptSuggestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string a = ((DbDataRecord)e.Item.DataItem).GetValue(6).ToString();
                if (a.Equals("100"))
                {
                    CheckBox chk = (CheckBox)e.Item.FindControl("chkRequired");
                    chk.Enabled = false;
                }
            }
        }

        protected void rptResourceAllocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }

        protected void chkRequired_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in rptSuggestions.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkRequired");
                    var chek = (CheckBox)sender;
                    if (chk.Checked)
                    {
                        int EmployeeID = Convert.ToInt32(chek.Attributes["EmployeeMasterID"]);
                        name.Add(EmployeeID);

                    }

                }
                name = name.Distinct().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string RequestID = Request.QueryString["RequestID"];
                string RequesterEmailID = AllocateResourceBL.GetRequesterEmail(RequestID);
                CPT_AllocateResource details = new CPT_AllocateResource();
                CPT_ResourceMaster empID = new CPT_ResourceMaster();
                AllocateResourceBL rbl = new AllocateResourceBL();

                foreach (var item in name)
                {
                    details.ResourceID = Convert.ToInt32(item);
                    details.RequestDetailID = requestDetailID;
                    details.RequestID = RequestID;
                    details.AccountID = AllocateResourceBL.getAccountID(details.RequestID.ToString());
                    details.StartDate = Convert.ToDateTime(StartDate);
                    details.EndDate = Convert.ToDateTime(EndDate);
                    empID.EmployeeMasterID = Convert.ToInt32(item);
                    details.RoleMasterID = roleID;
                    details.Released = false;
                    details.IsDeployed = false;
                    details.Utilization = float.Parse(ViewState["utilization"].ToString());

                    string acnt = rbl.getAccountByID(details.AccountID);
                    List<CPT_ResourceMaster> lst = rbl.getMailDetails(Convert.ToInt32(item));
                    string name = lst[0].EmployeetName;
                    string email = lst[0].Email;
                    rbl.Insert(details);
                    rbl.updateMap(empID);
                    sendConfirmation(name, email, RequesterEmailID, acnt, details.StartDate, details.EndDate);
                }
                Response.Redirect("ResourceMapping.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void sendConfirmation(string name, string mail, string RequesterEmail, string account, DateTime startDate, DateTime endDate)
        {
            try
            {
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "AlignedResource";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(mail);
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add(name);
                registrationEmail.CC = new List<string>();
                registrationEmail.CC.Add(RequesterEmail);
                registrationEmail.STARTDATE = startDate.ToShortDateString().ToString();
                registrationEmail.ENDDATE = endDate.ToShortDateString().ToString();
                registrationEmail.ACCOUNT = account;
                //registrationEmail.UID = lstdetils[0].EmployeeMasterID.ToString();
                TokenMessageTemplate valEmail = new TokenMessageTemplate();
                valEmail.SendEmail(registrationEmail);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //lblResult.Text = "Your message failed to send, please try again.";
            }
        }

        public void SearchAvailability()
        {
            string id = Request.QueryString["RequestID"];
            lblSuggestions.Text = id;
            AllocateResourceBL rbl = new AllocateResourceBL();
            rbl.getFreeEmployee(rptSuggestions, roleID, EndDate, skillID, StartDate);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                StartDate = ((Convert.ToDateTime(StartDate)).AddDays(7)).ToShortDateString();
                DateTime dtstart = Convert.ToDateTime(StartDate);
                DateTime dtEnd = Convert.ToDateTime(EndDate);
                if (dtstart > dtEnd)
                {
                    btnNext.Enabled = false;
                }
                else
                {

                    btnNext.Enabled = true;
                    lblStartDate.Text = StartDate;
                    CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                    List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                    lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                    if (lstdetils[0].RolesID == 20 || lstdetils[0].RolesID == 25)
                    {
                        SearchAvailability();
                    }
                    else
                    {
                        SearchAvailability();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        protected void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            try
            {
                StartDate = ((Convert.ToDateTime(StartDate)).AddDays(-7)).ToShortDateString();
                DateTime dtstart = Convert.ToDateTime(StartDate);
                DateTime dtEnd = Convert.ToDateTime(EndDate);
                if (dtstart <= dtEnd)
                {
                    btnNext.Enabled = true;
                    CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                    List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                    lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                    if (lstdetils[0].RolesID == 20 || lstdetils[0].RolesID == 25)
                    {
                        SearchAvailability();
                    }
                    else
                    {
                        SearchAvailability();
                    }
                    lblStartDate.Text = StartDate;
                }
                else
                {
                    btnNext.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void UnDO_Click(object sender, EventArgs e)
        {
            Response.Redirect("Allocate_Resource.aspx?RequestID=" + Request.QueryString["RequestID"] + "");
        }



    }
}