using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace businessLogic
{
    public class DeployResourcesBL
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;


        }

        public static void Bind(Repeater rpt)
        {
            try
            {
                //using (CPContext db = new CPContext())
                //{
                //    var query1 = (from p in db.CPT_ResourceDemand
                //                  join q in db.CPT_AccountMaster on p.AccountID equals q.AccountMasterID                                  
                //                  join ct in db.CPT_CityMaster on p.CityID equals ct.CityID
                //                  join x in db.CPT_ResourceMaster on p.ResourceRequestBy equals x.EmployeeMasterID
                //                  join r in db.CPT_AllocateResource on p.RequestID equals r.RequestID
                //                  join s in db.CPT_ResourceMaster on r.ResourceID equals s.EmployeeMasterID
                //                  orderby p.DateOfCreation descending

                //                  where p.StatusMasterID == 20 && r.IsDeployed == false
                //                  select new
                //                  {
                //                      p.RequestID,
                //                      p.DateOfCreation,
                //                      q.AccountName,                                    
                //                      ct.CityName,
                //                      p.ProcessName,
                //                      ResourceRequestBy = x.EmployeetName,
                //                      Name = s.EmployeetName,
                //                      ResourceID = s.EmployeeMasterID,
                //                      r.StartDate,
                //                      r.EndDate

                //                  }).ToList();

                //    rpt.DataSource = query1;
                //    rpt.DataBind();

                //}

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT AllocationID,[dbo].[ReportingManager](CPT_ResourceDemand.ResourceRequestBy) as RequesterEmail,CPT_AllocateResource.RequestId,CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName, ISNULL(CAST(CPT_AllocateResource.StartDate AS VARCHAR(12)), '-') AS StartDate, " +
                                   " ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)), '-') EndDate,  CPT_DesignationMaster.DesignationName, ISNULL(CPT_AccountMaster.AccountName, '-') " +
                                   " AS AccountName, ISNULL(CPT_ResourceDemand.ProcessName, '-') AS ProcessName  FROM CPT_AccountMaster INNER JOIN  CPT_AllocateResource ON " +
                                   " CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN  CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID " +
                                   " INNER JOIN  CPT_ResourceMaster INNER JOIN CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID ON " +
                                   " CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID  WHERE CPT_ResourceMaster.RolesID NOT IN(1, 4, 5, 8, 15, 20) " +
                                   " AND CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT RESOURCEID FROM CPT_AllocateResource WHERE[CPT_AllocateResource].ISDeployed = 1) and  [CPT_AllocateResource].[Released]!=1 ";

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

        public static void DeployStatus(int AllocationID)
        {
            try
                {
                    SqlConnection SqlConn = new SqlConnection();
                    SqlConn.ConnectionString = GetConnectionString();
                    string SqlString = " Update CPT_AllocateResource SET ISDeployed = 1  where AllocationID = " + AllocationID;


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
            try
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "Update CPT_ResourceDemand Set StatusMasterID = 32 WHERE RequestID = (SELECT RequestID  FROM [dbo].[CPT_ResourceDetails]  WHERE NoOfResources = [dbo].[TotalResurcesAllocated](ResourceTypeID, RequestDetailID) AND AllocationID = "+ AllocationID+")";


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
    }
}
