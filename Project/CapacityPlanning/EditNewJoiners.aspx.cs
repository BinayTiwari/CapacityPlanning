using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class EditNewJoiners : System.Web.UI.Page
    {
        int NewJoinerID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetDesignation(listDesignation);
                ClsCommon.ddlGetAccount(accountDropDownList);
                ClsCommon.ddlGetSkill(skillList);
                BindTextBoxvalues();
            }
        }

        protected void NewJoinerButton_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["JoinerId"]))
            {
                NewJoinerID = Convert.ToInt32(Request.QueryString["JoinerId"]);
            }

            string message = "";
            foreach (ListItem item in skillList.Items)
            {
                if (item.Selected)
                {
                    message += item.Value + ",";
                }
            }
            message = message.Remove(message.Length - 1).Trim();
            CPT_NewJoiners cPT_NewJoiners = new CPT_NewJoiners();
            cPT_NewJoiners.NewJoinerID = NewJoinerID;
            cPT_NewJoiners.Name = firstNameTextBox.Text.Trim();
            
            cPT_NewJoiners.DesignationID = Convert.ToInt32( listDesignation.SelectedValue);
            cPT_NewJoiners.JoiningDate = Convert.ToDateTime( dojTextBox.Text.Trim());
            cPT_NewJoiners.Location = baseLocationTextBox.Text.Trim();
            cPT_NewJoiners.Skills = message;
            cPT_NewJoiners.InterviewedBy = interviewedTextBox.Text.Trim();
            cPT_NewJoiners.Experience = expTextBox.Text.Trim();
            cPT_NewJoiners.Account =Convert.ToInt32( accountDropDownList.SelectedValue);
            NewJoinersBL newJoinersBL = new NewJoinersBL();
            newJoinersBL.Update(cPT_NewJoiners);
            Response.Redirect("NewJoiners.aspx");

        }

        private void BindTextBoxvalues()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["JoinerId"]))
                {
                    NewJoinerID = Convert.ToInt32(Request.QueryString["JoinerId"]);
                }
                CPT_NewJoiners newJoiners = new CPT_NewJoiners();
                newJoiners.NewJoinerID = NewJoinerID;
                NewJoinersBL newJoinersBL = new NewJoinersBL();

                List<CPT_NewJoiners> lst = newJoinersBL.uiDataBinding(newJoiners);
                firstNameTextBox.Text = lst[0].Name;
               
                listDesignation.Text = (lst[0].DesignationID.ToString());
                dojTextBox.Text = lst[0].JoiningDate.ToString();
                baseLocationTextBox.Text = lst[0].Location;
                
                interviewedTextBox.Text = lst[0].InterviewedBy;
                expTextBox.Text = lst[0].Experience;
                accountDropDownList.Text = lst[0].Account.ToString();

                String skillCommaSeperated = lst[0].Skills;
                String[] lstSkillSingle = skillCommaSeperated.Split(',');
                foreach (var item in lstSkillSingle)
                {

                    skillList.Items.FindByValue(item).Selected = true;
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            
            
        }
        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJoiners.aspx");
        }
    }
}