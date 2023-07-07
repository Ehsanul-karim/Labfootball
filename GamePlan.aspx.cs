using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using System.Web.Services;
using System.Collections;

namespace Labfootball
{
    public partial class GamePlan : System.Web.UI.Page
    {
        String club_name = String.Empty;
        String User_Type = String.Empty;
        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        static string global_filepath2;
        private string imgId;
        static DataTable subdataTable = new DataTable();


        static int f=0, m=0, d=0,g=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            club_name = Request.QueryString["club_name"].ToString().Trim();
            User_Type = Request.QueryString["type"].ToString().Trim();
            homeLink.ServerClick += HomeLink_Click;
            settingslink.HRef = $"Settings.aspx?type={User_Type}&club_name={club_name}";
            session_club.Text = club_name;
            setImage();
            if (User_Type.Equals("Supporter"))
            {
                LinkButton2.Visible = false;
                LinkButton1.Visible = false;
            }
            if (!IsPostBack)
            {
                subdataTable.Columns.Add("image", typeof(string));
                subdataTable.Columns.Add("player_name", typeof(string));
                subdataTable.Columns.Add("position", typeof(string));
                GetData();
                RepeaterSubstitute.DataSource = subdataTable;
                RepeaterSubstitute.DataBind();
                PopulatePlaying11AndSubstitutes();
            }
        }
        protected void HomeLink_Click(object sender, EventArgs e)
        {
            subdataTable.Clear();
            subdataTable.Columns.Clear();
            string url = $"home_m.aspx?type={User_Type}&club_name={club_name}";
            Response.Redirect(url);
        }
        private void PopulatePlaying11AndSubstitutes()
        {
            if(checkIfclubExists())
            {
                SqlConnection con = new SqlConnection(strcon1);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from Squad_Formation where club_name= '" + club_name + "';", con);
                SqlDataReader da = cmd.ExecuteReader();
                if (da.HasRows)
                {
                    da.Read();
                    Label1.Text =  da.GetValue(1).ToString();
                    playerImage1.ImageUrl = da.GetValue(2).ToString();
                    Label2.Text =  da.GetValue(3).ToString();
                    playerImage2.ImageUrl = da.GetValue(4).ToString();
                    Label3.Text =  da.GetValue(5).ToString();
                    playerImage3.ImageUrl = da.GetValue(6).ToString();
                    Label4.Text =  da.GetValue(7).ToString();
                    playerImage4.ImageUrl = da.GetValue(8).ToString();
                    Label5.Text =  da.GetValue(9).ToString();
                    playerImage5.ImageUrl = da.GetValue(10).ToString();
                    Label6.Text =  da.GetValue(11).ToString();
                    playerImage6.ImageUrl = da.GetValue(12).ToString();
                    Label7.Text =  da.GetValue(13).ToString();
                    playerImage7.ImageUrl = da.GetValue(14).ToString();
                    Label8.Text =  da.GetValue(15).ToString();
                    playerImage8.ImageUrl = da.GetValue(16).ToString();
                    Label9.Text =  da.GetValue(17).ToString();
                    playerImage9.ImageUrl = da.GetValue(18).ToString();
                    Label10.Text =  da.GetValue(19).ToString();
                    playerImage10.ImageUrl = da.GetValue(20).ToString();
                    Label11.Text =  da.GetValue(21).ToString();
                    playerImage11.ImageUrl = da.GetValue(22).ToString();
                    findRestSendToSub();
                }
                else
                {
                    Response.Write("<script>alert('Error');</script>");
                }

                con.Close();
            }
            else
            {
                DataTable dataTable = GetForwardsData();
                for (int i = 1; i <= dataTable.Rows.Count; i++)
                {
                    string imageUrl = dataTable.Rows[i - 1]["image"].ToString();
                    string position = dataTable.Rows[i - 1]["position"].ToString();
                    string charName = dataTable.Rows[i - 1]["player_name"].ToString();
                    if (string.Compare(playerImage4.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage4.ImageUrl = imageUrl;
                        Label4.Text = charName;
                    }
                    else if (string.Compare(playerImage2.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage2.ImageUrl = imageUrl;
                        Label2.Text = charName;
                    }
                    else if (string.Compare(playerImage1.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage1.ImageUrl = imageUrl;
                        Label1.Text = charName;
                    }
                    else
                    {
                        SendToSubstitute(imageUrl, charName, position);
                    }
                }
                dataTable = GetMiddlesData();
                for (int i = 1; i <= dataTable.Rows.Count; i++)
                {
                    string imageUrl = dataTable.Rows[i - 1]["image"].ToString();
                    string position = dataTable.Rows[i - 1]["position"].ToString();
                    string charName = dataTable.Rows[i - 1]["player_name"].ToString();
                    if (string.Compare(playerImage3.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage3.ImageUrl = imageUrl;
                        Label3.Text = charName;
                    }
                    else if (string.Compare(playerImage5.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage5.ImageUrl = imageUrl;
                        Label5.Text = charName;
                    }
                    else if (string.Compare(playerImage6.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage6.ImageUrl = imageUrl;
                        Label6.Text = charName;
                    }
                    else
                    {
                        SendToSubstitute(imageUrl, charName, position);
                    }
                }
                dataTable = GetDefenceData();
                for (int i = 1; i <= dataTable.Rows.Count; i++)
                {
                    string imageUrl = dataTable.Rows[i - 1]["image"].ToString();
                    string position = dataTable.Rows[i - 1]["position"].ToString();
                    string charName = dataTable.Rows[i - 1]["player_name"].ToString();
                    if (string.Compare(playerImage8.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage8.ImageUrl = imageUrl;
                        Label8.Text = charName;
                    }
                    else if (string.Compare(playerImage9.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage9.ImageUrl = imageUrl;
                        Label9.Text = charName;
                    }
                    else if (string.Compare(playerImage7.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage7.ImageUrl = imageUrl;
                        Label7.Text = charName;
                    }
                    else if (string.Compare(playerImage10.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage10.ImageUrl = imageUrl;
                        Label10.Text = charName;
                    }
                    else
                    {
                        SendToSubstitute(imageUrl, charName, position);
                    }
                }
                dataTable = GetkeeperData();
                for (int i = 1; i <= dataTable.Rows.Count; i++)

                {
                    string imageUrl = dataTable.Rows[i - 1]["image"].ToString();
                    string position = dataTable.Rows[i - 1]["position"].ToString();
                    string charName = dataTable.Rows[i - 1]["player_name"].ToString();
                    if (string.Compare(playerImage11.ImageUrl, "~/Images/bg.png")==0)
                    {
                        playerImage11.ImageUrl = imageUrl;
                        Label11.Text = charName;
                    }
                    else
                    {
                        SendToSubstitute(imageUrl, charName, position);
                    }
                }
            }
        }

        public void findRestSendToSub()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND  injury=0 AND market_status=0 ;";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
                for (int i = 1; i <= dataTable.Rows.Count; i++)
                {
                    string imageUrl = dataTable.Rows[i - 1]["image"].ToString();
                    string position = dataTable.Rows[i - 1]["position"].ToString();
                    string charName = dataTable.Rows[i - 1]["player_name"].ToString();
                    if (string.Compare(Label1.Text,charName)==0 || string.Compare(Label2.Text, charName)==0 || string.Compare(Label3.Text, charName)==0 || string.Compare(Label4.Text, charName)==0 || string.Compare(Label5.Text, charName)==0 || string.Compare(Label6.Text, charName)==0 || string.Compare(Label7.Text, charName)==0 || string.Compare(Label8.Text, charName)==0 || string.Compare(Label9.Text, charName)==0 || string.Compare(Label10.Text, charName)==0 || string.Compare(Label11.Text, charName)==0)
                    {

                    }
                    else
                    {
                        SendToSubstitute(imageUrl, charName, position);
                    }
                }
                connection.Close();
            }
        }

        private DataTable GetForwardsData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Forward' AND  injury=0 AND market_status=0";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
                connection.Close();

                return dataTable;
            }
        }
        private DataTable GetMiddlesData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Mid-Fielder' AND  injury=0 AND market_status=0";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
                connection.Close();

                return dataTable;
            }
        }
        private DataTable GetDefenceData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Defence' AND  injury=0 AND market_status=0";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
                connection.Close();

                return dataTable;
            }
        }
        private DataTable GetkeeperData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Goal-Keeper' AND  injury=0 AND market_status=0";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }
                connection.Close();

                return dataTable;
            }
        }



