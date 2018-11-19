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
            int flag = 0;
            foreach (RepeaterItem item in rptRPA.Items)
            {
                
                CheckBox chk = (CheckBox)item.FindControl("chkRPA");
                DropDownList ddlRating = (DropDownList)item.FindControl("ddlRPARating");
               
                if (chk.Checked)
                {
                    SkillIDs += chk.Attributes["SkillID"] + ",";
                    Ratings += ddlRating.SelectedValue + ",";                    
                    Skillname += chk.Attributes["Skillname"] + ", ";
                    flag = 1;
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
                    flag = 1;
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
                    flag = 1;
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
                    flag = 1;
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
                    flag = 1;
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
                    flag = 1;
                }
            }
            if (flag == 1)
            {
                lblSkill.Text = "Employees have Skill " + Skillname.Remove(Skillname.Length - 2);
                SkillIDs = SkillIDs.Remove(SkillIDs.Length - 1);
                Ratings = Ratings.Remove(Ratings.Length - 1);
                SkillDiv.Style.Add("display", "none");
                ViewEmployeeSkillsBL.GetEmployeeList(rptEmployeeList, SkillIDs, Ratings);
                EmployeeDiv.Style.Add("display", "block");

            }
            else
            {
                Response.Write("<Script>alert('No Skill Selected! Please select atleast one Skill.')</Script>");
            }            
        }

        //public void ViewCertificate()
        //{
        //    System.Diagnostics.Process.Start(@"");
        //}

        protected void rptEmployeeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item)
            {

            }
        }
    }
}