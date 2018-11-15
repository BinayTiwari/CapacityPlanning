﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;

namespace CapacityPlanning
{
    public partial class ManageMenus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ManageMenusBL.GetMenus(rptMenus);
            }
        }

        protected void InsertMenuMapping(object sender, EventArgs e)
        {
            List<RoleMenuMapping> lstRoleMenuMapping = new List<RoleMenuMapping>();
            foreach (RepeaterItem item in rptMenus.Items)
            {
                RoleMenuMapping details = new RoleMenuMapping();
                CheckBox chkAccountMgr = (CheckBox)item.FindControl("chkAccMgr");
                CheckBox chkAdmin = (CheckBox)item.FindControl("ChkAdmin");
                CheckBox ChkGovern = (CheckBox)item.FindControl("ChkGovernance");
                CheckBox ChkHeadBA = (CheckBox)item.FindControl("ChkHeadBA");
                CheckBox ChkHeadDlvry = (CheckBox)item.FindControl("ChkHeadDelivery");
                CheckBox ChkHR = (CheckBox)item.FindControl("ChkHR");
                CheckBox ChkPMO = (CheckBox)item.FindControl("ChkPMO");
                CheckBox ChkPM = (CheckBox)item.FindControl("ChkPM");
                CheckBox ChkRequestor = (CheckBox)item.FindControl("ChkRequestor");
                CheckBox ChkSolHead = (CheckBox)item.FindControl("ChkSolHead");
                
                if (chkAccountMgr.Checked)
                {
                    details.MenuID = Convert.ToInt32(chkAccountMgr.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(chkAccountMgr.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (chkAdmin.Checked)
                {
                    details.MenuID = Convert.ToInt32(chkAdmin.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(chkAdmin.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkGovern.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkGovern.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkGovern.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkHeadBA.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkHeadBA.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkHeadBA.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkHeadDlvry.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkHeadDlvry.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkHeadDlvry.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkHR.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkHR.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkHR.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkPMO.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkPMO.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkPMO.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkPM.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkPM.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkPM.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkRequestor.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkRequestor.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkRequestor.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkSolHead.Checked)
                {
                    details.MenuID = Convert.ToInt32(ChkSolHead.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkSolHead.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                
                
            }
            if (lstRoleMenuMapping.Count() > 0)
            {
                //ManageMenusBL.InsertRoleMapping(lstRoleMenuMapping);
            }
        }
    }
}