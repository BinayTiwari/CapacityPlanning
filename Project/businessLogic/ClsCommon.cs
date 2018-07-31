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
                            where c.IsActive == true
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
                            where c.IsActive == true & c.RegionID == regionID
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
                            where c.IsActive==true
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
                            where c.IsActive == true 
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
                            where c.IsActive == true
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
                            where c.IsActive == true
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
                            where c.IsActive == true
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
                            where c.IsActive == true
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
                            where c.IsActive == true
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
           // ddldropdownName.Items.Add(li);

            using (var db = new CPContext())
            {
                var query = from c in db.CPT_SkillsMaster
                            where c.IsActive == true
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
                            where c.IsActive == true
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
                             where q.RoleMasterID !=2

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
    }
}
