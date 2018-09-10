using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace businessLogic
{
    public class AllocateResourceBL
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;


        }
        public static int GetRequestDetailID(string RequestID, int SkillID)
        {
            int RequestDetailID = 0;
            try
            {
                using(CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceDetails
                                where p.RequestID == RequestID && p.SkillID == SkillID.ToString()
                                select p.RequestDetailID).ToList();

                    RequestDetailID = query[0];
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RequestDetailID;
        }

        public int Insert(CPT_AllocateResource allocateDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_AllocateResource.Add(allocateDetails);
                    db.SaveChanges();
                    UpdateStatus(allocateDetails.RequestID);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return 1;
        }
        public int updateMap(CPT_ResourceMaster employeeID)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = (from p in db.CPT_ResourceMaster
                                 where p.EmployeeMasterID == employeeID.EmployeeMasterID
                                 select p);
                    foreach (var item in query)
                    {
                        item.isMapped = 1;
                    }
                    db.SaveChanges();
                }
                catch (Exception exe)
                {
                    Console.WriteLine(exe.Message);
                }
            }
            return 1;
        }
        public void getFreeEmployee(Repeater rpt, int RoleID, DateTime StartDate, string SkillID, DateTime EndDate)
        {
            try
            {
                string dtS = String.Format("{0:yyyy-MM-dd}", StartDate);
                string dtE = String.Format("{0:yyyy-MM-dd}", EndDate);
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "SELECT CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName,CPT_AccountMaster.AccountName,CPT_ResourceMaster.RolesID,CPT_AllocateResource.ResourceID,CPT_ResourceDemand.ResourceRequestBy,CPT_ResourceDemand.ProcessName,dbo.Owner(CPT_ResourceDemand.ResourceRequestBy) as Owner, CPT_AllocateResource.EndDate"+
                                    " FROM CPT_AllocateResource RIGHT OUTER JOIN CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN"+
                                    " CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID LEFT OUTER JOIN CPT_AccountMaster ON CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID"+
                                    " Where(CPT_ResourceMaster.RolesID = "+ RoleID + "   and '"+ SkillID + "' in (Select CPT_ResourceMaster.Skillsid FROM CPT_ResourceMaster WHERE EmployeeMasterID = EmployeeMasterID) AND CPT_ResourceMaster.EmployeeMasterID NOT"+
                                    " IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource WHERE"+
                    " (CPT_AllocateResource.EndDate >= '"+ dtS + "') AND  ISDELETED = 0) OR CPT_ResourceMaster.EmployeeMasterID = 10161 )";

                //string SqlString = "SELECT  CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName, CPT_ResourceMaster.RolesID,CPT_AllocateResource.ResourceID" +
                //    " FROM CPT_AllocateResource RIGHT OUTER JOIN CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID" +
                //     " Where CPT_ResourceMaster.RolesID = "+ RoleID + "  and CPT_ResourceMaster.Skillsid = "+ SkillID + " AND CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource WHERE " +
                //    " (CPT_AllocateResource.StartDate <= '" + dtS + "')" + " OR (CPT_AllocateResource.EndDate >= '" + dtE + "'))";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    SqlDataReader reader = SqlCom.ExecuteReader();
                    rpt.DataSource = reader;
                    rpt.DataBind();
                }
                //using (CPContext db = new CPContext())
                //{

                //    //var query1 = (from p in db.CPT_ResourceMaster
                //    //              join q in db.CPT_AllocateResource on p.EmployeeMasterID equals q.ResourceID
                //    //              into t
                //    //              from rt in t.DefaultIfEmpty()
                //    //              where (p.RolesID == RoleID && p.Skillsid == SkillID)
                //    //              select new
                //    //              {
                //    //                  p.EmployeetName,
                //    //                  p.EmployeeMasterID
                //    //              }).ToList();
                //    //var query2 = (from p in db.CPT_ResourceMaster
                //    //              join q in db.CPT_AllocateResource on p.EmployeeMasterID equals q.ResourceID
                //    //              into t
                //    //              from rt in t.DefaultIfEmpty()
                //    //              where (p.RolesID == RoleID && rt.StartDate <= StartDate)
                //    //              select new
                //    //              {
                //    //                  p.EmployeetName,
                //    //                  p.EmployeeMasterID
                //    //              }).ToList();
                //    //var query = query1.Except(query2).ToList();
                //    //rpt.DataSource = query;
                //    //rpt.DataBind();
                //}
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        //public static void getEmployeeNameByResourceType(Repeater repeater, int RoleID)
        //{
        //    try
        //    {
        //        using (CPContext db = new CPContext())
        //        {
        //            var query = (from p in db.CPT_ResourceMaster
        //                         join q in db.CPT_AllocateResource on p.EmployeeMasterID equals q.ResourceID 
        //                         into t from rt in t.DefaultIfEmpty()
        //                         where (p.RolesID == RoleID && p.isMapped == 0)
        //                         select new
        //                         {
        //                             p.EmployeetName,
        //                         }).ToList();
        //            repeater.DataSource = query;
        //            repeater.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        public static List<int> ResourceID(List<string> name)
        {
            using (CPContext db = new CPContext())
            {
                List<int> query = new List<int>();

                List<int> lst = new List<int>();
                foreach (var item in name)
                {
                    query = (from p in db.CPT_ResourceMaster
                             where (p.EmployeetName == item)
                             select p.EmployeeMasterID).ToList();
                    foreach (var it in query)
                    {
                        lst.Add(it);
                    }

                }
                return lst;
            }
        }
        public static int getAccountID(string requestID)
        {
            using (CPContext db = new CPContext())
            {
                List<int> lst = new List<int>();
                var query = (from p in db.CPT_ResourceDemand
                             where (p.RequestID == requestID)
                             select p.AccountID
                             ).ToList();
                foreach (var item in query)
                {
                    lst.Add(item);
                }
                return lst[0];
            }
        }
        public static void AllocateResource(Repeater rpt)
        {
            try
            {
                //clear here
                using (CPContext db = new CPContext())
                {

                    var query =
                (from p in db.CPT_ResourceDetails
                 join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                 join r in db.CPT_SkillsMaster on p.SkillID equals r.SkillsMasterID.ToString()
                 select new
                 {
                     p.RequestID,
                     q.RoleName,
                     r.SkillsName,
                     p.NoOfResources,
                     p.StartDate,
                     p.EndDate
                 }).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public void AllocateResourceByID(Repeater rpt, string reqID)
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT CPT_ResourceDetails.RequestDetailID,CPT_ResourceDetails.ResourceTypeID, CPT_ResourceDetails.RequestID, CPT_RoleMaster.RoleName," +
                                  " CPT_SkillsMaster.SkillsName, CPT_ResourceDetails.NoOfResources,dbo.TotalResurcesAllocated(CPT_RoleMaster.RoleMasterID,CPT_ResourceDetails.RequestDetailID) As Allocated, CPT_ResourceDetails.StartDate, CPT_ResourceDetails.EndDate, CPT_RoleMaster.RoleMasterID " +
                                  " FROM CPT_SkillsMaster INNER JOIN CPT_ResourceDetails INNER JOIN CPT_RoleMaster ON CPT_ResourceDetails.ResourceTypeID = CPT_RoleMaster.RoleMasterID ON " +
                                  "  CPT_SkillsMaster.SkillsMasterID = CPT_ResourceDetails.SkillID WHERE CPT_ResourceDetails.RequestID = " + reqID + "";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    SqlDataReader reader = SqlCom.ExecuteReader();
                    rpt.DataSource = reader;
                    rpt.DataBind();
                }
              

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public List<CPT_ResourceMaster> getMailDetails(int id)
        {
            List<CPT_ResourceMaster> data = new List<CPT_ResourceMaster>();

            using (CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == id
                            select c;
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
                foreach (var ac in query)
                {
                    accountName = ac.AccountName;
                }
            }
            return accountName;
        }
        public void UpdateStatus(string reqID)
        {
            int status = 0;
            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT [dbo].[IsAllResourcesAreMapped](" + reqID + ") AS IsMapped ";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    status = Convert.ToInt32(SqlCom.ExecuteScalar());

                }

                if (status == 1)
                {
                    using (CPContext db = new CPContext())
                    {
                        var query = (from p in db.CPT_ResourceDemand
                                     where p.RequestID == reqID
                                     select p).ToList();
                        foreach (var item in query)
                        {
                            item.StatusMasterID = 20;
                        }
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static void viewResourceMaping(Repeater rpt, String requestID)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_AllocateResource
                             join d in db.CPT_ResourceMaster on c.ResourceID equals d.EmployeeMasterID
                             join e in db.CPT_RoleMaster on d.RolesID equals e.RoleMasterID
                             join f in db.CPT_ResourceDetails on c.RequestDetailID equals f.RequestDetailID
                             join g in db.CPT_SkillsMaster on f.SkillID equals g.SkillsMasterID.ToString()
                             where c.RequestID == requestID
                             select new
                             {
                                 c.ResourceID,
                                 c.StartDate,
                                 c.EndDate,
                                 d.EmployeetName,
                                 e.RoleName,
                                 g.SkillsName
                             }).ToList();
                rpt.DataSource = query;
                rpt.DataBind();

            }
        }

    }
}
