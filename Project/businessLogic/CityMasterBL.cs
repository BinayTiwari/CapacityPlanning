using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace businessLogic
{
    public class CityMasterBL
    {
        public int Insert(CPT_CityMaster CityDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_CityMaster
                             where c.CityName == CityDetails.CityName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_CityMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_CityMaster.Add(CityDetails);
                }

                db.SaveChanges();
            }
            return 1;
        }
        public int Update(CPT_CityMaster CityDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_CityMaster
                            where details.CityID == CityDetails.CityID
                            select details;
                foreach (CPT_CityMaster detail in query)
                {
                    detail.CityName = CityDetails.CityName;
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return 1;
        }

        public int Delete(CPT_CityMaster CityDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_CityMaster CityMaster = new CPT_CityMaster();
                    var deleteCityDetails = from details in db.CPT_CityMaster
                                               where details.CityID == CityDetails.CityID
                                               select details;

                    foreach (var detail in deleteCityDetails)
                    {
                        //db.CPT_CityMaster.Remove(detail);
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


