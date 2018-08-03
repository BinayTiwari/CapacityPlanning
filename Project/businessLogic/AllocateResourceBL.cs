using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class AllocateResourceBL
    {
        public static void getEmployeeNameByResourceType(Repeater repeater)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceMaster
                                 join q in db.CPT_ResourceDetails on p.RolesID equals q.ResourceTypeID
                                 join r in db.CPT_AllocateResource on p.isMapped equals r.Utilization
                                 where (r.Utilization != p.isMapped) && (p.RolesID == q.ResourceTypeID)
                                 select new
                                 {
                                     p.EmployeetName,
                                     q.StartDate,
                                     q.EndDate
                                 }).ToList();
                    repeater.DataSource = query;
                    repeater.DataBind();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //public static void bindRepeater(Repeater rpt)
        //{
        //    try
        //    {
        //        using (CPContext db = new CPContext())
        //        {
        //            var query = (from p in db.CPT_ResourceMaster
        //                         join q in db.CPT_ResourceDetails on p.RolesID equals q.ResourceTypeID
        //                         select new
        //                         {
        //                             p.EmployeetName,
        //                             q.StartDate,
        //                             q.EndDate
        //                         }
        //                       ).ToList();
        //            rpt.DataSource = query;
        //            rpt.DataBind();   
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
        public static void AllocateResource(GridView GV)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {
                   
                    var query =
                (from p in db.CPT_ResourceDemand
                 join q in db.CPT_PriorityMaster on p.PriorityID equals q.PriorityID
                 join r in db.CPT_ResourceDetails on p.RequestID equals r.RequestID
                 join u in db.CPT_RoleMaster on r.ResourceTypeID equals u.RoleMasterID
                 join s in db.CPT_StatusMaster on p.StatusMasterID equals s.StatusMasterID
                 join t in db.CPT_SkillsMaster on r.SkillID equals t.SkillsMasterID.ToString()
                 where p.RequestID == r.RequestID
                 select new
                 {
                     u.RoleName,
                     r.NoOfResources,
                     t.SkillsName,
                     r.StartDate,
                     r.EndDate,
                     s.StatusName,
                     q.PriorityName
                     
                 }).ToList();
                    GV.DataSource = query;
                    GV.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
