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
            using (CPContext db = new CPContext())
            {
                var query = (from p in db.CPT_ResourceMaster
                             join q in db.CPT_ResourceMaster on p.EmployeeMasterID equals q.ReportingManagerID
                             join r in db.CPT_RoleMaster on q.RolesID equals r.RoleMasterID
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



                             }).OrderBy(p => p.EmployeetName).ToList();
                rptResourceMaster.DataSource = query;
                rptResourceMaster.DataBind();
            }

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            // Response.Write("<script>alert('You really want to delete this item? The data will be deleted and cannot be recovered. ')</script>");

            CPT_ResourceMaster cPT_ResourceMaster = new CPT_ResourceMaster();
            LinkButton lb = sender as LinkButton;

            employeeID = Convert.ToInt32(lb.Attributes["empID"]);

            cPT_ResourceMaster.EmployeeMasterID = employeeID;
            ResourceMasterBL deleteresourceMasterBL = new ResourceMasterBL();
            deleteresourceMasterBL.Delete(cPT_ResourceMaster);
            BindGrid();


        }
    }
}