using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapacityPlanning
{
    public partial class PopupSkill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_SkillsMaster
                                 where p.IsActive == true
                                 select new
                                 {
                                     SkillID = p.SkillsMasterID,
                                     SkillName = p.SkillsName
                                 }

                                 ).ToList();
                    rptSkillSelect.DataSource = query;
                    rptSkillSelect.DataBind();

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string skillIDs = "";
            string skillName = "";
            foreach (RepeaterItem item in rptSkillSelect.Items)
            {
                CheckBox chkPrimary = (CheckBox)item.FindControl("chkPrimary");
                CheckBox chkSecondary = (CheckBox)item.FindControl("chkSecondary");
                CheckBox chkTernary = (CheckBox)item.FindControl("chkTernary");
                if (chkPrimary.Checked)
                {
                    skillIDs += chkPrimary.Attributes["SkillId"] + ",";
                    skillName += chkPrimary.Attributes["skillName"] + ",";
                }
                if (chkSecondary.Checked)
                {
                    skillIDs += chkSecondary.Attributes["SkillId"] + ",";
                    skillName += chkPrimary.Attributes["skillName"] + ",";
                }
                if (chkTernary.Checked)
                {
                    skillIDs += chkTernary.Attributes["SkillId"] + ",";
                    skillName += chkPrimary.Attributes["skillName"] + ",";
                }
            }
            if (!string.IsNullOrEmpty(skillIDs))
            {
                skillIDs = skillIDs.Remove(skillIDs.Length - 1);
                skillName = skillName.Remove(skillName.Length - 1);
            }
            //AddResourceDemand add = new AddResourceDemand();
            //add.SkillID(skillIDs);
            //add.SkillName(skillName);
            string s = "javascript:window.close('PopupSkill.aspx')";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "s", s, true);
        }
    }
}