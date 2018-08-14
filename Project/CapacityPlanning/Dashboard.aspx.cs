using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
namespace CapacityPlanning
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnClick_Click(object sender, EventArgs e)
        {
            try
            {
                DsVsRes.Style.Add("display", "block");
                DashboardBL.showDsVsRes(rptDsVsRes);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}