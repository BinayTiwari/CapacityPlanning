using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using System.Data;
using businessLogic;
using System.Reflection;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class Allocate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                List<int> statusID = new List<int>();
                int i = 0;
                statusID = AllocateBL.getResourceDemand(rptResourceAllocation);
                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    
                    DropDownList ddl = (DropDownList)item.FindControl("ddlPriorities");
                    ClsCommon.ddlGetAction(ddl);
                    ddl.Text = statusID[i].ToString();
                    i++;
                }


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                foreach (RepeaterItem item in rptResourceAllocation.Items)
                {
                    DropDownList ddl1 = (DropDownList)item.FindControl("ddlPriorities");
                    
                    int statusID = Convert.ToInt32(ddl1.SelectedValue);
                    //string PriorityName = ddl1.SelectedItem.Text;

                    AllocateBL ABL = new AllocateBL();
                    CPT_ResourceDemand CRM = new CPT_ResourceDemand();

                    Label lblRequestID = (Label)item.FindControl("Request");
                    CRM.RequestID = lblRequestID.Text.Trim();
                    CRM.StatusMasterID = statusID;

                    ABL.UpdateData(CRM);
                   
                    if(statusID == 26 || statusID == 27)
                    { 
                        if(statusID == 26)
                        {
                            Email(lblRequestID.Text, "Approved");
                        }
                        else
                        {
                            Email(lblRequestID.Text, "Rejected");
                        }
                        
                    }
                    

                }
                Response.Redirect("Allocate.aspx");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        

        public void Email(string RequestID, string Status)
        {
            try
            {
                
                List<string> data = AllocateBL.getRequestDetails(RequestID);
                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "RequestAction";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add(data[0]);
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add(data[1]);
                registrationEmail.PROJECT = data[2];
                registrationEmail.PROCESS = data[3];
                registrationEmail.STATUS = Status;
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