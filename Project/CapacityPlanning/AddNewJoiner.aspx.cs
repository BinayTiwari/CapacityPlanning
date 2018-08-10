using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;

namespace CapacityPlanning
{
    public partial class AddNewJoiner : System.Web.UI.Page
    {
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetDesignation(listDesignation);
                ClsCommon.ddlGetAccount(accountDropDownList);
                ClsCommon.ddlGetSkillDDL(skillListDD);

            }
            
            
            
        }

        protected void NewJoinerButton_Click(object sender, EventArgs e)
        {
            try
            {
                

                CPT_NewJoiners cPT_NewJoiners = new CPT_NewJoiners();
                cPT_NewJoiners.Account = Convert.ToInt32( accountDropDownList.SelectedValue);
                cPT_NewJoiners.DesignationID = Convert.ToInt32( listDesignation.SelectedValue);
                cPT_NewJoiners.Experience = expTextBox.Text.Trim();
                cPT_NewJoiners.Name = firstNameTextBox.Text.Trim();
            
                cPT_NewJoiners.InterviewedBy = interviewedTextBox.Text.Trim();
                cPT_NewJoiners.JoiningDate = Convert.ToDateTime(dojTextBox.Text.Trim());
                cPT_NewJoiners.Skills =Convert.ToInt32( skillListDD.SelectedValue);
                cPT_NewJoiners.Location = baseLocationTextBox.Text.Trim();

                NewJoinersBL newJoinersBL = new NewJoinersBL();
                newJoinersBL.Insert(cPT_NewJoiners);
                Response.Redirect("NewJoiners.aspx");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJoiners.aspx");
        }
    }
}