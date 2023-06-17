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
    public partial class loginPage : System.Web.UI.Page
    {
        String User_name = String.Empty;
        String club_name = String.Empty;

        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioButton RadioButton1 = (RadioButton)FindControl("RadioButton1");
                if (RadioButton1 != null)
                {
                    RadioButton1.Checked = true;
                    imageField.Src = "Images/Coaching%20Manual-244-min.jpg";
                }
            }
        }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                imageField.Src = "Images/realsupporter.jpg";

            }
            else
            {              
                imageField.Src = "Images/Coaching%20Manual-244-min.jpg";
            }
        }

        private bool CheckUserCredentials(string query,int p)
        {
            bool isValidUser = false;

            SqlConnection con = new SqlConnection(strcon1);
                con.Open();

            SqlCommand command = new SqlCommand(query, con);
                
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        club_name = dr.GetValue(1).ToString();
                        if (p==2)
                        {
                        User_name = "Supporter";
                        }
                        else
                        {
                        User_name = "Manager";
                        }
                        break;
                    }
                    isValidUser = true;
                }
                con.Close();

            return isValidUser;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            String password_1 = PasswordTextBox.Text.Trim();
            if (RadioButton1.Checked)
            {

                string query = "SELECT * FROM Manager_Lists WHERE email = '"+ emailTextBox.Text.Trim() +"' AND password = '"+ password_1+"';";

                bool isValidUser = CheckUserCredentials(query,1);


                if (isValidUser)
                {
                    Response.Redirect("~/home_m.aspx?type="+User_name+"&club_name="+club_name+"");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "loginFailed", "alert('Invalid credentials');", true);
                }
            }
            else
            {
                string query = "SELECT * FROM User_Lists WHERE email = '"+ emailTextBox.Text.Trim() +"' AND password = '"+ password_1+"';";

                bool isValidUser = CheckUserCredentials(query,2);

                if (isValidUser)
                {
                    Response.Redirect("~/home_m.aspx?type="+User_name+"&club_name="+club_name+"");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "loginFailed", "alert('Invalid credentials');", true);
                }
            }
        }


    }
}