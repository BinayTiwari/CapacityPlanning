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
    public partial class GradeMaster : System.Web.UI.Page
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

            List<CPT_GradeMaster> lstDesignation = new List<CPT_GradeMaster>();
            GradeMasterBL clsDesignation = new GradeMasterBL();
            lstDesignation = clsDesignation.getGrade();

            gvGrade.DataSource = lstDesignation;
            gvGrade.DataBind();


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

        protected void GradeAddButton_Click(object sender, EventArgs e)
        {
            try
            {

                CPT_GradeMaster gradedetails = new CPT_GradeMaster();
                gradedetails.Grade = GradeNameTextBox.Text;
                gradedetails.IsActive = true;

                GradeMasterBL insertGrade = new GradeMasterBL();
                insertGrade.Insert(gradedetails);
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
            gvGrade.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_GradeMaster gradedetails = new CPT_GradeMaster();
            int id = int.Parse(gvGrade.DataKeys[e.RowIndex].Value.ToString());
            gradedetails.GradeID = id;

            GradeMasterBL deleteGrade = new GradeMasterBL();
            deleteGrade.Delete(gradedetails);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {
                CPT_GradeMaster gradedetails = new CPT_GradeMaster();
                int id = int.Parse(gvGrade.DataKeys[e.RowIndex].Value.ToString());
                gradedetails.GradeID = id;
                string gradeName = ((TextBox)gvGrade.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
                gradedetails.Grade = gradeName;
                GradeMasterBL updateGrade = new GradeMasterBL();
                updateGrade.Update(gradedetails);
                gvGrade.EditIndex = -1;
                BindGrid();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvGrade.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

            gvGrade.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}