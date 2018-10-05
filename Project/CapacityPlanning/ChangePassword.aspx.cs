using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;

namespace CapacityPlanning
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        int employeeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdatePassword(object sender, EventArgs e)
        {
            if (txtPass.Text.Trim() == txtConfirm.Text.Trim())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["UID"]))
                {
                    employeeID = Convert.ToInt32(Request.QueryString["UID"].Trim());
                }
                else
                {
                    List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                    lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                    employeeID = lstdetils[0].EmployeeMasterID;

                }
                CPT_ResourceMaster details = new CPT_ResourceMaster();
                details.EmployeeMasterID = employeeID;
                details.EmployeePassword = txtPass.Text.Trim();
                ResourceMasterBL.updatePassword(details);
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Password updated successfully. You're redirecting to login page...";
                Response.AppendHeader("Refresh", "3;url=Login.aspx");
                //Response.Redirect("Login.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password not matched!.Please try again..";
            }
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}