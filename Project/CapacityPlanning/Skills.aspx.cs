using businessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;

namespace CapacityPlanning
{
    public partial class Skills : System.Web.UI.Page
    {
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                SetSkillsBL.GetNewSkills(rptRPA, rptLangPrg, rptMS, rptFrk, rptDB, rptOther);
            }
        }

        protected void InsertEmpSkills(object sender, EventArgs e)
        {
            try
            {
                string SkillIDs = "";
                
                string path = HttpContext.Current.Server.MapPath("Documents/");
                List<CPT_Certificate> lstCertificates = new List<CPT_Certificate>();                
                bool flag = SetSkillsBL.CheckEmpID(Convert.ToInt32(EmpID.Text));
                               
                if (flag)
                {
                    foreach (RepeaterItem item in rptRPA.Items)
                    {
                        CPT_Certificate details = new CPT_Certificate();
                        CheckBox chk = (CheckBox)item.FindControl("chkRPA");
                        DropDownList ddlRating = (DropDownList)item.FindControl("ddlRPARating");
                        FileUpload filePath = (FileUpload)item.FindControl("RPACertificate");
                        if (chk.Checked)
                        {
                            details.EmployeeID = Convert.ToInt32(EmpID.Text);
                            details.SkillID = Convert.ToInt32(chk.Attributes["SkillID"]);
                            SkillIDs += chk.Attributes["SkillID"] + ",";
                            details.Rating = Convert.ToInt32(ddlRating.SelectedValue);
                            if (filePath.HasFile)
                            {                     
                                filePath.SaveAs(path + filePath.FileName);
                                details.CertificatePath = path + filePath.FileName;
                            }
                            
                            lstCertificates.Add(details);
                        }
                    }
                    foreach (RepeaterItem item in rptLangPrg.Items)
                    {
                        CPT_Certificate details = new CPT_Certificate();
                        CheckBox chk = (CheckBox)item.FindControl("chkLangPrg");
                        DropDownList ddlRating = (DropDownList)item.FindControl("ddlLangPrgRating");
                        FileUpload filePath = (FileUpload)item.FindControl("LangPrgCertificate");
                        if (chk.Checked)
                        {
                            details.EmployeeID = Convert.ToInt32(EmpID.Text);
                            details.SkillID = Convert.ToInt32(chk.Attributes["SkillID"]);
                            SkillIDs += chk.Attributes["SkillID"] + ",";
                            details.Rating = Convert.ToInt32(ddlRating.SelectedValue);
                            if (filePath.HasFile)
                            {
                                filePath.SaveAs(path + filePath.FileName);
                                details.CertificatePath = path + filePath.FileName;
                            }
                            lstCertificates.Add(details);
                        }
                    }
                    foreach (RepeaterItem item in rptMS.Items)
                    {
                        CPT_Certificate details = new CPT_Certificate();
                        CheckBox chk = (CheckBox)item.FindControl("chkMS");
                        DropDownList ddlRating = (DropDownList)item.FindControl("ddlMSRating");
                        FileUpload filePath = (FileUpload)item.FindControl("MSCertificate");
                        if (chk.Checked)
                        {
                            details.EmployeeID = Convert.ToInt32(EmpID.Text);
                            details.SkillID = Convert.ToInt32(chk.Attributes["SkillID"]);
                            SkillIDs += chk.Attributes["SkillID"] + ",";
                            details.Rating = Convert.ToInt32(ddlRating.SelectedValue);
                            if (filePath.HasFile)
                            {
                                filePath.SaveAs(path + filePath.FileName);
                                details.CertificatePath = path + filePath.FileName;
                            }
                            lstCertificates.Add(details);
                        }
                    }
                    foreach (RepeaterItem item in rptFrk.Items)
                    {
                        CPT_Certificate details = new CPT_Certificate();
                        CheckBox chk = (CheckBox)item.FindControl("chkFrk");
                        DropDownList ddlRating = (DropDownList)item.FindControl("ddlFrkRating");
                        FileUpload filePath = (FileUpload)item.FindControl("FrkCertificate");
                        if (chk.Checked)
                        {
                            details.EmployeeID = Convert.ToInt32(EmpID.Text);
                            details.SkillID = Convert.ToInt32(chk.Attributes["SkillID"]);
                            SkillIDs += chk.Attributes["SkillID"] + ",";
                            details.Rating = Convert.ToInt32(ddlRating.SelectedValue);
                            if (filePath.HasFile)
                            {
                                filePath.SaveAs(path + filePath.FileName);
                                details.CertificatePath = path + filePath.FileName;
                            }
                            lstCertificates.Add(details);
                        }
                    }
                    foreach (RepeaterItem item in rptDB.Items)
                    {
                        CPT_Certificate details = new CPT_Certificate();
                        CheckBox chk = (CheckBox)item.FindControl("chkDB");
                        DropDownList ddlRating = (DropDownList)item.FindControl("ddlDBRating");
                        FileUpload filePath = (FileUpload)item.FindControl("DBCertificate");
                        if (chk.Checked)
                        {
                            details.EmployeeID = Convert.ToInt32(EmpID.Text);
                            details.SkillID = Convert.ToInt32(chk.Attributes["SkillID"]);
                            SkillIDs += chk.Attributes["SkillID"] + ",";
                            details.Rating = Convert.ToInt32(ddlRating.SelectedValue);
                            if (filePath.HasFile)
                            {
                                filePath.SaveAs(path + filePath.FileName);
                                details.CertificatePath = path + filePath.FileName;
                            }
                            lstCertificates.Add(details);
                        }
                    }
                    foreach (RepeaterItem item in rptOther.Items)
                    {
                        CPT_Certificate details = new CPT_Certificate();
                        CheckBox chk = (CheckBox)item.FindControl("chkOther");
                        DropDownList ddlRating = (DropDownList)item.FindControl("ddlOtherRating");
                        FileUpload filePath = (FileUpload)item.FindControl("OtherCertificate");
                        if (chk.Checked)
                        {
                            details.EmployeeID = Convert.ToInt32(EmpID.Text);
                            details.SkillID = Convert.ToInt32(chk.Attributes["SkillID"]);
                            SkillIDs += chk.Attributes["SkillID"] + ",";
                            details.Rating = Convert.ToInt32(ddlRating.SelectedValue);
                            if (filePath.HasFile)
                            {
                                filePath.SaveAs(path + filePath.FileName);
                                details.CertificatePath = path + filePath.FileName;
                            }
                            lstCertificates.Add(details);
                        }
                    }
                    if (!string.IsNullOrEmpty(SkillIDs))
                    {                       
                        SkillIDs = SkillIDs.Remove(SkillIDs.Length - 1);
                    }
          
                    SetSkillsBL.UpdateSkills(Convert.ToInt32(EmpID.Text), SkillIDs);
                    SetSkillsBL.InsertCertificate(lstCertificates);
                    form1.Style.Add("display", "none");
                    DvSkill.Style.Add("display", "none");
                    myDIV.Style.Add("display", "block");
                }
                else
                {
                    lblEmpID.Visible = true;
                    lblEmpID.Text = "Employee ID does not exists !";

                }
            }
            catch (Exception q)
            {
                Console.Write(q.Message);
            }
        }

        
    }
}