﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] != null)
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];

                lblUserName.Text = lstdetils[0].EmployeetName;
                ClsAuthentication authmenu = new ClsAuthentication();
                rptMeanu.DataSource = authmenu.getMeanu(lstdetils[0].RolesID);
                rptMeanu.DataBind();
                

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void rptMeanu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void LogOut(object source, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");

        }
    }
}