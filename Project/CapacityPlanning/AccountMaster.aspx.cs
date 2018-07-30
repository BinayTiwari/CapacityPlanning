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
    public partial class AccountMaster : System.Web.UI.Page
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

                GridView1.DataSource = (from c in db.CPT_AccountMaster
                                       where c.IsActive ==true
                                       select c).ToList();
                
                GridView1.DataBind();
            }
        }


        protected void AccountAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_AccountMaster accountdetails = new CPT_AccountMaster();
                accountdetails.AccountName = AccountNameTextBox.Text;
                accountdetails.IsActive = true;

                AccountMasterBL insertAccount = new AccountMasterBL();
                insertAccount.Insert(accountdetails);
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
            CPT_AccountMaster accountdetails = new CPT_AccountMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            accountdetails.AccountMasterID = id;

            AccountMasterBL deleteAccount = new AccountMasterBL();
            deleteAccount.Delete(accountdetails);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_AccountMaster accountdetails = new CPT_AccountMaster();
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                accountdetails.AccountMasterID = id;
                string accountName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                accountdetails.AccountName = accountName;
                AccountMasterBL updateAccount = new AccountMasterBL();
                updateAccount.Update(accountdetails);
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