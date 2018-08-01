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

            List<CPT_CityMaster> lstCity = new List<CPT_CityMaster>();
            CityMasterBL clsAccount = new CityMasterBL();
            lstCity = clsAccount.getCity();

            gvCity.DataSource = lstCity;
            gvCity.DataBind();


        }


        protected void CityAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_CityMaster Citydetails = new CPT_CityMaster();
                Citydetails.RegionID = Convert.ToInt32(RegionList.SelectedValue);
                Citydetails.CountryID = Convert.ToInt32(CountryList.SelectedValue);
                Citydetails.CityName = CityNameTextBox.Text.Trim();
                Citydetails.IsActive = true;

                CityMasterBL insertCity = new CityMasterBL();
                insertCity.Insert(Citydetails);
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
            gvCity.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_CityMaster Citydetails = new CPT_CityMaster();
            int id = int.Parse(gvCity.DataKeys[e.RowIndex].Value.ToString());
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
                int id = int.Parse(gvCity.DataKeys[e.RowIndex].Value.ToString());
                Citydetails.CityID = id;
                string CityName = ((TextBox)gvCity.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                Citydetails.CityName = CityName;
                CityMasterBL updateCity = new CityMasterBL();
                updateCity.Update(Citydetails);
                gvCity.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvCity.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCity.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RegionList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void RegionList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int regionID = Convert.ToInt32( RegionList.SelectedValue);
            
            
            ClsCommon.ddlGetCountry(CountryList,regionID);
            
        }

        protected void CountryList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}