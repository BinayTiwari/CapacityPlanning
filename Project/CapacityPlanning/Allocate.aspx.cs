using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using System.Data;
using businessLogic;
using System.Reflection;

namespace CapacityPlanning
{
    public partial class Allocate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                AllocateBL.getResourceDemand(rptResourceAllocation);
                
            }
        }
        protected void btnAllocate_Click(object sender, EventArgs e)
        {

            try
            {
                Button theButton = sender as Button;
                Response.Redirect("Allocate_Resource.aspx?RequestID=" + theButton.CommandArgument);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    DropDownList ddl = (DropDownList)item.FindControl("ddlPriorities");
                    string Priority = ddl.SelectedValue;
                    AllocateBL ABL = new AllocateBL();

                    CPT_ResourceDemand CRM = new CPT_ResourceDemand();
                    CRM.PriorityID = ABL.SelectID(Priority);

                    Label lblRequestID = (Label)item.FindControl("Request");
                    CRM.RequestID = lblRequestID.Text.Trim();
                   
                    ABL.UpdateData(CRM);
                }

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void rptResourceAllocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList selectList = e.Item.FindControl("ddlPriorities") as DropDownList;
            if (selectList != null)
            {
                 AllocateBL.ddlGetPriority(selectList);
            }
        }
    }
}