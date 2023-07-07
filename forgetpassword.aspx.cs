using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Net.Mail;

namespace Labfootball
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        String password =String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioButton RadioButton1 = (RadioButton)FindControl("RadioButton1");
                if (RadioButton1 != null)
                {
                    RadioButton1.Checked = true;
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
                string query = String.Empty;
            if (RadioButton1.Checked)
                {
                     query = "SELECT * FROM Manager_Lists WHERE email = '"+ emailTextBox.Text.Trim()+"';";
                }                
                else
                {
                    query = "SELECT * FROM User_Lists WHERE email = '"+ emailTextBox.Text.Trim() +"';";
                }
                bool isValidUser = CheckUserCredentials(query);
            if(isValidUser)
            {
               // SendPasswordEmail(emailTextBox.Text.Trim(), password);
                thankYouLabel.InnerText = "Your Password is :"+password;
            }
            else
            {
                thankYouLabel.InnerText = "No Account registerd on that email";
            }
            thankYouLabel.Style["display"] = "block";
        }
        private void SendPasswordEmail(string email, string password)
        {
            string fromEmail = "ehsanul.karim.talha@gmail.com"; // Your email address
            string fromPassword = "karim1907039"; // Your email password
            string subject = "Password Recovery";
            string body = $"Your new password is: {password}";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, fromPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        private bool CheckUserCredentials(string query)
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
                    password = dr.GetValue(2).ToString();
                    break;
                }
                isValidUser = true;
            }
            con.Close();

            return isValidUser;
        }
    }
}