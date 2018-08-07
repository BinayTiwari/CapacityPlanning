﻿using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class ResourceDemandBL
    {
        public int Insert(CPT_ResourceDemand resourceDemandDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_ResourceDemand.Add(resourceDemandDetails);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return 1;
        }
        
        public int Update(CPT_ResourceDemand resourceDemandDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = from details in db.CPT_ResourceDemand
                                where details.RequestID == resourceDemandDetails.RequestID
                                select details;

                    foreach (var detail in query)
                    {
                        detail.AccountID = resourceDemandDetails.AccountID;
                        //detail.CityID = resourceDemandDetails.CityID;
                        detail.OpportunityID = resourceDemandDetails.OpportunityID;
                        detail.SalesStageID = resourceDemandDetails.SalesStageID;
                        detail.ProcessName = resourceDemandDetails.ProcessName;
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

        
        public List<CPT_ResourceDemand> uiDataBinding(CPT_ResourceDemand resourceDemand)
        {
            List<CPT_ResourceDemand> data = new List<CPT_ResourceDemand>();
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceDemand
                            where c.RequestID == resourceDemand.RequestID
                            select c;
                foreach (var detail in query)
                {

                    data.Add(detail);
                }
            }
            return data;
        }

        public List<CPT_ResourceDetails> uiDataBindingDetails(GridView gv, CPT_ResourceDetails resourceDetails)
        {
            List<CPT_ResourceDetails> data = new List<CPT_ResourceDetails>();
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_ResourceDetails 
                              where c.RequestID == resourceDetails.RequestID
                            select c).ToList();
                foreach (var detail in query)
                {

                    data.Add(detail);


                }

                gv.DataSource = query;
                gv.DataBind();
            }
            
            return data;
        }

        public List<CPT_ResourceDemand> ViewResourceDemand(CPT_ResourceDemand masterDetail)
        {
            List<CPT_ResourceDemand> data = new List<CPT_ResourceDemand>();
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceDemand
                            where c.RequestID == masterDetail.RequestID
                            select c;

                foreach (var v in query)
                {
                    data.Add(v);
                }
            }
            return data;
        }

        public static void getResourceDemand(Repeater repeater, int employeeID)
        {
            using (CPContext db = new CPContext())
            {
                var query1 = (from p in db.CPT_ResourceDemand
                              join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID
                              join ct in db.CPT_CityMaster on p.CityID equals ct.CityID
                              join c in db.CPT_CountryMaster on ct.CountryID equals c.CountryMasterID
                              join t in db.CPT_OpportunityMaster on p.OpportunityID equals t.OpportunityID
                              join u in db.CPT_SalesStageMaster on p.SalesStageID equals u.SalesStageMasterID
                              join v in db.CPT_StatusMaster on p.StatusMasterID equals v.StatusMasterID
                              orderby p.DateOfCreation descending
                              where p.ResourceRequestBy == employeeID
                              select new
                              {
                                  p.RequestID,
                                  q.AccountName,
                                  c.CountryName,
                                  ct.CityName,
                                  t.OpportunityType,
                                  u.SalesStageName,
                                  p.ProcessName,
                                  v.StatusName,
                                  p.DateOfCreation

                              }).ToList();

                repeater.DataSource = query1;
                repeater.DataBind();
            }
        }

        public static List<int> getRegionID(int accountID)
        {

            using (CPContext db = new CPContext())
            {
                var query = (from p in db.CPT_AccountMaster
                             join q in db.CPT_CityMaster on p.CityID equals q.CityID
                             where p.AccountMasterID == accountID
                             select q.RegionID).ToList();


                return query;
            }

        }
        public static List<int> CityIDs(int regionID)
        {
            List<int> CityIDs;
            using (CPContext db = new CPContext())
            {
                var query = (from p in db.CPT_CityMaster
                             where p.RegionID == regionID & p.IsActive == true
                             select p.CityID).ToList();
                CityIDs = query;

            }
            return CityIDs;
        }
    }
}
