using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;

namespace CapacityPlanning
{
    public partial class DesignationMaster : System.Web.UI.Page
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

            List<CPT_DesignationMaster> lstDesignation = new List<CPT_DesignationMaster>();
            DesignationMasterBL clsDesignation = new DesignationMasterBL();
            lstDesignation = clsDesignation.getDesignation();

            gvDesignation.DataSource = lstDesignation;
            gvDesignation.DataBind();


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
        protected void DesignationAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_DesignationMaster Designationdetails = new CPT_DesignationMaster();
                Designationdetails.DesignationName = DesignationNameTextBox.Text.Trim();
                Designationdetails.IsActive = true;

                DesignationMasterBL insertDesignation = new DesignationMasterBL();
                insertDesignation.Insert(Designationdetails);
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
            gvDesignation.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_DesignationMaster Designationdetails = new CPT_DesignationMaster();
            int id = int.Parse(gvDesignation.DataKeys[e.RowIndex].Value.ToString());
            Designationdetails.DesignationMasterID = id;

            DesignationMasterBL deleteDesignation = new DesignationMasterBL();
            deleteDesignation.Delete(Designationdetails);
            BindGrid();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CPT_DesignationMaster Designationdetails = new CPT_DesignationMaster();
                int id = int.Parse(gvDesignation.DataKeys[e.RowIndex].Value.ToString());
                Designationdetails.DesignationMasterID = id;
                string DesignationName = ((TextBox)gvDesignation.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                Designationdetails.DesignationName = DesignationName;
                DesignationMasterBL updateDesignation = new DesignationMasterBL();
                updateDesignation.Update(Designationdetails);
                gvDesignation.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvDesignation.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDesignation.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}