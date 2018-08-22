using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccountRecovery_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAccountRecovery.Text.Trim()))
            {
                ClsAuthentication clsUserRegistration = new ClsAuthentication();
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                List<CPT_ResourceMaster> lstuserDetails = new List<CPT_ResourceMaster>();
                lstuserDetails = clsUserRegistration.getDetailsforPasswordRecovery(txtAccountRecovery.Text.Trim());
                if (lstuserDetails.Count > 0)
                {
                    try
                    {
                        registrationEmail.Name = "ForgetPassword";
                        registrationEmail.To = new List<string>();
                        registrationEmail.To.Add(txtAccountRecovery.Text);
                        registrationEmail.ToUserName = new List<string>();
                        registrationEmail.ToUserName.Add(lstuserDetails[0].EmployeetName);
                        registrationEmail.UID = lstuserDetails[0].EmployeeMasterID.ToString();
                        TokenMessageTemplate valEmail = new TokenMessageTemplate();
                        valEmail.SendEmail(registrationEmail);
                        //btnAccountRecovery.Visible = false;
                        lblMessage.Visible = true;
                        txtAccountRecovery.Text = string.Empty;
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "<strong  class='text - center'>If you have registered previously we have sent you a verification email, for password resetting click on that link. If you do not see it in your inbox please note that your email provider may have mistaken us as spam. If no email has arrived please try again.</strong>";
                        Response.AppendHeader("Refresh", "10;url=Login.aspx");
                        //Response.Redirect("Login.aspx");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    lblMessage.Text = "   Email not found...";
                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}