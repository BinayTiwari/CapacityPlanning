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

        public static void GetNewSkills(Repeater dtlRPA, Repeater dtlLangPrg, Repeater dtlMS, Repeater dtlFrk,
            Repeater dtlDB, Repeater dtlOther)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true && p.CategoryID == 1
                                 orderby p.SkillsName
                                 select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlRPA.DataSource = query;
                    dtlRPA.DataBind();

                    var query1 = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true && p.CategoryID == 2
                                 orderby p.SkillsName
                                 select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlLangPrg.DataSource = query1;
                    dtlLangPrg.DataBind();

                    var query2 = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true && p.CategoryID == 3
                                 orderby p.SkillsName
                                 select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlMS.DataSource = query2;
                    dtlMS.DataBind();

                    var query3 = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true && p.CategoryID == 4
                                 orderby p.SkillsName
                                 select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlFrk.DataSource = query3;
                    dtlFrk.DataBind();

                    var query4 = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true && p.CategoryID == 5
                                 orderby p.SkillsName
                                 select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlDB.DataSource = query4;
                    dtlDB.DataBind();

                    var query5 = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true && p.CategoryID == 6
                                 orderby p.SkillsName
                                 select new { p.SkillsMasterID, p.SkillsName }).ToList();

                    dtlOther.DataSource = query5;
                    dtlOther.DataBind();
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
                            where c.EmployeeMasterID == id && c.IsDeleted==0
                            select c).ToList();
                if (query.Count() > 0)
                {
                    flag = true;
                }

                return flag;
            }
        }

        public static void InsertCertificate(List<CPT_Certificate> certificateDetails)
        {
            try
            {
                Delete(certificateDetails[0].EmployeeID.Value);
                using(CPContext db = new CPContext())
                {
                    foreach(CPT_Certificate item in certificateDetails)
                    {
                        db.CPT_Certificate.Add(item);
                        
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception q)
            {
                Console.Write(q.Message);
            }
        }

        public static void Delete(int empID)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_Certificate
                                 where p.EmployeeID == empID
                                 select p).ToList();
                    if (query.Count() > 0)
                    {
                        foreach (var item in query)
                        {
                            db.CPT_Certificate.Remove(item);
                        }
                        db.SaveChanges();
                    }                                       
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
