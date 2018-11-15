using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entity;

namespace businessLogic
{
    public class ManageMenusBL
    {
        public static void GetMenus(Repeater rptMenus)
        {
            try
            {
                using(CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_MenuMaster
                                 where p.IsActive==true
                                select p).ToList();

                    rptMenus.DataSource = query;
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
    }
}
