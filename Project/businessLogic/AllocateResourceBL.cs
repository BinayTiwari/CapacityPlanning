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
        public void getFreeEmployee(Repeater rpt, int roleID, string endDate, string skillID, string startDate)
        {
            try
            {
                string dtS = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(startDate));
                string dtE = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(endDate));
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT EmployeeMasterID,EmployeetName,AccountName,ProcessName,EndDate,IsReleased,ISNULL([dbo].[SumOfUtilization](EmployeemAsterid)*100,0) as utilization FROM " +
                                   " (SELECT CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName,utilization, CASE ISNULL(CAST(CPT_AllocateResource.Released" +
                                   " As varchar(12)), '-') WHEN '-' Then '-' when '0' then 'No' ELSE 'Yes' END AS IsReleased,[dbo].[DesignationName]"+
                                   " (CPT_ResourceMaster.DesignationID) As Designation, ISNULL(CAST(CPT_AccountMaster.AccountName As VARCHAR(50)), '-')"+
                                   " AccountName, CPT_ResourceMaster.RolesID, CPT_AllocateResource.ResourceID, CPT_ResourceDemand.ResourceRequestBy,"+
                                   " ISNULL(CAST(CPT_ResourceDemand.ProcessName As VARCHAR(50)), '-') ProcessName, dbo.Owner(CPT_ResourceDemand.ResourceRequestBy)"+
                                   " as Owner, ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)), '-') EndDate, CPT_AllocateResource.EndDate As binner FROM CPT_AllocateResource RIGHT OUTER JOIN"+
                                   " CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN CPT_ResourceMaster"+
                                   " ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID LEFT OUTER JOIN CPT_AccountMaster ON"+
                                   " CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID Where(CPT_ResourceMaster.RolesID = "+ roleID +" and"+
                                   " (skillsid in (Select CPT_ResourceMaster.Skillsid FROM CPT_ResourceMaster where skillsid like '%"+ skillID +"%') and"+
                                   " CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource"+
                                   " WHERE(CPT_AllocateResource.EndDate >= '" + dtS + "') AND Released = 0) AND ISDELETED = 0))) a INNER JOIN"+
                                   " (Select ResourceID, Max(EndDate) AS EndDate1 FROM CPT_AllocateResource Group by ResourceID)"+
                                   " b ON a.EmployeeMasterID = b.ResourceID AND a.binner = b.EndDate1 UNION SELECT CPT_ResourceMaster.EmployeeMasterID,"+
                                   " CPT_ResourceMaster.EmployeetName, '-' AS AccountName,'-' AS ProcessName, '-' AS EndDate,'-' As IsReleased,0 as utilization" +
                                   " FROM CPT_ResourceMaster INNER JOIN CPT_DesignationMaster ON" +
                                   " CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID" +
                                   " WHERE CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT ResourceID FROM CPT_AllocateResource)" +
                                   " AND CPT_ResourceMaster.RolesID NOT IN(1, 4, 5, 8, 15, 20, 26, 25) AND ISDELETED = 0 AND CPT_ResourceMaster.RolesID =" + roleID + " AND" +
                                   " (skillsid in (Select CPT_ResourceMaster.Skillsid FROM CPT_ResourceMaster where skillsid like '%"+ skillID +"%') )";



                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    SqlDataReader reader = SqlCom.ExecuteReader();
                    rpt.DataSource = reader;
                    rpt.DataBind();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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

        public void AllocateResourceByID(Repeater rpt, string reqID,int RoleID)
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "";
                switch (RoleID)
                {
                    case 20:
                        SqlString = " SELECT CPT_ResourceDetails.RequestDetailID,CPT_ResourceDetails.ResourceTypeID, CPT_ResourceDetails.RequestID, CPT_RoleMaster.RoleName," +
                                  " CPT_SkillsMaster.SkillsName, CPT_ResourceDetails.NoOfResources,ISNULL(dbo.TotalResurcesAllocated(CPT_RoleMaster.RoleMasterID,CPT_ResourceDetails.RequestDetailID),0) As Allocated, CPT_ResourceDetails.StartDate, CPT_ResourceDetails.EndDate, CPT_RoleMaster.RoleMasterID " +
                                  " FROM CPT_SkillsMaster INNER JOIN CPT_ResourceDetails INNER JOIN CPT_RoleMaster ON CPT_ResourceDetails.ResourceTypeID = CPT_RoleMaster.RoleMasterID ON " +
                                  "  CPT_SkillsMaster.SkillsMasterID = CPT_ResourceDetails.SkillID WHERE CPT_ResourceDetails.RequestID = " + reqID + " AND CPT_RoleMaster.RoleMasterID = 14 ";
                        break;

                    case 25:
                        SqlString = " SELECT CPT_ResourceDetails.RequestDetailID,CPT_ResourceDetails.ResourceTypeID, CPT_ResourceDetails.RequestID, CPT_RoleMaster.RoleName," +
                                  " CPT_SkillsMaster.SkillsName, CPT_ResourceDetails.NoOfResources,ISNULL(dbo.TotalResurcesAllocated(CPT_RoleMaster.RoleMasterID,CPT_ResourceDetails.RequestDetailID),0) As Allocated, CPT_ResourceDetails.StartDate, CPT_ResourceDetails.EndDate, CPT_RoleMaster.RoleMasterID " +
                                  " FROM CPT_SkillsMaster INNER JOIN CPT_ResourceDetails INNER JOIN CPT_RoleMaster ON CPT_ResourceDetails.ResourceTypeID = CPT_RoleMaster.RoleMasterID ON " +
                                  "  CPT_SkillsMaster.SkillsMasterID = CPT_ResourceDetails.SkillID WHERE CPT_ResourceDetails.RequestID = " + reqID + " AND CPT_RoleMaster.RoleMasterID = 13 ";
                        break;

                    default:
                        SqlString = " SELECT CPT_ResourceDetails.RequestDetailID,CPT_ResourceDetails.ResourceTypeID, CPT_ResourceDetails.RequestID, CPT_RoleMaster.RoleName," +
                                  " CPT_SkillsMaster.SkillsName, CPT_ResourceDetails.NoOfResources,ISNULL(dbo.TotalResurcesAllocated(CPT_RoleMaster.RoleMasterID,CPT_ResourceDetails.RequestDetailID),0) As Allocated, CPT_ResourceDetails.StartDate, CPT_ResourceDetails.EndDate, CPT_RoleMaster.RoleMasterID " +
                                  " FROM CPT_SkillsMaster INNER JOIN CPT_ResourceDetails INNER JOIN CPT_RoleMaster ON CPT_ResourceDetails.ResourceTypeID = CPT_RoleMaster.RoleMasterID ON " +
                                  "  CPT_SkillsMaster.SkillsMasterID = CPT_ResourceDetails.SkillID WHERE CPT_ResourceDetails.RequestID = " + reqID + "";
                        break;
                }

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
                                 g.SkillsName,
                                 Allocated = c.Utilization
                             }).ToList();
                rpt.DataSource = query;
                rpt.DataBind();

            }
        }
        public static int getRole(string Role)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_RoleMaster
                                 where p.RoleName == Role
                                 select p.RoleMasterID
                                 ).ToList();
                    return query[0];
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            
        }

        public static string GetRequesterEmail(string RequestID)
        {
            string Email = "";
            try
            {
                using(CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceDemand
                                join q in db.CPT_ResourceMaster on p.ResourceRequestBy equals q.EmployeeMasterID
                                where p.RequestID == RequestID
                                select q.Email).ToList();

                    Email = query[0];
                }
                return Email;
            }
            catch (Exception EX)
            {
                Console.Write(EX.Message);
                return "";
            }
            
        }
    }
}
