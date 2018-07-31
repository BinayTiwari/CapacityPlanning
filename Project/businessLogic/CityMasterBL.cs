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

        public List<CPT_CityMaster> getCity()
        {

            List<CPT_CityMaster> lstCityName = new List<CPT_CityMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_OpportunityMaster.ToList();
                var query = (from p in db.CPT_CityMaster
                             join q in db.CPT_CountryMaster on p.CountryID equals q.CountryMasterID
                             join r in db.CPT_RegionMaster on p.RegionID equals r.RegionMasterID
                             orderby p.CityID descending
                             where p.IsActive == true
                             select new
                             {
                                 p.CityID,
                                 p.CityName,
                                 q.CountryName,
                                 r.RegionName
                                 
                             }).ToList();

                foreach (var item in query)
                {
                    CPT_CityMaster clscity = new CPT_CityMaster();
                    clscity.CityID = item.CityID;
                    clscity.CityName = item.CityName;
                    
                    

                    CPT_CountryMaster clsCountry = new CPT_CountryMaster();
                    clsCountry.CountryName = item.CountryName;
                    clscity.CPT_CountryMaster = clsCountry;

                    CPT_RegionMaster region = new CPT_RegionMaster();
                    region.RegionName = item.RegionName;
                    clscity.CPT_RegionMaster = region;
                    

                    lstCityName.Add(clscity);
                }


                return lstCityName;

            }

        }
    }

}


