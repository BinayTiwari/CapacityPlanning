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
    public partial class Joiner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                BindGrid();

            }
        }
        public void BindGrid()
        {

            List<CPT_NewJoiners> lstNewJoiners = new List<CPT_NewJoiners>();
            NewJoinersBL clsNewJoiners = new NewJoinersBL();
            lstNewJoiners = clsNewJoiners.getNewJoiners();

            rptNewJoiner.DataSource = lstNewJoiners;
            rptNewJoiner.DataBind();

        }
    }
}