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
    public partial class ResourceMaster : System.Web.UI.Page
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

            //List<CPT_ResourceMaster> lstResource = new List<CPT_ResourceMaster>();
            //ResourceMasterBL clsResource = new ResourceMasterBL();
            //lstResource = clsResource.getResource();

            //gvResource.DataSource = lstResource;
            //gvResource.DataBind();
            using (CPContext db = new CPContext()) { 
            var query = (from p in db.CPT_ResourceMaster
                         join q in db.CPT_ResourceMaster on p.EmployeeMasterID equals q.ReportingManagerID
                         join r in db.CPT_RoleMaster on p.RolesID equals r.RoleMasterID
                         let mgrName = p.EmployeetName
                         
                         select new

                         {
                             q.EmployeeMasterID,
                             q.EmployeetName,
                             q.ReportingManagerID,
                             q.BaseLocation,
                             q.Mobile,
                             mgrName,
                             r.RoleName
                             


                         }).OrderBy(p=>p.EmployeetName).ToList();
                rptResourceMaster.DataSource = query;
                rptResourceMaster.DataBind();
        }

        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_ResourceMaster cPT_ResourceMaster = new CPT_ResourceMaster();
           // int id = int.Parse(gvResource.DataKeys[e.RowIndex].Value.ToString());
         //   cPT_ResourceMaster.EmployeeMasterID = id;

            ResourceMasterBL deleteresourceMasterBL = new ResourceMasterBL();
            deleteresourceMasterBL.Delete(cPT_ResourceMaster);
            BindGrid();


        }



        protected void update(object sender, GridViewUpdateEventArgs e)
        {

            
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        //    gvResource.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
        //    gvResource.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {

          //  gvResource.EditIndex = -1;
            BindGrid();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditButton")
            {
                int index = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = gvResource.Rows[index];
            //    string rows = row.Cells[1].Text;

            ///    Response.Redirect("~/EditEmployee.aspx?EmployeeId=" + row.Cells[1].Text);
            }

            if(e.CommandName == "ViewProfile")
            {
                int index1 = Convert.ToInt32(e.CommandArgument);
             //   GridViewRow row1 = gvResource.Rows[index1];
             //   string rows = row1.Cells[1].Text;

              //  Response.Redirect("~/ResourceMaster.aspx?EmployeeId=" + row1.Cells[1].Text);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void View_Resource_Master(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            
        }

        



    }
}