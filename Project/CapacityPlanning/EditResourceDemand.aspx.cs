using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using businessLogic;
using System.Data;

namespace CapacityPlanning
{
    public partial class EditResourceDemand : System.Web.UI.Page
    {
        string requestID;
        int regionID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ClsCommon.ddlGetRegion(RegionMasterID);
                ClsCommon.ddlGetOpportunity(OpportunityID);
                ClsCommon.ddlGetSalesStage(SalesStageMasterID);
                ClsCommon.ddlGetAccount(AccountMasterID);
                //ClsCommon.ddlGetStatus(StatusMasterID);
                
                BindTextBoxvalues();
                bindDetailTextGrid();
                
              
            }
        }

        protected void BindTextBoxvalues()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RequestID"]))
                {
                    requestID = Request.QueryString["RequestID"].Trim();
                }
                CPT_ResourceDemand cPT_ResourceDemand = new CPT_ResourceDemand();
                cPT_ResourceDemand.RequestID = requestID;
                ResourceDemandBL resource = new ResourceDemandBL();
                List<CPT_ResourceDemand> lst = resource.uiDataBinding(cPT_ResourceDemand);
                List<int> regionIDs = ResourceDemandBL.getRegionID(lst[0].AccountID);
                regionID = regionIDs[0];
                RegionMasterID.Items.FindByValue(regionID.ToString()).Selected = true;
                
                OpportunityID.Text = lst[0].OpportunityID.ToString();
                processName.Text = lst[0].ProcessName;
                AccountMasterID.Text = lst[0].AccountID.ToString();
                SalesStageMasterID.Text = lst[0].SalesStageID.ToString();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }

        public void bindDetailTextGrid()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RequestID"]))
                {
                    requestID = Request.QueryString["RequestID"].Trim();
                }

                CPT_ResourceDetails resourceDetails = new CPT_ResourceDetails();
                resourceDetails.RequestID = requestID;

                ResourceDemandBL resource = new ResourceDemandBL();
                List<CPT_ResourceDetails> lstDetail = resource.uiDataBindingDetails(GridviewResourceDetail, resourceDetails);
                
                //ViewState["CurrentTable"] = lstDetail;

                for(int i =0; i< GridviewResourceDetail.Rows.Count; i++)
                {
                    DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[i].FindControl("ResourceTypeID");
                    ClsCommon.ddlGetRole(ddl);
                    ddl.SelectedValue = lstDetail[i].ResourceTypeID.ToString();
                    //ddl.Items.FindByValue(lstDetail[0].ResourceTypeID.ToString()).Selected = true;
                   
                    DropDownList ddl1 = (DropDownList)GridviewResourceDetail.Rows[i].FindControl("SkillID");
                    ClsCommon.ddlGetSkillDDL(ddl1);
                    ddl1.SelectedValue = lstDetail[i].SkillID.ToString();


                }
               



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        protected void Update_Resource_Demand(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["RequestId"]))
                {
                    requestID = Request.QueryString["RequestId"].Trim();
                }
                CPT_ResourceDemand resourceDemandDetails = new CPT_ResourceDemand();
                resourceDemandDetails.RequestID = requestID;
                resourceDemandDetails.AccountID = Convert.ToInt32(AccountMasterID.SelectedValue);
                resourceDemandDetails.OpportunityID = Convert.ToInt32(OpportunityID.SelectedValue);
                resourceDemandDetails.SalesStageID = Convert.ToInt32(SalesStageMasterID.SelectedValue);
                resourceDemandDetails.ProcessName = processName.Text;
                //resourceDemandDetails.StatusMasterID = Convert.ToInt32(StatusMasterID.SelectedValue);

                ResourceDemandBL updateResourceDemand = new ResourceDemandBL();
                //updateResourceDemand.Update(resourceDemandDetails);
                CPT_ResourceDetails resourceDetails = new CPT_ResourceDetails();
                

                DataTable data = new DataTable();
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
                            TextBox box2 = (TextBox)GridviewResourceDetail.Rows[i].Cells[2].FindControl("NoOfResources");
                            TextBox box3 = (TextBox)GridviewResourceDetail.Rows[i].Cells[3].FindControl("StartDate");
                            TextBox box4 = (TextBox)GridviewResourceDetail.Rows[i].Cells[4].FindControl("EndDate");
                            dtCurrentTable.Rows[i]["ResourceTypeID"] = ddl.SelectedValue;
                            dtCurrentTable.Rows[i]["NoOfResources"] = box2.Text.Trim();
                            dtCurrentTable.Rows[i]["SkillID"] = ddl.SelectedValue;                           
                            dtCurrentTable.Rows[i]["StartDate"] = box3.Text.Trim();
                            dtCurrentTable.Rows[i]["EndDate"] = box4.Text.Trim();
                        }

                        //Rebind the Grid with the current data to reflect changes   
                        GridviewResourceDetail.DataSource = dtCurrentTable;
                        GridviewResourceDetail.DataBind();
                    }
                    data = dtCurrentTable;
                }

                List<CPT_ResourceDetails> lstdetails = new List<CPT_ResourceDetails>();
                for (int i = 0; i < data.Rows.Count - 1; i++)
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
                }
                updateResourceDemand.Update(resourceDemandDetails);
                Response.Redirect("ResourceDemand.aspx");
            }

            

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

            regionID = Convert.ToInt32(RegionMasterID.SelectedValue);
            List<int> CityIDs = ResourceDemandBL.CityIDs(regionID);

            ClsCommon.ddlGetAccountWithCity(AccountMasterID, CityIDs);
        }

        protected void UnDoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResourceDemand.aspx");
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

                        DropDownList ddl = (DropDownList)GridviewResourceDetail.Rows[i].Cells[1].FindControl("ResourceTypeID");
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

                            //Assign the value from DataTable to the TextBox   
                            box2.Text = dt.Rows[i]["NoOfResources"].ToString().Trim();

                            //Set the Previous Selected Items on Each DropDownList on Postbacks
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

    }
}