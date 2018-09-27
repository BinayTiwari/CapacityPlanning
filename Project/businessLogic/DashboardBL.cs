using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Entity;
using System.Data.SqlClient;
using System.Configuration;
namespace businessLogic
{
    public class DashboardBL
    {
        public static void showDsVsRes(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {


                    var query = (from p in db.CPT_DesignationMaster
                                 join q in db.CPT_ResourceMaster on p.DesignationMasterID equals q.DesignationID
                                 group p by p.DesignationName into grp
                                 select new
                                 {
                                     Designation_Name = grp.Key,
                                     NoOfResources = grp.Count()
                                 }).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void showRMVsR(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from p in db.CPT_ResourceMaster
                                 join q in db.CPT_ResourceMaster on p.ReportingManagerID equals q.EmployeeMasterID
                                 group q by q.EmployeetName into grp
                                 select new
                                 {
                                     ReportingManager = grp.Key,
                                     NoOfReporter = grp.Count()
                                 }
                                 ).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void showAccVsNoR(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    //var query = (from p in db.CPT_AllocateResource 
                    //              join  )
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void showCapVsResDem(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query = (from c in db.CPT_ResourceDetails
                                 join d in db.CPT_RoleMaster on c.ResourceTypeID equals d.RoleMasterID

                                 group d by d.RoleName into grp
                                 select new
                                 {
                                     role = grp.Key,
                                     noOfRes = grp.Count()
                                 }).ToList();
                    rpt.DataSource = query;
                    rpt.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public static void showCap(Repeater rpt)
        {
            try
            {
                using (CPContext db = new CPContext())
                {
                    var query1 = (from p in db.CPT_RoleMaster
                                  join q in db.CPT_ResourceMaster on p.RoleMasterID equals q.RolesID
                                  group p by p.RoleName into grp
                                  select new
                                  {
                                      Role_Name = grp.Key,
                                      NoOfResources = grp.Count()
                                  }).ToList();
                    rpt.DataSource = query1;
                    rpt.DataBind();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void displayDesigVsRes(Chart chart)
        {
            using (CPContext db = new CPContext())
            {
                var acc = (from p in db.CPT_DesignationMaster
                           join q in db.CPT_ResourceMaster on p.DesignationMasterID equals q.DesignationID
                           group p by p.DesignationName into grp
                           select new
                           {
                               Designation_Name = grp.Key,
                               NoOfResources = grp.Count()
                           }).ToList();

                chart.Series[0].ToolTip = "#VALX : #VALY";
                chart.Series[0].ChartType = SeriesChartType.Pie;
                //Title ty1 = chart.Titles.Add("ty1");
                //ty1.ForeColor = System.Drawing.Color.Blue;
                //ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);
                //ty1.Text = "Designation V/S Number of Resources";
                chart.Series[0]["PieLabelStyle"] = "Disabled";
                if (acc.Count() > 0)
                {

                    string[] xValues = new string[acc.Count()];

                    int[] yValues = new int[acc.Count()];
                    int count = 0;
                    foreach (var obj in acc)
                    {
                        xValues[count] = obj.Designation_Name;
                        yValues[count] = obj.NoOfResources;
                        count++;
                    }
                    // chart.Series[0].ChartType = SeriesChartType.SplineArea;
                    chart.Series[0].Points.DataBindXY(xValues, yValues);

                }
            }
        }

        public void displayOppoPro(Chart chart)
        {
            using (CPContext db = new CPContext())
            {
                var acc = (from p in db.CPT_AllocateResource
                           join q in db.CPT_ResourceDemand on p.RequestID equals q.RequestID
                           join r in db.CPT_OpportunityMaster on q.OpportunityID equals r.OpportunityID
                           group p by r.OpportunityType into grp
                           select new
                           {
                               Designation_Name = grp.Key,
                               NoOfResources = grp.Count()
                           }).ToList();

                chart.Series[0].ToolTip = "#VALX : #VALY";
                chart.Series[0].ChartType = SeriesChartType.Pie;
                if (acc.Count() > 0)
                {

                    string[] xValues = new string[acc.Count()];
                    int[] yValues = new int[acc.Count()];
                    int count = 0;
                    foreach (var obj in acc)
                    {
                        xValues[count] = obj.Designation_Name;
                        yValues[count] = obj.NoOfResources;
                        count++;
                    }                   
                    chart.Series[0].Points.DataBindXY(xValues, yValues);
                    foreach (DataPoint p in chart.Series[0].Points)
                    {
                        p.Label = "#PERCENT\n#VALX";
                    }

                }
            }
        }



        public static void DisplayAccountWiseResources(Repeater rpt)
        {

            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "With Employees AS ( SELECT[CPT_AccountMaster].[AccountName],[CPT_RoleMaster].[RoleName], COUNT([CPT_AllocateResource].[RoleMasterID]) As ResourseNumber" +
                                    " FROM CPT_AccountMaster INNER JOIN CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN" +
                                   " CPT_RoleMaster ON CPT_AllocateResource.RoleMasterID = CPT_RoleMaster.RoleMasterID Where[AccountID] = [AccountID] AND[CPT_RoleMaster].RoleMasterID NOT IN(1,4,5,8,15,20) AND [CPT_AllocateResource].ISDeployed = 1 " +
                                   " Group by[CPT_AllocateResource].[RoleMasterID],[CPT_RoleMaster].[RoleName],[CPT_AccountMaster].[AccountName])" +
                                   " Select[AccountName],ISNULL([Project Manager],0) AS ProjectManager, ISNULL([Developer],0) AS Developer, ISNULL([Team Lead],0) As TeamLead, ISNULL([Quality Analyst],0) AS QualityAnalyst, ISNULL([Solution Architect],0) AS Architect, ISNULL([Senior Developer],0) As SeniorDeveloper, ISNULL([Business Analyst],0) As BUsinessAnalyst from Employees" +
                                    " pivot (" +
                                    " SUM([ResourseNumber])" +
                                    "FOR [RoleName]" +
                                    "IN ([Project Manager],[Developer],[Team Lead],[Quality Analyst],[Solution Architect],[Senior Developer],[Business Analyst])" +
                                     ") as pivotTable";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    rpt.DataSource = SqlCom.ExecuteReader();
                    rpt.DataBind();
                    //  t = reader["Total"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void displayDesigVsResBar(Chart chart)
        {
            using (CPContext db = new CPContext())
            {
                var acc = (from p in db.CPT_DesignationMaster
                           join q in db.CPT_ResourceMaster on p.DesignationMasterID equals q.DesignationID
                           group p by p.DesignationName into grp
                           select new
                           {
                               Designation_Name = grp.Key,
                               NoOfResources = grp.Count()
                           }).ToList();
                chart.Series[0].ToolTip = "#VALX : #VALY";
                chart.Series[0].ChartType = SeriesChartType.Bar;
                if (acc.Count() > 0)
                {
                    string[] xValues = new string[acc.Count()];
                    int[] yValues = new int[acc.Count()];
                    int count = 0;
                    foreach (var obj in acc)
                    {
                        xValues[count] = obj.Designation_Name;
                        yValues[count] = obj.NoOfResources;

                        count++;
                    }
                    chart.ChartAreas[0].AxisX.Interval = 1;
                    chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                    chart.Series[0].SmartLabelStyle.Enabled = true;
                    chart.Series[0].ChartType = SeriesChartType.Column;
                    chart.Series[0].Points.DataBindXY(xValues, yValues);
                }
            }
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;


        }
        public static void TotalStregth(Label NumberOfResources)
        {
            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "SELECT COUNT(CPT_ResourceMaster.EmployeeMasterID) Total  FROM CPT_AccountMaster INNER JOIN  CPT_AllocateResource ON CPT_AccountMaster.AccountMasterID = CPT_AllocateResource.AccountID INNER JOIN  CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID RIGHT OUTER JOIN  CPT_ResourceMaster INNER JOIN  CPT_DesignationMaster ON CPT_ResourceMaster.DesignationID = CPT_DesignationMaster.DesignationMasterID ON  CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID "+
                                   " WHERE CPT_ResourceMaster.RolesID NOT IN(1,4,5,8,15,20)   AND ISDeployed = 1 ";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    NumberOfResources.Text = SqlCom.ExecuteScalar().ToString();
                    //  t = reader["Total"].ToString();
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void OpenResourceRequest(Repeater rpt)
        {
            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = " SELECT  CPT_ResourceDetails.RequestID, CPT_RoleMaster.RoleName, "+
                                  "   CPT_SkillsMaster.SkillsName, CPT_ResourceDetails.NoOfResources, CPT_ResourceDetails.StartDate, CPT_ResourceDetails.EndDate, " +
                                    " CPT_OpportunityMaster.OpportunityType,  CPT_AccountMaster.AccountName,  ISNULL(dbo.TotalResurcesAllocated(CPT_RoleMaster.RoleMasterID, CPT_ResourceDetails.RequestDetailID),0) As Allocated" +
                                    " FROM CPT_SkillsMaster INNER JOIN " +
                                   "  CPT_ResourceDetails INNER JOIN " +
                                    "  CPT_RoleMaster ON CPT_ResourceDetails.ResourceTypeID = CPT_RoleMaster.RoleMasterID ON " +
                                     " CPT_SkillsMaster.SkillsMasterID = CPT_ResourceDetails.SkillID INNER JOIN " +
                                     " CPT_ResourceDemand ON CPT_ResourceDetails.RequestID = CPT_ResourceDemand.RequestID INNER JOIN " +
                                     " CPT_AccountMaster ON CPT_ResourceDemand.AccountID = CPT_AccountMaster.AccountMasterID INNER JOIN " +
                                     " CPT_OpportunityMaster ON CPT_ResourceDemand.OpportunityID = CPT_OpportunityMaster.OpportunityID " +
                                      "  WHERE CPT_ResourceDemand.StatusMasterID = 19 ORDER BY CPT_ResourceDetails.RequestID";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    rpt.DataSource = SqlCom.ExecuteReader();
                    rpt.DataBind();
                    //  t = reader["Total"].ToString();
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void OnBench(Label NumberOfResourcesOnBench)
        {
            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "Select COUNT(EmployeetName) FROM CPT_ResourceMaster WHERE RolesID NOT IN(1,4,5,8,15,20) AND EmployeeMasterID NOT IN "+
                                   "(SELECT  ResourceID FROM  CPT_AllocateResource WHERE ISDeployed = 1 ) and ISDELETED =0";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    NumberOfResourcesOnBench.Text = SqlCom.ExecuteScalar().ToString();
                    //  t = reader["Total"].ToString();
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static void OpenRequests(Label NumberOpenRequests)
        {
            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "SELECT   COUNT(CPT_ResourceDetails.NoOfResources) AS Total FROM CPT_ResourceDemand INNER JOIN  CPT_ResourceDetails ON CPT_ResourceDemand.RequestID = CPT_ResourceDetails.RequestID Where CPT_ResourceDemand.StatusMasterID = 19";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    NumberOpenRequests.Text = SqlCom.ExecuteScalar().ToString();
                    //  t = reader["Total"].ToString();
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void NewJoiners(Label CountToltal)
        {
            try
            {

                SqlConnection SqlConn = new SqlConnection();
                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "Select COUNT(*) AS CountToltal FROM [dbo].[CPT_NewJoiners]";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    CountToltal.Text = SqlCom.ExecuteScalar().ToString();
                    //  t = reader["Total"].ToString();
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public void displayMgrVsRpt(Chart chart)
        {
            using (CPContext db = new CPContext())
            {
                var acc = (from p in db.CPT_ResourceMaster
                           join q in db.CPT_ResourceMaster on p.ReportingManagerID equals q.EmployeeMasterID
                           group q by q.EmployeetName into grp
                           select new
                           {
                               ReportingManager = grp.Key,
                               NoOfReporter = grp.Count()
                           }
                             ).ToList();



                chart.Series[0].ToolTip = "#VALX : #VALY";
                chart.Series[0].ChartType = SeriesChartType.Bar;

                //Title ty1 = chart.Titles.Add("ty1");
                //ty1.ForeColor = System.Drawing.Color.Blue;
                //ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                //ty1.Text = "Reporting Manager V/S Number of Reporters";
                //chart.Series[0]["PieLabelStyle"] = "Disabled";


                if (acc.Count() > 0)
                {

                    string[] xValues = new string[acc.Count()];

                    int[] yValues = new int[acc.Count()];


                    int count = 0;

                    foreach (var obj in acc)
                    {
                        xValues[count] = obj.ReportingManager;
                        yValues[count] = obj.NoOfReporter;

                        count++;
                    }
                    chart.ChartAreas[0].AxisX.Interval = 1;
                    chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                    chart.Series[0].ChartType = SeriesChartType.Column;
                    chart.Series[0].Points.DataBindXY(xValues, yValues);
                }
            }

        }
        public static void displayRoleVsDem(Chart chart)
        {
            using (CPContext db = new CPContext())
            {
                var RoleDemand = (from c in db.CPT_ResourceDetails
                                  join d in db.CPT_RoleMaster on c.ResourceTypeID equals d.RoleMasterID

                                  group d by d.RoleName into grp
                                  select new
                                  {
                                      role = grp.Key,
                                      noOfRes = grp.Count()
                                  }).ToList();
                chart.Series[0].ToolTip = "#VALX : #VALY";
                chart.Series[0].ChartType = SeriesChartType.Bar;
                //Title ty1 = chart.Titles.Add("ty1");
                //ty1.ForeColor = System.Drawing.Color.Blue;
                //ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                //ty1.Text = "Role Vs Demand";
                if (RoleDemand.Count() > 0)
                {

                    string[] xValues = new string[RoleDemand.Count()];

                    int[] yValues = new int[RoleDemand.Count()];


                    int count = 0;

                    foreach (var obj in RoleDemand)
                    {
                        xValues[count] = obj.role;
                        yValues[count] = obj.noOfRes;

                        count++;
                    }
                    chart.ChartAreas[0].AxisX.Interval = 1;
                    chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                    chart.Series[0].ChartType = SeriesChartType.Line;
                    chart.Series[0].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[0].MarkerSize = 10;
                    chart.Series[0].MarkerColor = System.Drawing.Color.Blue;
                    chart.Series[0].Points.DataBindXY(xValues, yValues);


                }
            }
        }
        public static void showRoleVsCapacity(Chart chart)
        {
            using (CPContext db = new CPContext())
            {
                var RoleCap = (from p in db.CPT_RoleMaster
                               join q in db.CPT_ResourceMaster on p.RoleMasterID equals q.RolesID
                               group p by p.RoleName into grp
                               select new
                               {
                                   Role_Name = grp.Key,
                                   NoOfResources = grp.Count()
                               }).ToList();
                chart.Series[0].ToolTip = "#VALX : #VALY";

                //chart.Series[0].ChartType = SeriesChartType.Bar;
                //Title ty1 = chart.Titles.Add("ty1");
                //ty1.ForeColor = System.Drawing.Color.Blue;
                //ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                // ty1.Text = "Role Vs Capacity";
                if (RoleCap.Count() > 0)
                {

                    string[] xValues = new string[RoleCap.Count()];

                    int[] yValues = new int[RoleCap.Count()];


                    int count = 0;

                    foreach (var obj in RoleCap)
                    {
                        xValues[count] = obj.Role_Name;
                        yValues[count] = obj.NoOfResources;

                        count++;
                    }
                    chart.ChartAreas[0].AxisX.Interval = 1;
                    chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
                    //chart.Series[0].Label = "Y = #VALY\nX = #VALX";
                    //chart.Series[0].SmartLabelStyle.Enabled = true;
                    chart.Series[0].ChartType = SeriesChartType.Line;
                    chart.Series[0].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[0].MarkerSize = 10;
                    chart.Series[0].MarkerColor = System.Drawing.Color.Blue;

                    chart.Series[0].Points.DataBindXY(xValues, yValues);


                }
            }
        }



    }
}
