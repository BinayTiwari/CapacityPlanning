using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class ResourcesOnBenchBL
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;


        }
        public static void ResourcesOnBench(Repeater rpt)
        {

            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "SELECT EmployeeMasterID,EmployeetName,StartDate,EndDate,DesignationName,AccountName,ProcessName" +
                                   " FROM(SELECT CPT_ResourceMaster.EmployeeMasterID, CPT_ResourceMaster.EmployeetName, ISNULL(CAST(CPT_AllocateResource.StartDate" +
                                   " AS VARCHAR(12)), '-') AS StartDate, ISNULL(CAST(CPT_AllocateResource.EndDate As VARCHAR(12)), '-') AS EndDate, CPT_AllocateResource.EndDate As testdate," +
                                   " CPT_DesignationMaster.DesignationName, ISNULL(CPT_AccountMaster.AccountName, '-') AS AccountName," +
                                   " ISNULL(CPT_ResourceDemand.ProcessName, '-') AS ProcessName  FROM CPT_AccountMaster INNER JOIN  CPT_AllocateResource ON" +
                                   " CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN  CPT_ResourceDemand ON" +
                                   " CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID   RIGHT OUTER JOIN CPT_ResourceMaster INNER JOIN" +
                                   " CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID ON" +
                                   " CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID WHERE CPT_ResourceMaster.RolesID" +
                                   " NOT IN(1, 4, 5, 8, 15, 20, 26, 25)  AND CPT_ResourceMaster.EmployeeMasterID NOT IN(SELECT RESOURCEID FROM" +
                                   " CPT_AllocateResource WHERE[CPT_AllocateResource].ISDeployed = 1) AND ISDELETED = 0 AND" +
                                   " (CPT_AllocateResource.Released = 1 OR  CPT_AllocateResource.Released IS null)) a" +
                                   " INNER JOIN" +
                                   " (Select ResourceID, Max(EndDate)As EndDatea FROM CPT_AllocateResource WHERE CPT_AllocateResource.Released = 1 OR" +
                                   " CPT_AllocateResource.Released IS null Group by ResourceID) b ON a.EmployeeMasterID = b.ResourceID AND a.testdate = b.EndDatea" +
                                   " UNION" +
                                   " SELECT CPT_ResourceMaster.EmployeeMasterID,CPT_ResourceMaster.EmployeetName, '-' AS StartDate, '-' AS EndDate," +
                                   " CPT_DesignationMaster.DesignationName,'-' AS AccountName,'-' AS ProcessName FROM CPT_ResourceMaster" +
                                   " INNER JOIN" +
                                   " CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID" +
                                   " WHERE CPT_ResourceMaster.EmployeeMasterID" +
                                   " NOT IN(SELECT ResourceID FROM CPT_AllocateResource) AND CPT_ResourceMaster.RolesID NOT IN(1, 4, 5, 8, 15, 20, 26, 25) AND ISDELETED = 0";

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
    }
}
