﻿using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace businessLogic
{
    public class AccountMasterBL
    {
        public int Insert(CPT_AccountMaster accountDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_AccountMaster
                            where c.AccountName == accountDetails.AccountName & c.IsActive == false
                            select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_AccountMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_AccountMaster.Add(accountDetails);
                }
                
                db.SaveChanges();
            }
            return 1;


        }

        public int Update(CPT_AccountMaster accountDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_AccountMaster
                            where details.AccountMasterID == accountDetails.AccountMasterID
                            select details;

                
                foreach (CPT_AccountMaster detail in query)
                {
                    detail.AccountName = accountDetails.AccountName;
                  
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

        public int Delete(CPT_AccountMaster accountDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_AccountMaster accountMaster = new CPT_AccountMaster();
                    var deleteAccountDetails = from details in db.CPT_AccountMaster
                                               where details.AccountMasterID == accountDetails.AccountMasterID
                                               select details;

                    foreach (var detail in deleteAccountDetails)
                    {
                        //db.CPT_AccountMaster.Remove(detail);
                        detail.IsActive = false;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    
                }
            }
            return 1;
        }

        public List<CPT_AccountMaster> getAccount()
        {

            List<CPT_AccountMaster> lstAccountName = new List<CPT_AccountMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_AccountMaster.ToList();
                var query = (from p in db.CPT_AccountMaster
                             join q in db.CPT_CityMaster on p.CityID equals q.CityID
                             orderby p.AccountMasterID descending
                             where p.IsActive == true
                             select new
                             {
                                 p.AccountMasterID,
                                 p.AccountName,
                                 q.CityName
                             }).ToList();

                foreach (var item in query)
                {
                    CPT_AccountMaster clsAccount = new CPT_AccountMaster();
                    clsAccount.AccountMasterID = item.AccountMasterID;
                    clsAccount.AccountName = item.AccountName;

                    CPT_CityMaster city = new CPT_CityMaster();
                    city.CityName = item.CityName;
                    clsAccount.CPT_CityMaster = city;

                    lstAccountName.Add(clsAccount);
                }

                return lstAccountName;

            }

        }


    }
}
