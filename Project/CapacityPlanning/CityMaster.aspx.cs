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
    public partial class CityMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetRegion(RegionList);
                ClsCommon.ddlGetCountry(CountryList);
                BindGrid();
            }
        }
        private void BindGrid()
        {
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_CityMaster.ToList();
                //GridView1.DataSource = (from c in db.CPT_CityMaster
                //                        where c.IsActive == true
                //                        select c).ToList();

                var query = (from p in db.CPT_CityMaster
                             join q in db.CPT_CountryMaster on p.CountryID equals q.CountryMasterID
                             join r in db.CPT_RegionMaster on p.RegionID equals r.RegionMasterID
                             where p.IsActive == true
                             select new
                             {
                                 p.CityID,
                                 p.CityName,
                                 q.CountryName,
                                 r.RegionName
                             }).ToList();

                GridView1.DataSource = query;
                GridView1.DataBind();
            }
        }

        protected void CityAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_CityMaster Citydetails = new CPT_CityMaster();
                Citydetails.RegionID = Convert.ToInt32(RegionList.SelectedValue);
                Citydetails.CountryID = Convert.ToInt32(CountryList.SelectedValue);
                Citydetails.CityName = CityNameTextBox.Text;
                Citydetails.IsActive = true;

                CityMasterBL insertCity = new CityMasterBL();
                insertCity.Insert(Citydetails);
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
            CPT_CityMaster Citydetails = new CPT_CityMaster();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            Citydetails.CityID = id;

            CityMasterBL deleteCity = new CityMasterBL();
            deleteCity.Delete(Citydetails);
            BindGrid();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CPT_CityMaster Citydetails = new CPT_CityMaster();
                int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
                Citydetails.CityID = id;
                string CityName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                Citydetails.CityName = CityName;
                CityMasterBL updateCity = new CityMasterBL();
                updateCity.Update(Citydetails);
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