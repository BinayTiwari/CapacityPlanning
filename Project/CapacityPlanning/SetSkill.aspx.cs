using businessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapacityPlanning
{
    public partial class SetSkill : System.Web.UI.Page
    {
        List<string> Skills = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SetSkillsBL.GetSkills(dtlSkills);
            }
        }

        protected void chkSkill_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem item in dtlSkills.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkSkill");
                    var chek = (CheckBox)sender;
                    if (chk.Checked)
                    {
                        Skills.Add(chek.Attributes["SkillID"]);
                    }

                }
                Skills = Skills.Distinct().ToList();
            }
            catch (Exception p)
            {
                Console.Write(p.Message);
            }

        }

        protected void UpdateEmpSkills(object sender, EventArgs e)
        {
            try
            {
                string SkillIDs = "";
                bool flag = SetSkillsBL.CheckEmpID(Convert.ToInt32(EmpID.Text));

                if (Skills.Count > 0)
                {
                    foreach (string item in Skills)
                    {
                        SkillIDs += item + ",";
                    }
                    SkillIDs = SkillIDs.Remove(SkillIDs.Length - 1);
                }
                if (flag)
                {
                    SetSkillsBL.UpdateSkills(Convert.ToInt32(EmpID.Text), SkillIDs);
                    lblEmpID.Visible = false;
                    EmpID.Text = string.Empty;
                    foreach (DataListItem item in dtlSkills.Items)
                    {
                        CheckBox chk = (CheckBox)item.FindControl("chkSkill");
                        chk.Checked = false;
                    }
                    form1.Style.Add("display", "none");
                    DvSkill.Style.Add("display", "none");
                    myDIV.Style.Add("display", "block");
                }
                else
                {
                    lblEmpID.Visible = true;
                    lblEmpID.Text = "Employee ID does not exists !";

                }


            }
            catch (Exception q)
            {
                Console.Write(q.Message);
            }
        }


    }
}