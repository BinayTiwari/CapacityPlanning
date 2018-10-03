using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace businessLogic
{
    public class ClsCommon
    {
        public static void ddlGetCountry(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Country";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_CountryMaster
                            where c.IsActive == true orderby c.CountryName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.CountryMasterID.ToString();
                    li.Text = item.CountryName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetCountry(DropDownList ddldropdownName, int regionID)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Country";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_CountryMaster
                            where c.IsActive == true & c.RegionID == regionID orderby c.CountryName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.CountryMasterID.ToString();
                    li.Text = item.CountryName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetCity(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select City";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_CityMaster
                            where c.IsActive==true orderby c.CityName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.CityID.ToString();
                    li.Text = item.CityName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }
        public static void ddlGetCity(DropDownList ddldropdownName, int countryID)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select City";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_CityMaster
                            where c.IsActive == true && c.CountryID == countryID
                            orderby c.CityName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.CityID.ToString();
                    li.Text = item.CityName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }



        public static void ddlGetCity(DropDownList ddldropdownName, int countryID, int regionID)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select City";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_CityMaster
                            where c.IsActive == true & c.RegionID == regionID & c.CountryID == countryID orderby c.CityName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.CityID.ToString();
                    li.Text = item.CityName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetRegion(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Region";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_RegionMaster
                            where c.IsActive == true orderby c.RegionName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.RegionMasterID.ToString();
                    li.Text = item.RegionName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetAccount(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Account";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_AccountMaster
                            where c.IsActive == true orderby c.AccountName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.AccountMasterID.ToString();
                    li.Text = item.AccountName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }


        }

        public static void ddlGetDesignation(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Designation";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_DesignationMaster
                            where c.IsActive == true orderby c.DesignationName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.DesignationMasterID.ToString();
                    li.Text = item.DesignationName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetGrade(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Grade";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_GradeMaster
                            where c.IsActive == true orderby c.Grade
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.GradeID.ToString();
                    li.Text = item.Grade.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetOpportunity(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Opportunity Type";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_OpportunityMaster
                            where c.IsActive == true orderby c.OpportunityType
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.OpportunityID.ToString();
                    li.Text = item.OpportunityType.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetRole(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Role";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_RoleMaster
                            where  c.IsActive == true && (c.RoleMasterID != 1 || c.RoleMasterID != 4 || c.RoleMasterID != 5) orderby c.RoleName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.RoleMasterID.ToString();
                    li.Text = item.RoleName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetSkill(ListBox ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            //li.Text = "Select Skills";
            //li.Value = "0";
            //ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_SkillsMaster
                            where c.IsActive == true orderby c.SkillsName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.SkillsMasterID.ToString();
                    li.Text = item.SkillsName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }


        public static void ddlGetSkillDDL(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Skills";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_SkillsMaster
                            where c.IsActive == true orderby c.SkillsName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.SkillsMasterID.ToString();
                    li.Text = item.SkillsName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }




        public static void ddlGetSalesStage(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Sales Stage";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_SalesStageMaster
                            where c.IsActive == true orderby c.SalesStageName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.SalesStageMasterID.ToString();
                    li.Text = item.SalesStageName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetManager(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Reporting Manager";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = (from p in db.CPT_ResourceMaster
                             join q in db.CPT_RoleMaster on p.RolesID equals q.RoleMasterID
                             where q.RoleMasterID !=7 orderby p.EmployeetName orderby p.EmployeetName

                             select new
                             {
                                 p.EmployeeMasterID,
                                 p.EmployeetName
                             }).ToList();
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.EmployeeMasterID.ToString();
                    li.Text = item.EmployeetName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetStatus(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Status";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_StatusMaster
                            where c.IsActive == true orderby c.StatusName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.StatusMasterID.ToString();
                    li.Text = item.StatusName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetPriority(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Action";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_PriorityMaster
                            where c.IsActive == true orderby c.PriorityName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.PriorityID.ToString();
                    li.Text = item.PriorityName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            Random r = new Random();
            int number=r.Next(minValue, maxValue);
            return number;
        }

        public static void ddlGetAccountWithCity(DropDownList ddldropdownName, List<int> CityIDs)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Account";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            { 
                foreach(var item in CityIDs)
                {
                    var query = from q in db.CPT_AccountMaster
                                join r in db.CPT_CityMaster on q.CityID equals r.CityID
                                where item == q.CityID & q.IsActive == true orderby q.AccountName
                                select new
                                { q.AccountMasterID, q.AccountName, r.CityName };
                    foreach (var detail in query)
                    {
                        li = new ListItem();
                        li.Value = detail.AccountMasterID.ToString();
                        li.Text = detail.AccountName + " - " + detail.CityName;
                        ddldropdownName.Items.Add(li);

                    }

                }
                
            }
        }


        public static void ddlGetRoleforDemand(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Role";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_RoleMaster
                            where c.IsActive == true && (c.RoleMasterID != 1 && c.RoleMasterID != 4 && c.RoleMasterID != 16 
                            && c.RoleMasterID !=15 && c.RoleMasterID != 5 && c.RoleMasterID != 11 && c.RoleMasterID != 20) orderby c.RoleName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.RoleMasterID.ToString();
                    li.Text = item.RoleName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetStatusNew(DropDownList ddldropdownName, int statusID)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "Select Status";
            li.Value = "0";
            ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_StatusMaster
                            where c.IsActive == true && (c.StatusMasterID == 23 || c.StatusMasterID == statusID) orderby c.StatusName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.StatusMasterID.ToString();
                    li.Text = item.StatusName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }

        public static void ddlGetAction(DropDownList ddldropdownName)
        {
            ddldropdownName.Items.Clear();
            ListItem li = new ListItem();
            //li.Text = "Select Action";
            //li.Value = "0";
            //ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_StatusMaster
                            where c.IsActive == true && (c.StatusMasterID == 19 || c.StatusMasterID ==26 || c.StatusMasterID == 27 || c.StatusMasterID == 31)
                            orderby c.StatusName
                            select c;
                foreach (var item in query)
                {
                    li = new ListItem();
                    li.Value = item.StatusMasterID.ToString();
                    li.Text = item.StatusName.ToString();
                    ddldropdownName.Items.Add(li);

                }
            }
        }
    }
}
