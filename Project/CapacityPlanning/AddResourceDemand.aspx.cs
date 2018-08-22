using System;
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

namespace CapacityPlanning
{
    public partial class AddResourceDemand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetRegion(RegionMasterID);
                ClsCommon.ddlGetAccount(AccountMasterID);
                AccountMasterID.Enabled = false;

                ClsCommon.ddlGetOpportunity(OpportunityID);
                ClsCommon.ddlGetSalesStage(SalesStageMasterID);               
                
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
                            DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[3].FindControl("SkillID");
                            //TextBox box1 = (TextBox)GridviewResourceDetail.Rows[i].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)GridviewResourceDetail.Rows[i].Cells[2].FindControl("NoOfResources");
                            TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[4].FindControl("StartDate");
                            TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[5].FindControl("EndDate");

                            dtCurrentTable.Rows[i]["ResourceTypeID"] = ddl.SelectedValue;
                            dtCurrentTable.Rows[i]["NoOfResources"] = box2.Text.Trim();
                            dtCurrentTable.Rows[i]["SkillID"] = ddl1.SelectedValue;                            
                            dtCurrentTable.Rows[i]["StartDate"] = box3.Text.Trim();
                            dtCurrentTable.Rows[i]["EndDate"] = box4.Text.Trim();
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
                    details.NoOfResources = Convert.ToInt32(data.Rows[i]["NoOfResources"]);
                    details.SkillID = data.Rows[i]["SkillID"].ToString().Trim();
                    details.StartDate = Convert.ToDateTime(data.Rows[i]["StartDate"]);
                    details.EndDate = Convert.ToDateTime(data.Rows[i]["EndDate"]);

                    lstdetails.Add(details);
                    resourceDemandDetails.CPT_ResourceDetails = lstdetails;

                    //insertDemandDetails.Insert(demandDetails);

                }
                Email();
                insertResourceDemand.Insert(resourceDemandDetails);
                
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
            dt.Columns.Add(new DataColumn("NoOfResources", typeof(Int32)));//for TextBox value   
            dt.Columns.Add(new DataColumn("SkillID", typeof(string)));//for List selected item   
            dt.Columns.Add(new DataColumn("StartDate", typeof(string)));//for Start Date 
            dt.Columns.Add(new DataColumn("EndDate", typeof(string)));//for End Date 
            //Set the Default value.
            dt.Columns["NoOfResources"].DefaultValue = 5;

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            
            dr["NoOfResources"] = 5;
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
            DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[0].Cells[3].FindControl("SkillID");
            ClsCommon.ddlGetRole(ddl);
            ClsCommon.ddlGetSkillDDL(ddl1);          

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
                        DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[i].Cells[3].FindControl("SkillID");
                        TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[4].FindControl("StartDate");
                        TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[5].FindControl("EndDate");

                        dtCurrentTable.Rows[i]["ResourceTypeID"] = ddl.SelectedValue;
                        dtCurrentTable.Rows[i]["NoOfResources"] = box2.Text.Trim();
                        dtCurrentTable.Rows[i]["SkillID"] = ddl1.SelectedValue;                       
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
                        DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[rowIndex].Cells[3].FindControl("SkillID");
                        TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[4].FindControl("StartDate");
                        TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[5].FindControl("EndDate");

                        //Fill the DropDownList with Data 
                        ClsCommon.ddlGetRole(ddl);
                        ClsCommon.ddlGetSkillDDL(ddl1);                       

                        if (i < dt.Rows.Count - 1)
                        {
                            ddl.ClearSelection();
                            ddl.Items.FindByValue(dt.Rows[i]["ResourceTypeID"].ToString()).Selected = true;
                            box2.Text = dt.Rows[i]["NoOfResources"].ToString().Trim();
                            
                            ddl1.ClearSelection();
                            ddl1.Items.FindByValue(dt.Rows[i]["SkillID"].ToString()).Selected = true;
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
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
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
            SetPreviousData();
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

        public void Email()
        {
            try
            {
                List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
                lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
                string employeeEmailID = lstdetils[0].Email;

                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "ResourceDemand";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(employeeEmailID);
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add(lstdetils[0].EmployeetName);
                //registrationEmail.UID = lstdetils[0].EmployeeMasterID.ToString();
                TokenMessageTemplate valEmail = new TokenMessageTemplate();
                valEmail.SendEmail(registrationEmail);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }

}


