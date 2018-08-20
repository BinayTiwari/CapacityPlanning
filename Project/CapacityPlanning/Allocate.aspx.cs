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
                List<int> priorityID = new List<int>();
                int i = 0;
                priorityID = AllocateBL.getResourceDemand(rptResourceAllocation);
                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    
                    DropDownList ddl = (DropDownList)item.FindControl("ddlPriorities");
                    ClsCommon.ddlGetPriority(ddl);
                    ddl.Text = priorityID[i].ToString();
                    i++;
                }


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    DropDownList ddl1 = (DropDownList)item.FindControl("ddlPriorities");
                    int PriorityID = Convert.ToInt32(ddl1.SelectedValue);

                    AllocateBL ABL = new AllocateBL();

                    CPT_ResourceDemand CRM = new CPT_ResourceDemand();
                    //CRM.PriorityID = ABL.SelectID(Priority);


                    Label lblRequestID = (Label)item.FindControl("Request");
                    CRM.RequestID = lblRequestID.Text.Trim();
                    CRM.PriorityID = PriorityID;

                    ABL.UpdateData(CRM);
                    

                }
                Response.Redirect("Allocate.aspx");


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
                ClsCommon.ddlGetPriority(selectList);
            }

        }

    }
}