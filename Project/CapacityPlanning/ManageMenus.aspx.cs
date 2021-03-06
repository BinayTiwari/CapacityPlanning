﻿using System;
using System.Collections.Generic;
using System.Data.Common;
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
        static List<RoleMenuMapping> lstRoleMenu = new List<RoleMenuMapping>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                lstRoleMenu = ManageMenusBL.GetRoleMenuMapping();
                ManageMenusBL.GetMenus(rptMenus);
                
            }
        }

        protected void InsertMenuMapping(object sender, EventArgs e)
        {
            List<RoleMenuMapping> lstRoleMenuMapping = new List<RoleMenuMapping>();
            foreach (RepeaterItem item in rptMenus.Items)
            {
                
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
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(chkAccountMgr.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(chkAccountMgr.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (chkAdmin.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(chkAdmin.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(chkAdmin.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkGovern.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkGovern.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkGovern.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkHeadBA.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkHeadBA.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkHeadBA.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkHeadDlvry.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkHeadDlvry.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkHeadDlvry.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkHR.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkHR.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkHR.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkPMO.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkPMO.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkPMO.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkPM.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkPM.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkPM.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkRequestor.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkRequestor.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkRequestor.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
                if (ChkSolHead.Checked)
                {
                    RoleMenuMapping details = new RoleMenuMapping();
                    details.MenuID = Convert.ToInt32(ChkSolHead.Attributes["MenuID"]);
                    details.RoleID = Convert.ToInt32(ChkSolHead.Attributes["RoleID"]);
                    lstRoleMenuMapping.Add(details);
                }
            }
            
            if (lstRoleMenuMapping.Count() > 0)
            {
                ManageMenusBL.InsertRoleMapping(lstRoleMenuMapping);
            }
        }

        protected void rptMenus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    
                    int MenuID = Convert.ToInt32(((DbDataRecord)e.Item.DataItem).GetValue(0));
                    CheckBox chkAccMgr = (CheckBox)e.Item.FindControl("chkAccMgr");
                    CheckBox ChkAdmin = (CheckBox)e.Item.FindControl("ChkAdmin");
                    CheckBox ChkGovernance = (CheckBox)e.Item.FindControl("ChkGovernance");
                    CheckBox ChkHeadBA = (CheckBox)e.Item.FindControl("ChkHeadBA");
                    CheckBox ChkHeadDelivery = (CheckBox)e.Item.FindControl("ChkHeadDelivery");
                    CheckBox ChkHR = (CheckBox)e.Item.FindControl("ChkHR");
                    CheckBox ChkPMO = (CheckBox)e.Item.FindControl("ChkPMO");
                    CheckBox ChkPM = (CheckBox)e.Item.FindControl("ChkPM");
                    CheckBox ChkRequestor = (CheckBox)e.Item.FindControl("ChkRequestor");
                    CheckBox ChkSolHead = (CheckBox)e.Item.FindControl("ChkSolHead");
                    foreach(var item in lstRoleMenu)
                    {
                        if(item.MenuID == MenuID)
                        {
                            if (item.RoleID == Convert.ToInt32(chkAccMgr.Attributes["RoleID"]))
                                chkAccMgr.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkAdmin.Attributes["RoleID"]))
                                ChkAdmin.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkGovernance.Attributes["RoleID"]))
                                ChkGovernance.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkHeadBA.Attributes["RoleID"]))
                                ChkHeadBA.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkHeadDelivery.Attributes["RoleID"]))
                                ChkHeadDelivery.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkHR.Attributes["RoleID"]))
                                ChkHR.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkPMO.Attributes["RoleID"]))
                                ChkPMO.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkPM.Attributes["RoleID"]))
                                ChkPM.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkRequestor.Attributes["RoleID"]))
                                ChkRequestor.Checked = true;
                            if (item.RoleID == Convert.ToInt32(ChkSolHead.Attributes["RoleID"]))
                                ChkSolHead.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}