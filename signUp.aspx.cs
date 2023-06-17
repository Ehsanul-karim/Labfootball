using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
            }
            else
            {
                NameTextBox.Attributes["placeholder"] = "Enter Club Name";
                NameLabel.InnerText = "Club Name :";
                clubGroup.Visible = false;
            }
        }

        protected void AccountAddButton_Click(object sender, EventArgs e)
        {
            String password_1 = passwwordTextBox.Text.Trim();
            String password_2 = passwwordTextBox2.Text.Trim();
            if (RadioButton1.Checked)
            {
                if (password_1 == password_2)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon1);
                        con.Open();
                        SqlCommand str = new SqlCommand("insert into Manager_Lists ([club_name],[email],[password]) values (@club_name,@email,@password)", con);

                        str.Parameters.AddWithValue("@club_name", NameTextBox.Text.Trim());
                        str.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
                        str.Parameters.AddWithValue("@password", password_1);
                        str.ExecuteNonQuery();
                        con.Close();
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