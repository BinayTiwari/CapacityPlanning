using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic
{
    public class ImportExcelBL
    {
        public List<string> AccountName()
        {
            using (CPContext db = new CPContext())
            {
                List<string> lstAcc = new List<string>();
                //GridView1.DataSource = db.CPT_AccountMaster.ToList();
                var query = (from p in db.CPT_AccountMaster
                             where p.IsActive == true
                             select p.AccountName).ToList();
                             

                foreach(var item in query)
                {
                    lstAcc.Add(item);
                }
                return lstAcc;
                
            }
        }

        public List<string> RegionName()
        {
            using (CPContext db = new CPContext())
            {
                List<string> lstRegion = new List<string>();
                //GridView1.DataSource = db.CPT_AccountMaster.ToList();
                var query = (from p in db.CPT_RegionMaster
                             where p.IsActive == true
                             select p.RegionName).ToList();


                foreach (var item in query)
                {
                    lstRegion.Add(item);
                }
                return lstRegion;

            }
        }

        public List<string> CityName()
        {
            using (CPContext db = new CPContext())
            {
                List<string> lstCityName = new List<string>();
                //GridView1.DataSource = db.CPT_AccountMaster.ToList();
                var query = (from p in db.CPT_CityMaster
                             where p.IsActive == true
                             select p.CityName).ToList();


                foreach (var item in query)
                {
                    lstCityName.Add(item);
                }
                return lstCityName;

            }
        }

        public List<string> CountryName()
        {
            using (CPContext db = new CPContext())
            {
                List<string> lstCountryName = new List<string>();
                //GridView1.DataSource = db.CPT_AccountMaster.ToList();
                var query = (from p in db.CPT_CountryMaster
                             where p.IsActive == true
                             select p.CountryName).ToList();


                foreach (var item in query)
                {
                    lstCountryName.Add(item);
                }
                return lstCountryName;

            }
        }


        public static void InsertRegion(CPT_RegionMaster details)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_RegionMaster.Add(details);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public static void InsertCountry(CPT_CountryMaster details)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_CountryMaster.Add(details);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public static void InsertCity(CPT_CityMaster details)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_CityMaster.Add(details);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public static void InsertAccount(CPT_AccountMaster details)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_AccountMaster.Add(details);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


        public static List<int> getRegionID(List<string> lstRegionName)
        {
            using (CPContext db = new CPContext())
            {

                List<int> lstRegionID = new List<int>();
                foreach(var item in lstRegionName)
                {
                    var query = (from p in db.CPT_RegionMaster
                                 where p.IsActive == true && p.RegionName == item
                                 select p.RegionMasterID).ToList();
                    lstRegionID.Add(query[0]);
                }
                
                return lstRegionID;

            }
        }

        public static List<int> getCountryID(List<string> lstCountryNAme)
        {
            using (CPContext db = new CPContext())
            {

                List<int> lstCountryID = new List<int>();
                foreach (var item in lstCountryNAme)
                {
                    var query = (from p in db.CPT_CountryMaster
                                 where p.IsActive == true && p.CountryName == item
                                 select p.CountryMasterID).ToList();
                    lstCountryID.Add(query[0]);
                }
                return lstCountryID;

            }
        }

        public static List<int> getCityID(List<string> lstCity)
        {
            using (CPContext db = new CPContext())
            {

                List<int> lstCityID = new List<int>();
                foreach (var item in lstCity)
                {
                    var query = (from p in db.CPT_CityMaster
                                 where p.IsActive == true && p.CityName == item
                                 select p.CityID).ToList();
                    lstCityID.Add(query[0]);
                }
                return lstCityID;

            }
        }
    }
}
