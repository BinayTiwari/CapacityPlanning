using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapacityPlanning
{
    public partial class SalesFunnel : System.Web.UI.Page
    {
        List<string> lstRole = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                getRole(rptSells);
            }
        }
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;
        }
        public void getRole(Repeater rpt)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "select RoleName from [dbo].[CPT_RoleMaster] where isactive=1 and rolemasterid in(6,7,9,13,14,21,23)";
            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                SqlConn.Open();
                SqlDataReader reader = SqlCom.ExecuteReader();
                while (reader.Read())
                {
                    lstRole.Add(reader["RoleName"].ToString());
                }
                rpt.DataSource = lstRole;
                rpt.DataBind();
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lstVal = new List<int>();
                List<double> lstDiv = new List<double>();
                List<double> lstSub = new List<double>();
                List<double> lstMR = new List<double>();
                foreach (RepeaterItem item in rptSells.Items)
                {
                    TextBox txtVal = (TextBox)item.FindControl("txtRequired");
                    lstVal.Add(Convert.ToInt32(txtVal.Text.Trim()));

                }
                int sum = 0;
                foreach(var item in lstVal)
                {
                    sum = sum + item;
                }
                lblManDays.Text = sum.ToString()+" Man Days";

                foreach(var item in lstVal)
                {
                    lstDiv.Add(sum / item);
                }

                for(int i=0;i<lstDiv.Count;i++)
                {
                    lstSub.Add(lstDiv[i] - lstVal[i]);
                }

                foreach(var item in lstSub)
                {
                    lstMR.Add(item / 20);
                }

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "select RoleName from [dbo].[CPT_RoleMaster] where isactive=1 and rolemasterid in(6,7,9,13,14,21,23)";
                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    SqlDataReader reader = SqlCom.ExecuteReader();
                    while (reader.Read())
                    {
                        lstRole.Add(reader["RoleName"].ToString());
                    }
                }
                    DataTable table = new DataTable();
                table.Columns.Add("RoleName", typeof(string));
                table.Columns.Add("Percentage", typeof(double));
                for(int i=0;i< lstMR.Count;i++)
                {
                    DataRow dr = table.NewRow();
                    dr["RoleName"] = lstRole[i];
                    dr["Percentage"] = lstMR[i];
                    table.Rows.Add(dr);
                }
                myDIV.Style.Add("display", "none");
                Div.Style.Add("display", "block");
                btnCalculate.Visible = false;
                RptShow.DataSource = table;
                RptShow.DataBind();

                //Response.Write("<script>alert('sum= "+sum+"')</script>");
            }
            catch (Exception ex)
            {
                var message = new JavaScriptSerializer().Serialize(ex.Message.ToString());
                var script = string.Format("alert({0});", message);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", script, true);

                //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", script, true);
            }
        }
    }
}