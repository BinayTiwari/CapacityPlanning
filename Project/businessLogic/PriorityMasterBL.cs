using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using businessLogic;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class PriorityMasterBL
    {
        public static void FetchGrid(GridView GV)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    GV.DataSource = (from c in db.CPT_PriorityMaster
                                            where c.IsActive == true
                                            select c).ToList();
                    //GridView1.DataSource = db.CPT_PriorityMaster.ToList();
                    GV.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
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

    }
}
