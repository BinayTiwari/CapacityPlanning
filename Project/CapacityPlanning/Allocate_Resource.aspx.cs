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
                //AllocateResourceBL.AllocateResource(rptResourceAllocation);

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
                    rbl.Insert(details);
                    rbl.updateMap(empID);
                    String acnt = rbl.getAccountByID(details.AccountID);
                    List<CPT_ResourceMaster> lst = rbl.getMailDetails(resourceID[j]);
                    String name = lst[0].EmployeetName;
                    String email = lst[0].Email;

                    sendConfirmation(name, email, acnt, details.StartDate, details.EndDate);


                }
               
                //foreach(var item in resourceID)
                //{
                //    details.ResourceID = item;
                //}
                //details.ResourceID = AllocateResourceBL.ResourceID(Session["name"].ToString());
                //details.RequestID = Session["id"].ToString();
                //details.AccountID = AllocateResourceBL.getAccountID(Session["id"].ToString());
                //for (int i = 0; i < date.Count; i = i + 2)
                //{
                //    details.StartDate = Convert.ToDateTime(date[i]);
                //}
                //for (int i = 1; i < date.Count; i = i + 2)
                //{
                //    details.EndDate = Convert.ToDateTime(date[i]);
                //}


                //rbl.Insert(details);
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

                MailMessage msg = new MailMessage();

                msg.To.Add(mail);
                msg.IsBodyHtml = true;

                MailAddress address = new MailAddress(mail);
                msg.From = address;

                msg.Subject = "Allocation details to " + account;
                String body = "<html><head><body><p>Hi <b> "+name+",</b> </p>" +
                    "<br /><p> You have been allocated to <b> "+account+" </b> from <b> "+startDate.ToShortDateString()+
                    " </b> to <b> " + endDate.ToShortDateString()+".</b> </p>" +
                    "<br /> Contact your project manager for further assistance."+
                    "<br /><br /><b>Warm Regards<br /> Team Capacity Planning </b>" +
                    "<br /><h6>This email is system generated, please do not respond to this email.</h6></body></head></html>";
                
                msg.Body = body;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true; 
                NetworkCredential credentials = new NetworkCredential("resourceallocationgic@gmail.com", "incorrect@gic");
                client.Credentials = credentials;
                client.Send(msg);


            }
            catch
            {
                
                //lblResult.Text = "Your message failed to send, please try again.";
            }
        }
    }
}