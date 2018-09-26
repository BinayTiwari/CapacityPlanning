using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        List<string> name = new List<string>();
        static string StartDate;
        static string EndDate;
        static string skillID;
        static int roleID;
        static int requestDetailID;
        List<int> resourceID = new List<int>();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string id = Request.QueryString["RequestID"];
                lblResourceAllocation.Text = id;
                AllocateResourceBL displaydemand = new AllocateResourceBL();
                displaydemand.AllocateResourceByID(rptResourceAllocation, id);
                
                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    Label lblNoOfResources = (Label)item.FindControl("lblNoOfResources");
                    Label lblAllocated = (Label)item.FindControl("Allocated");
                    
                    if(Convert.ToInt32(lblNoOfResources.Text) == Convert.ToInt32(lblAllocated.Text))
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
                    skillID = query[0].SkillID;

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
                SearchAvailability();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void rptSuggestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

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
                        string EmployeeName = chek.Attributes["EmployeeName"];
                        name.Add(EmployeeName);

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
                CPT_AllocateResource details = new CPT_AllocateResource();
                CPT_ResourceMaster empID = new CPT_ResourceMaster();
                AllocateResourceBL rbl = new AllocateResourceBL();



                resourceID = AllocateResourceBL.ResourceID(name);
                for (int j = 0; j < name.Count; j++)
                {

                    details.ResourceID = resourceID[j];
                    details.RequestDetailID = requestDetailID;
                    details.RequestID = RequestID;
                    details.AccountID = AllocateResourceBL.getAccountID(details.RequestID.ToString());
                    details.StartDate = Convert.ToDateTime(StartDate);
                    details.EndDate = Convert.ToDateTime(EndDate);
                    empID.EmployeeMasterID = resourceID[j];
                    details.RoleMasterID = roleID;
                    details.Released = false;
                    details.IsDeployed = false;
                    //    if (NoOfResources >= 1)
                    //        details.Utilization = 1;
                    ////    else
                    details.Utilization = float.Parse(ViewState["utilization"].ToString());

                    string acnt = rbl.getAccountByID(details.AccountID);
                    List<CPT_ResourceMaster> lst = rbl.getMailDetails(resourceID[j]);
                    string name = lst[0].EmployeetName;
                    string email = lst[0].Email;
                    rbl.Insert(details);
                    rbl.updateMap(empID);

                    //sendConfirmation(name, email, acnt, details.StartDate, details.EndDate);

                }
                Response.Redirect("ResourceMapping.aspx");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void sendConfirmation(string name, string mail, string account, DateTime startDate, DateTime endDate)
        {
            try
            {
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "AlignedResource";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(mail);
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add(name);
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
            rbl.getFreeEmployee(rptSuggestions, roleID, EndDate, skillID);
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
                    SearchAvailability();
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
                    SearchAvailability();
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