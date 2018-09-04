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
    public partial class ViewResourceMapping : System.Web.UI.Page
    {
        int regionID;
        string requestID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetSalesStage(salesStageDD);
                ClsCommon.ddlGetAccount(accNameDD);
                ClsCommon.ddlGetOpportunity(oppTypeDD);
                ClsCommon.ddlGetRegion(regionNameDD);

                BindValue();
            }
        }

        public void BindValue()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["RequestID"]))
            {
                requestID = Request.QueryString["RequestID"].Trim();
            }



            CPT_ResourceDemand cPT_ResourceDemand = new CPT_ResourceDemand();
            cPT_ResourceDemand.RequestID = requestID;
            ResourceDemandBL resource = new ResourceDemandBL();
            CPT_ResourceDemand demand = new CPT_ResourceDemand();
            demand.RequestID = requestID;
            List<CPT_ResourceDemand> lst = resource.ViewResourceDemand(demand);

            reqID.Text = lst[0].RequestID;
            salesStageDD.Text = lst[0].SalesStageID.ToString();
            accNameDD.Text = lst[0].AccountID.ToString();
            proccName.Text = lst[0].ProcessName;
            oppTypeDD.Text = lst[0].OpportunityID.ToString();
            List<int> regionIDs = ResourceDemandBL.getRegionID(lst[0].AccountID);
            regionID = regionIDs[0];
            regionNameDD.Items.FindByValue(regionID.ToString()).Selected = true;


            ResourceDetailsBL.ViewResourceDetails(rptResourceDetails, requestID);
            AllocateResourceBL.viewResourceMaping(rptMapping, requestID);
        }
    }
}
