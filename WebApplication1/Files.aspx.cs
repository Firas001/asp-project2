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
    public partial class Files : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["role"] == null)
                Response.Redirect("login.aspx");

            else if (Session["role"].Equals("admin") || Session["role"].Equals("user"))
                fillUsersValues();

            else
                Response.Redirect("login.aspx");

        }

        protected void bt_add_click(object sender, EventArgs e)
        {
            try
            {
                string ext = Path.GetExtension(file_path.FileName);
                string file_name = "";

                file_name = file_name + Session["userID"].ToString() + "_";
                file_name = file_name + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
                file_name += DateTime.Now.Day.ToString();
                file_name += DateTime.Now.Hour.ToString();
                file_name += DateTime.Now.Minute.ToString();
                file_name += DateTime.Now.Second.ToString();

                file_path.SaveAs(Server.MapPath("~/Files/") + file_name + ext);
                string filepath = "~/Files/" + file_name + ext;
                string sql = "insert into Files(TITLE, UPLOAD_DATE,USER_ID,PATH,  NOTES, DOWNLOAD)";
                sql = sql + " values(@title,@date,@user, @path, @notes, @count) ";

                SqlConnection con = new SqlConnection(strcon);



                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@title", file_title.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@user", user_name.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@path", filepath);
                cmd.Parameters.AddWithValue("@notes", notes.Text);
                cmd.Parameters.AddWithValue("@count", 0);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                alert.Visible = true;
                lmsg.Text = "تم الادخال بنجاح";

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }



        void fillUsersValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT (FirstName +' '+ LastName) as full_name, USER_ID from USERS", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                user_name.DataSource = dt;

                user_name.DataTextField = "full_name";
                user_name.DataValueField = "USER_ID";

                user_name.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
    }
}