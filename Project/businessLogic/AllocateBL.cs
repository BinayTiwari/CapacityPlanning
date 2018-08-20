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
        public static int getResourceDemand(Repeater repeater)
        {
            int priorityID = 0;
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
                                  r.PriorityID

                              }).ToList();
                

                repeater.DataSource = query1;
                repeater.DataBind();
                foreach(var item in query1)
                {
                    priorityID = item.PriorityID;
                }
            }
            return priorityID;
        }
        
        public static void ddlGetPriority(DropDownList ddlPriorities)
        {
            using (CPContext db = new CPContext())
            {
              var Priority =
               (from t in db.CPT_PriorityMaster where t.IsActive == true select t).ToList();
                    ddlPriorities.DataSource = Priority;
                    ddlPriorities.DataTextField = "PriorityName";
                    ddlPriorities.DataValueField = "PriorityName";
                    ddlPriorities.DataBind();
                }
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
                        detail.PriorityID = details.PriorityID;

                    }


                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }
                    return 1;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
        public int SelectID(string PriorityName)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                   var query =
                       (from p in db.CPT_PriorityMaster
                        where p.PriorityName == PriorityName
                        select p.PriorityID).ToList();
                    int val = query[0];
                    return val;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 1;
            }
            }
        
    }
}
