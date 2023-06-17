using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Labfootball
{
    public partial class Addcourse : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CourseAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                //   SqlCommand cmd = new SqlCommand("insert into Courses ([id],[code],[name],[teacher1],[teacher2],[year],[term]) values ('3','CSE1101','Discrete Math','Hashem','Dola','1st','1st')", con);
                SqlCommand cmd = new SqlCommand("insert into Courses ([id],[code],[name],[teacher1],[teacher2],[year],[term]) values (@id,@code,@name,@teacher1,@teacher2,@year,@term)", con);

                cmd.Parameters.AddWithValue("@id", CourseIdTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@code", CourseCodeTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@name", CourseNameTextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@teacher1", CourseTeacher1TextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@teacher2", CourseTeacher2TextBox.Text.Trim());
                cmd.Parameters.AddWithValue("@year", CourseYearDropDownList.SelectedValue);
                cmd.Parameters.AddWithValue("@term", CourseTermDropDownList.SelectedValue);

                cmd.ExecuteNonQuery();


                con.Close();

                Response.Write("<script>alert('Successful')</script>");
                
                //intent function
                Response.Redirect("~/ListCourse.aspx");

            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('Exception :" + ex.Message + "')</script>");
            }

        }
    }
}