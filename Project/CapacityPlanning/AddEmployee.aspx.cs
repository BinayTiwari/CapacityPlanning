﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;

namespace CapacityPlanning
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetDesignation(listDesignation);
                 ClsCommon.ddlGetRole(listRole);
                ClsCommon.ddlGetSkillDDL(listSkillDD);
                ClsCommon.ddlGetManager(RManagerDropDownList);
               
            }
        }

        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                

                //string message = "";
                //foreach (ListItem item in listSkill.Items)
                //{
                //    if (item.Selected)
                //    {
                //        message += item.Value + ",";
                //    }
                //}
                //message = message.Remove(message.Length - 1).Trim();
                CPT_ResourceMaster employeeDetails = new CPT_ResourceMaster();
                employeeDetails.EmployeeMasterID =Convert.ToInt32( empIdText.Text.Trim());
                employeeDetails.EmployeetName = fName.Text;
                employeeDetails.Photo = @"C:\Users\raian\Downloads\Data'" + FileUploadControl.FileName + "'";
                employeeDetails.ReportingManagerID =Convert.ToInt32( RManagerDropDownList.Text.Trim());
                employeeDetails.Email = mail.Text.Trim();
                employeeDetails.EmployeePassword = pass.Text.Trim();
                employeeDetails.BaseLocation = bLocation.Text.Trim();
                employeeDetails.Mobile = phone.Text.Trim();
                employeeDetails.DesignationID = Convert.ToInt32(listDesignation.SelectedValue);
                employeeDetails.RolesID = Convert.ToInt32(listRole.SelectedValue);
                employeeDetails.JoiningDate = Convert.ToDateTime(dojoining.Text.Trim());
                employeeDetails.PAN = panNoTxt.Text.Trim();
                employeeDetails.Skillsid = listSkillDD.SelectedValue;
                employeeDetails.Address = addressTxt.Text.Trim();
                employeeDetails.PriorWorkExperience =(float) Convert.ToDouble( expText.Text.Trim());
                employeeDetails.PassportNo = passportNum.Text;
                employeeDetails.PassportExpiryDate = Convert.ToDateTime(passExpDate.Text.Trim());
                employeeDetails.VisaExpiryDate = Convert.ToDateTime(visExpDate.Text.Trim());
                employeeDetails.DateOfCreation = DateTime.Now;
                employeeDetails.DateOfModification = DateTime.Now;
                employeeDetails.CreatedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.ModifiedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.LastLogin = DateTime.Now;
                ResourceMasterBL insertResource = new ResourceMasterBL();
                insertResource.Insert(employeeDetails);
                Response.Redirect("ResourceMaster.aspx");
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
