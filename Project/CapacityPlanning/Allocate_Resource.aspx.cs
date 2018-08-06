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
               
                    string id= Session["id"].ToString();
                lblResourceAllocation.Text = id;
                    AllocateResourceBL.AllocateResourceByID(rptResourceAllocation, id);
                
            }
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