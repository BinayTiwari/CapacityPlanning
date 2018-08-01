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
        private void BindGrid()
        {

            List<CPT_AccountMaster> lstAccount = new List<CPT_AccountMaster>();
            AccountMasterBL clsAccount = new AccountMasterBL();
            lstAccount = clsAccount.getAccount();

            gvAccount.DataSource = lstAccount;
            gvAccount.DataBind();
            

        }


        protected void AccountAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_AccountMaster accountdetails = new CPT_AccountMaster();
                accountdetails.AccountName = AccountNameTextBox.Text.Trim();
                accountdetails.IsActive = true;

                AccountMasterBL insertAccount = new AccountMasterBL();
                insertAccount.Insert(accountdetails);
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
            gvAccount.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_AccountMaster accountdetails = new CPT_AccountMaster();
            int id = int.Parse(gvAccount.DataKeys[e.RowIndex].Value.ToString());
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
                int id = int.Parse(gvAccount.DataKeys[e.RowIndex].Value.ToString());
                accountdetails.AccountMasterID = id;
                string accountName = ((TextBox)gvAccount.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                accountdetails.AccountName = accountName;
                AccountMasterBL updateAccount = new AccountMasterBL();
                updateAccount.Update(accountdetails);
                gvAccount.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvAccount.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvAccount.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}