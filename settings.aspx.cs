using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Labfootball
{
    public partial class settings : System.Web.UI.Page
    {
        String club_name = String.Empty;
        String User_Type = String.Empty;
        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        static string global_filepath2;
        protected void Page_Load(object sender, EventArgs e)
        {
            club_name = Request.QueryString["club_name"].ToString().Trim();
            User_Type = Request.QueryString["type"].ToString().Trim();
            homeLink.ServerClick += HomeLink_Click;
            session_club.Text = club_name;
            setImage();
        }
        protected void HomeLink_Click(object sender, EventArgs e)
        {
            string url = $"home_m.aspx?type={User_Type}&club_name={club_name}";
            Response.Redirect(url);
        }
        private void setImage()
        {
            SqlConnection con = new SqlConnection(strcon1);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from Manager_Lists where club_name= '"+ club_name +"';", con);
            SqlDataReader da = cmd.ExecuteReader();
            if (da.HasRows)
            {
                da.Read();
                if (da.IsDBNull(3))
                {
                    global_filepath2 = "Images/default-team-logo%20(1).png";
                    Console.WriteLine("From Default");
                }
                else
                {
                    global_filepath2 = da.GetValue(3).ToString();
                    Console.WriteLine("From DB");
                }
                string script = "<script>$(document).ready(function() { readURL3('" + global_filepath2 + "'); });</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SetImageSource1", script);
                con.Close();
                return;
            }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtNewPassword.Text;
            string pass2 = txtConfirmPassword.Text;
            if(pass.Equals(pass2))
            {
                SqlConnection con = new SqlConnection(strcon1);
                SqlCommand cmd;
                con.Open();
                string encryptedPassword = EncryptPassword(pass);
                cmd = new SqlCommand("Update Manager_Lists set password = @password where email = '"+email+"';", con);
                    cmd.Parameters.AddWithValue("@password", encryptedPassword);
                    cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Password Changed');</script>");
                con.Close();
            }
        }
        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}