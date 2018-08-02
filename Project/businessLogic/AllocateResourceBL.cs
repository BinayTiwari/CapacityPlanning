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
                 join u in db.CPT_DesignationMaster on r.ResourceTypeID equals u.DesignationMasterID
                 join s in db.CPT_StatusMaster on p.StatusMasterID equals s.StatusMasterID
                 join t in db.CPT_SkillsMaster on r.SkillID equals t.SkillsName
                 select new
                 {
                     u.DesignationName,
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
