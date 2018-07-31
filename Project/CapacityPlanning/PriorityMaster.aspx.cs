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
    public partial class PriorityMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                PriorityMasterBL.FetchGrid(GridView1);

            }
        }

        protected void PriorityAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_PriorityMaster accountdetails = new CPT_PriorityMaster();
                accountdetails.PriorityName = PriorityNameTextBox.Text.Trim();
                accountdetails.IsActive = true;

                PriorityMasterBL insertPriority = new PriorityMasterBL();
                insertPriority.Insert(accountdetails);
                PriorityMasterBL.FetchGrid(GridView1);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PriorityMasterBL.FetchGrid(GridView1);
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_PriorityMaster accountdetails = new CPT_PriorityMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            accountdetails.PriorityID = id;

            PriorityMasterBL deletePriority = new PriorityMasterBL();
            deletePriority.Delete(accountdetails);
            PriorityMasterBL.FetchGrid(GridView1);


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_PriorityMaster accountdetails = new CPT_PriorityMaster();
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                accountdetails.PriorityID = id;
                string accountName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                accountdetails.PriorityName = accountName;
                PriorityMasterBL updatePriority = new PriorityMasterBL();
                updatePriority.Update(accountdetails);
                GridView1.EditIndex = -1;
                PriorityMasterBL.FetchGrid(GridView1);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            PriorityMasterBL.FetchGrid(GridView1);
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;
            PriorityMasterBL.FetchGrid(GridView1);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}