using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Entity;
namespace businessLogic
{
    public static class DashboardBL
    {
        public static void showDsVsRes(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_DesignationMaster
                                 join q in db.CPT_ResourceMaster on p.DesignationMasterID equals q.DesignationID
                                 
                                 select new 
                                 {
                                     Designation_Name = p.DesignationName,
                                     NoOfResources = q.EmployeeMasterID

                                 }

                                 ).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
