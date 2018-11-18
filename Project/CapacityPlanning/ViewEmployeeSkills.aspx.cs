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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SetSkillsBL.GetNewSkills(rptRPA, rptLangPrg, rptMS, rptFrk, rptDB, rptOther);
            }
        }

        protected void InsertEmpSkills(object sender, EventArgs e)
        {
            string SkillIDs = "";
            string Ratings = "";
            string Skillname = "";
            foreach (RepeaterItem item in rptRPA.Items)
            {
                
                CheckBox chk = (CheckBox)item.FindControl("chkRPA");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlRPARating");
               
                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";                    
                    Skillname += chk.Attributes["Skillname"] + ", ";
                    
                }
            }
            foreach (RepeaterItem item in rptLangPrg.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkLangPrg");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlLangPrgRating");

                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";
                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptMS.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkMS");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlMSRating");

                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";
                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptFrk.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkFrk");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlFrkRating");

                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";
                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptDB.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkDB");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlDBRating");

                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";
                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            foreach (RepeaterItem item in rptOther.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkOther");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlOtherRating");

                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";
                    Skillname += chk.Attributes["Skillname"] + ", ";

                }
            }
            if (Skillname.Length > 1 && SkillIDs.Length > 1)
            {
                lblSkill.Text = "Employees have Skill" + Skillname.Remove(Skillname.Length - 1);
                SkillIDs = SkillIDs.Remove(SkillIDs.Length - 1);
            }
            else
            {
                lblSkill.Text = "No Skill Selected";
            }
            if(Ratings.Length > 1)
            {
                Ratings = Ratings.Remove(Ratings.Length - 1);
            }
            
            SkillDiv.Style.Add("display", "none");
            ViewEmployeeSkillsBL.GetEmployeeList(rptEmployeeList, SkillIDs, Ratings);
            EmployeeDiv.Style.Add("display", "block");

        }
    }
}