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

                //DropDownList ddlPriorities = (FindControl("ddlPriorities") as DropDownList);
                //AllocateBL.ddlGetPriority(ddlPriorities);

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
                    //Response.Redirect("Allocate.aspx");
                    //ddl.Text = ddl.SelectedItem.Value.ToString();
                    //DataTable dt = new DataTable();
                    //ddl.Items.FindByValue(dt.Rows[0]["PriorityName"].ToString()).Selected = true;

                    //ddl.Items.FindByValue("PriorityName").Selected = true;
                    //Label lbl = (Label)item.FindControl("lblPriority");
                    //string priority = ddl.Text;
                    ////// string priority = (FindControl("lblPriority") as Label).Text;

                    //ddl.Items.FindByValue(Priority).Selected = true;
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