using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class ResourceDemand : System.Web.UI.Page
    {
        int employeeID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindGrid();
            }

        }

        private void BindGrid()
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                employeeID = lstdetils[0].EmployeeMasterID;

                ResourceDemandBL.getResourceDemand(GridView1, employeeID);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }          
          
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        //protected void delete(object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
        //        String id = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        //        resourceDemandDetails.RequestID = id;

        //        ResourceDemandBL deleteResourceDemand = new ResourceDemandBL();
        //        deleteResourceDemand.Delete(resourceDemandDetails);
        //        BindGrid();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }
        //}

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                //int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                //resourceDemandDetails.RequestID = id.ToString();
                //string accountName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                //accountdetails.AccountName = accountName;
                //AccountMasterBL updateAccount = new AccountMasterBL();
                //updateAccount.Update(accountdetails);
                //GridView1.EditIndex = -1;
                //BindGrid();

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string rows = row.Cells[0].Text;

                Response.Redirect("~/EditResourceDemand.aspx?RequestId=" + row.Cells[0].Text);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void View_Resource_Demand(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}






