using businessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using System.Data.Common;
using System.Data;

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
            try
            {
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
                    Response.Write("<Script>alert('No Skill Selected! Please select atleast one Skill to view Employees.')</Script>");
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
                        
        }

        protected void rptEmployeeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    string Path = ((DbDataRecord)e.Item.DataItem).GetValue(4).ToString();
                    if (Path.Equals("-"))
                    {
                        Label lblPath = (Label)e.Item.FindControl("lblCerti");
                        lblPath.Text = "Not Available";
                    }
                    else
                    {
                        Button btnView = (Button)e.Item.FindControl("btnViewCerti");
                        btnView.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            
        }

        protected void btnViewCertificate(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                string path = btn.Attributes["CertiPath"];
                string ss = "http://gridinfocom-001-site2.ftempurl.com/Documents/10458_53_Orchestrator%20certificate.pdf";
                System.Diagnostics.Process.Start(ss);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }           
        }
    }
}