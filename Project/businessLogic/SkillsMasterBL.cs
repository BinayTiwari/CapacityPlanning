using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic
{
    public class SkillsMasterBL
    {
        public int Insert(CPT_SkillsMaster skillsDetails)
        {
            using (CPContext db = new CPContext())
            {

                var query = (from c in db.CPT_SkillsMaster
                             where c.SkillsName == skillsDetails.SkillsName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_SkillsMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_SkillsMaster.Add(skillsDetails);
                }

                db.SaveChanges();
            }
            return 1;
        }

        public int Update(CPT_SkillsMaster SkillsDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = from details in db.CPT_SkillsMaster
                                where details.SkillsMasterID == SkillsDetails.SkillsMasterID
                                select details;

                    foreach (CPT_SkillsMaster detail in query)
                    {
                        detail.SkillsName = SkillsDetails.SkillsName;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return 1;
        }

        public int Delete(CPT_SkillsMaster SkillsDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_SkillsMaster SkillsMaster = new CPT_SkillsMaster();
                    var deleteSkillsDetails = from details in db.CPT_SkillsMaster
                                                  where details.SkillsMasterID == SkillsDetails.SkillsMasterID
                                                  select details;

                    foreach (var detail in deleteSkillsDetails)
                    {
                        //db.CPT_SkillsMaster.Remove(detail);
                        detail.IsActive = false;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return 1;
        }
    }
}
