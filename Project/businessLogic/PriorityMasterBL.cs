using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using businessLogic;

namespace businessLogic
{
    public class PriorityMasterBL
    {
         public int Insert(CPT_PriorityMaster priorityDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_PriorityMaster
                             where c.PriorityName == priorityDetails.PriorityName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_PriorityMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_PriorityMaster.Add(priorityDetails);
                }

                db.SaveChanges();
            }
            return 1;


        }

        public int Update(CPT_PriorityMaster priorityDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_PriorityMaster
                            where details.PriorityID == priorityDetails.PriorityID
                            select details;

               
                foreach (CPT_PriorityMaster detail in query)
                {
                    detail.PriorityName = priorityDetails.PriorityName;
                  
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

        public int Delete(CPT_PriorityMaster priorityDetails)
        {
            using (CPContext db = new CPContext())
            {

                try
                {

                    CPT_PriorityMaster priorityMaster = new CPT_PriorityMaster();
                    var deletePriorityDetails = from details in db.CPT_PriorityMaster
                                               where details.PriorityID == priorityDetails.PriorityID
                                               select details;

                    foreach (var detail in deletePriorityDetails)
                    {
                        //db.CPT_PriorityMaster.Remove(detail);
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
        public List<CPT_PriorityMaster> getPriority()
        {

            List<CPT_PriorityMaster> lstPriorityName = new List<CPT_PriorityMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_CountryMaster.ToList();
                var query = (from c in db.CPT_PriorityMaster
                             orderby c.PriorityID descending
                             where c.IsActive == true
                             select new
                             {
                                 c.PriorityID,
                                 c.PriorityName
                             }).ToList();

                foreach (var item in query)
                {
                    CPT_PriorityMaster region = new CPT_PriorityMaster();

                    region.PriorityName = item.PriorityName;
                    region.PriorityID = item.PriorityID;


                    lstPriorityName.Add(region);
                }


                return lstPriorityName;

            }

        }
    }
}
