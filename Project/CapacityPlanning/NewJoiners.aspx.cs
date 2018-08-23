using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using businessLogic;
using Entity;
using MessageTemplate;

namespace CapacityPlanning
{
    public partial class NewJoiners : System.Web.UI.Page
    {
        int jID = 0;
        string name = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                BindGrid();

            }
        }

        public void BindGrid()
        {
            
            List<CPT_NewJoiners> lstNewJoiners = new List<CPT_NewJoiners>();
            NewJoinersBL clsNewJoiners = new NewJoinersBL();
            lstNewJoiners = clsNewJoiners.getNewJoiners();

            rptNewJoiner.DataSource = lstNewJoiners;
            rptNewJoiner.DataBind();

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            CPT_NewJoiners newJoiners = new CPT_NewJoiners();
            
            LinkButton lb = sender as LinkButton;

            jID = Convert.ToInt32(lb.Attributes["joinerID"]);
            name = lb.Attributes["joinerName"];
            newJoiners.NewJoinerID = jID;
            Email();
            NewJoinersBL newJoinersBL = new NewJoinersBL();
            newJoinersBL.Delete(newJoiners);
            
            
            BindGrid();
        }

        public void Email()
        {
            try
            {
                

                CPT_EmailTemplate registrationEmail = new CPT_EmailTemplate();
                registrationEmail.Name = "DeclinedOffer";
                registrationEmail.To = new List<string>();
                registrationEmail.To.Add("anshuman.rai@gridinfocom.com");
                registrationEmail.ToUserName = new List<string>();
                registrationEmail.ToUserName.Add("Anshuman");
                registrationEmail.JOINER = name;
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