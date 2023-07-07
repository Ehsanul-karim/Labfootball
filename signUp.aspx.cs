using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


namespace Labfootball
{
    public partial class signUp : System.Web.UI.Page
    {
        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        private void PopulateClubList()
        {
            using (SqlConnection con = new SqlConnection(strcon1))
            {
                string query = "SELECT club_name FROM Manager_Lists";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string clubName = reader["club_name"].ToString();
                    ListItem listItem = new ListItem(clubName, clubName);
                    clubList1.Items.Add(listItem);
                }
                reader.Close();
                con.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioButton RadioButton1 = (RadioButton)FindControl("RadioButton1");
                if (RadioButton1 != null)
                {
                    RadioButton1.Checked = true;
                    clubGroup.Visible = false;
                }
                PopulateClubList();
            }
        }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                NameTextBox.Attributes["placeholder"] = "Enter Your Name";
                NameLabel.InnerText = "Your Name :";
                clubGroup.Visible = true;
                cont.Style["background"] = "linear-gradient(0deg, rgba(8, 32, 50, 0.9), rgba(8, 32, 50, 0.9)), url('./Images/supporterWelcomereal.jpg'), #082032;";
                
            }
            else
            {
                NameTextBox.Attributes["placeholder"] = "Enter Club Name";
                NameLabel.InnerText = "Club Name :";
                clubGroup.Visible = false;
                cont.Style["background"] = "linear-gradient(0deg, rgba(8, 32, 50, 0.9), rgba(8, 32, 50, 0.9)), url('./Images/footerplus2.jpg'), #082032;";
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
        protected void AccountAddButton_Click(object sender, EventArgs e)
        {
            String password_1 = passwwordTextBox.Text.Trim();
            String password_2 = passwwordTextBox2.Text.Trim();
            HttpCookie cookie = new HttpCookie("UserInfo");
            if (RadioButton1.Checked)
            {
                if (password_1 == password_2)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon1);
                        con.Open();
                        SqlCommand str = new SqlCommand("insert into Manager_Lists ([club_name],[email],[password],[club_logo]) values (@club_name,@email,@password,@club_logo)", con);

                        str.Parameters.AddWithValue("@club_name", NameTextBox.Text.Trim());
                        str.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
                        string encryptedPassword = EncryptPassword(password_1);
                        str.Parameters.AddWithValue("@password", encryptedPassword);
                        str.Parameters.AddWithValue("@club_logo", "Images/default-team-logo(1).png");
                        str.ExecuteNonQuery();
                        con.Close();
                        cookie["email"]=EmailTextBox.Text.Trim();
                        cookie["password"]=password_1;
                        Session["email"]=EmailTextBox.Text.Trim();
                        Response.Cookies.Add(cookie);
                        Response.Write("<script>alert('Successful')</script>");
                        Response.Redirect("~/home_m.aspx?type="+"Manager"+"&club_name="+NameTextBox.Text.Trim()+"");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Exception :" + ex.Message + "')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Password Don't Match')</script>");
                }
            }
            else
            {
                if (password_1 == password_2)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon1);
                        con.Open(); 
                        SqlCommand str = new SqlCommand("insert into User_Lists ([user_name],[email],[password],[club_name]) values (@user_name,@email,@password,@club_name)", con); 
                        str.Parameters.AddWithValue("@user_name", NameTextBox.Text.Trim());
                        str.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
                        str.Parameters.AddWithValue("@password", password_1);
                        str.Parameters.AddWithValue("@club_name", clubList1.SelectedValue);
                        str.ExecuteNonQuery();

                        con.Close();
                        cookie["email"]=EmailTextBox.Text.Trim();
                        cookie["password"]=password_1;
                        Session["email"]=EmailTextBox.Text.Trim();
                        Response.Cookies.Add(cookie);
                        Response.Write("<script>alert('Successful')</script>");

                        Response.Redirect("~/home_m.aspx?type="+"Supporter"+"&club_name="+clubList1.SelectedValue+"");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Exception :" + ex.Message + "')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Password Don't Match')</script>");
                }
            }
        }
    }
}