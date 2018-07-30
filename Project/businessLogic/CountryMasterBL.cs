using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace businessLogic
{
    public class CountryMasterBL
    {
        public int Insert(CPT_CountryMaster countryDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_CountryMaster
                             where c.CountryName == countryDetails.CountryName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_CountryMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_CountryMaster.Add(countryDetails);
                }

                db.SaveChanges();
            }
            return 1;


        }
        public int Update(CPT_CountryMaster CountryDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_CountryMaster
                            where details.CountryMasterID == CountryDetails.CountryMasterID
                            select details;
                foreach (CPT_CountryMaster detail in query)
                {
                    detail.CountryName = CountryDetails.CountryName;

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
        public int Delete(CPT_CountryMaster CountryDetails)
        {
            using (CPContext db = new CPContext())
            {

                try
                {

                    CPT_CountryMaster CountryMaster = new CPT_CountryMaster();
                    var deleteCountryDetails = from details in db.CPT_CountryMaster
                                               where details.CountryMasterID == CountryDetails.CountryMasterID
                                               select details;

                    var deleteCityDetails = from details in db.CPT_CityMaster
                                               where details.CountryID == CountryDetails.CountryMasterID
                                               select details;

                    foreach (var detail in deleteCountryDetails)
                    {
                        //db.CPT_CountryMaster.Remove(detail);
                        detail.IsActive = false;
                    }
                    foreach (var detail in deleteCityDetails)
                    {
                        //db.CPT_CountryMaster.Remove(detail);
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


