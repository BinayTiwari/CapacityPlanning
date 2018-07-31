using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace businessLogic
{
    public class DesignationMasterBL
    {
        public int Insert(CPT_DesignationMaster designationDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_DesignationMaster
                             where c.DesignationName == designationDetails.DesignationName & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_DesignationMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_DesignationMaster.Add(designationDetails);
                }

                db.SaveChanges();
            }
            return 1;
        }

        public int Update(CPT_DesignationMaster DesignationDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_DesignationMaster
                            where details.DesignationMasterID == DesignationDetails.DesignationMasterID
                            select details;

                foreach (CPT_DesignationMaster detail in query)
                {
                    detail.DesignationName = DesignationDetails.DesignationName;
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

        public int Delete(CPT_DesignationMaster DesignationDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    CPT_DesignationMaster DesignationMaster = new CPT_DesignationMaster();
                    var deleteDesignationDetails = from details in db.CPT_DesignationMaster
                                             where details.DesignationMasterID == DesignationDetails.DesignationMasterID
                                             select details;

                    foreach (var detail in deleteDesignationDetails)
                    {
                        // db.CPT_DesignationMaster.Remove(detail);
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
        public List<CPT_DesignationMaster> getDesignation()
        {

            List<CPT_DesignationMaster> lstDesignationName = new List<CPT_DesignationMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_DesignationMaster.ToList();
                var query = (from p in db.CPT_DesignationMaster
                             orderby p.DesignationMasterID descending
                             where p.IsActive == true
                             select new
                             {
                                 p.DesignationMasterID,
                                 p.DesignationName,

                             }).ToList();

                foreach (var item in query)
                {
                    CPT_DesignationMaster clsDesignation = new CPT_DesignationMaster();
                    clsDesignation.DesignationMasterID = item.DesignationMasterID;
                    clsDesignation.DesignationName = item.DesignationName;





                    lstDesignationName.Add(clsDesignation);
                }


                return lstDesignationName;

            }

        }
    }
}
