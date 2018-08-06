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
    public partial class ResourceMapping : System.Web.UI.Page
    {
        //string RequestID = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ResourceMappingBL.ResourceMapping(rptResourceMapping);

            }
        }
        protected void btnMap_Click(object sender, EventArgs e)
        {

            try
            {
                Button theButton = sender as Button;
                Session["id"] = theButton.CommandArgument;
               // string getID = theButton.CommandArgument;
                //AllocateResourceBL.AllocateResourceByID(rptResourceAllocation, getID);
                Response.Redirect("Allocate_Resource.aspx");
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void rptResourceMapping_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
        }
    }
}