using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace businessLogic
{
    public class RegionMasterBL
    {
        public int Insert(CPT_RegionMaster regionDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_RegionMaster
                             where c.RegionName == regionDetails.RegionName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_RegionMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_RegionMaster.Add(regionDetails);
                }

                db.SaveChanges();
            }
            return 1;


        }
        public int Update(CPT_RegionMaster regionDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_RegionMaster
                            where details.RegionMasterID == regionDetails.RegionMasterID
                            select details;
                foreach (CPT_RegionMaster detail in query)
                {
                    detail.RegionName = regionDetails.RegionName;

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
        public int Delete(CPT_RegionMaster regionDetails)
        {
            using (CPContext db = new CPContext())
            {

                try
                {

                    CPT_RegionMaster RegionMaster = new CPT_RegionMaster();
                    var deleteRegionDetails = from details in db.CPT_RegionMaster
                                               where details.RegionMasterID == regionDetails.RegionMasterID
                                               select details;

                    var deleteCountryDetails = from details in db.CPT_CountryMaster
                                            where details.RegionID == regionDetails.RegionMasterID
                                            select details;

                    var deleteCityDetails = from details in db.CPT_CityMaster
                                              where details.RegionID == regionDetails.RegionMasterID
                                              select details;

                    foreach (var detail in deleteRegionDetails)
                    {
                        //db.CPT_RegionMaster.Remove(detail);
                        detail.IsActive = false;
                        
                    }
                    foreach (var detail in deleteCountryDetails)
                    {
                        //db.CPT_RegionMaster.Remove(detail);
                        detail.IsActive = false;

                    }
                    foreach(var detail in deleteCityDetails)
                    {
                        //db.CPT_RegionMaster.Remove(detail);
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
