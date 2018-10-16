using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;

namespace MailAutomation
{
    public class Program
    {
        static void Main(string[] args)
        {
            SendMail();
        }

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;
        }

        public static void SendMail()
        {
            SqlConnection SqlConn = new SqlConnection();
            try
            {
                List<string> lstEmail = new List<string>();
                List<string> lstManagerName = new List<string>();
                List<string[]> lstDetails = new List<string[]>();

                SqlConn.ConnectionString = GetConnectionString();
                string SqlString = "SELECT CPT_ResourceMaster.EmployeetName, CPT_AccountMaster.AccountName, CPT_ResourceDemand.ProcessName," +
                    " CPT_ResourceMaster.ReportingManagerID,[dbo].[Owner](CPT_ResourceMaster.ReportingManagerID) As Manager," +
                    " [dbo].[ReportingManager] (CPT_ResourceMaster.ReportingManagerID) As ReportingManagerEmail," +
                    " CAST(CPT_AllocateResource.EndDate as  Varchar(12)) as ReleaseDate" +
                    " FROM CPT_AllocateResource INNER JOIN CPT_AccountMaster ON CPT_AllocateResource.AccountID = CPT_AccountMaster.AccountMasterID" +
                    " INNER JOIN CPT_ResourceDemand ON CPT_AllocateResource.RequestID = CPT_ResourceDemand.RequestID INNER JOIN" +
                    " CPT_ResourceMaster ON CPT_AllocateResource.ResourceID = CPT_ResourceMaster.EmployeeMasterID" +
                    " where CPT_AllocateResource.EndDate < GETDATE()+7 AND CPT_AllocateResource.Released = 0 order by CPT_AllocateResource.EndDate";

                using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
                {
                    SqlConn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(SqlCom);
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        lstEmail.Add(row["ReportingManagerEmail"].ToString());
                        lstManagerName.Add(row["Manager"].ToString());
                    }
                    lstEmail = lstEmail.Distinct().ToList();
                    lstManagerName = lstManagerName.Distinct().ToList();

                    int i = 0;
                    while (i < lstEmail.Count)
                    {                       
                        foreach (DataRow row in dt.Rows)
                        {
                            if (lstEmail[i] == row["ReportingManagerEmail"].ToString())
                            {
                                string[] arr = new string[4];
                                arr[0] = row["EmployeetName"].ToString();
                                arr[1] = row["AccountName"].ToString();
                                arr[2] = row["ProcessName"].ToString();
                                arr[3] = row["ReleaseDate"].ToString();
                                lstDetails.Add(arr);
                            }
                        }
                        Email(lstEmail[i], lstManagerName[i], lstDetails);
                        lstDetails.Clear();
                        i++;
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                SqlConn.Close();
            }
        }

        public static void Email(string EmailID,string MangerName, List<string[]> Body)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("resourceallocationgic@gmail.com");
            mail.To.Add("rahul.chaurasia@gridinfocom.com");
            //mail.CC.Add("binay.tiwari@gridinfocom.com,gautam.rastogi@gridinfocom.com,heena.dudeja@gridinfocom.com");
            mail.Subject = "Resources to be released";
            mail.Body = "Hi " + MangerName + ",<br><p style='color: black; '>These are the resources to be released.</p><table border='1'><tr><th>EmployeeName</th>" +
                        " <th>Project</th> <th>ProcessName</th> <th>Release Date</th></tr>";
            foreach(var item in Body)
            {
                mail.Body += "<tr><td>" + item[0] + "</td>" + "<td>" + item[1] + "</td>" + "<td>" + item[2] + "</td>" + "<td>" + item[3] + "</td></tr>";
            }
            mail.Body += "</table><br> <p><b>Warm Regards, </b></p> <p><b>Work Force Allocation</b></p>" +
                         " <p><h6>This email is system generated, please do not respond to this email.</h6></p>";
            
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("resourceallocationgic@gmail.com", "incorrect@gic");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        
    }
}
