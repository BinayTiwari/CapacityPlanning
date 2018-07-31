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
    public partial class RegionMaster : System.Web.UI.Page
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
            List<CPT_RegionMaster> lstRegion = new List<CPT_RegionMaster>();
            RegionMasterBL clsRegion = new RegionMasterBL();
            lstRegion = clsRegion.getRegion();

            GridView1.DataSource = lstRegion;
            GridView1.DataBind();
        }

        protected void SaveRegionButton(object sender, EventArgs e)
        {

            try
            {

                CPT_RegionMaster Regiondetails = new CPT_RegionMaster();
                Regiondetails.RegionName = RegionInput.Text.Trim();
                Regiondetails.IsActive = true;

                RegionMasterBL insertRegion = new RegionMasterBL();
                insertRegion.Insert(Regiondetails);
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

            CPT_RegionMaster Regiondetails = new CPT_RegionMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            Regiondetails.RegionMasterID = id;

            RegionMasterBL deleteRegion = new RegionMasterBL();
            deleteRegion.Delete(Regiondetails);
            BindGrid();


        }


        
        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_RegionMaster Regiondetails = new CPT_RegionMaster();
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                Regiondetails.RegionMasterID = id;
                string RegionName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                Regiondetails.RegionName = RegionName;
                RegionMasterBL updateRegion = new RegionMasterBL();
                updateRegion.Update(Regiondetails);
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