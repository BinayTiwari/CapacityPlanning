using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;
using System.Data;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class EditResourceDemand : System.Web.UI.Page
    {
        string requestID;
        int regionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetOpportunity(OpportunityID);
                ClsCommon.ddlGetRegion(RegionMasterID);
                ClsCommon.ddlGetSalesStage(SalesStageMasterID);
                
                BindTextBoxvalues();
                bindDetailTextGrid();
                disableFields();

            }
        }

        protected void BindTextBoxvalues()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RequestID"]))
                {
                    requestID = Request.QueryString["RequestID"].Trim();
                }

                List<CPT_ResourceDemand> lst = ResourceDemandBL.uiDataBinding(requestID);
                ClsCommon.ddlGetStatusNew(StatusMasterID, lst[0].StatusMasterID.Value);

                OpportunityID.Text = lst[0].OpportunityID.ToString();
                List<int> regionIDs = ResourceDemandBL.getRegionID(lst[0].AccountID);
                regionID = regionIDs[0];
                RegionMasterID.Items.FindByValue(regionID.ToString()).Selected = true;
                List<int> CityIDs = ResourceDemandBL.CityIDs(regionID);
                ClsCommon.ddlGetAccountWithCity(AccountMasterID, CityIDs);
                AccountMasterID.Text = lst[0].AccountID.ToString();
                SalesStageMasterID.Text = lst[0].SalesStageID.ToString();
                processName.Text = lst[0].ProcessName;
                StatusMasterID.Text = lst[0].StatusMasterID.ToString();
                
                ViewState["dateOfCreation"] = lst[0].DateOfCreation.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void bindDetailTextGrid()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RequestID"]))
                {
                    requestID = Request.QueryString["RequestID"].Trim();
                }

                List<CPT_ResourceDetails> lstDetail = ResourceDemandBL.uiDataBindingDetails(GridviewResourceDetail, requestID);

                if (GridviewResourceDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < GridviewResourceDetail.Rows.Count; i++)
                    {
                        DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[i].FindControl("ResourceTypeID");
                        ClsCommon.ddlGetRoleforDemand(ddl);
                        ddl.SelectedValue = lstDetail[i].ResourceTypeID.ToString();
                        //ddl.Items.FindByValue(lstDetail[0].ResourceTypeID.ToString()).Selected = true;

                        DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[i].FindControl("SkillID");
                        ClsCommon.ddlGetSkillDDL(ddl1);
                        ddl1.SelectedValue = lstDetail[i].SkillID.ToString();

                    }
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void Update_Resource_Demand(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RequestId"]))
                {
                    requestID = Request.QueryString["RequestId"].Trim();
                }

                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];

                CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                resourceDemandDetails.RequestID = requestID;
                resourceDemandDetails.AccountID = Convert.ToInt32(AccountMasterID.SelectedValue);
                int CityID = ResourceDemandBL.getCityID(Convert.ToInt32(AccountMasterID.SelectedValue));
                resourceDemandDetails.CityID = CityID;
                resourceDemandDetails.OpportunityID = Convert.ToInt32(OpportunityID.SelectedValue);
                resourceDemandDetails.SalesStageID = Convert.ToInt32(SalesStageMasterID.SelectedValue);
                resourceDemandDetails.ProcessName = processName.Text;
                resourceDemandDetails.StatusMasterID = Convert.ToInt32(StatusMasterID.SelectedValue);
                resourceDemandDetails.DateOfCreation = Convert.ToDateTime(ViewState["dateOfCreation"]);
                resourceDemandDetails.DateOfModification = DateTime.Now;
                resourceDemandDetails.ResourceRequestBy = lstdetils[0].EmployeeMasterID;                
                resourceDemandDetails.PriorityID = 27;
                if (Convert.ToInt32(StatusMasterID.SelectedValue) == 23)
                {
                    ResourceDemandBL.updateReleasedValue(requestID);
                }

                ResourceDemandBL insertResourceDemand = new ResourceDemandBL();

                List<CPT_ResourceDetails> lstdetails = new List<CPT_ResourceDetails>();

                for (int i = 0; i < GridviewResourceDetail.Rows.Count; i++)
                {
                    CPT_ResourceDetails details = new CPT_ResourceDetails();

                    details.RequestID = resourceDemandDetails.RequestID;
                    details.ResourceTypeID = Convert.ToInt32(((DropDownList)GridviewResourceDetail.Rows[i].Cells[0].FindControl("ResourceTypeID")).SelectedValue);
                    details.NoOfResources = (float)Convert.ToDouble(((TextBox)GridviewResourceDetail.Rows[i].Cells[1].FindControl("NoOfResources")).Text.Trim());
                    details.SkillID = ((DropDownList)GridviewResourceDetail.Rows[i].Cells[2].FindControl("SkillID")).SelectedValue;
                    details.StartDate = Convert.ToDateTime(((TextBox)GridviewResourceDetail.Rows[i].Cells[3].FindControl("StartDate")).Text.Trim());
                    string endDate = ((TextBox)GridviewResourceDetail.Rows[i].Cells[4].FindControl("EndDate")).Text.Trim();
                    details.EndDate = DateTime.Parse(endDate);

                    lstdetails.Add(details);
                    resourceDemandDetails.CPT_ResourceDetails = lstdetails;
                }

                insertResourceDemand.Update(resourceDemandDetails);
                Email(requestID,Convert.ToInt32(StatusMasterID.SelectedValue));

                Response.Redirect("ResourceDemand.aspx");


            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void RegionMasterID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RegionMasterID.SelectedItem.Text == "Select Region")
            {
                AccountMasterID.Enabled = false;
            }
            else
            {
                AccountMasterID.Enabled = true;
            }

            regionID = Convert.ToInt32(RegionMasterID.SelectedValue);
            List<int> CityIDs = ResourceDemandBL.CityIDs(regionID);
            ClsCommon.ddlGetAccountWithCity(AccountMasterID, CityIDs);
        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceDemand.aspx");
        }

        public void Email(string RequestID,int Status)
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                string employeeEmailID = lstdetils[0].Email;

                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                if(Status == 23)
                {
                    registrationEmail.Name = "DropResourceRequest";
                    registrationEmail.STATUS = requestID;
                }
                else
                {
                    registrationEmail.Name = "UpdateResourceDemand";
                }
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(employeeEmailID);
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add(lstdetils[0].EmployeetName);
                //registrationEmail.UID = lstdetils[0].EmployeeMasterID.ToString();
                TokenMessageTemplate valEmail = new TokenMessageTemplate();
                valEmail.SendEmail(registrationEmail);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void disableFields()
        {
            int statusID = ResourceDemandBL.getStatusbyRequest(requestID);
            if (statusID == 20 || statusID == 32 || statusID == 26)
            {
                OpportunityID.Enabled = false;
                RegionMasterID.Enabled = false;
                AccountMasterID.Enabled = false;
                SalesStageMasterID.Enabled = false;
                processName.Enabled = false;

                GridviewResourceDetail.Enabled = false;


            }

        }



    }
}