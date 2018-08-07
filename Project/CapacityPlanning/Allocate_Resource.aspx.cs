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
                    AllocateResourceBL.getEmployeeNameByResourceType(rptSuggestions,role);
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
        //protected void btnSave_Click(object sender,EventArgs e)
        //{
        //    try
        //    {
        //        foreach(RepeaterItem item in Repeat.Items)
        //        {
        //            CheckBox chk = (CheckBox)item.FindControl("chkRequired");
        //            if (chk.Checked)
        //            {
        //                //insert here from ui
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

    }
}