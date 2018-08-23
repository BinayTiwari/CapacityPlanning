using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using Entity;
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

                Title ty1 = chart.Titles.Add("ty1");
                ty1.ForeColor = System.Drawing.Color.DarkRed;
                ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                ty1.Text = "Designation V/S Number of Resources";
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

                Title ty1 = chart.Titles.Add("ty1");
                ty1.ForeColor = System.Drawing.Color.DarkRed;
                ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                ty1.Text = "Reporting Manager V/S Number of Reporters";
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
                Title ty1 = chart.Titles.Add("ty1");
                ty1.ForeColor = System.Drawing.Color.DarkRed;
                ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                ty1.Text = "Role Vs Demand";
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

                    chart.Series[0].ChartType = SeriesChartType.Column;

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
                Title ty1 = chart.Titles.Add("ty1");
                ty1.ForeColor = System.Drawing.Color.DarkRed;
                ty1.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Underline);

                ty1.Text = "Role Vs Capacity";
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

                    chart.Series[0].ChartType = SeriesChartType.Bar;

                    chart.Series[0].Points.DataBindXY(xValues, yValues);


                }
            }
        }



    }
}
