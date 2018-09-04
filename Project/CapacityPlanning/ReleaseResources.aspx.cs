using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;

namespace CapacityPlanning
{
    public partial class ReleaseResources : System.Web.UI.Page
    {
        int employeeID = 0, logId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                BindRpt();
            }
            
        }

        public void BindRpt()
        {
            List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
            lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
            logId = lstdetils[0].EmployeeMasterID;
            ReleaseResourcesBL.BindRepeater(rptResourceRelease, logId);
        }

        protected void releaseButton_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            employeeID = Convert.ToInt32(lb.Attributes["empID"]);
            ReleaseResourcesBL.setReleasedStatus(employeeID);
        }
    }
}