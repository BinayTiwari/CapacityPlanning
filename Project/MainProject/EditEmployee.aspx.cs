using System;
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
                ClsCommon.ddlGetSkill(listSkill);
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
                CPT_ResourceMaster employeeDetails = new CPT_ResourceMaster();
                employeeDetails.EmployeeMasterID = employeeID;
                employeeDetails.EmployeetName = fName.Text;
                employeeDetails.ReportingManagerID = Convert.ToInt32( RManagerDropDownList.Text);
                employeeDetails.Email = mail.Text;
                employeeDetails.EmployeePassword = pass.Text;
                employeeDetails.BaseLocation = bLocation.Text;
                employeeDetails.Mobile = phone.Text;
                employeeDetails.DesignationID = Convert.ToInt32(listDesignation.SelectedValue);
                employeeDetails.RolesID = Convert.ToInt32(listRole.SelectedValue);
                employeeDetails.JoiningDate = Convert.ToDateTime(dojoining.Text.ToString());
                employeeDetails.PriorWorkExperience = Convert.ToInt32( expText.Text);
                employeeDetails.PAN = panNoTxt.Text;
                employeeDetails.Skillsid = message;
                employeeDetails.PassportNo = passportNum.Text;
                employeeDetails.PassportExpiryDate = Convert.ToDateTime(passExpDate.Text.ToString());
                employeeDetails.VisaExpiryDate = Convert.ToDateTime(visExpDate.Text.ToString());
                employeeDetails.DateOfModification = Convert.ToDateTime( DateTime.Now.ToString());
                employeeDetails.ModifiedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.LastLogin = Convert.ToDateTime(DateTime.Now.ToString());
                ResourceMasterBL updateResource = new ResourceMasterBL();
                updateResource.Update(employeeDetails);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private void BindTextBoxvalues()
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
            RManagerDropDownList..Text = lst[0].ReportingManagerID.ToString();

            pass.Text = lst[0].EmployeePassword;
            mail.Text = lst[0].Email;
            bLocation.Text = lst[0].BaseLocation;
            phone.Text = Convert.ToString(lst[0].Mobile);
            listDesignation.Text =Convert.ToString( lst[0].DesignationID);
            dojoining.Text = Convert.ToString(lst[0].JoiningDate.ToShortDateString());
            expText.Text =Convert.ToString( lst[0].PriorWorkExperience);
            panNoTxt.Text = lst[0].PassportNo;
            passportNum.Text = lst[0].PassportNo;
            listSkill.Text = lst[0].Skillsid;
            addressTxt.Text = lst[0].Address;
            passExpDate.Text = Convert.ToString(lst[0].PassportExpiryDate);
            visExpDate.Text = Convert.ToString(lst[0].VisaExpiryDate);
            listDesignation.Text = lst[0].DesignationID.ToString();
            listRole.Text = lst[0].RolesID.ToString();
            //listSkill.Text = Convert.ToString( lst[0].Skillsid.ToString());
            
        }


    }
}