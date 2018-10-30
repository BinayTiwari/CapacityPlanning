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
    public partial class DeployResources : System.Web.UI.Page
    {
        int resourceID = 0;
        string acName = "";
        string prName = "";
        string requestID = "";
        string startDate = "";
        string endDate = "";
        string RequesterEmailID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindRepeater();
            }
        }

        public void BindRepeater()
        {
            DeployResourcesBL.Bind(rptDeployResources);
        }

        protected void DeployResource(object sender, EventArgs e)
        {
            try
            {
                Button theButton = sender as Button;
                resourceID = Convert.ToInt32(theButton.CommandArgument);
                acName = theButton.Attributes["acName"];
                prName = theButton.Attributes["prName"];
                startDate = theButton.Attributes["StartDate"];
                endDate = theButton.Attributes["EndDate"];
                RequesterEmailID = theButton.Attributes["RequesterEmail"];
                DeployResourcesBL.DeployStatus(Convert.ToInt32(theButton.Attributes["AllocationID"]));
                Email();
                BindRepeater();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Email()
        {
            try
            {
                string mail = ReleaseResourcesBL.getEmailIdByEmpID(resourceID);
                string name = ReleaseResourcesBL.getNameByEmpID(resourceID);
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "DeployResource";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(mail);
                registrationEmail.CC = new List<string>();
                registrationEmail.CC.Add(RequesterEmailID);
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add(name);
                registrationEmail.PROJECT = acName;
                registrationEmail.PROCESS = prName;
                registrationEmail.STARTDATE = startDate;
                registrationEmail.ENDDATE = endDate;
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