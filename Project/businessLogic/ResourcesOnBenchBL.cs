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
                string SqlString = " SELECT   CPT_ResourceMaster.EmployeetName, CPT_DesignationMaster.DesignationName,ISNULL(AccountName,'-') As AccountName ," +
                                   " ISNULL(ProcessName, '-') As ProcessName, ISNULL(CAST(ReleaseDate AS VARCHAR(13)), '-') AS ReleaseDate " +
                                   " FROM CPT_DesignationMaster INNER JOIN CPT_ResourceMaster ON CPT_DesignationMaster.DesignationMasterID = CPT_ResourceMaster.DesignationID LEFT OUTER JOIN " +
                                   " CPT_AllocateResource ON CPT_ResourceMaster.EmployeeMasterID = CPT_AllocateResource.ResourceID " +
                                   " LEFT OUTER JOIN ResourcesOnBench     ON CPT_ResourceMaster.EmployeeMasterID = ResourcesOnBench.ResourceID WHERE CPT_ResourceMaster.DesignationID NOT IN(36, 37, 38, 42) AND CPT_AllocateResource.IsDeployed = 0 ";
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
