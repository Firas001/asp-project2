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
using System.Globalization;

namespace WebApplication1
{
    public partial class users : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"] == null)
                    Response.Redirect("login.aspx");

                else if (Session["role"].Equals("admin")) {
                    {
                        if (!IsPostBack)
                            PopulateGridview();
                    }

                else
                    Response.Redirect("login.aspx");
            }
        }

        void PopulateGridview()
        {
            SqlConnection con = new SqlConnection(strcon);
            DataTable dtbl = new DataTable();

            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM USERS", con);
            sqlDa.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                USERS_View.DataSource = dtbl;
                USERS_View.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                USERS_View.DataSource = dtbl;
                USERS_View.DataBind();
                USERS_View.Rows[0].Cells.Clear();
                USERS_View.Rows[0].Cells.Add(new TableCell());
                USERS_View.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                USERS_View.Rows[0].Cells[0].Text = "لا يوجد بيانات ..!";
                USERS_View.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void USERS_View_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);
            string usertype = (USERS_View.FooterRow.FindControl("USERTYPE") as TextBox).Text.Trim();


            if (e.CommandName.Equals("AddNew"))
            {
                if (usertype == "1" || usertype == "2")
                {
                    string query = "INSERT INTO USERS (USER_ID, FirstName, LastName, EMAIL, PASS ,USER_TYPE) VALUES (@id, @FName, @LName,@EMAIL, @password ,@USERTYPE)";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@id", RandomString(4).Trim());
                    sqlCmd.Parameters.AddWithValue("@FName", (USERS_View.FooterRow.FindControl("FirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LName", (USERS_View.FooterRow.FindControl("LastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@EMAIL", (USERS_View.FooterRow.FindControl("EMAIL") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", (USERS_View.FooterRow.FindControl("Password") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@USERTYPE", (USERS_View.FooterRow.FindControl("USERTYPE") as TextBox).Text.Trim());
                    con.Open();
                    sqlCmd.ExecuteNonQuery();
                    con.Close();
                    PopulateGridview();

                }
                else
                {
                    alert_danger.Visible = true;
                    lmsg_danger.Text = "لا يمكن اختيار نوع الرتبة إلا 1 أو 2";
                }
            }
            

        }

        protected void USERS_View_RowEditing(object sender, GridViewEditEventArgs e)
        {
            USERS_View.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void USERS_View_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            USERS_View.EditIndex = -1;
            PopulateGridview();
        }

        protected void USERS_View_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);

                string userid = USERS_View.DataKeys[e.RowIndex].Value.ToString();
                string usertype = (USERS_View.Rows[e.RowIndex].FindControl("USERTYPE") as TextBox).Text.Trim();

            if (not_admin(userid))
            {
                if (usertype == "1" || usertype == "2")
                {

                    con.Open();
                    string query = "UPDATE USERS SET FirstName=@FName, LastName=@LName,EMAIL=@EMAIL, PASS=@Password, USER_TYPE=@USERTYPE WHERE USER_ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@FName", (USERS_View.Rows[e.RowIndex].FindControl("FirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Lname", (USERS_View.Rows[e.RowIndex].FindControl("LastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@EMAIL", (USERS_View.Rows[e.RowIndex].FindControl("EMAIL") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", (USERS_View.Rows[e.RowIndex].FindControl("Password") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@USERTYPE", (USERS_View.Rows[e.RowIndex].FindControl("USERTYPE") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", USERS_View.DataKeys[e.RowIndex].Value.ToString());
                    sqlCmd.ExecuteNonQuery();
                    USERS_View.EditIndex = -1;
                    PopulateGridview();

                    alert_success.Visible = true;
                    lmsg_success.Text = "تم تعديل بيانات المستخدم: " + userid;
                }

                else
                {
                    alert_danger.Visible = true;
                    lmsg_danger.Text = "لا يمكن اختيار نوع الرتبة إلا 1 أو 2";
                }
            }

        }

        protected void USERS_View_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                string userid = USERS_View.DataKeys[e.RowIndex].Value.ToString();

                if (not_admin(userid))
                {
                    string query = "DELETE FROM USERS WHERE USER_ID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.Parameters.AddWithValue("@id", USERS_View.DataKeys[e.RowIndex].Value.ToString());
                    con.Open();
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();

                    alert_success.Visible = true;
                    lmsg_success.Text = "تم حذف المستخدم: " + userid;
                }
              
            }

            catch (Exception ex)
            {
                alert_danger.Visible = true;
                lmsg_danger.Text = ex.Message;

            }

        }


        // دالة إنشاء اسم مستخدم عشوائي

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // حماية الأدمن من الحذف
        protected bool not_admin(string userid)
        {
            if (!(userid == "admin"))
                return true;

            Response.Write("<script>alert('لا يمكنك تعديل أو حذف حساب مالك الموقع');</script>");
            return false;

        }


    }
}