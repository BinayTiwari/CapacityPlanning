using System;
using Entity;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class ResourceDetailsBL
    {
        public int Insert(CPT_ResourceDetails demandDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_ResourceDetails.Add(demandDetails);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return 1;
        }
        public static void ViewResourceDetails(Repeater rpt, string requestID)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from p in db.CPT_ResourceDetails
                             join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                             join r in db.CPT_SkillsMaster on p.SkillID equals r.SkillsMasterID.ToString()
                             where p.RequestID == requestID
                             select new
                             {
                                 q.RoleName,
                                 p.NoOfResources,
                                 r.SkillsName,
                                 p.StartDate,
                                 p.EndDate
                             }).ToList();

                rpt.DataSource = query;
                rpt.DataBind();
            }
        }
    }
}
