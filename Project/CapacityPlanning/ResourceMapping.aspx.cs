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
                int roleID = 0;
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                if(lstdetils[0].RolesID == 20)
                {
                    roleID = 14;
                    ResourceMappingBL.ResourceMappingRoleWise(rptResourceMapping, roleID);
                }
                else if(lstdetils[0].RolesID == 25)
                {
                    roleID = 13;
                    ResourceMappingBL.ResourceMappingRoleWise(rptResourceMapping, roleID);
                }
                else
                {
                    ResourceMappingBL.ResourceMapping(rptResourceMapping);
                }

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