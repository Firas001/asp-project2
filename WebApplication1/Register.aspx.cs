using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            user_name.Attributes.Add("class", "is-invalid");
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                alert.Visible = true;
                lmsg.Text = "اسم المستخدم موجود مسبقاً، جرب اسما آخر";
                user_name.Attributes.Add("class", "is-invalid");
            }

            else
            {
                signUpNewUser();

            }
        }



        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from users where USER_ID='" + user_name.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }




        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO users(USER_ID, FirstName, LastName, EMAIL, PASS, USER_TYPE) values(@userID, @fname, @lname, @email, @password, @user_type)", con);
                cmd.Parameters.AddWithValue("@userID", user_name.Text.Trim());
                cmd.Parameters.AddWithValue("@fname", first_name.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", last_name.Text.Trim());
                cmd.Parameters.AddWithValue("@email", email.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password.Text.Trim());
                cmd.Parameters.AddWithValue("@user_type", "2");
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("select *, (FirstName +' '+ LastName) as full_name from users where (USER_ID='" + user_name.Text.Trim() + "' AND PASS='" + password.Text.Trim() + "')", con);
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {    
                    Session["userID"] = dr["USER_ID"].ToString();
                    Session["user_name"] = dr["full_name"].ToString();
                }
                Session["role"] = "user";

                con.Close();

                Response.Redirect("home.aspx");


            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }







    }
}