using businessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace CapacityPlanning
{
    public partial class ImportExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = HttpContext.Current.Server.MapPath("~/Upload/");
                string FilePath = FolderPath + DateTime.Now.ToString("dd-MM-yyyy")+".xlsx";
                FileUpload1.SaveAs(FilePath);
                Ui.Style.Add("display","none");
                gridView.Style.Add("display", "block");
                lblShow.Visible = true;
                lblShow.ForeColor = Color.Green;
                lblShow.Text = "Processing...";
                Import_To_Grid(FilePath, Extension, "Yes");
                lblShow.Visible = false;

            }
        }
        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls":
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx":
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;
            }
            conStr = string.Format(conStr, FilePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt1 = new DataTable();
            cmdExcel.Connection = connExcel;
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            oda.Fill(dt1);
            connExcel.Close();
            GridView1.Caption = Path.GetFileName(FilePath);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            DataTable dt=ConvertExcelToDataTable(FilePath);
            processData(dt);
        }
        private static DataTable ConvertExcelToDataTable(string FileName)
        {
            DataTable dtResult = null;
            int totalSheet = 0; //No of sheets on excel file  
            using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';"))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = string.Empty;
                if (dt != null)
                {
                    var tempDataTable = (from dataRow in dt.AsEnumerable()
                                         where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                         select dataRow).CopyToDataTable();
                    dt = tempDataTable;
                    totalSheet = dt.Rows.Count;
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                }
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds, "excelData");
                dtResult = ds.Tables["excelData"];
                objConn.Close();
                return dtResult; //Returning Dattable  
            }
        }
        private void processData(DataTable dt)
        {
            try
            {
                List<string> lstAccountName = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstAccountName.Add(dt.Rows[i]["Client"].ToString());
                }
                lstAccountName = lstAccountName.Distinct().ToList();

                List<string> lstRegion = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstRegion.Add(dt.Rows[i]["Region"].ToString());
                }
                lstRegion = lstRegion.Distinct().ToList();

                List<string> lstCountry = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstCountry.Add(dt.Rows[i]["Country"].ToString());
                }
                lstCountry = lstCountry.Distinct().ToList();

                List<string> lstCity = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstCity.Add(dt.Rows[i]["City"].ToString());
                }
                lstCity = lstCity.Distinct().ToList();

                ImportExcelBL account = new ImportExcelBL();
                var lstAccount = account.AccountName();
                List<string> lstInsertAccount = new List<string>();
                lstInsertAccount = lstAccountName.Except(lstAccount).ToList();

                var lstRegionName = account.RegionName();
                List<string> lstInsertRegion = lstRegion.Except(lstRegionName).ToList();

                var lstCountryName = account.CountryName();
                List<string> lstInsertCountryName = lstCountry.Except(lstCountryName).ToList();

                List<string> lstRegionNAmes = new List<string>();
                foreach (var item in lstInsertCountryName)
                {
                    var dt1 = dt.Select("Country = '" + item + "'").CopyToDataTable().DefaultView.ToTable(true, "Region");
                    lstRegionNAmes.Add(dt1.Rows[0][0].ToString());
                }

                var lstCityName = account.CityName();
                List<string> lstInsertCity = lstCity.Except(lstCityName).ToList();

                List<string> lstRegionNameForCity = new List<string>();
                List<string> lstCountryNameForCity = new List<string>();
                foreach (var item in lstInsertCity)
                {
                    var dt1 = dt.Select("City = '" + item + "'").CopyToDataTable().DefaultView.ToTable(true, "Region");
                    lstRegionNameForCity.Add(dt1.Rows[0][0].ToString());
                    var dt2 = dt.Select("City = '" + item + "'").CopyToDataTable().DefaultView.ToTable(true, "Country");
                    lstCountryNameForCity.Add(dt2.Rows[0][0].ToString());
                }

                List<string> lstCityNameForAcc = new List<string>();
                foreach (var item in lstInsertAccount)
                {
                    var dt1 = dt.Select("Client = '" + item + "'").CopyToDataTable().DefaultView.ToTable(true, "City");
                    lstCityNameForAcc.Add(dt1.Rows[0][0].ToString());
                }
                CPT_RegionMaster details = new CPT_RegionMaster();
                if(lstInsertRegion.Count>0)
                {
                    foreach (var item in lstInsertRegion)
                    {
                        details.RegionName = item;
                        details.IsActive = true;
                        ImportExcelBL.InsertRegion(details);
                    }
                }
                
                CPT_CountryMaster country = new CPT_CountryMaster();
                if(lstInsertCountryName.Count>0)
                {
                    for (int item = 0; item < lstInsertCountryName.Count; item++)
                    {
                        country.CountryName = lstInsertCountryName[item];
                        country.RegionID = ImportExcelBL.getRegionID(lstRegionNAmes)[item];
                        country.IsActive = true;
                        ImportExcelBL.InsertCountry(country);
                    }
                }
                
                CPT_CityMaster city = new CPT_CityMaster();
                if(lstInsertCity.Count>0)
                {
                    for (int i = 0; i < lstInsertCity.Count; i++)
                    {
                        city.CityName = lstInsertCity[i];
                        city.RegionID = ImportExcelBL.getRegionID(lstRegionNameForCity)[i];
                        city.CountryID = ImportExcelBL.getCountryID(lstCountryNameForCity)[i];
                        city.IsActive = true;
                        ImportExcelBL.InsertCity(city);
                    }
                }
               
                CPT_AccountMaster accountDetails = new CPT_AccountMaster();
                if(lstInsertAccount.Count>0)
                {
                    for (int i = 0; i < lstInsertAccount.Count; i++)
                    {
                        accountDetails.AccountName = lstInsertAccount[i];
                        accountDetails.CityID = ImportExcelBL.getCityID(lstCityNameForAcc)[i];
                        accountDetails.IsActive = true;
                        ImportExcelBL.InsertAccount(accountDetails);

                    }
                }
                
            }
            catch (Exception ex)
            {
                lblShow.ForeColor = Color.Red;
                lblShow.Text = ex.Message;
            }
        }
        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string FolderPath = HttpContext.Current.Server.MapPath("Upload/");
            string FileName = GridView1.Caption;
            string Extension = Path.GetExtension(FileName);
            string FilePath = Server.MapPath(FolderPath + FileName);
            Import_To_Grid(FilePath, Extension, "Yes");
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        
    }
}