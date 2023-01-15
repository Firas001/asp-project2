using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace WebApplication1
{
    public partial class home : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillFiles();
            }


        }

        void fillFiles()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("select *, (select FirstName +' '+ LastName from users where user_id=Files.user_id)"
                                                        + "as user_name from FILES order by UPLOAD_DATE desc", con);

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            Files.DataSource = dtbl;
            Files.DataBind();
            con.Close();
        }


        protected void DeleteFile(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlDataReader dr;
                SqlCommand cmd;
                string path = null;

                // get file id by row
                int FILEID = Convert.ToInt32((sender as LinkButton).CommandArgument);

                // get path
                string path_query = "select PATH from files WHERE FILE_ID =" + FILEID;

                con.Open();

                cmd = new SqlCommand(path_query, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    path = dr[0].ToString();
                }
                dr.Close();



                // delete ~/ from path
                path = path.Remove(0, 1);

                // غير المسار هدا بمسار مشروعك في حهازك
                path = "C://Users//FirasDW//Desktop//firas//asp-project1//WebApplication1" + path;


                con.Close();


                con.Open();

                // delete path from database
                string delete_query = "delete FILES where FILE_ID=" + FILEID;
                cmd = new SqlCommand(delete_query, con);

                cmd.ExecuteNonQuery();


                con.Close();

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                Response.Write("<script>alert('تمت عملية الحذف بنجاح');</script>");
                fillFiles();





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }


        protected void DownloadFile(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);


            // get path
            string filePath = (sender as LinkButton).CommandArgument;


            // add 1 download counter
            con.Open();
            string query = "UPDATE Files SET DOWNLOAD = DOWNLOAD + 1 WHERE Path='" + filePath + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            fillFiles();

            // download

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();

        }

        protected void Files_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           // ظهور زر حذف للأدمن فقط
            
            if (Session["role"] == null)
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
            }
            else if (Session["role"].Equals("admin"))
            {
                e.Row.Cells[7].Visible = true;
                e.Row.Cells[8].Visible = true;
            }
            else if (Session["role"].Equals("user"))
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = true;
            }
            else
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
            }


        }
    }
}