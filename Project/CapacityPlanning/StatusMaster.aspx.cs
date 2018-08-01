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
    public partial class StatusMaster : System.Web.UI.Page
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

            List<CPT_StatusMaster> lstStatus = new List<CPT_StatusMaster>();
            StatusMasterBL clsStatus = new StatusMasterBL();
            lstStatus = clsStatus.getStatus();

            gvStatus.DataSource = lstStatus;
            gvStatus.DataBind();


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
        protected void StatusAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_StatusMaster Statusdetails = new CPT_StatusMaster();
                Statusdetails.StatusName = StatusNameTextBox.Text;
                Statusdetails.IsActive = true;

                StatusMasterBL insertStatus = new StatusMasterBL();
                insertStatus.Insert(Statusdetails);
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
            gvStatus.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_StatusMaster Statusdetails = new CPT_StatusMaster();
            int id = int.Parse(gvStatus.DataKeys[e.RowIndex].Value.ToString());
            Statusdetails.StatusMasterID = id;

            StatusMasterBL deleteStatus = new StatusMasterBL();
            deleteStatus.Delete(Statusdetails);
            BindGrid();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CPT_StatusMaster Statusdetails = new CPT_StatusMaster();
                int id = int.Parse(gvStatus.DataKeys[e.RowIndex].Value.ToString());
                Statusdetails.StatusMasterID = id;
                string StatusName = ((TextBox)gvStatus.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                Statusdetails.StatusName = StatusName;
                StatusMasterBL updateStatus = new StatusMasterBL();
                updateStatus.Update(Statusdetails);
                gvStatus.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvStatus.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStatus.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}