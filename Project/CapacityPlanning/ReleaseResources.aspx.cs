using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class ReleaseResources : System.Web.UI.Page
    {
        int employeeID = 0, logId = 0;
        string acName = "";
        string prName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                BindRpt();
            }
            
        }

        public void BindRpt()
        {
            List<CPT_ResourceMaster> lstdetils = new List<CPT_ResourceMaster>();
            lstdetils = (List<CPT_ResourceMaster>)Session["UserDetails"];
            logId = lstdetils[0].EmployeeMasterID;
            ReleaseResourcesBL.BindRepeater(rptResourceRelease, logId);
        }

        protected void releaseButton_Click(object sender, EventArgs e)
        {

            LinkButton lb = sender as LinkButton;
            acName = lb.Attributes["acName"];
            prName = lb.Attributes["prName"];
//employeeID = ;
            ReleaseResourcesBL.setReleasedStatus(Convert.ToInt32(lb.Attributes["AlocationID"]));
          //  Email();
            Response.Redirect("ReleaseResources.aspx");
        }
        public void Email()
        {
            try
            {
                string mail = ReleaseResourcesBL.getEmailIdByEmpID(employeeID);
                string name = ReleaseResourcesBL.getNameByEmpID(employeeID);
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "ReleaseResource";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(mail);
                registrationEmail.ToUserName = new List<string>();
                
                registrationEmail.ToUserName.Add(name);
                registrationEmail.PROJECT= acName;
                registrationEmail.PROCESS = prName;

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