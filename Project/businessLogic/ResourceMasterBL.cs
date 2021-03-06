﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entity;
using System.Data.SqlClient;
using System.Configuration;


namespace businessLogic
{
    public class ResourceMasterBL
    {
       
        public int Insert( CPT_ResourceMaster resourcedetails)
        {


            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_ResourceMaster.Add(resourcedetails);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
               
            }
            return 1;


        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;


        }
        public  static  void Delete(CPT_ResourceMaster resourceDetails)
        {

            try
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " Update CPT_ResourceMaster SET ISDELETED =1  where EmployeeMasterID = "+resourceDetails.EmployeeMasterID;


                    using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    SqlCom.ExecuteNonQuery();

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);

            }



            }
        
       

        public int Update(CPT_ResourceMaster resourceDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = from details in db.CPT_ResourceMaster
                                where details.EmployeeMasterID == resourceDetails.EmployeeMasterID
                                select details;


                    foreach (CPT_ResourceMaster detail in query)
                    {
                        detail.EmployeeMasterID = resourceDetails.EmployeeMasterID;
                        detail.EmployeetName = resourceDetails.EmployeetName;
                       // detail.EmployeePassword = resourceDetails.EmployeePassword;
                        detail.ReportingManagerID = resourceDetails.ReportingManagerID;
                        detail.Email = resourceDetails.Email;
                        detail.BaseLocation = resourceDetails.BaseLocation;
                        detail.Mobile = resourceDetails.Mobile;
                        detail.DesignationID = resourceDetails.DesignationID;
                        detail.RolesID = resourceDetails.RolesID;
                        detail.JoiningDate = resourceDetails.JoiningDate;
                        detail.PriorWorkExperience = resourceDetails.PriorWorkExperience;
                        detail.Address = resourceDetails.Address;
                        detail.PAN = resourceDetails.PAN;
                        detail.Skillsid = resourceDetails.Skillsid;
                        detail.PassportNo = resourceDetails.PassportNo;
                        detail.PassportExpiryDate = resourceDetails.PassportExpiryDate;
                        detail.VisaExpiryDate = resourceDetails.VisaExpiryDate;
                        detail.DateOfModification = DateTime.Now;
                        detail.ModifiedBy = resourceDetails.ModifiedBy;

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

        public List<CPT_ResourceMaster> uiDataBinding(CPT_ResourceMaster resourceMaster)
        {
            List<CPT_ResourceMaster> data = new List<CPT_ResourceMaster>();
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == resourceMaster.EmployeeMasterID
                            select c;
                foreach(var detail in query)
                {
                    
                    data.Add(detail);
                }
            }
            return data;
        }

       public List<CPT_AllocateResource> assignmentCurrentBinding( CPT_ResourceMaster resource)
        {
            List<CPT_AllocateResource> data = new List<CPT_AllocateResource>();
            using(CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_AllocateResource

                             where c.ResourceID == resource.EmployeeMasterID && c.IsDeployed == true
                             select c);
                foreach(var detail in query)
                {
                    data.Add(detail);
                }
            }

            return data;
        }

        public List<CPT_AllocateResource> assignmentNextBinding(CPT_ResourceMaster resource)
        {
            List<CPT_AllocateResource> data = new List<CPT_AllocateResource>();
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_AllocateResource

                             where c.ResourceID == resource.EmployeeMasterID && c.IsDeployed == false && c.Released == false
                             select c);
                foreach (var detail in query)
                {
                    data.Add(detail);
                }
            }

            return data;
        }

        public string getAccountByID(int accountID)
        {
            String accountName = "";
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_AccountMaster
                            where c.AccountMasterID == accountID
                            select new
                            {
                                c.AccountName
                            }
                                ;
                foreach(var ac in query)
                {
                    accountName = ac.AccountName;
                }
            }
            return accountName;
        }

        //public void BindresRepeater(Repeater rptResourceMaster)
        //{
        //    using (CPContext db = new CPContext())
        //    {
        //        var query = (from p in db.CPT_ResourceMaster
        //                     join q in db.CPT_ResourceMaster on p.EmployeeMasterID equals q.ReportingManagerID
        //                     join r in db.CPT_RoleMaster on q.RolesID equals r.RoleMasterID
        //                     let mgrName = p.EmployeetName
        //                     where (p = p.RolesID exceptionList.Contains p.RolesID WHERE CPT_ResourceMaster.RolesID NOT IN(1, 4, 8, 15, 16)

        //                     select new

        //                     {
        //                         q.EmployeeMasterID,
        //                         q.EmployeetName,
        //                         q.ReportingManagerID,
        //                         q.BaseLocation,
        //                         q.Mobile,
        //                         mgrName,
        //                         r.RoleName



        //                     }).OrderBy(p => p.EmployeetName).ToList();
        //        rptResourceMaster.DataSource = query;
        //        rptResourceMaster.DataBind();
        //    }

        //}

  
    public static void displayTotalStrength(Repeater rpt)
    {

        try
        {
               

                   SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName, CPT_ResourceMaster.BaseLocation, CPT_ResourceMaster.Mobile, " +
                                    " CPT_ResourceMaster.JoiningDate, CPT_RoleMaster.RoleName, CPT_DesignationMaster.DesignationName FROM            CPT_ResourceMaster INNER JOIN " +
                                    " CPT_RoleMaster ON CPT_ResourceMaster.RolesID = CPT_RoleMaster.RoleMasterID INNER JOIN " +
                                    " CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID " +
                                    " WHERE(CPT_ResourceMaster.RolesID NOT IN(1,4,5,8,15,26)) AND ISDELETED =0 " +
                                    " ORDER BY CPT_ResourceMaster.EmployeetName";
                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                SqlConn.Open();
                rpt.DataSource = SqlCom.ExecuteReader();
                rpt.DataBind();
                //  t = reader["Total"].ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void updatePassword(CPT_ResourceMaster record)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = (from p in db.CPT_ResourceMaster
                                 where p.EmployeeMasterID == record.EmployeeMasterID
                                 select p).ToList();

                    foreach (CPT_ResourceMaster item in query)
                    {
                        item.EmployeePassword = record.EmployeePassword;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public int checkDuplicateID(int id)
        {
            int flag = 0;
            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == id
                            select c;
                if (query.Count() > 0)
                {
                    flag = 1;
                }

                return flag;
            }
        }

    }

}
