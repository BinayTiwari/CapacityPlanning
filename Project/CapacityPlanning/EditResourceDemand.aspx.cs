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
    public partial class EditResourceDemand : System.Web.UI.Page
    {
        String requestID;
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
               // ClsCommon.ddlGetPriority(PriorityID);
                ClsCommon.ddlGetDesignation(ResourceType);
                //BindGrid();


            }
        }

        protected void BindTextBoxvalues()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["RequesID"]))
            {

            }
        }

        protected void Update_Resource_Demand(object sender, EventArgs e)
        {
            try
            {
                CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();

                //CPT_CityMaster cityDetails = new CPT_CityMaster();
                resourceDemandDetails.AccountID = Convert.ToInt32(AccountMasterID.SelectedValue);
                //cityDetails.RegionID = Convert.ToInt32(RegionMasterID.SelectedValue);
                //cityDetails.CountryID = Convert.ToInt32(CountryMasterID.SelectedValue);
                resourceDemandDetails.CityID = Convert.ToInt32(CityID.SelectedValue);
                resourceDemandDetails.OpportunityID = Convert.ToInt32(OpportunityID.SelectedValue);
                resourceDemandDetails.SalesStageID = Convert.ToInt32(SalesStageMasterID.SelectedValue);
                resourceDemandDetails.ProcessName = processName.Text;

                ResourceDemandBL insertResourceDemand = new ResourceDemandBL();
                insertResourceDemand.Update(resourceDemandDetails);

                CPT_ResourceDetails resourceDetails = new CPT_ResourceDetails();
                resourceDetails.ResourceTypeID = Convert.ToInt32( ResourceType.SelectedValue);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}