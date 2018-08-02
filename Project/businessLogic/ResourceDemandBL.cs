using Entity;
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

        public static void getResourceDemand(GridView gridview, int employeeID)
        {
            using (CPContext db = new CPContext())
            {
             var query1 = (from p in db.CPT_ResourceDemand
                          join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID
                          join r in db.CPT_CityMaster on p.CityID equals r.CityID
                          join ct in db.CPT_CountryMaster on r.CountryID equals ct.CountryMasterID
                          join s in db.CPT_CityMaster on p.CityID equals s.CityID
                          join t in db.CPT_OpportunityMaster on p.OpportunityID equals t.OpportunityID
                          join u in db.CPT_SalesStageMaster on p.SalesStageID equals u.SalesStageMasterID
                          join v in db.CPT_StatusMaster on p.StatusMasterID equals v.StatusMasterID
                          orderby p.DateOfCreation descending
                          where p.ResourceRequestBy == employeeID
                          select new
                          { p.RequestID, q.AccountName, ct.CountryName, s.CityName, t.OpportunityType, u.SalesStageName, p.ProcessName, v.StatusName

                          }).ToList();

                gridview.DataSource = query1;
                gridview.DataBind();
            }
        }
    }
}
