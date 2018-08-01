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
    public partial class OpportunityMaster : System.Web.UI.Page
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

            List<CPT_OpportunityMaster> lstOpportunity = new List<CPT_OpportunityMaster>();
            OpportunityMasterBL clsOpportunity = new OpportunityMasterBL();
            lstOpportunity = clsOpportunity.getOpportunity();

            gvOpportunity.DataSource = lstOpportunity;
            gvOpportunity.DataBind();


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

        protected void OpportunityAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_OpportunityMaster opportunitydetails = new CPT_OpportunityMaster();
                opportunitydetails.OpportunityType = OpportunityNameTextBox.Text.Trim();
                opportunitydetails.IsActive = true;

                OpportunityMasterBL insertOpportunity = new OpportunityMasterBL();
                insertOpportunity.Insert(opportunitydetails);
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
            gvOpportunity.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_OpportunityMaster opportunitydetails = new CPT_OpportunityMaster();
            int id = int.Parse(gvOpportunity.DataKeys[e.RowIndex].Value.ToString());
            opportunitydetails.OpportunityID = id;

            OpportunityMasterBL deleteOpportunity = new OpportunityMasterBL();
            deleteOpportunity.Delete(opportunitydetails);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_OpportunityMaster opportunitydetails = new CPT_OpportunityMaster();
                int id = int.Parse(gvOpportunity.DataKeys[e.RowIndex].Value.ToString());
                opportunitydetails.OpportunityID = id;
                string opportunityName = ((TextBox)gvOpportunity.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                opportunitydetails.OpportunityType = opportunityName;
                OpportunityMasterBL updateOpportunity = new OpportunityMasterBL();
                updateOpportunity.Update(opportunitydetails);
                gvOpportunity.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvOpportunity.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvOpportunity.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}