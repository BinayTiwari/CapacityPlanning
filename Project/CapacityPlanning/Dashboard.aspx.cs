using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using System.Windows.Forms;


using Entity;
using System.Web.UI.DataVisualization.Charting;

namespace CapacityPlanning
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DashboardBL dashboardBL = new DashboardBL();
            dashboardBL.displayDesigVsRes(myChart);
            DashboardBL.DisplayAccountWiseResources(rptAccountWiseResources);
            //DashboardBL.showRoleVsCapacity(RoleCap);
            DashboardBL.displayRoleVsDem(RoleDem);
            dashboardBL.displayMgrVsRpt(MgrVSRpt);
            dashboardBL.displayDesigVsResBar(myChartBar);
            DashboardBL.TotalStregth(lblStregth);
            DashboardBL.OnBench(NumberOfResourcesOnBench);
            DashboardBL.OpenRequests(OpenResourceRequests);
            DashboardBL.NewJoiners(NewJoiners);

        }
        protected void btnClick_Click(object sender, EventArgs e)
        {
            try
            {
                graphBlock.Style.Add("display", "none");
                Response.Redirect("TotalStrengths.aspx");
                //DsVsRes.Style.Add("display", "block");
                RMVsR.Style.Add("display", "none");
                CapVsResDem.Style.Add("display", "none");
                AccVsNoR.Style.Add("display", "none");
                //DashboardBL.showDsVsRes(rptDsVsRes);
                //DashboardBL.displayTotalStrength(rptDsVsRes);
                //
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        protected void btnClick1_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpenResourceRequests.aspx");

        }

        protected void btnClick2_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("ResourcesOnBench.aspx");

        }
        protected void btnClick3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Joiner.aspx");
        }

    
        
    }
}