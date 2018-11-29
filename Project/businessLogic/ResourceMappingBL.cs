using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entity;

namespace businessLogic
{
    public class ResourceMappingBL
    {
        public static void ResourceMapping(Repeater rpt)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {
                    var query1 = (from p in db.CPT_ResourceDemand
                                  join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID
                                  join ct in db.CPT_CityMaster on p.CityID equals ct.CityID
                                  join c in db.CPT_CountryMaster on ct.CountryID equals c.CountryMasterID
                                  join t in db.CPT_OpportunityMaster on p.OpportunityID equals t.OpportunityID
                                  join u in db.CPT_SalesStageMaster on p.SalesStageID equals u.SalesStageMasterID
                                  join z in db.CPT_PriorityMaster on p.PriorityID equals z.PriorityID
                                  join v in db.CPT_StatusMaster on p.StatusMasterID equals v.StatusMasterID
                                  join w in db.CPT_ResourceMaster on p.ResourceRequestBy equals w.EmployeeMasterID
                                  where v.StatusMasterID == 26
                                  orderby p.DateOfCreation descending

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
                                      p.DateOfCreation,
                                      z.PriorityName,
                                      w.EmployeetName

                                  }).ToList();

                    rpt.DataSource = query1;
                    rpt.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public static void ResourceMappingRoleWise(Repeater rpt,int roleID)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {
                    var query1 = (from p in db.CPT_ResourceDemand
                                  join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID
                                  join r in db.CPT_ResourceDetails on p.RequestID equals r.RequestID
                                  join ct in db.CPT_CityMaster on p.CityID equals ct.CityID
                                  join t in db.CPT_OpportunityMaster on p.OpportunityID equals t.OpportunityID
                                  join w in db.CPT_ResourceMaster on p.ResourceRequestBy equals w.EmployeeMasterID
                                  where p.StatusMasterID == 26 && r.ResourceTypeID == roleID
                                  orderby p.DateOfCreation descending

                                  select new
                                  {
                                      p.RequestID,
                                      q.AccountName,
                                      ct.CityName,
                                      t.OpportunityType,
                                      p.ProcessName,
                                      p.DateOfCreation,
                                      w.EmployeetName

                                  }).ToList();

                    rpt.DataSource = query1;
                    rpt.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
