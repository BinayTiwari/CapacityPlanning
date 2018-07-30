using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic
{
    public class RoleMasterBL
    {
        public int Insert(CPT_RoleMaster roleDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_RoleMaster
                             where c.RoleName == roleDetails.RoleName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_RoleMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_RoleMaster.Add(roleDetails);
                }

                db.SaveChanges();
            }
            return 1;
        }

        public int Update(CPT_RoleMaster RoleDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = from details in db.CPT_RoleMaster
                                where details.RoleMasterID == RoleDetails.RoleMasterID
                                select details;

                    foreach (CPT_RoleMaster detail in query)
                    {
                        detail.RoleName = RoleDetails.RoleName;
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

        public int Delete(CPT_RoleMaster RoleDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_RoleMaster RoleMaster = new CPT_RoleMaster();
                    var deleteRoleDetails = from details in db.CPT_RoleMaster
                                               where details.RoleMasterID == RoleDetails.RoleMasterID
                                               select details;

                    foreach (var detail in deleteRoleDetails)
                    {
                        //db.CPT_RoleMaster.Remove(detail);
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
