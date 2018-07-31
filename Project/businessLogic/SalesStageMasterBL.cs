using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogic
{
    public class SalesStageMasterBL
    {
        public int Insert(CPT_SalesStageMaster salesStageDetails)
        {
            using (CPContext db = new CPContext())
            {

                var query = (from c in db.CPT_SalesStageMaster
                             where c.SalesStageName == salesStageDetails.SalesStageName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_SalesStageMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_SalesStageMaster.Add(salesStageDetails);
                }

                db.SaveChanges();
            }
            return 1;
        }

        public int Update(CPT_SalesStageMaster SalesStageDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = from details in db.CPT_SalesStageMaster
                                where details.SalesStageMasterID == SalesStageDetails.SalesStageMasterID
                                select details;

                    foreach (CPT_SalesStageMaster detail in query)
                    {
                        detail.SalesStageName = SalesStageDetails.SalesStageName;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return 1;
        }

        public int Delete(CPT_SalesStageMaster SalesStageDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_SalesStageMaster SalesStageMaster = new CPT_SalesStageMaster();
                    var deleteSalesStageDetails = from details in db.CPT_SalesStageMaster
                                            where details.SalesStageMasterID == SalesStageDetails.SalesStageMasterID
                                            select details;

                    foreach (var detail in deleteSalesStageDetails)
                    {
                        //db.CPT_SalesStageMaster.Remove(detail);
                        detail.IsActive = false;
                    }
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            return 1;
        }
        public List<CPT_SalesStageMaster> getSalesStage()
        {

            List<CPT_SalesStageMaster> lstSalesStage = new List<CPT_SalesStageMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_CountryMaster.ToList();
                var query = (from c in db.CPT_SalesStageMaster
                             orderby c.SalesStageMasterID descending
                             where c.IsActive == true
                             select new
                             {
                                 c.SalesStageMasterID,
                                 c.SalesStageName
                             }).ToList();

                foreach (var item in query)
                {
                    CPT_SalesStageMaster SalesStage = new CPT_SalesStageMaster();

                    SalesStage.SalesStageMasterID = item.SalesStageMasterID;
                    SalesStage.SalesStageName = item.SalesStageName;


                    lstSalesStage.Add(SalesStage);
                }


                return lstSalesStage;

            }

        }
    }
}
