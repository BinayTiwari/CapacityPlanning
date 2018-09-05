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
    public partial class viewEmployee : System.Web.UI.Page
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
                empCurrentStatus();
                listSkill.Enabled = false;
                BindTextBoxvalues();
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
                emplID.Text = lst[0].EmployeeMasterID.ToString();                
                Name.Text = lst[0].EmployeetName;
                RManagerDropDownList.Text = lst[0].ReportingManagerID.ToString();
                nameLBL.Text = lst[0].EmployeetName;
                mailID.Text = lst[0].Email;
                bLocation.Text = lst[0].BaseLocation;
                phone.Text = Convert.ToString(lst[0].Mobile);
                listDesignation.Text = Convert.ToString(lst[0].DesignationID);
                dojoining.Text = (Convert.ToString(Convert.ToDateTime(lst[0].JoiningDate).ToShortDateString()));
                expText.Text = Convert.ToString(lst[0].PriorWorkExperience);
                panNoTxt.Text = lst[0].PAN;
                passportNum.Text = lst[0].PassportNo;
                addressTxt.Text = lst[0].Address;
                //passExpDate.Text = Convert.ToString(Convert.ToDateTime(lst[0].PassportExpiryDate).ToShortDateString());
                //visExpDate.Text = Convert.ToString(Convert.ToDateTime(lst[0].VisaExpiryDate).ToShortDateString());
                if (Convert.ToDateTime(lst[0].PassportExpiryDate).ToShortDateString() == "1/1/0001")
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
                //    listSkillDD.Text = lst[0].Skillsid;
                

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

        private void empCurrentStatus()
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
                List<CPT_AllocateResource> lst = resourceMasterBL.assignmentBinding(resourceMaster);
                int acntID = lst[0].AccountID;
                String acName = resourceMasterBL.getAccountByID(acntID);
                crntAssign.Text = acName;
                endDate.Text = lst[0].EndDate.ToShortDateString().ToString();
                
                
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceMaster.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceMaster.aspx");
        }
    }
}