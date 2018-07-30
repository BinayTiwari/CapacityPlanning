using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        detail.CityID = resourceDemandDetails.CityID;
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

        public int Delete(CPT_ResourceDemand resourceDemandDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var deleteResourceDemandDetails = from details in db.CPT_ResourceDemand
                                                      where details.RequestID == resourceDemandDetails.RequestID
                                                      select details;

                    foreach (var detail in deleteResourceDemandDetails)
                    {
                        db.CPT_ResourceDemand.Remove(detail);
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
    }
}
