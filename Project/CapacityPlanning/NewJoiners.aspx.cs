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
    public partial class NewJoiners : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                BindGrid();

            }
        }

        public void BindGrid()
        {
            //using(CPContext db = new CPContext())
            //{
            //    var query = (from p in db.CPT_NewJoiners
            //                 join q in db.CPT_AccountMaster on p.Account equals q.AccountMasterID
            //                 join r in db.CPT_DesignationMaster on p.DesignationID equals r.DesignationMasterID
            //                 select new
            //                 {
            //                     p.NewJoinerID,
            //                     p.FirstName,
            //                     p.Location,
            //                     p.LastName,
            //                     p.JoiningDate,
            //                     p.Experience,
            //                     p.InterviewedBy,
            //                     p.Skills,
            //                     q.AccountName,
            //                     r.DesignationName  
            //                 }).ToList();

            //    GridView1.DataSource = query;
            //    GridView1.DataBind();
            //}

            List<CPT_NewJoiners> lstNewJoiners = new List<CPT_NewJoiners>();
            NewJoinersBL clsNewJoiners = new NewJoinersBL();
            lstNewJoiners = clsNewJoiners.getNewJoiners();

            GridView1.DataSource = lstNewJoiners;
            GridView1.DataBind();

        }
        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_NewJoiners newJoiners = new CPT_NewJoiners();
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            
            newJoiners.NewJoinerID = id;

            NewJoinersBL newJoinersBL = new NewJoinersBL();
            newJoinersBL.Delete(newJoiners);
            BindGrid();

        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string rows = row.Cells[0].Text;

                Response.Redirect("~/EditNewJoiners.aspx?JoinerId=" + row.Cells[0].Text);
            }
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            try
            {

                
                

            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
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