using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication1
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["role"] == null)
            {
                Login.Visible = true;
                Logout.Visible = false;

            }      
            else
            {
                Login.Visible = false;
                Logout.Visible = true;
                wellcom.InnerText = "مرحباً " + Session["user_name"] + " بكلية تقنية المعلومات";

            }


        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["userID"] = null;
            Session["role"] = null;
            Session["user_name"] = null;

            Response.Redirect("home.aspx");
        }


    }
}