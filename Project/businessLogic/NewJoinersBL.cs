﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Web.UI.WebControls;

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
                        detail.Name = newJoinersDetails.Name;
                        
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

        

        public List<CPT_NewJoiners> getNewJoiners()
        {

            List<CPT_NewJoiners> lstNewJoiners = new List<CPT_NewJoiners>();
            using (CPContext db = new CPContext())
            {
                var query = (from p in db.CPT_NewJoiners
                             join q in db.CPT_AccountMaster on p.Account equals q.AccountMasterID
                             join r in db.CPT_DesignationMaster on p.DesignationID equals r.DesignationMasterID
                             join s in db.CPT_SkillsMaster on  p.Skills equals s.SkillsMasterID
                             where p.HasJoined == false
                             select new
                             {
                                 p.NewJoinerID,
                                 p.Name,
                                 p.Location,
                               
                                 p.JoiningDate,
                                 p.Experience,
                                 p.InterviewedBy,
                                 p.Skills,
                                 q.AccountName,
                                 r.DesignationName,
                                 p.Account,
                                 p.DesignationID,
                                 s.SkillsName
                             }).ToList();

                foreach (var item in query)
                {
                    CPT_NewJoiners clsNewJoiners = new CPT_NewJoiners();
                    clsNewJoiners.NewJoinerID = item.NewJoinerID;
                    clsNewJoiners.Name = item.Name;
                    clsNewJoiners.Location = item.Location;
                    clsNewJoiners.Skills = item.Skills;
                    clsNewJoiners.InterviewedBy = item.InterviewedBy;
                    clsNewJoiners.Experience = item.Experience;
                    clsNewJoiners.JoiningDate = item.JoiningDate;

                    CPT_AccountMaster account = new CPT_AccountMaster();
                    account.AccountName = item.AccountName;
                    clsNewJoiners.CPT_AccountMaster = account;

                    CPT_DesignationMaster designation = new CPT_DesignationMaster();
                    designation.DesignationName = item.DesignationName;
                    clsNewJoiners.CPT_DesignationMaster = designation;

                    CPT_SkillsMaster skillsMaster = new CPT_SkillsMaster();
                    skillsMaster.SkillsName = item.SkillsName;
                    clsNewJoiners.CPT_SkillsMaster = skillsMaster;
                    lstNewJoiners.Add(clsNewJoiners);
                }
                return lstNewJoiners;

            }

        }

        public void changeHasJoinedValue(int newJoinersDetails)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var qurey = from p in db.CPT_NewJoiners
                                where p.NewJoinerID == newJoinersDetails
                                select p;
                    foreach(var detail in qurey)
                    {
                        detail.HasJoined = true;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        public string getdesignationByID(int ID)
        {
            String dsnName = "";
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_DesignationMaster
                            where c.DesignationMasterID == ID
                            select new
                            {
                                c.DesignationName
                            }
                                ;
                foreach (var ac in query)
                {
                    dsnName = ac.DesignationName;
                }
            }
            return dsnName;
        }



        public string getManagerByID(int ID)
        {
            String mgrName = "";
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == ID
                            select new
                            {
                                c.EmployeetName
                            }
                                ;
                foreach (var ac in query)
                {
                    mgrName = ac.EmployeetName;
                }
            }
            return mgrName;
        }

        public int checkDuplicateID(int id)
        {
            int flag = 0;
            using(CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == id
                            select c;
                if(query.Count() > 0)
                {
                    flag = 1;
                }

                return flag;
            }
        }

    }
}
