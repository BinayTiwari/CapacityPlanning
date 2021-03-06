﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace businessLogic
{
   public class ReleaseResourcesBL
    {
        public static void BindRepeater(Repeater rpt, int id)
        {
            try
            {
                
                using (CPContext db = new CPContext())
                {
                    if(id == 10161 || id == 10399)
                    {
                        var query = (from c in db.CPT_ResourceMaster
                                     join d in db.CPT_AllocateResource on c.EmployeeMasterID equals d.ResourceID
                                     join e in db.CPT_ResourceDemand on d.RequestID equals e.RequestID
                                     join f in db.CPT_AccountMaster on d.AccountID equals f.AccountMasterID
                                     where d.Released == false && d.IsDeployed == true
                                     select new
                                     {
                                         d.AllocationID,
                                         c.EmployeeMasterID,
                                         c.EmployeetName,
                                         f.AccountName,
                                         e.ProcessName,
                                         d.StartDate,
                                         d.EndDate
                                     }).ToList();
                        rpt.DataSource = query;
                        rpt.DataBind();
                    }
                    else
                    {
                        var query = (from c in db.CPT_ResourceMaster
                                     join d in db.CPT_AllocateResource on c.EmployeeMasterID equals d.ResourceID
                                     join e in db.CPT_ResourceDemand on d.RequestID equals e.RequestID
                                     join f in db.CPT_AccountMaster on d.AccountID equals f.AccountMasterID
                                     where d.Released == false && d.IsDeployed == true && e.ResourceRequestBy == id
                                     select new
                                     {
                                         d.AllocationID,
                                         c.EmployeeMasterID,
                                         c.EmployeetName,
                                         f.AccountName,
                                         e.ProcessName,
                                         d.StartDate,
                                         d.EndDate
                                     }).ToList();
                        rpt.DataSource = query;
                        rpt.DataBind();
                    }
                    

                    
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void setReleasedStatus(int id)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from c in db.CPT_AllocateResource
                                 where c.AllocationID == id
                                 select c).ToList();
                    foreach(var detail in query)
                    {
                        detail.Released = true;
                        detail.EndDate = DateTime.Now;
                        detail.IsDeployed = false;
                    }
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string getEmailIdByEmpID(int id)
        { string mail = "";
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from c in db.CPT_ResourceMaster
                                 where c.EmployeeMasterID == id
                                 select c.Email).ToList();
                    mail = query[0];
                }

            }
            catch (Exception)
            {

                throw;
            }
            return mail;
        }

        public static string getNameByEmpID(int id)
        {
            string name = "";
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from c in db.CPT_ResourceMaster
                                 where c.EmployeeMasterID == id
                                 select c.EmployeetName).ToList();
                    name = query[0];
                }

            }
            catch (Exception)
            {

                throw;
            }
            return name;
        }
    }
}
