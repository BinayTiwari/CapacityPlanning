using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace businessLogic
{
    public class AllocateResourceBL
    {
        public int Insert(CPT_AllocateResource allocateDetails)
        {
            using (CPContext db = new CPContext())
            {
                try
                {
                    db.CPT_AllocateResource.Add(allocateDetails);
                    db.SaveChanges();
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
                    foreach(var item in query)
                    {
                        item.isMapped = 1;
                    }
                    db.SaveChanges();
                }
                catch(Exception exe)
                {
                    Console.WriteLine(exe.Message);
                }
            }
            return 1;
        }
        public static void getEmployeeNameByResourceType(Repeater repeater, string RoleName)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceMaster
                                 join q in db.CPT_ResourceDetails on p.RolesID equals q.ResourceTypeID
                                 join r in db.CPT_RoleMaster on q.ResourceTypeID equals r.RoleMasterID
                                 where (r.RoleName == RoleName) && (p.isMapped == 0)
                                 select new
                                 {
                                     p.EmployeetName,
                                     q.StartDate,
                                     q.EndDate
                                 }).ToList();
                    repeater.DataSource = query;
                    repeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static List<int> ResourceID(List<string> name)
        {
            using (CPContext db = new CPContext())
            {
                List<int> query = new List<int>();

                List<int> lst = new List<int>();
                foreach (var item in name)
                {
                    query = (from p in db.CPT_ResourceMaster
                             where (p.EmployeetName == item)
                             select p.EmployeeMasterID).ToList();
                    foreach (var it in query)
                    {
                        lst.Add(it);
                    }

                }
                //var query = (from p in db.CPT_ResourceMaster
                //             where (p.EmployeetName == name)
                //             select p.EmployeeMasterID).ToList();
                //int id = Convert.ToInt32(query);
                //foreach(var i in query)
                //{
                //    lst.Add(i);
                //}
                return lst;
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
        public static void AllocateResourceByID(Repeater rpt, string reqID)
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
                 where p.RequestID == reqID
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

        public List<CPT_ResourceMaster> getMailDetails(int id)
        {
            List<CPT_ResourceMaster> data = new List<CPT_ResourceMaster>();

            using(CPContext db = new CPContext())
            {
                var query = from c in db.CPT_ResourceMaster
                            where c.EmployeeMasterID == id
                            select c;
                foreach(var detail in query)
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

        public static void viewResourceMaping(Repeater rpt, String requestID)
        {
            using (CPContext db = new CPContext())
            {
                var query = (from c in db.CPT_AllocateResource
                             join d in db.CPT_ResourceMaster on c.ResourceID equals d.EmployeeMasterID
                             join e in db.CPT_RoleMaster on d.RolesID equals e.RoleMasterID
                             where c.RequestID == requestID
                             select new
                             {
                                 c.ResourceID,
                                 c.StartDate,
                                 c.EndDate,
                                 d.EmployeetName,
                                 e.RoleName
                             }).ToList();
                 rpt.DataSource = query;
                rpt.DataBind();

            }
        }
        
    }
}
