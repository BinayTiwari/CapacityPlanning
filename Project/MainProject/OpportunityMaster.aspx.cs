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
            using (CPContext db = new CPContext())
            {
                GridView1.DataSource = (from c in db.CPT_OpportunityMaster
                                        where c.IsActive == true
                                        select c).ToList();
                //GridView1.DataSource = db.CPT_OpportunityMaster.ToList();
                GridView1.DataBind();
            }
        }


        protected void OpportunityAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_OpportunityMaster opportunitydetails = new CPT_OpportunityMaster();
                opportunitydetails.OpportunityType = OpportunityNameTextBox.Text;
                opportunitydetails.IsActive = true;

                OpportunityMasterBL insertOpportunity = new OpportunityMasterBL();
                insertOpportunity.Insert(opportunitydetails);
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
            CPT_OpportunityMaster opportunitydetails = new CPT_OpportunityMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
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
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                opportunitydetails.OpportunityID = id;
                string opportunityName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                opportunitydetails.OpportunityType = opportunityName;
                OpportunityMasterBL updateOpportunity = new OpportunityMasterBL();
                updateOpportunity.Update(opportunitydetails);
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