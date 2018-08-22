using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                            where mr.RoleID == RoleID && m.IsActive == true 
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
    }

}

