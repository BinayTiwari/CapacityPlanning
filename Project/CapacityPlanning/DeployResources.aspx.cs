using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;

namespace CapacityPlanning
{
    public partial class DeployResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindRepeater();
            }
        }

        public void BindRepeater()
        {
            DeployResourcesBL.Bind(rptDeployResources);
        }

        protected void DeployResource(object sender, EventArgs e)
        {
            Button theButton = sender as Button;
            DeployResourcesBL.DeployStatus(Convert.ToInt32(theButton.CommandArgument), theButton.Attributes["RequestId"]);
            BindRepeater();
        }
    }
}