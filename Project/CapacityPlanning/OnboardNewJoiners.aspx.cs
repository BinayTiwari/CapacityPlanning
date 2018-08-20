using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class OnboardNewJoiners : System.Web.UI.Page
    {
        int NewJoinerID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                ClsCommon.ddlGetDesignation(listDesignation);
                ClsCommon.ddlGetRole(listRole);
                ClsCommon.ddlGetSkillDDL(listSkillDD);
                ClsCommon.ddlGetManager(RManagerDropDownList);
                BindTextBoxvalues();
            }
            

        }


        private void BindTextBoxvalues()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["JoinerId"]))
                {
                    NewJoinerID = Convert.ToInt32(Request.QueryString["JoinerId"]);
                }
                CPT_NewJoiners newJoiners = new CPT_NewJoiners();
                newJoiners.NewJoinerID = NewJoinerID;
                NewJoinersBL newJoinersBL = new NewJoinersBL();
                List<CPT_NewJoiners> lst = newJoinersBL.uiDataBinding(newJoiners);

                fName.Text = lst[0].Name;
                listDesignation.Text = lst[0].DesignationID.ToString();
                dojoining.Text = lst[0].JoiningDate.ToString();
                bLocation.Text = lst[0].Location;
                expText.Text = lst[0].Experience;
                listSkillDD.Text = lst[0].Skills.ToString();
                



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }


        }


        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["JoinerId"]))
                {
                    NewJoinerID = Convert.ToInt32(Request.QueryString["JoinerId"]);
                }
                if (FileUploadControl.HasFile)
                {
                    FileUploadControl.SaveAs(@"C:\Users\raian\Downloads\Data\" + FileUploadControl.FileName);
                }
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                CPT_ResourceMaster employeeDetails = new CPT_ResourceMaster();
                employeeDetails.EmployeeMasterID = Convert.ToInt32(empIdText.Text.Trim());
                employeeDetails.EmployeetName = fName.Text;
                employeeDetails.Photo = @"C:\Users\raian\Downloads\Data\" + FileUploadControl.FileName.ToString();
                employeeDetails.ReportingManagerID = Convert.ToInt32(RManagerDropDownList.Text.Trim());
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
                employeeDetails.PriorWorkExperience = (float)Convert.ToDouble(expText.Text.Trim());
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
                NewJoinersBL newJoiners = new NewJoinersBL();
                newJoiners.changeHasJoinedValue(NewJoinerID);
                Response.Redirect("NewJoiners.aspx");
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