using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;
namespace CapacityPlanning
{
    public partial class Allocate_Resource : System.Web.UI.Page
    {
        List<string> dateSatrt = new List<string>();
        List<string> name = new List<string>();
        List<string> dateEnd = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //AllocateResourceBL.AllocateResource(rptResourceAllocation);

                string id = Session["id"].ToString();
                lblResourceAllocation.Text = id;
                AllocateResourceBL.AllocateResourceByID(rptResourceAllocation, id);

            }
        }
        protected void btnAllocate_Resource_Click(object sender, EventArgs e)
        {


            try
            {
                myDIV.Style.Add("display", "block");
                Button theButton = sender as Button;
                Session["role"] = theButton.CommandArgument;
                string role = Session["role"].ToString();
                if (role != null)
                {
                    string id = Session["id"].ToString();
                    lblSuggestions.Text = id;
                    AllocateResourceBL.getEmployeeNameByResourceType(rptSuggestions, role);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void rptSuggestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void rptResourceAllocation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void chkRequired_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (RepeaterItem item in rptSuggestions.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkRequired");
                    var chek = (CheckBox)sender;
                    string StarDate = chek.Attributes["StartDate"];
                    string EndDate = chek.Attributes["EndDate"];
                    string EmployeeName = chek.Attributes["EmployeeName"];
                    if (chk.Checked)
                    {
                        dateSatrt.Add(StarDate);
                        dateEnd.Add(EndDate);
                        name.Add(EmployeeName);
                        //insert here from ui
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] items = new string[5];
                CPT_AllocateResource details = new CPT_AllocateResource();
                AllocateResourceBL rbl = new AllocateResourceBL();
                for (int i = 0; i < name.Count; i++)
                {
                    items[i] = name[i];
                }
                List<int> resourceID = new List<int>();
                resourceID = AllocateResourceBL.ResourceID(items);
                for(int j=0;j<name.Count;j++)
                {
                    details.ResourceID = resourceID[j];
                    details.RequestID = Session["id"].ToString();
                    details.AccountID = AllocateResourceBL.getAccountID(Session["id"].ToString());
                    details.StartDate = Convert.ToDateTime(dateSatrt[j]);
                    details.EndDate = Convert.ToDateTime(dateEnd[j]);
                    rbl.Insert(details);
                }
                //foreach(var item in resourceID)
                //{
                //    details.ResourceID = item;
                //}
                //details.ResourceID = AllocateResourceBL.ResourceID(Session["name"].ToString());
                //details.RequestID = Session["id"].ToString();
                //details.AccountID = AllocateResourceBL.getAccountID(Session["id"].ToString());
                //for (int i = 0; i < date.Count; i = i + 2)
                //{
                //    details.StartDate = Convert.ToDateTime(date[i]);
                //}
                //for (int i = 1; i < date.Count; i = i + 2)
                //{
                //    details.EndDate = Convert.ToDateTime(date[i]);
                //}


                //rbl.Insert(details);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}