using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class OnboardNewJoiners : System.Web.UI.Page
    {
        int NewJoinerID = 0;
        string name = "";
        string location = "";
        string doj = "";
        string desig = "";
        string rmgr = "";
        int mgr = 0;
        string eml = "";
        string phn = "";
        int des = 0;
        List<CPT_NewJoiners> lst;


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
                lst = newJoinersBL.uiDataBinding(newJoiners);
                

                fName.Text = lst[0].Name;
                listDesignation.Text = lst[0].DesignationID.ToString();
                dojoining.Text = (Convert.ToDateTime( lst[0].JoiningDate)).ToShortDateString().ToString();
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


                CPT_NewJoiners newJoiners = new CPT_NewJoiners();
                newJoiners.NewJoinerID = NewJoinerID;
                NewJoinersBL newJoinersBL = new NewJoinersBL();

                lst = newJoinersBL.uiDataBinding(newJoiners);
                name = lst[0].Name;
                location = lst[0].Location;
                doj = Convert.ToDateTime( lst[0].JoiningDate).ToShortDateString().ToString();
                des = (int) lst[0].DesignationID;
                desig = newJoinersBL.getdesignationByID(des);
                mgr = Convert.ToInt32( RManagerDropDownList.Text);
                rmgr = newJoinersBL.getManagerByID(mgr);
                eml = mail.Text;
                phn = phone.Text;

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
                if (employeeDetails.PAN != "")
                {
                    employeeDetails.PAN = panNoTxt.Text.Trim();
                }
                if (employeeDetails.Skillsid != "")
                {
                    employeeDetails.Skillsid = listSkillDD.SelectedValue;
                }
                if (employeeDetails.Address != "")
                {
                    employeeDetails.Address = addressTxt.Text.Trim();

                }
                if (employeeDetails.PriorWorkExperience != null)
                {
                    employeeDetails.PriorWorkExperience = (float)Convert.ToDouble(expText.Text.Trim());
                }
                if (employeeDetails.PassportNo != "")
                {
                    employeeDetails.PassportNo = passportNum.Text.Trim();

                }
                if (employeeDetails.PassportExpiryDate != null)
                {
                    employeeDetails.PassportExpiryDate = Convert.ToDateTime(passExpDate.Text.Trim().ToString());
                }
                if (employeeDetails.VisaExpiryDate != null)
                {
                    employeeDetails.VisaExpiryDate = Convert.ToDateTime(visExpDate.Text.Trim().ToString());
                }
                employeeDetails.DateOfCreation = DateTime.Now;
                employeeDetails.DateOfModification = DateTime.Now;
                employeeDetails.CreatedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.ModifiedBy = lstdetils[0].EmployeeMasterID;
                employeeDetails.LastLogin = DateTime.Now;
                Email();
                ResourceMasterBL insertResource = new ResourceMasterBL();
                insertResource.Insert(employeeDetails);
                //NewJoinersBL newJoinersBL = new NewJoinersBL();
                newJoinersBL.changeHasJoinedValue(NewJoinerID);
                Response.Redirect("NewJoiners.aspx");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Email()
        {
            try
            {
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "Onboard";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add("anshuman.rai@gridinfocom.com");
                //registrationEmail.ToUserName = new List<string>();
                //registrationEmail.ToUserName.Add("Anshuman");
                registrationEmail.JOINER = name;
                registrationEmail.BASELOCATION = location;
                registrationEmail.DOJ = doj;
                registrationEmail.DESIGNATION = desig;
                registrationEmail.EMAIL = eml;
                registrationEmail.PHONE = phn;
                registrationEmail.REPORTINGMGR = rmgr;

                TokenMessageTemplate valEmail = new TokenMessageTemplate();
                valEmail.SendEmail(registrationEmail);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJoiners.aspx");
        }
    }
}