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
    public partial class CountryMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                
                ClsCommon.ddlGetRegion(RegionList);
                BindGrid();
            }
        }
        private void BindGrid()
        {
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_CountryMaster.ToList();
                var query = (from p in db.CPT_CountryMaster
                             join q in db.CPT_RegionMaster on p.RegionID equals q.RegionMasterID
                             where p.IsActive == true
                             select new
                             {
                                 p.CountryMasterID,
                                 p.CountryName,
                                 q.RegionName
                             }).ToList();
                //GridView1.DataSource = (from c in db.CPT_CountryMaster
                //                        where c.IsActive == true
                //                        select c).ToList();
                GridView1.DataSource = query;

                GridView1.DataBind();

            }
        }

        protected void CountryAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_CountryMaster Countrydetails = new CPT_CountryMaster();
                Countrydetails.RegionID = Convert.ToInt32(RegionList.SelectedValue);
                Countrydetails.CountryName = CountryNameTextBox.Text;
                Countrydetails.IsActive = true;

                CountryMasterBL insertCountry = new CountryMasterBL();
                insertCountry.Insert(Countrydetails);
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

            CPT_CountryMaster Countrydetails = new CPT_CountryMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            Countrydetails.CountryMasterID = id;

            CountryMasterBL deleteCountry = new CountryMasterBL();
            deleteCountry.Delete(Countrydetails);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_CountryMaster Countrydetails = new CPT_CountryMaster();
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                Countrydetails.CountryMasterID = id;
                string CountryName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                Countrydetails.CountryName = CountryName;
                CountryMasterBL updateCountry = new CountryMasterBL();
                updateCountry.Update(Countrydetails);
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

        protected void RegionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }
    }
}