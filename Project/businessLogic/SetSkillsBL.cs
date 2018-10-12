using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class SetSkillsBL
    {
        public static void GetSkills(DataList dtlSkills)
        {
            try
            {
                using(CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_SkillsMaster
                                where p.IsActive == true orderby p.SkillsName
                                select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlSkills.DataSource = query;
                    dtlSkills.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void UpdateSkills(int EmpID, string Skills)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceMaster
                                 where p.EmployeeMasterID == EmpID
                                 select p).ToList();

                    foreach(CPT_ResourceMaster item in query)
                    {
                        item.Skillsid = Skills;
                    }
                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static bool CheckEmpID(int id)
        {
            bool flag = false;
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == id
                            select c).ToList();
                if (query.Count() > 0)
                {
                    flag = true;
                }

                return flag;
            }
        }
    }
}
