using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class DeployResourcesBL
    {
        public static void Bind(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query1 = (from p in db.CPT_ResourceDemand
                                  join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID                                  
                                  join ct in db.CPT_CityMaster on p.CityID equals ct.CityID
                                  join x in db.CPT_ResourceMaster on p.ResourceRequestBy equals x.EmployeeMasterID
                                  join r in db.CPT_AllocateResource on p.RequestID equals r.RequestID
                                  join s in db.CPT_ResourceMaster on r.ResourceID equals s.EmployeeMasterID
                                  orderby p.DateOfCreation descending
                                  
                                  where p.StatusMasterID == 20 && r.IsDeployed == false
                                  select new
                                  {
                                      p.RequestID,
                                      p.DateOfCreation,
                                      q.AccountName,                                    
                                      ct.CityName,
                                      p.ProcessName,
                                      ResourceRequestBy = x.EmployeetName,
                                      Name = s.EmployeetName,
                                      ResourceID = s.EmployeeMasterID
                                       
                                  }).ToList();

                    rpt.DataSource = query1;
                    rpt.DataBind();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeployStatus(int resourceID, string requestID)
        {
            try
            {
                
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_AllocateResource
                                where p.ResourceID == resourceID
                                select p);

                    foreach(CPT_AllocateResource item in query)
                    {
                        item.IsDeployed = true;
                    }                    
                    db.SaveChanges();
                }

                using(CPContext db = new CPContext())
                {
                    var query = from p in db.CPT_AllocateResource
                                where p.RequestID == requestID && p.IsDeployed == true
                                select p;

                    var query1 = from p in db.CPT_AllocateResource
                                where p.RequestID == requestID
                                select p;
                    
                    if(query.Count() == query1.Count())
                    {
                        var query2 = from q in db.CPT_ResourceDemand
                                     where q.RequestID == requestID
                                     select q;

                        foreach(CPT_ResourceDemand detail in query2)
                        {
                            detail.StatusMasterID = 32;
                        }
                        db.SaveChanges();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
