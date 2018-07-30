using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace businessLogic
{
    public class NewJoinersBL
    {
        public int Insert(CPT_NewJoiners newJoiners)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    db.CPT_NewJoiners.Add(newJoiners);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           
            return 1;
        }

        public int Update(CPT_NewJoiners newJoinersDetails)
        {
            try
            {
                using(CPContext db = new CPContext())
                {
                    CPT_NewJoiners newJoiners = new CPT_NewJoiners();
                    var query = from c in db.CPT_NewJoiners
                                where c.NewJoinerID == newJoinersDetails.NewJoinerID
                                select c;
                    foreach(var detail in query)
                    {
                        detail.FirstName = newJoinersDetails.FirstName;
                        detail.LastName = newJoinersDetails.LastName;
                        detail.Location = newJoinersDetails.Location;
                        detail.JoiningDate = newJoinersDetails.JoiningDate;
                        detail.Experience = newJoinersDetails.Experience;
                        detail.DesignationID = newJoinersDetails.DesignationID;
                        detail.InterviewedBy = newJoinersDetails.InterviewedBy;
                        detail.Account = newJoinersDetails.Account;
                        detail.Skills = newJoinersDetails.Skills;

                    }
                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return 1;
        }

        public int Delete(CPT_NewJoiners newJoinersDetail)
        {

                using(CPContext db = new CPContext())
                {

                try
                {
                    CPT_NewJoiners newJoiners = new CPT_NewJoiners();
                    var query = from c in db.CPT_NewJoiners
                                where c.NewJoinerID == newJoinersDetail.NewJoinerID
                                select c;
                    foreach (var detail in query)
                    {
                        db.CPT_NewJoiners.Remove(detail);
                        
                    }
                    db.SaveChanges();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                    
                }
                
           
            return 1;
        }

        public List<CPT_NewJoiners> uiDataBinding(CPT_NewJoiners newJoiners)
        {
            List<CPT_NewJoiners> data = new List<CPT_NewJoiners>();
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_NewJoiners
                            where c.NewJoinerID == newJoiners.NewJoinerID
                            select c;
                foreach (var detail in query)
                {

                    data.Add(detail);
                }
              
            }
            return data;
        }
    }
}
