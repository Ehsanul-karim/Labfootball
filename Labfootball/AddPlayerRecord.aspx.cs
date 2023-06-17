using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace Labfootball
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        String club_name = String.Empty;
        String User_Type = String.Empty;
        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        static string global_filepath;
        static string global_filepath2;
        protected void Page_Load(object sender, EventArgs e)
        {
            club_name = Request.QueryString["club_name"].ToString().Trim();
            User_Type = Request.QueryString["type"].ToString().Trim();
            session_club.Text = club_name;
            session_club2.Text = club_name;
            GridView1.DataBind();
            setImage();
            string url = $"home_m.aspx?type={User_Type}&club_name={club_name}";
            homeLink.HRef = url;
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
        protected void AddButton_Click(object sender, EventArgs e)
        {
            allEnabled();
            int newid = fillNewPlayerId();
            TextBox1.Text = ""+newid;
        }
        protected void DoneButton_Click(object sender, EventArgs e)
        {

            if (checkIfPlayerExists())
            {
                updatePlayerByID();
                allclear();
                allDisable();
            }
            else
            {
                addNewPlayer();
                allclear();
                allDisable();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "upd")
            {
                //Response.Write("<script>alert('Update Id "+ e.CommandArgument +"');</script>");
                TextBox1.Text = ""+e.CommandArgument;
                allEnabled();
                allFillup();
            }
            else if(e.CommandName == "del")
            {
                TextBox1.Text = ""+e.CommandArgument;
                //Response.Write("<script>alert('Delete Id "+ e.CommandArgument +"');</script>");
                deleteBookByID();
                allclear();
                Response.Write("<script>alert('Delete Id "+ e.CommandArgument +"');</script>");
            }
        }
        bool checkIfPlayerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon1);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Player_Lis where player_id= '" + TextBox1.Text.Trim() + "' OR player_name= '"+ TextBox2.Text.Trim() + "' ;", con);
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
        void addNewPlayer()
        {
            try
            {
                string playerID2 = TextBox1.Text.Trim();
                int convertedPlayerID = int.Parse(playerID2);
                string playerName = TextBox2.Text.Trim();
                string country = DropDownList1.SelectedValue;
                string position = DropDownList3.SelectedValue;

                string joinDate = TextBox3.Text.Trim();

                string age = TextBox9.Text.Trim();

                string SkillStatus = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    SkillStatus = SkillStatus + ListBox1.Items[i] + ",";
                }
                SkillStatus = SkillStatus.Remove(SkillStatus.Length - 1);

                string filepath = "~/book_inventory/icon.png";
                string filename = string.Empty;
                if (FileUpload1.HasFile)
                {
                    filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }
                SqlConnection con = new SqlConnection(strcon1);
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Player_Lis ([player_id], [player_name], [country], [position] ,[join_date],[age],[salary],[market_price],[skillStatus],[image],[club_name]) VALUES (@player_id, @player_name, @country, @position, @join_date,@age,@salary,@market_price,@skillStatus,@image,@club_name);", con);
                cmd.Parameters.AddWithValue("@player_id", convertedPlayerID);
                cmd.Parameters.AddWithValue("@player_name", playerName);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@join_date", joinDate);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@salary", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@market_price", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@skillStatus", SkillStatus);
                cmd.Parameters.AddWithValue("@image", filepath);
                cmd.Parameters.AddWithValue("@club_name", club_name);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Player added successfully.');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatePlayerByID()
        {
            try
            {
                string SkillStatus = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    SkillStatus = SkillStatus + ListBox1.Items[i] + ",";
                }
                SkillStatus = SkillStatus.Remove(SkillStatus.Length - 1);

                string filepath = global_filepath;
                string filename = string.Empty;
                if (FileUpload1.HasFile)
                {
                    filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                string playerID2 = TextBox1.Text.Trim();
                int convertedPlayerID = int.Parse(playerID2);
                string playerName = TextBox2.Text.Trim();
                string country = DropDownList1.SelectedValue;
                string position = DropDownList3.SelectedValue;

                string joinDate = TextBox3.Text.Trim();

                string age = TextBox9.Text.Trim();

                SqlConnection con = new SqlConnection(strcon1);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE Player_Lis set player_name = @player_name, SkillStatus=@SkillStatus, position=@position, country=@country, join_date=@join_date, age=@age, image=@image, salary=@salary, market_price = @market_price where player_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@player_name", playerName);
                cmd.Parameters.AddWithValue("@SkillStatus", SkillStatus);
                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@join_date", joinDate);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@image", filepath);
                cmd.Parameters.AddWithValue("@salary", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@market_price", TextBox11.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Player_details Updated Successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        int fillNewPlayerId()
        {
            int newid=1;
            try
            {
                SqlConnection con = new SqlConnection(strcon1);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT MAX(player_id) +1 AS new_player_id FROM Player_Lis;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["new_player_id"] != DBNull.Value)
                    {
                        newid = int.Parse(dt.Rows[0]["new_player_id"].ToString());
                    }
                    else
                    {
                        newid = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            
            return newid;
        }
        void allFillup()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon1);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * from Player_Lis where player_id= "+ TextBox1.Text.Trim() +";", con);
                SqlDataReader da = cmd.ExecuteReader();
                if (da.HasRows)
                {
                    da.Read();
                    TextBox2.Text =  da.GetValue(0).ToString();
                    DropDownList1.SelectedValue = da.GetValue(1).ToString();
                    DropDownList3.SelectedValue = da.GetValue(2).ToString();

                    String testDate = da.GetValue(3).ToString();
                    DateTime dateValue;
                    if (DateTime.TryParse(testDate, out dateValue))
                    {
                        string formattedDate = dateValue.ToString("yyyy-MM-dd");
                        TextBox3.Text = formattedDate;
                    }

                    TextBox9.Text = da.GetValue(4).ToString();
                    String skillString = da.GetValue(5).ToString();
                    string[] skills = skillString.Split(',');
                    foreach (ListItem item in ListBox1.Items)
                    {
                        if (skills.Contains(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                    TextBox10.Text = da.GetValue(8).ToString(); 
                    TextBox11.Text = da.GetValue(9).ToString();

                    string imagelink = da.GetValue(6).ToString();
                    global_filepath = imagelink;
                    imagelink = imagelink.Substring(1);

                    string script = "<script>document.getElementById('imgview').src = '" + imagelink + "';</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "SetImageSource2", script);
                } 
                else
                {
                    Response.Write("<script>alert('Error');</script>");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void Button3_Click1(object sender, EventArgs e)
        {
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            deleteBookByID();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
           // getBookByID();
        }

        void deleteBookByID()
        {
                try
                {
                    SqlConnection con = new SqlConnection(strcon1);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from Player_Lis WHERE player_id=" + TextBox1.Text.Trim() + "", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
        }
        void allEnabled ()
        {
            FileUpload1.Enabled = true;
            TextBox2.Enabled = true;
            DropDownList1.Enabled = true;
            DropDownList3.Enabled = true;
            TextBox3.Enabled = true;
            TextBox9.Enabled = true;
            ListBox1.Enabled = true;
            TextBox10.Enabled = true;
            TextBox11.Enabled = true;
            DoneButton.Visible = true;
            AddButton.Visible = false;
            GridView1.Enabled = false;
        }
        void allDisable()
        {
            FileUpload1.Enabled = false;
            TextBox2.Enabled = false;
            DropDownList1.Enabled = false;
            DropDownList3.Enabled = false;
            TextBox3.Enabled = false;
            TextBox9.Enabled = false;
            ListBox1.Enabled = false;
            TextBox10.Enabled = false;
            TextBox11.Enabled = false;
            DoneButton.Visible = false;
            AddButton.Visible = true;
            GridView1.Enabled = true;
        }
        void allclear()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            DropDownList1.SelectedIndex = 0;
            DropDownList3.SelectedIndex = 0;
            TextBox3.Text = string.Empty;
            TextBox9.Text = string.Empty;
            foreach (ListItem i in ListBox1.Items)
            {
                i.Selected = false;
            }
            TextBox10.Text = string.Empty;
            TextBox11.Text = string.Empty;
        }
    }
}