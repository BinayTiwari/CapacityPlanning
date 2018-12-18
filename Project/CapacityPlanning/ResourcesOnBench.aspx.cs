using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using businessLogic;

namespace CapacityPlanning
{
    public partial class ResourcesOnBench : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResourcesOnBenchBL.ResourcesOnBench(rptDsVsRes);
            //foreach (RepeaterItem item in rptDsVsRes.Items)
            //{
            //    HtmlTableRow tr = (HtmlTableRow)item.FindControl("trID");
            //    Label lblStatus = (Label)item.FindControl("lblStatus");
            //    if (lblStatus.Text == "Free")
            //    {
            //        tr.BgColor = System.Drawing.Color.Red.ToString();
            //    }
            //    else if (lblStatus.Text == "Allocated")
            //    {
            //        tr.BgColor = System.Drawing.Color.Yellow.ToString();
            //    }
            //    else
            //    {
            //        tr.BgColor = System.Drawing.Color.Red.ToString();
            //    }
            //}
        }
    }
}