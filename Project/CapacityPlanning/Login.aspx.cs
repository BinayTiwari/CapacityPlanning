using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Entity;
using businessLogic;

namespace CapacityPlanning
{

    public partial class Login : System.Web.UI.Page
    {
        public string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtEmail.Text = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }

            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            CPT_ResourceMaster auth = new CPT_ResourceMaster();
            ClsAuthentication blauthentication = new ClsAuthentication();

            auth.Email = txtEmail.Text.Trim();
            auth.EmployeePassword = txtPassword.Text.Trim();
            List<CPT_ResourceMaster> lstuserdetails = new List<CPT_ResourceMaster>();

            lstuserdetails = blauthentication.getActiveUser(auth);
            if (lstuserdetails.Count > 0)
            {
                Session["UserDetails"] = lstuserdetails;
                Response.Redirect("Dashboard.aspx");
            }

            else
            {
                lblErrorMsg.Visible = true;
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                lblErrorMsg.Text = "Your email or password is incorrect!";
            }
            if (chkRemember.Checked)
            {
                Response.Cookies["UserName"].Value = txtEmail.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(300);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(300);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
           
        }
    }
}