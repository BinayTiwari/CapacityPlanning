using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class ResourceMaster : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                BindGrid();

            }
        }
        private void BindGrid()
        {
            using (CPContext db = new CPContext())
            {


                GridView1.DataSource = (from c in db.CPT_ResourceMaster
                                       select c).ToList();
                GridView1.DataBind();
            }
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_ResourceMaster cPT_ResourceMaster = new CPT_ResourceMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            cPT_ResourceMaster.EmployeeMasterID = id;

            ResourceMasterBL deleteresourceMasterBL = new ResourceMasterBL();
            deleteresourceMasterBL.Delete(cPT_ResourceMaster);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            BindGrid();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string rows = row.Cells[1].Text;

                Response.Redirect("~/EditEmployee.aspx?EmployeeId=" + row.Cells[1].Text);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void View_Resource_Master(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }



    }
}