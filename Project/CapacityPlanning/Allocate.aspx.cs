using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using System.Data;
using businessLogic;
namespace CapacityPlanning
{
    public partial class Allocate : System.Web.UI.Page
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
            using (CPContext db = new CPContext())
            {

                //GridView1.DataSource = db.CPT_AccountMaster.ToList();//account name
                //GridView1.DataSource = db.CPT_ResourceMaster.ToList();//reporting manager
                //GridView1.DataSource = db.CPT_PriorityMaster.ToList();//priority name


                //star date and end date no of resorces

                // GridView1.DataSource = db.CPT_SalesStageMaster.ToList();
                //GridView1.DataSource = db.CPT_ResourceMaster.ToList();
                ////GridView1.DataSource = db.CPT_ResourceDetails.ToList();//salestage
                var qs =
            (from p in db.CPT_ResourceDemand
             join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID
             join r in db.CPT_SalesStageMaster on p.SalesStageID equals r.SalesStageMasterID
             join s in db.CPT_ResourceMaster on p.ResourceRequestBy equals s.EmployeeMasterID
             join t in db.CPT_PriorityMaster on p.PriorityID equals t.PriorityID
             join u in db.CPT_ResourceDetails on p.RequestID equals u.RequestID
             select new
             {
                 p.RequestID,
                 q.AccountName,
                 
                 p.ProcessName,
                 u.StartDate,
                 r.SalesStageName,
                 u.NoOfResources,
                 t.PriorityName
             }).ToList();
                GridView1.DataSource = qs;
                GridView1.DataBind();
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}