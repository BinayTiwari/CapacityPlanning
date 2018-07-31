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

                AllocateBL.AllocateGrid(GridView1);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            AllocateBL.AllocateGrid(GridView1);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AllocateBL.ddlGetPriority(e);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    DropDownList ddl = (DropDownList)GridView1.Rows[i].FindControl("ddlPriorities");
                    string Priority = ddl.SelectedValue;
                    AllocateBL ABL = new AllocateBL();
                    CPT_ResourceDemand CRM = new CPT_ResourceDemand();
                    CRM.PriorityID = ABL.SelectID(Priority);
                    CRM.RequestID = GridView1.Rows[i].Cells[0].Text;
                    ABL.Update(CRM);
                }

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}