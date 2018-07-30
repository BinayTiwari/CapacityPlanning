using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;
using System.Data;

namespace CapacityPlanning
{
    public partial class AddResourceDemand : System.Web.UI.Page
    {
        private int numOfRows = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetAccount(AccountMasterID);
                ClsCommon.ddlGetRegion(RegionMasterID);
                ClsCommon.ddlGetCountry(CountryMasterID);
                ClsCommon.ddlGetCity(CityID);
                ClsCommon.ddlGetOpportunity(OpportunityID);
                ClsCommon.ddlGetSalesStage(SalesStageMasterID);
                ClsCommon.ddlGetPriority(PriorityID);
                //BindGrid();


            }
        }

      
        protected void Add_Resource_Demand(object sender, EventArgs e)
        {
            try
            {

                CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];


                resourceDemandDetails.AccountID = Convert.ToInt32(AccountMasterID.SelectedValue);
                resourceDemandDetails.CityID = Convert.ToInt32(CityID.SelectedValue);
                resourceDemandDetails.OpportunityID = Convert.ToInt32(OpportunityID.SelectedValue);
                resourceDemandDetails.SalesStageID = Convert.ToInt32(SalesStageMasterID.SelectedValue);
                resourceDemandDetails.ProcessName = processName.Text.Trim();
                resourceDemandDetails.DateOfCreation = DateTime.Now;
                resourceDemandDetails.DateOfModification = DateTime.Now;
                resourceDemandDetails.ResourceRequestBy = lstdetils[0].EmployeeMasterID;
                resourceDemandDetails.PriorityID = Convert.ToInt32(PriorityID.SelectedValue);
                resourceDemandDetails.RequestID = ClsCommon.GetRandomNumber(111111,999999).ToString();

                CPT_ResourceDetails demandDetails = new CPT_ResourceDetails();

                
                demandDetails.RequestID = resourceDemandDetails.RequestID;
                demandDetails.ResourceTypeID = 7 ;
                demandDetails.NoOfResources = 4;
                demandDetails.StartDate = DateTime.Now;
                demandDetails.EndDate = DateTime.Now.AddDays(30);
                demandDetails.SkillID = "1";

                resourceDemandDetails.CPT_ResourceDetails.Add(demandDetails);

                ResourceDemandBL insertResourceDemand = new ResourceDemandBL();
                insertResourceDemand.Insert(resourceDemandDetails);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




    }

}
