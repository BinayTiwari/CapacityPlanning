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
                ClsCommon.ddlGetSkill(skillList);

            }
            
            
            
        }

        protected void NewJoinerButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "";
                foreach (ListItem item in skillList.Items)
                {
                    if (!item.Selected)
                    {
                        message += item.Value + ",";
                    }
                }
                message = message.Remove(message.Length - 1);

                CPT_NewJoiners cPT_NewJoiners = new CPT_NewJoiners();
                cPT_NewJoiners.Account = Convert.ToInt32( accountDropDownList.SelectedValue);
                cPT_NewJoiners.DesignationID = Convert.ToInt32( listDesignation.SelectedValue);
                cPT_NewJoiners.Experience = expTextBox.Text;
                cPT_NewJoiners.FirstName = firstNameTextBox.Text;
                cPT_NewJoiners.LastName = lastNameTextBox.Text;
                cPT_NewJoiners.InterviewedBy = interviewedTextBox.Text;
                cPT_NewJoiners.JoiningDate = Convert.ToDateTime(dojTextBox.Text);
                cPT_NewJoiners.Skills = message;
                cPT_NewJoiners.Location = baseLocationTextBox.Text;

                NewJoinersBL newJoinersBL = new NewJoinersBL();
                newJoinersBL.Insert(cPT_NewJoiners);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }
    }
}