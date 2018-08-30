using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
namespace CapacityPlanning
{
    public partial class AllTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                BindRepeater();
            }

        }

        public void BindRepeater()
        {
            AllTicketsBL.Bind(rptResourceAllTickets);
        }
    }
}