        private void GetData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT image, player_name, position FROM Player_Lis where club_name='" + club_name + "' and injury=1 and market_status=0;";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader da = command.ExecuteReader();
                while (da.Read())
                {
                    DataRow newRow = subdataTable.NewRow();
                    newRow["image"] = da.GetValue(0).ToString();
                    newRow["player_name"] = da.GetValue(1).ToString();
                    newRow["position"] = da.GetValue(2).ToString();
                    subdataTable.Rows.Add(newRow);
                }
                connection.Close();
            }
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

        protected void swapbutton_click(object sender, EventArgs e)
        {
            string fromfieldname = playerNameHidden.Value;
            string fromfieldpos = string.Empty;
            string fromfieldimageurl = string.Empty;

            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT position, image FROM Player_Lis WHERE player_name='"+fromfieldname+"'";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader da = command.ExecuteReader();
                if (da.HasRows)
                {
                    da.Read();
                    fromfieldpos = da.GetValue(0).ToString();
                    fromfieldimageurl = da.GetValue(1).ToString();
                }
                connection.Close();
            }
            

            string fromsubname = playerName2Hidden.Value;
            string fromsubpos = string.Empty;
            string fromsubimageurl = string.Empty;
            string fromsubinjury = string.Empty;
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT position, image, injury FROM Player_Lis WHERE player_name='"+fromsubname+"'";

                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader da = command.ExecuteReader();
                if (da.HasRows)
                {
                    da.Read();
                    fromsubpos = da.GetValue(0).ToString();
                    fromsubimageurl = da.GetValue(1).ToString();
                    fromsubinjury = da.GetValue(2).ToString();
                }
                connection.Close();
            }


            if (fromsubinjury.Equals("1"))
            {

                Response.Write("<script>alert('This is an injured player');</script>");
            }
            else
            {
                if (String.Equals(fromsubpos, fromfieldpos))
                {
                    DeleteFromSubstitute(fromsubname);
                    SendToSubstitute(fromfieldimageurl, fromfieldname, fromfieldpos);
                    sendToField(fromsubname,fromsubimageurl,fromfieldname);
                }
                else
                {
                    Response.Write("<script>alert('Their position is different');</script>");
                }
            }

        }
        protected void Donebutton_click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon1);
            SqlCommand cmd;
            con.Open();
            if (checkIfclubExists())
            {
                cmd = new SqlCommand("Update Squad_Formation set player_1 = @player_1, image_1 = @image_1,player_2 = @player_2, image_2 = @image_2,player_3 = @player_3, image_3 = @image_3,player_4 = @player_4, image_4 = @image_4,player_5 = @player_5, image_5 = @image_5,player_6 = @player_6, image_6 = @image_6,player_7 = @player_7, image_7 = @image_7,player_8 = @player_8, image_8 = @image_8,player_9 = @player_9, image_9 = @image_9,player_10 = @player_10, image_10 = @image_10,player_11 = @player_11, image_11 = @image_11 where club_name = '"+club_name+"';", con);
                cmd.Parameters.AddWithValue("@player_1", Label1.Text);
                cmd.Parameters.AddWithValue("@image_1", playerImage1.ImageUrl);
                cmd.Parameters.AddWithValue("@player_2", Label2.Text);
                cmd.Parameters.AddWithValue("@image_2", playerImage2.ImageUrl);
                cmd.Parameters.AddWithValue("@player_3", Label3.Text);
                cmd.Parameters.AddWithValue("@image_3", playerImage3.ImageUrl);
                cmd.Parameters.AddWithValue("@player_4", Label4.Text);
                cmd.Parameters.AddWithValue("@image_4", playerImage4.ImageUrl);
                cmd.Parameters.AddWithValue("@player_5", Label5.Text);
                cmd.Parameters.AddWithValue("@image_5", playerImage5.ImageUrl);
                cmd.Parameters.AddWithValue("@player_6", Label6.Text);
                cmd.Parameters.AddWithValue("@image_6", playerImage6.ImageUrl);
                cmd.Parameters.AddWithValue("@player_7", Label7.Text);
                cmd.Parameters.AddWithValue("@image_7", playerImage7.ImageUrl);
                cmd.Parameters.AddWithValue("@player_8", Label8.Text);
                cmd.Parameters.AddWithValue("@image_8", playerImage8.ImageUrl);
                cmd.Parameters.AddWithValue("@player_9", Label9.Text);
                cmd.Parameters.AddWithValue("@image_9", playerImage9.ImageUrl);
                cmd.Parameters.AddWithValue("@player_10", Label10.Text);
                cmd.Parameters.AddWithValue("@image_10", playerImage10.ImageUrl);
                cmd.Parameters.AddWithValue("@player_11", Label11.Text);
                cmd.Parameters.AddWithValue("@image_11", playerImage11.ImageUrl);
                cmd.ExecuteNonQuery();
            }

            else
            {
                cmd = new SqlCommand("INSERT INTO Squad_Formation ([player_1], [image_1],[player_2], [image_2],[player_3], [image_3],[player_4], [image_4],[player_5], [image_5],[player_6], [image_6],[player_7], [image_7],[player_8], [image_8],[player_9], [image_9],[player_10], [image_10],[player_11], [image_11], [club_name]) VALUES (@player_1, @image_1,@player_2, @image_2,@player_3, @image_3,@player_4, @image_4,@player_5, @image_5,@player_6, @image_6,@player_7, @image_7,@player_8, @image_8,@player_9, @image_9,@player_10, @image_10,@player_11, @image_11,@club_name);", con);
                cmd.Parameters.AddWithValue("@player_1", Label1.Text);
                cmd.Parameters.AddWithValue("@image_1", playerImage1.ImageUrl);
                cmd.Parameters.AddWithValue("@player_2", Label2.Text);
                cmd.Parameters.AddWithValue("@image_2", playerImage2.ImageUrl);
                cmd.Parameters.AddWithValue("@player_3", Label3.Text);
                cmd.Parameters.AddWithValue("@image_3", playerImage3.ImageUrl);
                cmd.Parameters.AddWithValue("@player_4", Label4.Text);
                cmd.Parameters.AddWithValue("@image_4", playerImage4.ImageUrl);
                cmd.Parameters.AddWithValue("@player_5", Label5.Text);
                cmd.Parameters.AddWithValue("@image_5", playerImage5.ImageUrl);
                cmd.Parameters.AddWithValue("@player_6", Label6.Text);
                cmd.Parameters.AddWithValue("@image_6", playerImage6.ImageUrl);
                cmd.Parameters.AddWithValue("@player_7", Label7.Text);
                cmd.Parameters.AddWithValue("@image_7", playerImage7.ImageUrl);
                cmd.Parameters.AddWithValue("@player_8", Label8.Text);
                cmd.Parameters.AddWithValue("@image_8", playerImage8.ImageUrl);
                cmd.Parameters.AddWithValue("@player_9", Label9.Text);
                cmd.Parameters.AddWithValue("@image_9", playerImage9.ImageUrl);
                cmd.Parameters.AddWithValue("@player_10", Label10.Text);
                cmd.Parameters.AddWithValue("@image_10", playerImage10.ImageUrl);
                cmd.Parameters.AddWithValue("@player_11", Label11.Text);
                cmd.Parameters.AddWithValue("@image_11", playerImage11.ImageUrl);
                cmd.Parameters.AddWithValue("@club_name", club_name);
                cmd.ExecuteNonQuery();
            }

            con.Close();
            HomeLink_Click(sender, e);
        }
        bool checkIfclubExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon1);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from Squad_Formation where club_name= '" + club_name + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    con.Close() ;
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected string GetTruncatedPlayerName(object playerName)
        {
            string name = playerName.ToString();
            if (name.Length > 7)
            {
                name = name.Substring(0, 7); // Truncate the player name to 7 characters
            }
            return name;
        }
        protected void SendToSubstitute(string imageurl, string playerName, string position)
        {
            DataRow newRow = subdataTable.NewRow();
            newRow[0] = ""+imageurl;
            newRow[1] = ""+playerName;
            newRow[2] = ""+position;
            subdataTable.Rows.Add(newRow);

            RepeaterSubstitute.DataSource = subdataTable;
            RepeaterSubstitute.DataBind();
        }
        protected void DeleteFromSubstitute(string playerName)
        {
            DataRow[] rows = subdataTable.Select("player_name = '" + playerName + "'");
            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    subdataTable.Rows.Remove(row);
                }
            }

            RepeaterSubstitute.DataSource = subdataTable;
            RepeaterSubstitute.DataBind();
        }
        protected void sendToField(string charName, string imageUrl, string fieldplayerName)
        {
            if(Label1.Text.Equals(fieldplayerName))
            {
                playerImage1.ImageUrl = imageUrl;
                Label1.Text = charName;
            }
            else if (Label2.Text.Equals(fieldplayerName))
            {
                playerImage2.ImageUrl = imageUrl;
                Label2.Text = charName;
            }
            else if (Label3.Text.Equals(fieldplayerName))
            {
                playerImage3.ImageUrl = imageUrl;
                Label3.Text = charName;
            }
            else if (Label4.Text.Equals(fieldplayerName))
            {
                playerImage4.ImageUrl = imageUrl;
                Label4.Text = charName;
            }
            else if (Label5.Text.Equals(fieldplayerName))
            {
                playerImage5.ImageUrl = imageUrl;
                Label5.Text = charName;
            }
            else if (Label6.Text.Equals(fieldplayerName))
            {
                playerImage6.ImageUrl = imageUrl;
                Label6.Text = charName;
            }
            else if (Label7.Text.Equals(fieldplayerName))
            {
                playerImage7.ImageUrl = imageUrl;
                Label7.Text = charName;

            }
            else if (Label8.Text.Equals(fieldplayerName))
            {
                playerImage8.ImageUrl = imageUrl;
                Label8.Text = charName;
            }
            else if (Label9.Text.Equals(fieldplayerName))
            {
                playerImage9.ImageUrl = imageUrl;
                Label9.Text = charName;
            }
            else if (Label10.Text.Equals(fieldplayerName))
            {
                playerImage10.ImageUrl = imageUrl;
                Label10.Text = charName;
            }
            else if (Label11.Text.Equals(fieldplayerName))
            {
                playerImage11.ImageUrl = imageUrl;
                Label11.Text = charName;
            }
            else
            {

            }
        }
    }

}