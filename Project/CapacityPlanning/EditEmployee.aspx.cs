﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        int employeeID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                ClsCommon.ddlGetDesignation(listDesignation);
                ClsCommon.ddlGetRole(listRole);
                //ClsCommon.ddlGetSkillDDL(listSkillDD);
                ClsCommon.ddlGetSkill(listSkill);
                ClsCommon.ddlGetManager(RManagerDropDownList);
                BindTextBoxvalues();
            }


        }

        protected void AddEmployeeDetail_Click(object sender, EventArgs e)
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];

                if (!string.IsNullOrEmpty(Request.QueryString["EmployeeId"]))
                {
                    employeeID = Convert.ToInt32(Request.QueryString["EmployeeId"]);
                }
                string message = "";
                foreach (ListItem item in listSkill.Items)
                {
                    if (item.Selected)
                    {
                        message += item.Value + ",";
                    }
                }
                message = message.Remove(message.Length - 1);
                CPT_ResourceMaster employeeDetails = new CPT_ResourceMaster();
                employeeDetails.EmployeeMasterID = employeeID;
                employeeDetails.EmployeetName = fName.Text.Trim();
                employeeDetails.ReportingManagerID = Convert.ToInt32(RManagerDropDownList.Text.Trim());
                employeeDetails.Email = mail.Text.Trim();
                
                employeeDetails.BaseLocation = bLocation.Text.Trim();
                employeeDetails.Mobile = phone.Text.Trim();
                employeeDetails.DesignationID = Convert.ToInt32(listDesignation.SelectedValue);
                employeeDetails.RolesID = Convert.ToInt32(listRole.SelectedValue);
                employeeDetails.JoiningDate = Convert.ToDateTime(dojoining.Text.ToString());
                //employeeDetails.Skillsid = listSkillDD.SelectedValue;
                employeeDetails.Skillsid = message;
                if (expText.Text.Trim() != "")
                {
                    employeeDetails.PriorWorkExperience = (float)Convert.ToDouble(expText.Text.Trim());
                }
                if(panNoTxt.Text.Trim() != "")
                {
                    employeeDetails.PAN = panNoTxt.Text.Trim();
                }
               
                    
                
                if(addressTxt.Text != "")
                {
                    employeeDetails.Address = addressTxt.Text.Trim();

                }
                if(passportNum.Text != "")
                {
                    employeeDetails.PassportNo = passportNum.Text.Trim();

                }
                
                if (passExpDate.Text.Trim() != "")
                {
                    employeeDetails.PassportExpiryDate = Convert.ToDateTime(passExpDate.Text.Trim().ToString());
                }

                if (visExpDate.Text.Trim() != "")
                {
                    employeeDetails.VisaExpiryDate = Convert.ToDateTime(visExpDate.Text.Trim().ToString());
                }


                employeeDetails.DateOfModification = Convert.ToDateTime(DateTime.Now.ToString());
                employeeDetails.ModifiedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.LastLogin = Convert.ToDateTime(DateTime.Now.ToString());
                ResourceMasterBL updateResource = new ResourceMasterBL();
                updateResource.Update(employeeDetails);

                Response.Redirect("ResourceMaster.aspx");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void BindTextBoxvalues()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EmployeeId"]))
                {
                    employeeID = Convert.ToInt32(Request.QueryString["EmployeeId"]);
                }
                CPT_ResourceMaster resourceMaster = new CPT_ResourceMaster();
                resourceMaster.EmployeeMasterID = employeeID;
                ResourceMasterBL resourceMasterBL = new ResourceMasterBL();
                List<CPT_ResourceMaster> lst = resourceMasterBL.uiDataBinding(resourceMaster);
                empIdText.Text = lst[0].EmployeeMasterID.ToString();
                fName.Text = lst[0].EmployeetName;
                RManagerDropDownList.Text = lst[0].ReportingManagerID.ToString();
                
                mail.Text = lst[0].Email;
                bLocation.Text = lst[0].BaseLocation;
                phone.Text = Convert.ToString(lst[0].Mobile);
                listDesignation.Text = Convert.ToString(lst[0].DesignationID);

                dojoining.Text = Convert.ToString(lst[0].JoiningDate);

                dojoining.Text = (Convert.ToString(Convert.ToDateTime( lst[0].JoiningDate).ToShortDateString()));
                //dojoining.Text = Convert.ToString(lst[0].JoiningDate.ToShortDateString());

                expText.Text = Convert.ToString(lst[0].PriorWorkExperience);
                panNoTxt.Text = lst[0].PAN;
                passportNum.Text = lst[0].PassportNo;

                addressTxt.Text = lst[0].Address;
                if(Convert.ToDateTime(lst[0].PassportExpiryDate).ToShortDateString() == "1/1/0001")
                {
                    passExpDate.Text = "";
                }
                else
                {

                    passExpDate.Text = Convert.ToString(Convert.ToDateTime(lst[0].PassportExpiryDate).ToShortDateString());
                }
                if (Convert.ToDateTime(lst[0].VisaExpiryDate).ToShortDateString() == "1/1/0001")
                {
                    visExpDate.Text = "";
                }
                else
                {

                    visExpDate.Text = Convert.ToString(Convert.ToDateTime(lst[0].VisaExpiryDate).ToShortDateString());
                }

               
               
                listDesignation.Text = lst[0].DesignationID.ToString();
                listRole.Text = lst[0].RolesID.ToString();
                //listSkillDD.Text = lst[0].Skillsid;

                String skillCommaSeperated = lst[0].Skillsid;
                String[] lstSkillSingle = skillCommaSeperated.Split(',');
                foreach (var item in lstSkillSingle)
                {

                    listSkill.Items.FindByValue(item).Selected = true;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceMaster.aspx");
        }
    }
}