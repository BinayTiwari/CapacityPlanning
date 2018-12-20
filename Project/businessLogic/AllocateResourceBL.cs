using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
        public void getFreeEmployee(Repeater rpt, int roleID, string endDate, List<string> skillID, string startDate)
        {
            try
            {
                string dtS = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(startDate));
                string dtE = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(endDate));
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT EmployeeMasterID,EmployeetName,AccountName,ProcessName,EndDate,IsReleased,ISNULL([dbo].[SumOfUtilization](EmployeemAsterid)*100,0) as utilization FROM " +
                                   " (SELECT CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName,utilization, CASE ISNULL(CAST(CPT_AllocateResource.Released" +
                                   " As varchar(12)), '-') WHEN '-' Then '-' when '0' then 'No' ELSE 'Yes' END AS IsReleased,[dbo].[DesignationName]" +
                                   " (CPT_ResourceMaster.DesignationID) As Designation, ISNULL(CAST(CPT_AccountMaster.AccountName As VARCHAR(50)), '-')" +
                                   " AccountName, CPT_ResourceMaster.RolesID, CPT_AllocateResource.ResourceID, CPT_ResourceDemand.ResourceRequestBy," +
                                   " ISNULL(CAST(CPT_ResourceDemand.ProcessName As VARCHAR(50)), '-') ProcessName, dbo.Owner(CPT_ResourceDemand.ResourceRequestBy)" +
                                   " as Owner, ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)), '-') EndDate, CPT_AllocateResource.EndDate As binner FROM CPT_AllocateResource RIGHT OUTER JOIN" +
                                   " CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN CPT_ResourceMaster" +
                                   " ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID LEFT OUTER JOIN CPT_AccountMaster ON" +
                                   " CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID Where(CPT_ResourceMaster.RolesID = " + roleID + " and" +
                                   " (skillsid in (Select CPT_ResourceMaster.Skillsid FROM CPT_ResourceMaster where skillsid like '%"+skillID[0]+"%' or skillsid like '%"+skillID[1]+ "%' or skillsid like '%" + skillID[2] + "%') and" +
                                   " CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT CPT_AllocateResource.ResourceID FROM CPT_AllocateResource" +
                                   " WHERE(CPT_AllocateResource.EndDate >= '" + dtS + "') AND Released = 0) AND ISDELETED = 0))) a INNER JOIN" +
                                   " (Select ResourceID, Max(EndDate) AS EndDate1 FROM CPT_AllocateResource Group by ResourceID)" +
                                   " b ON a.EmployeeMasterID = b.ResourceID AND a.binner = b.EndDate1 UNION SELECT CPT_ResourceMaster.EmployeeMasterID," +
                                   " CPT_ResourceMaster.EmployeetName, '-' AS AccountName,'-' AS ProcessName, '-' AS EndDate,'-' As IsReleased,0 as utilization" +
                                   " FROM CPT_ResourceMaster INNER JOIN CPT_DesignationMaster ON" +
                                   " CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID" +
                                   " WHERE CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT ResourceID FROM CPT_AllocateResource)" +
                                   " AND CPT_ResourceMaster.RolesID NOT IN(1, 4, 5, 8, 15, 20, 26, 25) AND ISDELETED = 0 AND CPT_ResourceMaster.RolesID =" + roleID + " AND" +
                                   " (skillsid in (Select CPT_ResourceMaster.Skillsid FROM CPT_ResourceMaster where skillsid like '%" + skillID[0] + "%' or skillsid like '%" + skillID[1] + "%' or skillsid like '%" + skillID[2] + "%') )";



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

        public void AllocateResourceByID(Repeater rpt, string reqID, int RoleID)
        {
            try
            {
                DataTable table = new DataTable();

                //string SqlString = "";
                switch (RoleID)
                {
                    case 20:
                        using (CPContext db = new CPContext())
                        {
                            var query = (from p in db.CPT_ResourceDetails
                                         join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                                         where p.RequestID == reqID && q.RoleMasterID == 14
                                         select new
                                         {
                                             p.RequestID,
                                             p.RequestDetailID,
                                             q.RoleMasterID,
                                             q.RoleName,
                                             p.NoOfResources,
                                             p.StartDate,
                                             p.EndDate,
                                         }).ToList();
                            var lookup = db.CPT_SkillsMaster
                                         .ToDictionary(x => x.SkillsMasterID, x => x.SkillsName);
                            var query1 = (from p in db.CPT_ResourceDetails
                                          join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                                          where p.RequestID == reqID && q.RoleMasterID == 14
                                          select p.SkillID
                                          ).ToList();
                            table.Columns.Add("RequestID", typeof(int));
                            table.Columns.Add("RequestDetailID", typeof(int));
                            table.Columns.Add("RoleMasterID", typeof(int));
                            table.Columns.Add("RoleName", typeof(string));
                            table.Columns.Add("NoOfResources", typeof(double));
                            table.Columns.Add("Skills", typeof(string));
                            table.Columns.Add("StartDate", typeof(string));
                            table.Columns.Add("EndDate", typeof(string));
                            table.Columns.Add("Allocated", typeof(string));
                            for (int i = 0; i < query1.Count; i++)
                            {
                                var query2 = query1[i].Split(',');
                                string strSkill = "";
                                foreach (var item in query2)
                                {
                                    strSkill += (lookup[Convert.ToInt32(item)]) + ",";
                                }
                                if (!string.IsNullOrEmpty(strSkill))
                                {
                                    strSkill = strSkill.Remove(strSkill.Length - 1);
                                }
                                DataRow dr = table.NewRow();
                                dr["RequestID"] = query[i].RequestID;
                                dr["RequestDetailID"] = query[i].RequestDetailID;
                                dr["RoleMasterID"] = query[i].RoleMasterID;
                                dr["RoleName"] = query[i].RoleName;
                                dr["NoOfResources"] = query[i].NoOfResources;
                                dr["Skills"] = strSkill;
                                dr["StartDate"] = query[i].StartDate.ToString("MMM dd yyyy");
                                dr["EndDate"] = query[i].EndDate.ToString("MMM dd yyyy");
                                dr["Allocated"] = TotalResurcesAllocated(query[i].RequestDetailID, query[i].RequestDetailID);
                                table.Rows.Add(dr);
                            }
                        }
                        break;

                    case 25:
                        using (CPContext db = new CPContext())
                        {
                            var query = (from p in db.CPT_ResourceDetails
                                         join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                                         where p.RequestID == reqID && q.RoleMasterID == 13
                                         select new
                                         {
                                             p.RequestID,
                                             p.RequestDetailID,
                                             q.RoleMasterID,
                                             q.RoleName,
                                             p.NoOfResources,
                                             p.StartDate,
                                             p.EndDate,
                                         }).ToList();
                            var lookup = db.CPT_SkillsMaster
                                         .ToDictionary(x => x.SkillsMasterID, x => x.SkillsName);
                            var query1 = (from p in db.CPT_ResourceDetails
                                          join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                                          where p.RequestID == reqID && q.RoleMasterID == 13
                                          select p.SkillID
                                          ).ToList();
                            table.Columns.Add("RequestID", typeof(int));
                            table.Columns.Add("RequestDetailID", typeof(int));
                            table.Columns.Add("RoleMasterID", typeof(int));
                            table.Columns.Add("RoleName", typeof(string));
                            table.Columns.Add("NoOfResources", typeof(double));
                            table.Columns.Add("Skills", typeof(string));
                            table.Columns.Add("StartDate", typeof(string));
                            table.Columns.Add("EndDate", typeof(string));
                            table.Columns.Add("Allocated", typeof(double));
                            for (int i = 0; i < query1.Count; i++)
                            {
                                var query2 = query1[i].Split(',');
                                string strSkill = "";
                                foreach (var item in query2)
                                {
                                    strSkill += (lookup[Convert.ToInt32(item)]) + ",";
                                }
                                if (!string.IsNullOrEmpty(strSkill))
                                {
                                    strSkill = strSkill.Remove(strSkill.Length - 1);
                                }
                                DataRow dr = table.NewRow();
                                dr["RequestID"] = query[i].RequestID;
                                dr["RequestDetailID"] = query[i].RequestDetailID;
                                dr["RoleMasterID"] = query[i].RoleMasterID;
                                dr["RoleName"] = query[i].RoleName;
                                dr["NoOfResources"] = query[i].NoOfResources;
                                dr["Skills"] = strSkill;
                                dr["StartDate"] = query[i].StartDate.ToString("MMM dd yyyy");
                                dr["EndDate"] = query[i].EndDate.ToString("MMM dd yyyy");
                                dr["Allocated"] = TotalResurcesAllocated(query[i].RoleMasterID, query[i].RequestDetailID);
                                table.Rows.Add(dr);
                            }
                        }
                        break;

                    default:
                        using (CPContext db = new CPContext())
                        {
                            var query = (from p in db.CPT_ResourceDetails
                                         join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                                         where p.RequestID == reqID
                                         select new
                                         {
                                             p.RequestID,
                                             p.RequestDetailID,
                                             q.RoleMasterID,
                                             q.RoleName,
                                             p.NoOfResources,
                                             p.StartDate,
                                             p.EndDate,
                                         }).ToList();
                            var lookup = db.CPT_SkillsMaster
                                         .ToDictionary(x => x.SkillsMasterID, x => x.SkillsName);
                            var query1 = (from p in db.CPT_ResourceDetails
                                          join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                                          where p.RequestID == reqID
                                          select p.SkillID
                                          ).ToList();
                            table.Columns.Add("RequestID", typeof(int));
                            table.Columns.Add("RequestDetailID", typeof(int));
                            table.Columns.Add("RoleMasterID", typeof(int));
                            table.Columns.Add("RoleName", typeof(string));
                            table.Columns.Add("NoOfResources", typeof(double));
                            table.Columns.Add("Skills", typeof(string));
                            table.Columns.Add("StartDate", typeof(string));
                            table.Columns.Add("EndDate", typeof(string));
                            table.Columns.Add("Allocated", typeof(double));
                            for (int i = 0; i < query1.Count; i++)
                            {
                                var query2 = query1[i].Split(',');
                                string strSkill = "";
                                foreach (var item in query2)
                                {
                                    strSkill += (lookup[Convert.ToInt32(item)]) + ",";
                                }
                                if (!string.IsNullOrEmpty(strSkill))
                                {
                                    strSkill = strSkill.Remove(strSkill.Length - 1);
                                }
                                DataRow dr = table.NewRow();
                                dr["RequestID"] = query[i].RequestID;
                                dr["RequestDetailID"] = query[i].RequestDetailID;
                                dr["RoleMasterID"] = query[i].RoleMasterID;
                                dr["RoleName"] = query[i].RoleName;
                                dr["NoOfResources"] = query[i].NoOfResources;
                                dr["Skills"] = strSkill;
                                dr["StartDate"] = query[i].StartDate.ToString("MMM dd yyyy");
                                dr["EndDate"] = query[i].EndDate.ToString("MMM dd yyyy");
                                dr["Allocated"] = TotalResurcesAllocated(query[i].RoleMasterID, query[i].RequestDetailID);
                                table.Rows.Add(dr);
                            }
                        }
                        break;
                }


                rpt.DataSource = table;
                rpt.DataBind();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        private double TotalResurcesAllocated(int roleMasterID, int requestDetailID)
        {
            SqlConnection SqlConn = new SqlConnection();
            int i = 0;
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "select dbo.TotalResurcesAllocated(" + roleMasterID + "," + requestDetailID + ") as Allocated";
            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                SqlConn.Open();
                SqlDataReader reader = SqlCom.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["Allocated"] != DBNull.Value)
                    {

                        i = Convert.ToInt32(reader["Allocated"]);

                    }
                }


            }
            return i;
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
        public static void viewResourceMaping(Repeater rpt, string requestID)
        {
            using (CPContext db = new CPContext())
            {
                var lookup = db.CPT_SkillsMaster
                             .ToDictionary(x => x.SkillsMasterID, x => x.SkillsName);
                var query1 = (from p in db.CPT_ResourceDetails
                              where p.RequestID == requestID
                              select p.SkillID
                               ).ToList();
                var query = (from c in db.CPT_AllocateResource
                             join d in db.CPT_ResourceMaster on c.ResourceID equals d.EmployeeMasterID
                             join e in db.CPT_RoleMaster on d.RolesID equals e.RoleMasterID
                             join f in db.CPT_ResourceDetails on c.RequestDetailID equals f.RequestDetailID
                             where c.RequestID == requestID
                             select new
                             {
                                 c.ResourceID,
                                 c.StartDate,
                                 c.EndDate,
                                 d.EmployeetName,
                                 e.RoleName,
                                 Allocated = c.Utilization
                             }).ToList();
                DataTable table = new DataTable();
                table.Columns.Add("ResourceID", typeof(string));
                table.Columns.Add("StartDate", typeof(string));
                table.Columns.Add("EndDate", typeof(string));
                table.Columns.Add("EmployeetName", typeof(string));
                table.Columns.Add("RoleName", typeof(string));
                table.Columns.Add("SkillsName", typeof(string));
                table.Columns.Add("Allocated", typeof(double));
                for (int i = 0; i < query.Count; i++)
                {
                    var query2 = query1[i].Split(',');
                    string strSkill = "";
                    foreach (var item in query2)
                    {
                        strSkill += lookup[Convert.ToInt32(item)] + ",";
                    }
                    if (!string.IsNullOrEmpty(strSkill))
                    {
                        strSkill = strSkill.Remove(strSkill.Length - 1);
                    }
                    DataRow dr = table.NewRow();
                    dr["ResourceID"] = query[i].ResourceID;
                    dr["StartDate"] = query[i].StartDate.ToString("MMM dd yyyy");
                    dr["EndDate"] = query[i].EndDate.ToString("MMM dd yyyy");
                    dr["EmployeetName"] = query[i].EmployeetName;
                    dr["RoleName"] = query[i].RoleName;
                    dr["SkillsName"] = strSkill;
                    dr["Allocated"] = query[i].Allocated;

                    table.Rows.Add(dr);
                }
                rpt.DataSource = table;
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
                using (CPContext db = new CPContext())
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
