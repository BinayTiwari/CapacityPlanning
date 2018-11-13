using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using Entity;


namespace MessageTemplate
{
    public class TokenMessageTemplate
    {

        string ccAddress;
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CPContext"].ConnectionString;
        }

        string ReplaceTokens(string template, Dictionary<string, string> replacements)
        {
            var rex = new Regex(@"\${([^}]+)}");
            return (rex.Replace(template, delegate (Match m)
            {
                string key = m.Groups[1].Value;
                string rep = replacements.ContainsKey(key) ? replacements[key] : m.Value;
                return (rep);
            }));
        }

        public void SendEmail(CPT_EmailTemplate valemail)
        {
            string token;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            switch (valemail.Name)
            {
                case "Registration":
                    MessageTemplate(ref valemail);
                    int i = 0;
                    foreach (string address in valemail.To)
                    {
                        dict.Add("FORUMNAME", "Capacity Planning");
                        dict.Add("NAME", valemail.ToUserName[i].ToString());
                        dict.Add("EMAIL", address);
                        dict.Add("UID", valemail.UID);
                        token = ReplaceTokens(valemail.Body, dict);
                        valemail.Body = token;
                        send(ConfigurationManager.AppSettings["FromEmail"].ToString(), address, valemail.Subject, token);
                    }
                    break;

                case "ForgetPassword":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("EMAIL", valemail.Name);
                    dict.Add("UID", valemail.UID);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "ResourceDemand":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("EMAIL", valemail.Name);
                    //dict.Add("BccEmail", valemail.BccEmailAddresses);
                    //dict.Add("UID", valemail.UID);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    ccAddress = valemail.BccEmailAddresses;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "UpdateResourceDemand":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("EMAIL", valemail.Name);
                    //dict.Add("BccEmail", valemail.BccEmailAddresses);
                    //dict.Add("UID", valemail.UID);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    ccAddress = valemail.BccEmailAddresses;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "DeclinedOffer":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("JOINER", valemail.JOINER);
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("EMAIL", valemail.Name);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "AlignedResource":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("ACCOUNT", valemail.ACCOUNT);
                    dict.Add("STARTDATE", valemail.STARTDATE);
                    dict.Add("ENDDATE", valemail.ENDDATE);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    ccAddress += valemail.CC[0];
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "Onboard":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("JOINER", valemail.JOINER);
                    dict.Add("DESIGNATION", valemail.DESIGNATION);
                    dict.Add("BASELOCATION", valemail.BASELOCATION);
                    dict.Add("DOJ", valemail.DOJ);
                    dict.Add("EMAIL", valemail.EMAIL);
                    dict.Add("PHONE", valemail.PHONE);
                    dict.Add("REPORTINGMGR", valemail.REPORTINGMGR);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "ReleaseResource":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("PROJECT", valemail.PROJECT);
                    dict.Add("PROCESS", valemail.PROCESS);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    ccAddress = valemail.BccEmailAddresses;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "DeployResource":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("PROJECT", valemail.PROJECT);
                    dict.Add("PROCESS", valemail.PROCESS);
                    dict.Add("STARTDATE", valemail.STARTDATE);
                    dict.Add("ENDDATE", valemail.ENDDATE);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    if (!valemail.BccEmailAddresses.Contains(valemail.CC[0]))
                    {
                        ccAddress += valemail.CC[0] + ",";
                    }
                    ccAddress += valemail.BccEmailAddresses;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "RequestAction":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("PROJECT", valemail.PROJECT);
                    dict.Add("PROCESS", valemail.PROCESS);
                    dict.Add("STATUS", valemail.STATUS);
                    dict.Add("STATOR", valemail.STATOR);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    ccAddress = valemail.BccEmailAddresses;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;

                case "DropResourceRequest":
                    MessageTemplate(ref valemail);
                    dict.Add("FORUMNAME", "Work Force Allocation");
                    dict.Add("NAME", valemail.ToUserName[0].ToString());
                    dict.Add("EMAIL", valemail.EMAIL);
                    dict.Add("REQUESTID", valemail.STATUS);
                    token = ReplaceTokens(valemail.Body, dict);
                    valemail.Body = token;
                    ccAddress = valemail.BccEmailAddresses;
                    send(ConfigurationManager.AppSettings["FromEmail"].ToString(), valemail.To[0], valemail.Subject, token);
                    break;
            }

        }

        private void MessageTemplate(ref CPT_EmailTemplate valemail)
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = GetConnectionString();
            string SqlString = "SELECT Id, Name, BccEmailAddresses, Subject, Body, IsActive, EmailAccountId, LimitedToStores FROM  CPT_EmailTemplate Where Name = '" + valemail.Name + "'";

            using (SqlCommand SqlCom = new SqlCommand(SqlString, SqlConn))
            {
                SqlConn.Open();
                SqlDataReader reader = SqlCom.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        valemail.Subject = Convert.ToString(reader["Subject"]);
                        valemail.Body = Convert.ToString(reader["Body"]);
                        valemail.BccEmailAddresses = Convert.ToString(reader["BccEmailAddresses"]);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void send(string fromAddress, string toAddress, string subject, string body)
        {
            try
            {
                const string fromPassword = "incorrect@gic";

                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;

                }
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(fromAddress, "Work Force Allocation");
                if (!string.IsNullOrEmpty(ccAddress))
                {
                    string[] CCAddr = ccAddress.Split(',');
                    foreach (string add in CCAddr)
                    {
                        mail.CC.Add(add);
                    }

                }
                mail.To.Add(toAddress);
                mail.Subject = subject;
                mail.Body = body;
                // Passing values to smtp object
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
