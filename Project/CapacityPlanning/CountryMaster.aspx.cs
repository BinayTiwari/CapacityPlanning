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
                CountryNameTextBox.Enabled = false;

                ClsCommon.ddlGetRegion(RegionList);
                BindGrid();
            }
        }
        private void BindGrid()
        {

            List<CPT_CountryMaster> lstCountry = new List<CPT_CountryMaster>();
            CountryMasterBL clsCountry = new CountryMasterBL();
            lstCountry = clsCountry.getCountry();

            gvCountry.DataSource = lstCountry;
            gvCountry.DataBind();


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

        protected void CountryAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_CountryMaster Countrydetails = new CPT_CountryMaster();
                Countrydetails.RegionID = Convert.ToInt32(RegionList.SelectedValue);
                Countrydetails.CountryName = CountryNameTextBox.Text.Trim();
                Countrydetails.IsActive = true;

                CountryMasterBL insertCountry = new CountryMasterBL();
                insertCountry.Insert(Countrydetails);
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
            gvCountry.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {

            CPT_CountryMaster Countrydetails = new CPT_CountryMaster();
            int id = int.Parse(gvCountry.DataKeys[e.RowIndex].Value.ToString());
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
                int id = int.Parse(gvCountry.DataKeys[e.RowIndex].Value.ToString());
                Countrydetails.CountryMasterID = id;
                string CountryName = ((TextBox)gvCountry.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                Countrydetails.CountryName = CountryName;
                CountryMasterBL updateCountry = new CountryMasterBL();
                updateCountry.Update(Countrydetails);
                gvCountry.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvCountry.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvCountry.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RegionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (RegionList.SelectedValue == "")
            {
                CountryNameTextBox.Enabled = false;
            }
            else
            {
                CountryNameTextBox.Enabled = true;
            }

        }
    }
}