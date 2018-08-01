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

                BindGrid();

            }
        }

        private void BindGrid()
        {
            List<CPT_PriorityMaster> lstPriority = new List<CPT_PriorityMaster>();
            PriorityMasterBL clsPriority = new PriorityMasterBL();
            lstPriority = clsPriority.getPriority();

            gvPriority.DataSource = lstPriority;
            gvPriority.DataBind();
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

        protected void PriorityAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_PriorityMaster accountdetails = new CPT_PriorityMaster();
                accountdetails.PriorityName = PriorityNameTextBox.Text;
                accountdetails.IsActive = true;

                PriorityMasterBL insertPriority = new PriorityMasterBL();
                insertPriority.Insert(accountdetails);
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
            gvPriority.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_PriorityMaster accountdetails = new CPT_PriorityMaster();
            int id = int.Parse(gvPriority.DataKeys[e.RowIndex].Value.ToString());
            accountdetails.PriorityID = id;

            PriorityMasterBL deletePriority = new PriorityMasterBL();
            deletePriority.Delete(accountdetails);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_PriorityMaster accountdetails = new CPT_PriorityMaster();
                int id = int.Parse(gvPriority.DataKeys[e.RowIndex].Value.ToString());
                accountdetails.PriorityID = id;
                string accountName = ((TextBox)gvPriority.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                accountdetails.PriorityName = accountName;
                PriorityMasterBL updatePriority = new PriorityMasterBL();
                updatePriority.Update(accountdetails);
                gvPriority.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvPriority.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvPriority.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}