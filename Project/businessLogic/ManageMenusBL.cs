using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entity;

namespace businessLogic
{
    public class ManageMenusBL
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;
        }
        public static void GetMenus(Repeater rptMenus)
        {
            try
            {
                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "select MenuID,MenuName from [CPT_MenuMaster] where IsActive = 1 order by MenuName";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    SqlDataReader reader = SqlCom.ExecuteReader();
                    rptMenus.DataSource = reader;
                    rptMenus.DataBind();
                }
               
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void InsertRoleMapping(List<RoleMenuMapping> lstRoleMenus)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    foreach(RoleMenuMapping item in lstRoleMenus)
                    {
                        db.RoleMenuMappings.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static List<RoleMenuMapping> GetRoleMenuMapping()
        {
            List<RoleMenuMapping> lstRoleMenu = new List<RoleMenuMapping>();
            try
            {
                using(CPContext db = new CPContext())
                {
                    var query = (from p in db.RoleMenuMappings
                                select p).ToList();

                    lstRoleMenu = query;
                }
                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return lstRoleMenu;
        }
    }
}
