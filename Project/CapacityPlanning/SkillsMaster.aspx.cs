﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;

namespace CapacityPlanning
{
    public partial class SkillsMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            List<CPT_SkillsMaster> lstSkill = new List<CPT_SkillsMaster>();
            SkillsMasterBL clsSkill = new SkillsMasterBL();
            lstSkill = clsSkill.getSkill();

            gvSkills.DataSource = lstSkill;
            gvSkills.DataBind();
        }
        public void CleartextBoxes(Control parent)
        {

            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))
                {

                    ((TextBox)(c)).Text = "";
                }

                if (c.HasControls())
                {
                    CleartextBoxes(c);
                }
            }
        }
        protected void SkillsAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                CPT_SkillsMaster Skillsdetails = new CPT_SkillsMaster();
                Skillsdetails.SkillsName = SkillsNameTextBox.Text.Trim();
                Skillsdetails.IsActive = true;

                SkillsMasterBL insertSkills = new SkillsMasterBL();
                insertSkills.Insert(Skillsdetails);
                BindGrid();
                CleartextBoxes(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSkills.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void delete(object sender, GridViewDeleteEventArgs e)
        {
            CPT_SkillsMaster Skillsdetails = new CPT_SkillsMaster();
            int id = int.Parse(gvSkills.DataKeys[e.RowIndex].Value.ToString());
            Skillsdetails.SkillsMasterID = id;

            SkillsMasterBL deleteSkills = new SkillsMasterBL();
            deleteSkills.Delete(Skillsdetails);
            BindGrid();
        }

        protected void update(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                CPT_SkillsMaster Skillsdetails = new CPT_SkillsMaster();
                int id = int.Parse(gvSkills.DataKeys[e.RowIndex].Value.ToString());
                Skillsdetails.SkillsMasterID = id;
                string SkillsName = ((TextBox)gvSkills.Rows[e.RowIndex].Cells[1].Controls[0]).Text.Trim();
                Skillsdetails.SkillsName = SkillsName;
                SkillsMasterBL updateSkills = new SkillsMasterBL();
                updateSkills.Update(Skillsdetails);
                gvSkills.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void edit(object sender, GridViewEditEventArgs e)
        {
            gvSkills.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void canceledit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSkills.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}