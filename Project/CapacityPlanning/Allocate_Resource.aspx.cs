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
                AllocateResourceBL.bindRepeater(Repeat);
               
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
        protected void btnAllocate_Resource_Click(object sender, EventArgs e)
        {

            try
            {
                
                //Button theButton = sender as Button;
                //Response.Redirect("Allocate_Resource.aspx?RequestID=" + theButton.CommandArgument);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void gdvAllocateResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gdvAllocateResources.PageIndex = e.NewPageIndex;
            //AllocateResourceBL.AllocateResource(gdvAllocateResources);
        }
    }
}