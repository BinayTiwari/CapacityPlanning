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
    public partial class RoleMaster : System.Web.UI.Page
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
            List<CPT_RoleMaster> lstRole = new List<CPT_RoleMaster>();
            RoleMasterBL clsRole = new RoleMasterBL();
            lstRole = clsRole.getRole();

            GridView1.DataSource = lstRole;
            GridView1.DataBind();
        }

        protected void RoleAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_RoleMaster Roledetails = new CPT_RoleMaster();
                Roledetails.RoleName = RoleNameTextBox.Text.Trim();
                Roledetails.IsActive = true;

                RoleMasterBL insertRole = new RoleMasterBL();
                insertRole.Insert(Roledetails);
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_RoleMaster Roledetails = new CPT_RoleMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            Roledetails.RoleMasterID = id;

            RoleMasterBL deleteRole = new RoleMasterBL();
            deleteRole.Delete(Roledetails);
            BindGrid();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CPT_RoleMaster Roledetails = new CPT_RoleMaster();
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                Roledetails.RoleMasterID = id;
                string RoleName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                Roledetails.RoleName = RoleName;
                RoleMasterBL updateRole = new RoleMasterBL();
                updateRole.Update(Roledetails);
                GridView1.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}