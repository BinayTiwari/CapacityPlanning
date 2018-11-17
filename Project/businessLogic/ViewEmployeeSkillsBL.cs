using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace businessLogic
{
    public class ViewEmployeeSkillsBL
    {
        public static void GetEmployeeList(List<Int32> lstSkillIDs, List<Int32> lstRatings)
        {
            try
            {
                using(CPContext db = new CPContext())
                {
                    var query = from p in db.CPT_Certificate
                                join q in db.CPT_ResourceMaster on p.EmployeeID equals q.EmployeeMasterID
                                join r in db.CPT_SkillsMaster on p.SkillID equals r.SkillsMasterID
                                where p.SkillID == lstSkillIDs[0] && p.Rating >= lstRatings[0]
                                select new { q.EmployeetName, r.SkillsName, p.Rating};
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
