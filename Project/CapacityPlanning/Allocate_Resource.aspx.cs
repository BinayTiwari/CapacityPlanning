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
    public partial class Allocate_Resource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //CPT_ResourceDetails details = new CPT_ResourceDetails();
                //details.RequestID = "1";// Session["RequestID"].ToString();

                AllocateResourceBL.AllocateResource(gdvAllocateResources);
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAllocateResources.PageIndex = e.NewPageIndex;
            AllocateResourceBL.AllocateResource(gdvAllocateResources);
        }
        protected void gdvAllocateResources_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //AllocateResourceBL.AllocateResource(gdvAllocateResources);
        }
       
        protected void gdvAllocateResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gdvAllocateResources.PageIndex = e.NewPageIndex;
            //AllocateResourceBL.AllocateResource(gdvAllocateResources);
        }
    }
}