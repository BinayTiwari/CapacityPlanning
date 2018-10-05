using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class ResourceDemand : System.Web.UI.Page
    {
        int employeeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                employeeID = lstdetils[0].EmployeeMasterID;

                ResourceDemandBL.getResourceDemand(rptResourcedemand, employeeID);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }          
          
        }

    }
}






