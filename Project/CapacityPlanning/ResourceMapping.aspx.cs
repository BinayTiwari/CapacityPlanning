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

                //AllocateResourceBL.AllocateResourceByID(rptResourceAllocation, getID);
                string AccountName = theButton.Attributes["AccountName"];
                string ProcessName = theButton.Attributes["ProcessName"];
                Response.Redirect("Allocate_Resource.aspx?RequestID="+theButton.CommandArgument+ "&AccountName="+ AccountName + "&ProcessName="+ ProcessName +"");
                
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