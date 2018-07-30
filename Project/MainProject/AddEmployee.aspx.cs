using System;
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
                ClsCommon.ddlGetSkill(listSkill);
                ClsCommon.ddlGetManager(RManagerDropDownList);
               
            }
        }

        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];

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
                employeeDetails.EmployeeMasterID =Convert.ToInt32( empIdText.Text);
                employeeDetails.EmployeetName = fName.Text;
                employeeDetails.Photo = @"C:\Users\raian\Downloads\Data'" + FileUploadControl.FileName + "'";
                employeeDetails.ReportingManagerID =Convert.ToInt32( RManagerDropDownList.Text);
                employeeDetails.Email = mail.Text;
                employeeDetails.EmployeePassword = pass.Text;
                employeeDetails.BaseLocation = bLocation.Text;
                employeeDetails.Mobile = phone.Text;
                employeeDetails.DesignationID = Convert.ToInt32(listDesignation.SelectedValue);
                employeeDetails.RolesID = Convert.ToInt32(listRole.SelectedValue);
                employeeDetails.JoiningDate = Convert.ToDateTime(dojoining.Text);
                employeeDetails.PAN = panNoTxt.Text;
                employeeDetails.Skillsid = message;
                employeeDetails.PriorWorkExperience =Convert.ToInt32( expText.Text);
                employeeDetails.PassportNo = passportNum.Text;
                employeeDetails.PassportExpiryDate = Convert.ToDateTime(passExpDate.Text);
                employeeDetails.VisaExpiryDate = Convert.ToDateTime(visExpDate.Text);
                employeeDetails.DateOfCreation = DateTime.Now;
                employeeDetails.DateOfModification = DateTime.Now;
                employeeDetails.CreatedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.ModifiedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.LastLogin = DateTime.Now;
                ResourceMasterBL insertResource = new ResourceMasterBL();
                insertResource.Insert(employeeDetails);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
