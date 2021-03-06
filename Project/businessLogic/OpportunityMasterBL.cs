﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace businessLogic
{
    public class OpportunityMasterBL
    {
        public int Insert(CPT_OpportunityMaster opportunityDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_OpportunityMaster
                             where c.OpportunityType == opportunityDetails.OpportunityType & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_OpportunityMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_OpportunityMaster.Add(opportunityDetails);
                }

                db.SaveChanges();
            }
            return 1;


        }

        public int Update(CPT_OpportunityMaster opportunityDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_OpportunityMaster
                            where details.OpportunityID == opportunityDetails.OpportunityID
                            select details;

                
                foreach (CPT_OpportunityMaster detail in query)
                {
                    detail.OpportunityType = opportunityDetails.OpportunityType;
                   
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

        public int Delete(CPT_OpportunityMaster opportunityDetails)
        {
            using (CPContext db = new CPContext())
            {

                try
                {

                    CPT_OpportunityMaster opportunityMaster = new CPT_OpportunityMaster();
                    var deleteOpportunityDetails = from details in db.CPT_OpportunityMaster
                                               where details.OpportunityID == opportunityDetails.OpportunityID
                                               select details;

                    foreach (var detail in deleteOpportunityDetails)
                    {
                        //db.CPT_OpportunityMaster.Remove(detail);
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

        public List<CPT_OpportunityMaster> getOpportunity()
        {

            List<CPT_OpportunityMaster> lstOpportunityName = new List<CPT_OpportunityMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_OpportunityMaster.ToList();
                var query = (from p in db.CPT_OpportunityMaster
                             orderby p.OpportunityID descending
                             where p.IsActive == true
                             select new
                             {
                                 p.OpportunityID,
                                 p.OpportunityType,

                             }).ToList();

                foreach (var item in query)
                {
                    CPT_OpportunityMaster clsOpportunity = new CPT_OpportunityMaster();
                    clsOpportunity.OpportunityID = item.OpportunityID;
                    clsOpportunity.OpportunityType = item.OpportunityType;





                    lstOpportunityName.Add(clsOpportunity);
                }


                return lstOpportunityName;

            }

        }

    }
}
