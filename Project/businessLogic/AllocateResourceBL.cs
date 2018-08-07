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
        //public int Insert(CPT_AllocateResource allocateDetails)
        //{
        //    using (CPContext db = new CPContext())
        //    {
        //        try
        //        {
        //            db.CPT_AllocateResource.Add(allocateDetails);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }

        //    }
        //    return 1;
        //}
        //public static void getEmployeeNameByResourceType(Repeater repeater,string RoleName)
        //{
        //    try
        //    {
        //        using (CPContext db = new CPContext())
        //        {
        //            var query = (from p in db.CPT_ResourceMaster
        //                         join q in db.CPT_ResourceDetails on p.RolesID equals q.ResourceTypeID
        //                         join r in db.CPT_RoleMaster on p.RolesID equals r.RoleMasterID
        //                         where (RoleName == r.RoleName) && (p.isMapped==0)
        //                         select new
        //                         {
        //                             p.EmployeetName,
        //                             q.StartDate,
        //                             q.EndDate
        //                         }).ToList();
        //            repeater.DataSource = query;
        //            repeater.DataBind();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
      
        public static void AllocateResource(Repeater rpt)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {
                   
                    var query =
                (from p in db.CPT_ResourceDetails
                 join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                 join r in db.CPT_SkillsMaster on p.SkillID equals r.SkillsMasterID.ToString()
                 select new
                 {
                     p.RequestID,
                     q.RoleName,
                     r.SkillsName,
                     p.NoOfResources,
                     p.StartDate,
                     p.EndDate
                 }).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public static void AllocateResourceByID(Repeater rpt, string reqID)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {

                    var query =
                (from p in db.CPT_ResourceDetails
                 join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                 join r in db.CPT_SkillsMaster on p.SkillID equals r.SkillsMasterID.ToString()
                 where p.RequestID == reqID
                 select new
                 {
                     p.RequestID,
                     q.RoleName,
                     r.SkillsName,
                     p.NoOfResources,
                     p.StartDate,
                     p.EndDate
                 }).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
