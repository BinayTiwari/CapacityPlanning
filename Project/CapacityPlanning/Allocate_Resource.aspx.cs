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
        int skillID;
        List<int> resourceID = new List<int>();
        //int RoleID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string id = Request.QueryString["RequestID"];
                lblResourceAllocation.Text = id;
                AllocateResourceBL displaydemand = new AllocateResourceBL();
                displaydemand.AllocateResourceByID(rptResourceAllocation, id);
                // AllocateResourceBL.AllocateResourceByID(rptResourceAllocation, id);
                // AllocateResourceBL.NoOfAllocated(rptResourceAllocation,id);
            }
        }
        protected void btnAllocate_Resource_Click(object sender, EventArgs e)
        {


            try
            {
                myDIV.Style.Add("display", "block");
                Button theButton = sender as Button;
                StartDate = theButton.Attributes["StartDate"];
                EndDate = theButton.Attributes["EndDate"];
                string skillName = theButton.Attributes["SkillsName"];
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_SkillsMaster
                                 where p.SkillsName == skillName
                                 select p.SkillsMasterID).ToList();
                    skillID = query[0];

                }

                ViewState["RoleID"] = Convert.ToInt32(theButton.CommandArgument);
                lblStartDate.Text = StartDate;
                lblEndDate.Text = EndDate;
                SearchAvailability(Convert.ToInt32(theButton.CommandArgument));
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
                //int count = 0;
                foreach (RepeaterItem item in rptSuggestions.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkRequired");
                    var chek = (CheckBox)sender;
                    //var reminderHiddenField = (HiddenField)chek.NamingContainer.FindControl("employeeID");
                    if (chk.Checked)
                    {
                        //var empID = reminderHiddenField.Value;
                        //name.Add(empID);
                        string EmployeeName = chek.Attributes["EmployeeName"];
                        name.Add(EmployeeName);
                        /*count++*/

                    }

                }
                //if(count>0)
                //dateSatrt = dateSatrt.Distinct().ToList();
                //dateEnd = dateEnd.Distinct().ToList();
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

                CPT_AllocateResource details = new CPT_AllocateResource();
                CPT_ResourceMaster empID = new CPT_ResourceMaster();
                AllocateResourceBL rbl = new AllocateResourceBL();


                resourceID = AllocateResourceBL.ResourceID(name);
                for (int j = 0; j < name.Count; j++)
                {

                    details.ResourceID = resourceID[j];
                    details.RequestID = Request.QueryString["RequestID"]; 
                    details.AccountID = AllocateResourceBL.getAccountID(details.RequestID.ToString());
                    details.StartDate = Convert.ToDateTime(StartDate);
                    details.EndDate = Convert.ToDateTime(EndDate);
                    empID.EmployeeMasterID = resourceID[j];
                    String acnt = rbl.getAccountByID(details.AccountID);
                    List<CPT_ResourceMaster> lst = rbl.getMailDetails(resourceID[j]);
                    String name = lst[0].EmployeetName;
                    String email = lst[0].Email;
                    rbl.Insert(details);
                    rbl.updateMap(empID);
                    //sendConfirmation(name, email, acnt, details.StartDate, details.EndDate);

                }
                Response.Redirect("ResourceMapping.aspx");
                //foreach (Repeater row in rptSuggestions.Items)
                //{
                //    var cb = row.FindControl("chkRequired") as CheckBox;
                //    if (cb != null)
                //        cb.Checked = false;

                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void sendConfirmation(String name, String mail, String account, DateTime startDate, DateTime endDate)
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
        public void SearchAvailability(int RoleID)
        {
            string id = Request.QueryString["RequestID"];
            lblSuggestions.Text = id;
            int roleID = Convert.ToInt32(ViewState["RoleID"]);
            DateTime dateStart = Convert.ToDateTime(StartDate);
             DateTime dateEnd = Convert.ToDateTime(EndDate);
            AllocateResourceBL rbl = new AllocateResourceBL();
            rbl.getFreeEmployee(rptSuggestions, roleID, dateStart, skillID.ToString(), dateEnd);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                StartDate = ((Convert.ToDateTime(StartDate)).AddDays(7)).ToShortDateString();
                DateTime dtstart = Convert.ToDateTime(StartDate);
                DateTime dtEnd = Convert.ToDateTime(EndDate);
                if (dtstart >= dtEnd)
                {

                    btnNext.Enabled = false;
                }
                else
                {

                    btnNext.Enabled = true;
                    lblStartDate.Text = StartDate;
                    SearchAvailability(Convert.ToInt32(ViewState["RoleID"]));
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

                    SearchAvailability(Convert.ToInt32(ViewState["RoleID"]));
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


        //private void Search(int RoleID)
        //{
        //    try
        //    {

        //        string id = Session["id"].ToString();
        //        lblSuggestions.Text = id;
        //        AllocateResourceBL.getEmployeeNameByResourceType(rptSuggestions, RoleID);

        //    }

        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //}
    }
}