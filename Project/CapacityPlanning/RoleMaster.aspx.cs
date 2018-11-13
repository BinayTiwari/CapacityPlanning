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

        protected void BindGrid()
        {
            RoleMasterBL.getRole(gvRole);
        }
        public void CleartextBoxes(Control parent)
        {

            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {

                    ((TextBox)(c)).Text = "";
                }

                if (c.HasControls())
                {
                    CleartextBoxes(c);
                }
            }
        }
        protected void RoleAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_RoleMaster Roledetails = new CPT_RoleMaster();
                Roledetails.RoleName = RoleNameTextBox.Text;
                Roledetails.Show_in_Dropdown = true;
                Roledetails.IsActive = true;

                RoleMasterBL insertRole = new RoleMasterBL();
                insertRole.Insert(Roledetails);
                BindGrid();
                CleartextBoxes(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRole.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_RoleMaster Roledetails = new CPT_RoleMaster();
            int id = int.Parse(gvRole.DataKeys[e.RowIndex].Value.ToString());
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
                int id = int.Parse(gvRole.DataKeys[e.RowIndex].Value.ToString());
                Roledetails.RoleMasterID = id;
                string RoleName = ((TextBox)gvRole.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                DropDownList ddl = (DropDownList)gvRole.Rows[e.RowIndex].FindControl("ddlShow");                
                Roledetails.RoleName = RoleName;
                Roledetails.Show_in_Dropdown = ddl.SelectedValue == "0"? false : true;
                RoleMasterBL updateRole = new RoleMasterBL();
                updateRole.Update(Roledetails);
                gvRole.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvRole.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRole.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}