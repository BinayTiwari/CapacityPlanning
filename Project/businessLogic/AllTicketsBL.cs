using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
   public class AllTicketsBL
    {

        public static void Bind(Repeater rpt)
        {
            try
            {
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
                                      r.PriorityID,
                                      r.PriorityName,
                                      

                                  }).ToList();

                    foreach (var item in query1)
                    {
                       
                    }

                    rpt.DataSource = query1;
                    rpt.DataBind();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
