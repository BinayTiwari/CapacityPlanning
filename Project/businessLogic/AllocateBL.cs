using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace businessLogic
{
    public class AllocateBL : ResourceDemandBL
    {
        public static List<int> getResourceDemand(Repeater repeater)
        {
            List<int> statusID = new List<int>();
            using (CPContext db = new CPContext())
            {
                var query1 = (from p in db.CPT_ResourceDemand
                              join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID
                              join r in db.CPT_PriorityMaster on p.PriorityID equals r.PriorityID
                              join ct in db.CPT_CityMaster on p.CityID equals ct.CityID
                              join c in db.CPT_CountryMaster on ct.CountryID equals c.CountryMasterID
                              join t in db.CPT_OpportunityMaster on p.OpportunityID equals t.OpportunityID
                              join u in db.CPT_SalesStageMaster on p.SalesStageID equals u.SalesStageMasterID
                              join v in db.CPT_StatusMaster on p.StatusMasterID equals v.StatusMasterID
                              where p.StatusMasterID == 19 || p.StatusMasterID == 31
                              orderby p.DateOfCreation descending
                              join x in db.CPT_ResourceMaster on p.ResourceRequestBy equals x.EmployeeMasterID
                              select new
                              {
                                  p.RequestID,
                                  q.AccountName,
                                  c.CountryName,
                                  ct.CityName,
                                  x.EmployeetName,
                                  t.OpportunityType,
                                  u.SalesStageName,
                                  p.ProcessName,
                                  v.StatusName,
                                  p.DateOfCreation,
                                  v.StatusMasterID

                              }).ToList();

                foreach (var item in query1)
                {
                    statusID.Add(item.StatusMasterID);
                }

                repeater.DataSource = query1;
                repeater.DataBind();

            }
            return statusID;
        }

        public int UpdateData(CPT_ResourceDemand details)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query =
                       (from p in db.CPT_ResourceDemand
                        where p.RequestID == details.RequestID
                        select p);

                    foreach (CPT_ResourceDemand detail in query)
                    {
                        detail.StatusMasterID = details.StatusMasterID;

                    }

                    db.SaveChanges();

                    return 1;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        public static List<string> getRequestDetails(string RequestID)
        {
            List<string> details = new List<string>();
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceDemand
                                 join q in db.CPT_ResourceMaster on p.ResourceRequestBy equals q.EmployeeMasterID
                                 join r in db.CPT_AccountMaster on p.AccountID equals r.AccountMasterID
                                 join s in db.CPT_CityMaster on p.CityID equals s.CityID
                                 where p.RequestID == RequestID
                                 select new { q.Email, q.EmployeetName, r.AccountName, s.CityName, p.ProcessName }).ToList();


                    string project = query[0].AccountName + "-" + query[0].CityName;
                    details.Add(query[0].Email);
                    details.Add(query[0].EmployeetName);
                    details.Add(project);
                    details.Add(query[0].ProcessName);

                }
            }

            catch (Exception w)
            {
                Console.WriteLine(w.Message);
            }

            return details;
        }

    }
}
