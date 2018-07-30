using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapacityPlanning
{
    public partial class AddExperience : System.Web.UI.Page
    {
        
            private ArrayList GetDummyData()
            {
                ArrayList arr = new ArrayList();
                arr.Add(new ListItem("Item1", "1"));
                arr.Add(new ListItem("Item2", "2"));
                arr.Add(new ListItem("Item3", "3"));
                arr.Add(new ListItem("Item4", "4"));
                arr.Add(new ListItem("Item5", "5"));
                return arr;
            }

            private void FillDropDownList(DropDownList ddl)
            {
                ArrayList arr = GetDummyData();

                foreach (ListItem item in arr)
                {
                    ddl.Items.Add(item);
                }
            }

            private void SetInitialRow()
            {

                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
                dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
                dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for DropDownList selected item   
                dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

                dr = dt.NewRow();
                dr["RowNumber"] = 1;
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dt.Rows.Add(dr);

                //Store the DataTable in ViewState for future reference   
                ViewState["CurrentTable"] = dt;

                //Bind the Gridview   
                Gridview1.DataSource = dt;
                Gridview1.DataBind();

                //After binding the gridview, we can then extract and fill the DropDownList with Data   
                DropDownList ddl1 = (DropDownList)Gridview1.Rows[0].Cells[3].FindControl("DropDownList1");
                DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[4].FindControl("DropDownList2");
                FillDropDownList(ddl1);
                FillDropDownList(ddl2);
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

                            //extract the TextBox values   

                            TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox2");

                            dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                            dtCurrentTable.Rows[i]["Column2"] = box2.Text;

                            //extract the DropDownList Selected Items   

                            DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[3].FindControl("DropDownList1");
                            DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[4].FindControl("DropDownList2");

                            // Update the DataRow with the DDL Selected Items   

                            dtCurrentTable.Rows[i]["Column3"] = ddl1.SelectedItem.Text;
                            dtCurrentTable.Rows[i]["Column4"] = ddl2.SelectedItem.Text;

                        }

                        //Rebind the Grid with the current data to reflect changes   
                        Gridview1.DataSource = dtCurrentTable;
                        Gridview1.DataBind();
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

                            TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("TextBox1");
                            TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("TextBox2");

                            DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("DropDownList1");
                            DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("DropDownList2");

                            //Fill the DropDownList with Data   
                            FillDropDownList(ddl1);
                            FillDropDownList(ddl2);

                            if (i < dt.Rows.Count - 1)
                            {

                                //Assign the value from DataTable to the TextBox   
                                box1.Text = dt.Rows[i]["Column1"].ToString();
                                box2.Text = dt.Rows[i]["Column2"].ToString();

                                //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                                ddl1.ClearSelection();
                                ddl1.Items.FindByText(dt.Rows[i]["Column3"].ToString()).Selected = true;

                                ddl2.ClearSelection();
                                ddl2.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;

                            }

                            rowIndex++;
                        }
                    }
                }
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    SetInitialRow();
                }
            }

            protected void ButtonAdd_Click(object sender, EventArgs e)
            {
                AddNewRowToGrid();
            }

            protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
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
                LinkButton lb = (LinkButton)sender;
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
                    Gridview1.DataSource = dt;
                    Gridview1.DataBind();
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
        }
        
    
}