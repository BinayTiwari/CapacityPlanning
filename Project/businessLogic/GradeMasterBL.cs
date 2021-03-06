﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace businessLogic
{
    public class GradeMasterBL
    {

        public int Insert(CPT_GradeMaster gradeDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_GradeMaster
                             where c.Grade == gradeDetails.Grade & c.IsActive == false
                             select c).ToList();
                if (query.Count() > 0)
                {
                    foreach (CPT_GradeMaster detail in query)
                    {
                        detail.IsActive = true;
                    }
                }
                else
                {
                    db.CPT_GradeMaster.Add(gradeDetails);
                }

                db.SaveChanges();
            }
            return 1;


        }

        public int Update(CPT_GradeMaster gradeDetails)
        {
            using (CPContext db = new CPContext())
            {
                var query = from details in db.CPT_GradeMaster
                            where details.GradeID == gradeDetails.GradeID
                            select details;

                foreach (CPT_GradeMaster detail in query)
                {
                    detail.Grade = gradeDetails.Grade;
                   
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

        public int Delete(CPT_GradeMaster gradeDetails)
        {
            using (CPContext db = new CPContext())
            {

                try
                {

                    CPT_GradeMaster gradeMaster = new CPT_GradeMaster();
                    var deleteGradeDetails = from details in db.CPT_GradeMaster
                                               where details.GradeID == gradeDetails.GradeID
                                               select details;

                    foreach (var detail in deleteGradeDetails)
                    {
                        db.CPT_GradeMaster.Remove(detail);
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

        public List<CPT_GradeMaster> getGrade()
        {

            List<CPT_GradeMaster> lstGradeName = new List<CPT_GradeMaster>();
            using (CPContext db = new CPContext())
            {
                //GridView1.DataSource = db.CPT_GradeMaster.ToList();
                var query = (from p in db.CPT_GradeMaster
                             orderby p.GradeID descending
                             where p.IsActive == true
                             select new
                             {
                                 p.GradeID,
                                 p.Grade,

                             }).ToList();

                foreach (var item in query)
                {
                    CPT_GradeMaster clsGrade = new CPT_GradeMaster();
                    clsGrade.GradeID = item.GradeID;
                    clsGrade.Grade = item.Grade;





                    lstGradeName.Add(clsGrade);
                }


                return lstGradeName;

            }
        }       }
}
