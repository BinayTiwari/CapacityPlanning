using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic
{
    public class StatusMasterBL
    {
        public int Insert(CPT_StatusMaster statusDetails)
        {
            using (CPContext db = new CPContext())
            {

                var query = (from c in db.CPT_StatusMaster
                             where c.StatusName == statusDetails.StatusName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_StatusMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_StatusMaster.Add(statusDetails);
                }

                db.SaveChanges();
            }
            return 1;
        }

        public int Update(CPT_StatusMaster StatusDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = from details in db.CPT_StatusMaster
                                where details.StatusMasterID == StatusDetails.StatusMasterID
                                select details;

                    foreach (CPT_StatusMaster detail in query)
                    {
                        detail.StatusName = StatusDetails.StatusName;
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

        public int Delete(CPT_StatusMaster StatusDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_StatusMaster StatusMaster = new CPT_StatusMaster();
                    var deleteStatusDetails = from details in db.CPT_StatusMaster
                                              where details.StatusMasterID == StatusDetails.StatusMasterID
                                              select details;

                    foreach (var detail in deleteStatusDetails)
                    {
                        //db.CPT_StatusMaster.Remove(detail);
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
