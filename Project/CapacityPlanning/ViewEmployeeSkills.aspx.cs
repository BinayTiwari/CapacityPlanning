using businessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace CapacityPlanning
{
    public partial class ViewEmployeeSkills : System.Web.UI.Page
    {
        public string Skillnames = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SetSkillsBL.GetNewSkills(rptRPA, rptLangPrg, rptMS, rptFrk, rptDB, rptOther);

            }
        }

        protected void InsertEmpSkills(object sender, EventArgs e)
        {
            List<Int32> lstSkillID = new List<Int32>();
            List<Int32> lstRating = new List<Int32>();
            string Skillname = "";
            foreach (RepeaterItem item in rptRPA.Items)
            {
                
                CheckBox chk = (CheckBox)item.FindControl("chkRPA");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlRPARating");
               
                if (chk.Checked)
                {
                    lstSkillID.Add( Convert.ToInt32(chk.Attributes["SkillID"]));
                    lstRating.Add(Convert.ToInt32(ddlRating.SelectedValue));
                    
                    Skillname += chk.Attributes["Skillname"] + ", ";
                    
                }
            }
            foreach (RepeaterItem item in rptLangPrg.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkLangPrg");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlLangPrgRating");

                if (chk.Checked)
                {
                    lstSkillID.Add(Convert.ToInt32(chk.Attributes["SkillID"]));
                    lstRating.Add(Convert.ToInt32(ddlRating.SelectedValue));

                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptMS.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkMS");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlMSRating");

                if (chk.Checked)
                {
                    lstSkillID.Add(Convert.ToInt32(chk.Attributes["SkillID"]));
                    lstRating.Add(Convert.ToInt32(ddlRating.SelectedValue));

                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptFrk.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkFrk");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlFrkRating");

                if (chk.Checked)
                {
                    lstSkillID.Add(Convert.ToInt32(chk.Attributes["SkillID"]));
                    lstRating.Add(Convert.ToInt32(ddlRating.SelectedValue));

                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptDB.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkDB");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlDBRating");

                if (chk.Checked)
                {
                    lstSkillID.Add(Convert.ToInt32(chk.Attributes["SkillID"]));
                    lstRating.Add(Convert.ToInt32(ddlRating.SelectedValue));

                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptOther.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkOther");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlOtherRating");

                if (chk.Checked)
                {
                    lstSkillID.Add(Convert.ToInt32(chk.Attributes["SkillID"]));
                    lstRating.Add(Convert.ToInt32(ddlRating.SelectedValue));

                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            if (Skillname.Length > 1)
            {
                Skillnames = Skillname.Remove(Skillname.Length - 1);
            }
            
            SkillDiv.Style.Add("display", "none");
            ViewEmployeeSkillsBL.GetEmployeeList(lstSkillID, lstRating);
            EmployeeDiv.Style.Add("display", "block");

        }
    }
}