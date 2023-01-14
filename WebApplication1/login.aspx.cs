using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //// استرجاع بيانات الدخول المخزنة
            {
                if (Request.Cookies["user_name"] != null && Request.Cookies["password"] != null) //// حفظ بيانات الدخول
                {
                    user_name.Text = Request.Cookies["user_name"].Value;
                    password.Attributes["value"] = Request.Cookies["password"].Value;
                    loginRemember.Checked = true;
                }
            }

        }

        protected void Login_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand("select *, (FirstName +' '+ LastName) as full_name from users where USER_ID=@id AND pass=@password", con);

            cmd.Parameters.AddWithValue("@id", user_name.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password.Text.Trim());

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["USER_TYPE"].Equals("1"))
                        Session["role"] = "admin";
                    else if (dr["USER_TYPE"].Equals("2"))
                        Session["role"] = "user";
                    else
                        break;
                    Session["userID"] = dr["USER_ID"].ToString();
                    Session["user_name"] = dr["full_name"].ToString();
                }

                if (Session["role"] == null)
                {
                    alert.Visible = true;
                    lmsg.Text = "البيانات المدخلة غير صحيحة";
                }
                else
                {    
                    if (loginRemember.Checked) // حفظ بيانات الدخول
                    {
                        Response.Cookies["user_name"].Value = user_name.Text.Trim();
                        Response.Cookies["password"].Value = password.Text.Trim();
                    }
                    Response.Redirect("home.aspx");
                }
            }
            else
            {
                alert.Visible = true;
                lmsg.Text = "البيانات المدخلة غير صحيحة";
            }
            con.Close();
        }



        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}