using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class ViewEmployeeSkillsBL
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;
        }

        public static void GetEmployeeList(Repeater rpt, string SkillIDs, string Ratings)
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "select EmployeeMasterID, EmployeetName, SkillsName, Rating, ISNULL(CertificatePath, '-') As Cerificate" +
                                   " from [dbo].[CPT_ResourceMaster] inner join [dbo].[CPT_Certificate] ON" +
                                   " [CPT_ResourceMaster].EmployeeMasterID = [CPT_Certificate].EmployeeID inner join" +
                                   " [dbo].[CPT_SkillsMaster] ON [CPT_Certificate].SkillID = [CPT_SkillsMaster].SkillsMasterID where" +
                                   " SkillID in (" + SkillIDs + ") And Rating in ("+ Ratings + ") order by EmployeetName";

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
                Console.Write(ex.Message);
            }
        }
    }
}
