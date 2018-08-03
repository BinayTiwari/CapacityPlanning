using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        protected void btnAllocate_Resource_Click(object sender, EventArgs e)
        {
            

            try
            {
                myDIV.Style.Add("display","block");
                Button theButton = sender as Button;
                if (theButton != null)
                {
                    AllocateResourceBL.getEmployeeNameByResourceType(Repeat, theButton.CommandArgument);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void btnSave_Click(object sender,EventArgs e)
        {
            try
            {
                foreach(RepeaterItem item in Repeat.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkRequired");
                    if (chk.Checked)
                    {
                        //insert here from ui
                    }
                }
            }
            catch(Exception ex)
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