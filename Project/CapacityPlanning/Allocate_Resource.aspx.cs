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
        List<string> dateSatrt = new List<string>();
        List<string> name = new List<string>();
        List<string> dateEnd = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                string id = Session["id"].ToString();
                lblResourceAllocation.Text = id;
                AllocateResourceBL.AllocateResourceByID(rptResourceAllocation, id);
            }
        }
        protected void btnAllocate_Resource_Click(object sender, EventArgs e)
        {


            try
            {
                myDIV.Style.Add("display", "block");
                Button theButton = sender as Button;
                Session["role"] = theButton.CommandArgument;
                string role = Session["role"].ToString();
                if (role != null)
                {
                    string id = Session["id"].ToString();
                    lblSuggestions.Text = id;
                    AllocateResourceBL.getEmployeeNameByResourceType(rptSuggestions, role);
                }
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
                        string StarDate = chek.Attributes["StartDate"];
                        string EndDate = chek.Attributes["EndDate"];
                        string EmployeeName = chek.Attributes["EmployeeName"];
                        dateSatrt.Add(StarDate);
                        dateEnd.Add(EndDate);
                        name.Add(EmployeeName);
                        //insert here from ui
                    }

                }
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

                List<int> resourceID = new List<int>();
                resourceID = AllocateResourceBL.ResourceID(name);
                for (int j = 0; j < name.Count; j++)
                {
                    
                    details.ResourceID = resourceID[j];
                    details.RequestID = Session["id"].ToString();
                    details.AccountID = AllocateResourceBL.getAccountID(Session["id"].ToString());
                    details.StartDate = Convert.ToDateTime(dateSatrt[j]);
                    details.EndDate = Convert.ToDateTime(dateEnd[j]);
                    empID.EmployeeMasterID = resourceID[j];
                    String acnt = rbl.getAccountByID(details.AccountID);
                    List<CPT_ResourceMaster> lst = rbl.getMailDetails(resourceID[j]);
                    String name = lst[0].EmployeetName;
                    String email = lst[0].Email;
                    sendConfirmation(name, email, acnt, details.StartDate, details.EndDate);
                    rbl.Insert(details);
                    rbl.updateMap(empID);
                }
               
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void sendConfirmation(String name, String mail, String account, DateTime startDate, DateTime endDate )
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //lblResult.Text = "Your message failed to send, please try again.";
            }
        }
    }
}