using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace businessLogic
{
    public class AllocateBL
    {
        public static void AllocateGrid(GridView GV)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {
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
                     s.ReportingManagerID,
                     p.ProcessName,
                     u.StartDate,
                     r.SalesStageName,
                     u.NoOfResources,
                     t.PriorityName
                 }).ToList();
                    GV.DataSource = qs;
                    GV.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public static void ddlGetPriority(GridViewRowEventArgs e)
        {
            using (CPContext db = new CPContext())
            {
                var Priority =
               (from t in db.CPT_PriorityMaster where t.IsActive == true select t).ToList();

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlPriorities = (e.Row.FindControl("ddlPriorities") as DropDownList);
                    ddlPriorities.DataSource = Priority;
                    ddlPriorities.DataTextField = "PriorityName";
                    ddlPriorities.DataValueField = "PriorityName";
                    ddlPriorities.DataBind();
                    ddlPriorities.Items.Insert(0, new ListItem("Set Priority"));
                    ddlPriorities.SelectedIndex = 0;
                }
            }
        }
        public int Update(CPT_ResourceDemand details)
        {
            using (CPContext db = new CPContext())
            {
                var query =
                   (from p in db.CPT_ResourceDemand
                    where p.RequestID == details.RequestID
                    select p);

                foreach (CPT_ResourceDemand detail in query)
                {
                    detail.PriorityID = details.PriorityID;

                }


                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
                return 1;
            }
        }
    }
}
