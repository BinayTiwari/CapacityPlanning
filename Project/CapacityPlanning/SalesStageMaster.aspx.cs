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
    public partial class SalesStageMaster : System.Web.UI.Page
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
            List<CPT_SalesStageMaster> lstSalesStage = new List<CPT_SalesStageMaster>();
            SalesStageMasterBL clsSalesStage = new SalesStageMasterBL();
            lstSalesStage = clsSalesStage.getSalesStage();

            gvSalesStage.DataSource = lstSalesStage;
            gvSalesStage.DataBind();
        }

        protected void SalesStageAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_SalesStageMaster SalesStagedetails = new CPT_SalesStageMaster();
                SalesStagedetails.SalesStageName = SalesStageNameTextBox.Text.Trim();
                SalesStagedetails.IsActive = true;

                SalesStageMasterBL insertSalesStage = new SalesStageMasterBL();
                insertSalesStage.Insert(SalesStagedetails);
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalesStage.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_SalesStageMaster SalesStagedetails = new CPT_SalesStageMaster();
            int id = int.Parse(gvSalesStage.DataKeys[e.RowIndex].Value.ToString());
            SalesStagedetails.SalesStageMasterID = id;

            SalesStageMasterBL deleteSalesStage = new SalesStageMasterBL();
            deleteSalesStage.Delete(SalesStagedetails);
            BindGrid();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CPT_SalesStageMaster SalesStagedetails = new CPT_SalesStageMaster();
                int id = int.Parse(gvSalesStage.DataKeys[e.RowIndex].Value.ToString());
                SalesStagedetails.SalesStageMasterID = id;
                string SalesStageName = ((TextBox)gvSalesStage.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                SalesStagedetails.SalesStageName = SalesStageName;
                SalesStageMasterBL updateSalesStage = new SalesStageMasterBL();
                updateSalesStage.Update(SalesStagedetails);
                gvSalesStage.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvSalesStage.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSalesStage.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}