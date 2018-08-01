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

            gvRegion.DataSource = lstRegion;
            gvRegion.DataBind();
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
        protected void SaveRegionButton(object sender, EventArgs e)
        {

            try
            {

                CPT_RegionMaster Regiondetails = new CPT_RegionMaster();
                Regiondetails.RegionName = RegionInput.Text;
                Regiondetails.IsActive = true;

                RegionMasterBL insertRegion = new RegionMasterBL();
                insertRegion.Insert(Regiondetails);
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
            gvRegion.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }





        protected void delete(object sender, GridViewDeleteEventArgs e)
        {

            CPT_RegionMaster Regiondetails = new CPT_RegionMaster();
            int id = int.Parse(gvRegion.DataKeys[e.RowIndex].Value.ToString());
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
                int id = int.Parse(gvRegion.DataKeys[e.RowIndex].Value.ToString());
                Regiondetails.RegionMasterID = id;
                string RegionName = ((TextBox)gvRegion.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                Regiondetails.RegionName = RegionName;
                RegionMasterBL updateRegion = new RegionMasterBL();
                updateRegion.Update(Regiondetails);
                gvRegion.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvRegion.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvRegion.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}