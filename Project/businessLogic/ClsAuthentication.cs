using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Entity;

namespace businessLogic
{
   public class ClsAuthentication
    {
        public List<CPT_ResourceMaster> getActiveUser(CPT_ResourceMaster details)
        {
            List<CPT_ResourceMaster> lstUserDetails = new List<CPT_ResourceMaster>();

            using (var db = new CPContext())
            {

                var query = from c in db.CPT_ResourceMaster 
                where (c.Email == details.Email) && (c.EmployeePassword == details.EmployeePassword)
               select c;

                foreach (var item in query )
                {
                    CPT_ResourceMaster activeUser = new CPT_ResourceMaster();

                    activeUser.EmployeetName = item.EmployeetName;
                    activeUser.RolesID = item.RolesID;
                    activeUser.EmployeeMasterID = item.EmployeeMasterID;
                    activeUser.Email = item.Email;
                    

                    lstUserDetails.Add(activeUser);
                }
            }
            
            return lstUserDetails;
        }

        public List<CPT_MenuMaster> getMeanu(int RoleID)
        {
            List<CPT_MenuMaster> lstMeanu = new List<CPT_MenuMaster>();

            using (var db = new CPContext())
            {
                var query = from m in db.CPT_MenuMaster
                            join mr in db.RoleMenuMappings on m.MenuID equals mr.MenuID
                            where mr.RoleID == RoleID && m.IsActive == true orderby m.MenuName
                            select m;

                foreach (var item in query)
                {
                    CPT_MenuMaster menu = new CPT_MenuMaster();

                    menu.MenuName = item.MenuName;
                    menu.MenuURL = item.MenuURL;

                    lstMeanu.Add(menu);
                }

                return lstMeanu;
            }
        }

        public List<CPT_ResourceMaster> getDetailsforPasswordRecovery(string Email)
        {
            List<CPT_ResourceMaster> lstuserDetails = new List<CPT_ResourceMaster>();
            using (CPContext db = new CPContext())
            {
                var query = from p in db.CPT_ResourceMaster
                            where p.Email == Email
                            select p;

                foreach (var item in query)
                {
                    CPT_ResourceMaster EmailID = new CPT_ResourceMaster();

                    //EmailID.Email = item;
                    lstuserDetails.Add(item);
                }
            }
            return lstuserDetails;
        }


        public int EmpAccess()
        {

            int flag = 0;
            string CurrentURL = HttpContext.Current.Request.Url.AbsoluteUri;
            List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
            lstdetils = (List<CPT_ResourceMaster>)HttpContext.Current.Session["UserDetails"];
            int lid = lstdetils[0].EmployeeMasterID;

            using (CPContext db = new CPContext())
            {

                var murl = (from c in db.CPT_ResourceMaster
                            join f in db.RoleMenuMappings on c.RolesID equals f.RoleID
                            join e in db.CPT_MenuMaster on f.MenuID equals e.MenuID
                            where c.EmployeeMasterID == lid
                            select new
                            {
                                e.MenuURL
                            }).ToList();

                foreach (var u in murl)
                {
                    char c = '.';
                    string q = u.MenuURL.Split(c)[0];
                    if (CurrentURL.Contains(q))
                    {
                        //Access Granted
                        flag = 1;
                        break;
                    }
                    else
                    {
                        //Access Denied                        
                    }
                }

                return flag;
                /*if(flag!=1)
                {
                   // Redirect to Page: Not Authorized  
                   
                    
                }*/

            }

        }
    }

}

