using System;
using Entity;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class ResourceDetailsBL
    {
        public static int Insert(CPT_ResourceDetails demandDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_ResourceDetails.Add(demandDetails);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return 1;
        }

        public static void ViewResourceDetails(Repeater rpt, string requestID)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from p in db.CPT_ResourceDetails
                             join q in db.CPT_RoleMaster on p.ResourceTypeID equals q.RoleMasterID
                             where p.RequestID == requestID
                             select new
                             {
                                 q.RoleName,
                                 p.NoOfResources,
                                 p.StartDate,
                                 p.EndDate
                             }).ToList();
                var lookup = db.CPT_SkillsMaster
                             .ToDictionary(x => x.SkillsMasterID, x => x.SkillsName);
                var query1 = (from p in db.CPT_ResourceDetails
                              where p.RequestID == requestID
                              select p.SkillID
                              ).ToList();
                DataTable table = new DataTable();
                table.Columns.Add("RoleName", typeof(string));
                table.Columns.Add("NoOfResources", typeof(double));
                table.Columns.Add("Skills", typeof(string));
                table.Columns.Add("StartDate", typeof(string));
                table.Columns.Add("EndDate", typeof(string));
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
                    dr["RoleName"] = query[i].RoleName;
                    dr["NoOfResources"] = query[i].NoOfResources;
                    dr["Skills"] = strSkill;
                    dr["StartDate"] = query[i].StartDate.ToString("MMM dd yyyy");
                    dr["EndDate"] = query[i].EndDate.ToString("MMM dd yyyy");
                    table.Rows.Add(dr);
                }
                rpt.DataSource = table;
                rpt.DataBind();
            }
        }

        public static int deleteResourceDetails(string requestID)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    var query = (from p in db.CPT_ResourceDetails
                                 where p.RequestID == requestID
                                 select p);
                    foreach (var item in query)
                    {
                        db.CPT_ResourceDetails.Remove(item);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }
            }
            return 1;
        }

    }
}
