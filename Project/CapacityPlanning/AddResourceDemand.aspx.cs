﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;
using System.Data;
using System.Collections;
using MessageTemplate;
using System.Net.Mail;

namespace CapacityPlanning
{
    public partial class AddResourceDemand : System.Web.UI.Page
    {
        //protected string min { get; set; }
        List<string> lstRoles = new List<string>();
        List<string> lstSkills = new List<string>();
        List<string> lstStartDate = new List<string>();
        List<string> lstEnddate = new List<string>();
        string AccountName = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //TextBox box3 = (TextBox)GridviewResourceDdviail.FindControl("StartDate");
               
                //box3.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");


                ClsCommon.ddlGetRegion(RegionMasterID);
                ClsCommon.ddlGetAccount(AccountMasterID);
                AccountMasterID.Enabled = false;

                ClsCommon.ddlGetOpportunity(OpportunityID);
                ClsCommon.ddlGetSalesStage(SalesStageMasterID);
                string minDate = DateTime.Now.AddDays(7).ToShortDateString();
                SetInitialRow();
            }
        }


        protected void Add_Resource_Demand(object sender, EventArgs e)
        {
            try
            {
                DataTable data = new DataTable();
                CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];

                resourceDemandDetails.RequestID = ClsCommon.GetRandomNumber(111111, 999999).ToString();
                resourceDemandDetails.AccountID = Convert.ToInt32(AccountMasterID.SelectedValue);
                int CityID = ResourceDemandBL.getCityID(Convert.ToInt32(AccountMasterID.SelectedValue));
                resourceDemandDetails.CityID = CityID;
                resourceDemandDetails.OpportunityID = Convert.ToInt32(OpportunityID.SelectedValue);
                resourceDemandDetails.SalesStageID = Convert.ToInt32(SalesStageMasterID.SelectedValue);
                resourceDemandDetails.ProcessName = processName.Text.Trim();               
                resourceDemandDetails.DateOfCreation = DateTime.Now;
                resourceDemandDetails.DateOfModification = DateTime.Now;
                resourceDemandDetails.ResourceRequestBy = lstdetils[0].EmployeeMasterID;
                resourceDemandDetails.StatusMasterID = 19;
                resourceDemandDetails.PriorityID = 27;
                AccountName = AccountMasterID.SelectedItem.Text.Trim();
                ResourceDemandBL insertResourceDemand = new ResourceDemandBL();
                //insertResourceDemand.Insert(resourceDemandDetails);

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                        //add new row to DataTable   
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        //Store the current data to ViewState for future reference   
                        ViewState["CurrentTable"] = dtCurrentTable;

                        for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                        {
                            //extract the DropDownList Selected Items   
                            DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[i].Cells[1].FindControl("ResourceTypeID");
                            DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[3].FindControl("ddlPrimary");
                            DropDownList ddl2 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[4].FindControl("ddlSecondry");
                            DropDownList ddl3 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[5].FindControl("ddlTernary");
                            //TextBox box1 = (TextBox)GridviewResourceDetail.Rows[i].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)GridviewResourceDetail.Rows[i].Cells[2].FindControl("NoOfResources");
                            TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[6].FindControl("StartDate");
                            TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[7].FindControl("EndDate");

                            dtCurrentTable.Rows[i]["ResourceTypeID"] = ddl.SelectedValue;
                            dtCurrentTable.Rows[i]["NoOfResources"] = box2.Text.Trim();
                            dtCurrentTable.Rows[i]["PrimarySkill"] = ddl1.SelectedValue;
                            dtCurrentTable.Rows[i]["SecondrySkill"] = ddl2.SelectedValue;
                            dtCurrentTable.Rows[i]["TernarySkill"] = ddl3.SelectedValue;
                            dtCurrentTable.Rows[i]["StartDate"] = box3.Text.Trim();
                            dtCurrentTable.Rows[i]["EndDate"] = box4.Text.Trim();
                            lstRoles.Add(ddl.SelectedItem.Text);
                            lstSkills.Add(ddl1.SelectedItem.Text+","+ddl2.SelectedItem.Text+","+ddl3.SelectedItem.Text);
                            lstStartDate.Add(box3.Text.Trim());
                            lstEnddate.Add(box4.Text.Trim());
                        }

                        //Rebind the Grid with the current data to reflect changes   
                        GridviewResourceDetail.DataSource = dtCurrentTable;
                        GridviewResourceDetail.DataBind();
                    }
                    data = dtCurrentTable;
                }

                
                ResourceDetailsBL insertDemandDetails = new ResourceDetailsBL();
                List<CPT_ResourceDetails> lstdetails = new List<CPT_ResourceDetails>();

                for(int i = 0; i < data.Rows.Count - 1; i++)
                {
                    CPT_ResourceDetails details = new CPT_ResourceDetails();

                    details.RequestID = resourceDemandDetails.RequestID;
                    details.ResourceTypeID = Convert.ToInt32(data.Rows[i]["ResourceTypeID"]);
                    details.NoOfResources = (float)Convert.ToDouble(data.Rows[i]["NoOfResources"]);
                    details.SkillID = data.Rows[i]["PrimarySkill"].ToString().Trim()+","+ data.Rows[i]["SecondrySkill"].ToString().Trim()+","+ data.Rows[i]["TernarySkill"].ToString().Trim();
                    details.StartDate = Convert.ToDateTime(data.Rows[i]["StartDate"]);
                    details.EndDate = Convert.ToDateTime(data.Rows[i]["EndDate"]);

                    lstdetails.Add(details);
                    resourceDemandDetails.CPT_ResourceDetails = lstdetails;

                    //insertDemandDetails.Insert(demandDetails);

                }
                insertResourceDemand.Insert(resourceDemandDetails);
                EmailNew(lstSkills, lstRoles, processName.Text.Trim(),lstStartDate,lstEnddate,AccountName);

                // Email();

                Response.Redirect("ResourceDemand.aspx");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }      

        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ResourceTypeID", typeof(Int32)));//for DropDownList selected item   
            dt.Columns.Add(new DataColumn("NoOfResources", typeof(float)));//for TextBox value   
            dt.Columns.Add(new DataColumn("PrimarySkill", typeof(string)));
            dt.Columns.Add(new DataColumn("SecondrySkill", typeof(string)));//for List selected item   
            dt.Columns.Add(new DataColumn("TernarySkill", typeof(string)));//for List selected item   
            dt.Columns.Add(new DataColumn("StartDate", typeof(string)));//for Start Date 
            dt.Columns.Add(new DataColumn("EndDate", typeof(string)));//for End Date 
            //Set the Default value.
            //dt.Columns["NoOfResources"].DefaultValue = 5;

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            
            //dr["NoOfResources"] = 5;
            dr["StartDate"] = string.Empty;
            dr["EndDate"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            GridviewResourceDetail.DataSource = dt;
            GridviewResourceDetail.DataBind();

            //After binding the gridview, we can then extract and fill the DropDownList with Data   
            DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[0].Cells[1].FindControl("ResourceTypeID");
            DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[0].Cells[3].FindControl("ddlPrimary");
            DropDownList ddl2 = (DropDownList)GridviewResourceDetail.Rows[0].Cells[4].FindControl("ddlSecondry");
            DropDownList ddl3 = (DropDownList)GridviewResourceDetail.Rows[0].Cells[5].FindControl("ddlTernary");

            //ListBox ddl2 = (ListBox)GridviewResourceDetail.Rows[0].Cells[3].FindControl("SkillID1");

            TextBox box3 = (TextBox)GridviewResourceDetail.Rows[0].Cells[6].FindControl("StartDate");
            TextBox box4 = (TextBox)GridviewResourceDetail.Rows[0].Cells[7].FindControl("EndDate");
            //box3.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            //box4.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");


            ClsCommon.ddlGetRoleforDemand(ddl);
            ClsCommon.ddlGetSkillddl(ddl1,"Select Primary Skill");
            ClsCommon.ddlGetSkillddl(ddl2, "Select Secondry Skill");
            ClsCommon.ddlGetSkillddl(ddl3, "Select Ternary Skill");
            //ClsCommon.ddlGetSkillDDL(ddl1);
            //ClsCommon.ddlGetSkill(ddl2);

        }

        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the DropDownList Selected Items   
                        DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[i].Cells[1].FindControl("ResourceTypeID");
                        TextBox box2 = (TextBox)GridviewResourceDetail.Rows[i].Cells[2].FindControl("NoOfResources");
                        DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[3].FindControl("ddlPrimary");
                        DropDownList ddl2 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[4].FindControl("ddlSecondry");
                        DropDownList ddl3 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[5].FindControl("ddlTernary");
                        TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[6].FindControl("StartDate");
                        TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[7].FindControl("EndDate");

                        //box3.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                        //box4.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");


                        dtCurrentTable.Rows[i]["ResourceTypeID"] = ddl.SelectedValue;
                        dtCurrentTable.Rows[i]["NoOfResources"] = box2.Text.Trim();
                        dtCurrentTable.Rows[i]["PrimarySkill"] = ddl1.SelectedValue;
                        dtCurrentTable.Rows[i]["SecondrySkill"] = ddl2.SelectedValue;
                        dtCurrentTable.Rows[i]["TernarySkill"] = ddl3.SelectedValue;

                        dtCurrentTable.Rows[i]["StartDate"] = box3.Text.Trim();
                        dtCurrentTable.Rows[i]["EndDate"] = box4.Text.Trim();

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridviewResourceDetail.DataSource = dtCurrentTable;
                    GridviewResourceDetail.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData();
        }

        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[1].FindControl("ResourceTypeID");
                        TextBox box2 = (TextBox)GridviewResourceDetail.Rows[i].Cells[2].FindControl("NoOfResources");
                        DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[3].FindControl("ddlPrimary");
                        DropDownList ddl2 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[4].FindControl("ddlSecondry");
                        DropDownList ddl3 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[5].FindControl("ddlTernary");
                        TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[6].FindControl("StartDate");
                        TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[7].FindControl("EndDate");

                        //box3.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                        //box4.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");


                        //Fill the DropDownList with Data 
                        ClsCommon.ddlGetRoleforDemand(ddl);
                        //ClsCommon.ddlGetSkillDDL(ddl1);  
                        ClsCommon.ddlGetSkillddl(ddl1, "Select Primary Skill");
                        ClsCommon.ddlGetSkillddl(ddl2, "Select Secondry Skill");
                        ClsCommon.ddlGetSkillddl(ddl3, "Select Ternary Skill");

                        if (i < dt.Rows.Count-1)
                        {
                            ddl.ClearSelection();
                            ddl.Items.FindByValue(dt.Rows[i]["ResourceTypeID"].ToString()).Selected = true;
                            box2.Text = dt.Rows[i]["NoOfResources"].ToString().Trim();
                            
                            ddl1.ClearSelection();
                            ddl2.ClearSelection();
                            ddl3.ClearSelection();
                            ddl1.Items.FindByValue(dt.Rows[i]["PrimarySkill"].ToString()).Selected = true;
                            ddl2.Items.FindByValue(dt.Rows[i]["SecondrySkill"].ToString()).Selected = true;
                            ddl3.Items.FindByValue(dt.Rows[i]["TernarySkill"].ToString()).Selected = true;
                            box3.Text = dt.Rows[i]["StartDate"].ToString().Trim();
                            
                            box4.Text = dt.Rows[i]["EndDate"].ToString().Trim();
                                                      
                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            
            AddNewRowToGrid();
            
        }

        protected void GridviewResourceDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Button lb = (Button)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex <= dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                GridviewResourceDetail.DataSource = dt;
                GridviewResourceDetail.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousDataforRemove();
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        protected void RegionMasterID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RegionMasterID.SelectedItem.Text == "Select Region")
            {
                AccountMasterID.Enabled = false;
            }
            else
            {
                AccountMasterID.Enabled = true;
            }

            int regionID = Convert.ToInt32(RegionMasterID.SelectedValue);
            List<int> CityIDs = ResourceDemandBL.CityIDs(regionID);
            
        
            ClsCommon.ddlGetAccountWithCity(AccountMasterID, CityIDs);

        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceDemand.aspx");
        }
        public void EmailNew(List<string> lstSkills,List<string> lstRole,string ProcessName,List<string> StartDate, List<string> EndDate,string Account)
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("resourceallocationgic@gmail.com");
                mail.To.Add(lstdetils[0].Email);
                //mail.To.Add("jagmeet.sarna@gridinfocom.com");
               mail.CC.Add("pradeep.tyagi@gridinfocom.com,arun.kumar@gridinfocom.com,saransh.gupta@gridinfocom.com");
                mail.Subject = "Resource Requested";
                mail.Body = "<div align='justify' style='font - family: Calibri; font - size: 15px;'>" +
                    "<strong> Dear <b> Team </b></strong>,&nbsp;" +
                    "<p> Mr "+lstdetils[0].EmployeetName +" has raise a resource request for process <b>"+Account +" - "+ ProcessName+"</b>.<br/>" +
                    "Please find the details below.</p><table border='1' cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'><th>Role</th><th>Skills</th><th>Start Date</th><th>End Date</th></tr> ";
                for(int i=0;i<lstSkills.Count;i++)
                {
                    mail.Body += "<tr><td>" + lstRole[i] + "</td>" + "<td>" + lstSkills[i] + "</td> <td>"+StartDate[i]+"</td><td>"+EndDate[i]+"</td></tr>";
                }

                mail.Body += "</table><br><p> Please login to the capacity planning tool to allocate resources.</p> "+
                             "<a href='http://gridinfocom-001-site2.ftempurl.com'> <b>click here<b> </a><br>" +
                            "<p><b>Warm Regards, </b></p> <p><b>Work Force Allocation</b></p>" +                             
                             " <p><h6>This email is system generated, please do not respond to this email.</h6></p>";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("resourceallocationgic@gmail.com", "incorrect@gic");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        //public void Email()
        //{
        //    try
        //    {
        //        List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
        //        lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
        //        string employeeEmailID = lstdetils[0].Email;

        //        CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
        //        registrationEmail.Name = "ResourceDemand";
        //        registrationEmail.To = new List<string>();
        //        registrationEmail.To.Add(employeeEmailID);
        //        registrationEmail.ToUserName = new List<string>();
        //        registrationEmail.ToUserName.Add(lstdetils[0].EmployeetName);
        //        //registrationEmail.UID = lstdetils[0].EmployeeMasterID.ToString();
        //        TokenMessageTemplate valEmail = new TokenMessageTemplate();
        //        valEmail.SendEmail(registrationEmail);
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }
            
        //}

        private void SetPreviousDataforRemove()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["CurrentTable"] != null)
                {

                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    if (dt.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[1].FindControl("ResourceTypeID");
                            TextBox box2 = (TextBox)GridviewResourceDetail.Rows[rowIndex].Cells[2].FindControl("NoOfResources");
                            DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[3].FindControl("ddlPrimary");
                            DropDownList ddl2 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[4].FindControl("ddlSecondry");
                            DropDownList ddl3 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[5].FindControl("ddlTernary");
                            TextBox box3 = (TextBox)GridviewResourceDetail.Rows[rowIndex].Cells[6].FindControl("StartDate");
                            TextBox box4 = (TextBox)GridviewResourceDetail.Rows[rowIndex].Cells[7].FindControl("EndDate");

                            //box3.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                            //box4.Attributes["min"] = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");


                            //Fill the DropDownList with Data 
                            ClsCommon.ddlGetRoleforDemand(ddl);
                            // ClsCommon.ddlGetSkillDDL(ddl1);
                            ClsCommon.ddlGetSkillddl(ddl1, "Select Primary Skill");
                            ClsCommon.ddlGetSkillddl(ddl2, "Select Secondry Skill");
                            ClsCommon.ddlGetSkillddl(ddl3, "Select Ternary Skill");


                            ddl.ClearSelection();
                            
                                ddl.Items.FindByValue(dt.Rows[i]["ResourceTypeID"].ToString()).Selected = true;
                                box2.Text = dt.Rows[i]["NoOfResources"].ToString().Trim();

                                ddl1.ClearSelection();
                            ddl2.ClearSelection();
                            ddl3.ClearSelection();
                            ddl1.Items.FindByValue(dt.Rows[i]["PrimarySkill"].ToString()).Selected = true;
                            ddl2.Items.FindByValue(dt.Rows[i]["SecondrySkill"].ToString()).Selected = true;
                            ddl3.Items.FindByValue(dt.Rows[i]["TernarySkill"].ToString()).Selected = true;

                            box3.Text = dt.Rows[i]["StartDate"].ToString().Trim();
                                box4.Text = dt.Rows[i]["EndDate"].ToString().Trim();
                            
                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            //int rowIndex = 0;
            
        }
    }

}


