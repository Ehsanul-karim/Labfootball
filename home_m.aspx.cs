using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.HtmlControls;
using System.Reflection.Emit;
using System.Web.DynamicData;

namespace Labfootball
{
    public partial class home_m : System.Web.UI.Page
    {
        String club_name = String.Empty;
        String User_Type = String.Empty;
        static string email = String.Empty;
        static string email2 = String.Empty;
        static string password_of_user = String.Empty;

        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            club_name = Request.QueryString["club_name"].ToString().Trim();
            User_Type = Request.QueryString["type"].ToString().Trim();

            string url = $"GamePlan.aspx?type={User_Type}&club_name={club_name}";
            formationLink.HRef = url;
            transferLink.HRef = $"transfer.aspx?type={User_Type}&club_name={club_name}";
            settingslink.HRef = $"Settings.aspx?type={User_Type}&club_name={club_name}";
            HttpCookie cookie = Request.Cookies["UserInfo"];
            session_club.Text = club_name;
            if (User_Type.Equals("Manager"))
            {
                btnUpload.Visible = true;
                fileUpload1.Visible = false;
            }
            if(cookie != null)
            {
                email = cookie["email"].ToString();
                password_of_user = cookie["password"].ToString();
            }
            if (User_Type.Equals("Supporter"))
            {
                btnUpload.Visible = false;
                fileUpload1.Visible = false;
                AddPlayerButton.Visible = false;
            }
            setImage();
           if (!IsPostBack)
           {
                Repeaterkeeper.DataSource = GetData(0);
                 Repeaterkeeper.DataBind();

                 Repeaterdefense.DataSource = GetData(1);
                 Repeaterdefense.DataBind();

                 Repeatermiddle.DataSource = GetData(2);
                 Repeatermiddle.DataBind();

                 Repeaterforward.DataSource = GetData(3);
                 Repeaterforward.DataBind();


             }
               
        }

        private DataTable GetData(int i)
        {
            String position = String.Empty;
            if (i== 0)
                position = "Goal-Keeper";
            else if (i== 1)
                position = "Defence";
            else if (i== 2)
                position = "Mid-Fielder";
            else 
                position = "Forward";

            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT image, player_name, age, country , injury FROM Player_Lis where club_name='" + club_name + "' and position='"+position+"' and market_status=0;";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                DataTable dataTable = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }

                connection.Close();

                return dataTable;
            }
        }
        protected void Repeaterkeeper_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowView = (DataRowView)e.Item.DataItem;
                string injury = rowView["injury"].ToString();

                LinkButton disablePlayerButton = (LinkButton)e.Item.FindControl("disablePlayer");
                LinkButton LinkPlayerButton = (LinkButton)e.Item.FindControl("LinkButton1");
                if (User_Type.Equals("Supporter"))
                {
                    disablePlayerButton.Visible = false;
                    LinkPlayerButton.Visible = false;
                }

                if (injury == "0")
                {
                    disablePlayerButton.BackColor = Color.Green;
                }
                else if (injury == "1")
                {
                    disablePlayerButton.BackColor = Color.Red;
                }
            }
        }
        protected void Repeaterdefense_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowView = (DataRowView)e.Item.DataItem;
                string injury = rowView["injury"].ToString();

                LinkButton disablePlayerButton = (LinkButton)e.Item.FindControl("disablePlayer");
                LinkButton LinkPlayerButton = (LinkButton)e.Item.FindControl("LinkButton1");
                if (User_Type.Equals("Supporter"))
                {
                    disablePlayerButton.Visible = false;
                    LinkPlayerButton.Visible = false;
                }
                if (injury == "0")
                {
                    disablePlayerButton.BackColor = Color.Green;
                }
                else if (injury == "1")
                {
                    disablePlayerButton.BackColor = Color.Red;
                }
            }
        }
        protected void Repeatermiddle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowView = (DataRowView)e.Item.DataItem;
                string injury = rowView["injury"].ToString();

                LinkButton disablePlayerButton = (LinkButton)e.Item.FindControl("disablePlayer");
                LinkButton LinkPlayerButton = (LinkButton)e.Item.FindControl("LinkButton1");
                if (User_Type.Equals("Supporter"))
                {
                    disablePlayerButton.Visible = false;
                    LinkPlayerButton.Visible = false;
                }
                if (injury == "0")
                {
                    disablePlayerButton.BackColor = Color.Green;
                }
                else if (injury == "1")
                {
                    disablePlayerButton.BackColor = Color.Red;
                }
            }
        }
        protected void Repeaterforward_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView rowView = (DataRowView)e.Item.DataItem;
                string injury = rowView["injury"].ToString();

                LinkButton disablePlayerButton = (LinkButton)e.Item.FindControl("disablePlayer");
                LinkButton LinkPlayerButton = (LinkButton)e.Item.FindControl("LinkButton1");
                if (User_Type.Equals("Supporter"))
                {
                    disablePlayerButton.Visible = false;
                    LinkPlayerButton.Visible = false;
                }
                if (injury == "0")
                {
                    disablePlayerButton.BackColor = Color.Green;
                }
                else if (injury == "1")
                {
                    disablePlayerButton.BackColor = Color.Red;
                }
            }
        }
        private void changeInjuryStatus(String playerName, int i)
        {

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select = "SELECT injury FROM Player_Lis WHERE player_name = '"+playerName+"';";
            string update = "UPDATE Player_Lis SET injury = @Injury WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand = new SqlCommand(select, con);
            SqlCommand updateCommand = new SqlCommand(update, con);

            string currentInjuryStatus = selectCommand.ExecuteScalar().ToString();
            if (currentInjuryStatus == "0")
            {
                updateCommand.Parameters.AddWithValue("@Injury", "1");             
            }
            else if (currentInjuryStatus == "1")
            {
                updateCommand.Parameters.AddWithValue("@Injury", "0");
            }
            updateCommand.ExecuteNonQuery();
            changeSquadFormationIfNeed(playerName);
            con.Close();
            if (i== 0)
            {
                Repeaterkeeper.DataSource = GetData(0);
                Repeaterkeeper.DataBind();
            }
            else if (i== 1)
            {
                Repeaterdefense.DataSource = GetData(1);
                Repeaterdefense.DataBind();
            }

            else if (i== 2)
            { 
                Repeatermiddle.DataSource = GetData(2);
                Repeatermiddle.DataBind();
            }
            else
            {
                Repeaterforward.DataSource = GetData(3);
                Repeaterforward.DataBind();
            }
        }
        public void changeSquadFormationIfNeed(string playerName)
        {
            if (checkIfclubExists())
            {
                if(checkifplayerExistin11(playerName))
                {
                    DataTable allPlayerName = new DataTable();
                    using (SqlConnection con = new SqlConnection(strcon1))
                    {
                        con.Open();

                        string selectQuery = "SELECT * FROM Squad_Formation WHERE club_name = @clubName;";
                        SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                        selectCommand.Parameters.AddWithValue("@clubName", club_name);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            allPlayerName.Columns.Add("player_name", typeof(string));

                            while (reader.Read())
                            {
                                for (int i = 1; i <= 11; i++)
                                {
                                    string columnName = "player_" + i;
                                    string currentPlayer = reader.GetString(reader.GetOrdinal(columnName));

                                    if (currentPlayer != playerName)
                                    {
                                        DataRow newRow = allPlayerName.NewRow();
                                        newRow["player_name"] = currentPlayer;
                                        allPlayerName.Rows.Add(newRow);
                                    }
                                }
                            }
                        }
                        con.Close();
                    }

                    string position = findPlayerPosition(playerName);
                    string image = findPlayerImage(playerName);
                    using (SqlConnection connection = new SqlConnection(strcon1))
                    {
                        string query = "SELECT player_name, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='"+position+"' AND  injury=0 AND market_status=0";

                        connection.Open();

                        SqlCommand command = new SqlCommand(query, connection);

                        SqlDataReader reader = command.ExecuteReader();
                        bool flagofChange=false;
                        if (reader.HasRows)
                        {
                            List<string> existingPlayerNames = allPlayerName.AsEnumerable().Select(row => row.Field<string>("player_name")).ToList();
                            while (reader.Read())
                            {
                                string newPlayer = reader.GetValue(0).ToString();
                                string newPlayer_image = reader.GetValue(1).ToString();
                                if (!existingPlayerNames.Contains(newPlayer))
                                {
                                    flagofChange = true;
                                    RemoveAndReplace(playerName, image, newPlayer, newPlayer_image);
                                    break; // Exit the loop after replacing the player
                                }
                            }
                        }
                        if(flagofChange==false)
                        {
                            string newPlayer = "Labellingggggggggggggg";
                            string newPlayer_image = "~/Images/bg.png";
                            RemoveAndReplace(playerName, image, newPlayer, newPlayer_image);
                        }

                        connection.Close();
                    }
                }
            }
        }
        private void RemoveAndReplace(string playerName, string playerImage, string newPlayer, string newPlayer_image)
        {
            SqlConnection con = new SqlConnection(strcon1);
            SqlCommand cmd;
            con.Open();

            string selectQuery = "SELECT * from Squad_Formation where club_name= '" + club_name + "';";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                reader.Read();
                    // Find and replace player name and image
                    for (int i = 1; i <= 11; i++)
                    {
                        string columnName = "player_" + i;
                        string imageColumnName = "image_" + i;

                        string currentPlayer = reader.GetString(reader.GetOrdinal(columnName));
                        string currentImage = reader.GetString(reader.GetOrdinal(imageColumnName));

                        if (currentPlayer == playerName)
                        {
                            reader.Close(); // Close the DataReader
                                        // Update player name
                            string updatePlayerQuery = $"UPDATE Squad_Formation SET {columnName} = @newPlayer WHERE club_name = @clubName;";
                            SqlCommand updatePlayerCommand = new SqlCommand(updatePlayerQuery, con);
                            updatePlayerCommand.Parameters.AddWithValue("@newPlayer", newPlayer);
                            updatePlayerCommand.Parameters.AddWithValue("@clubName", club_name);
                            updatePlayerCommand.ExecuteNonQuery();
                        }

                        if (currentImage == playerImage)
                        {
                            // Update player image
                            string updateImageQuery = $"UPDATE Squad_Formation SET {imageColumnName} = @newPlayerImage WHERE club_name = @clubName;";
                            SqlCommand updateImageCommand = new SqlCommand(updateImageQuery, con);
                            updateImageCommand.Parameters.AddWithValue("@newPlayerImage", newPlayer_image);
                            updateImageCommand.Parameters.AddWithValue("@clubName", club_name);
                            updateImageCommand.ExecuteNonQuery();
                            break;
                        }
                    }              
            }
        }
        private string findPlayerPosition(string playerName)
        {
            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select = "SELECT position FROM Player_Lis WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand = new SqlCommand(select, con);
            string position = selectCommand.ExecuteScalar().ToString();
            con.Close();
            return position;
        }
        private string findPlayerImage(string playerName)
        {
            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select = "SELECT image FROM Player_Lis WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand = new SqlCommand(select, con);
            string image = selectCommand.ExecuteScalar().ToString();
            con.Close ();
            return image;
        }
        private bool checkifplayerExistin11(string playerName)
        {
            bool playerExists = false;

            using (SqlConnection con = new SqlConnection(strcon1))
            {
                con.Open();

                string selectQuery = "SELECT * FROM Squad_Formation WHERE player_1 = @playerName OR player_2 = @playerName OR player_3 = @playerName OR player_4 = @playerName OR player_5 = @playerName OR player_6 = @playerName OR player_7 = @playerName OR player_8 = @playerName OR player_9 = @playerName OR player_10 = @playerName OR player_11 = @playerName;";
                SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                selectCommand.Parameters.AddWithValue("@playerName", playerName);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        playerExists = true;
                    }
                }
                con.Close();
            }

            return playerExists;
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
                    con.Close();
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
        protected void Forward_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 3);
            }
            if (e.CommandName == "SellPlayer")
            {
                
                string playerName = e.CommandArgument.ToString();
                string script = $"if (confirm('Are you sure you want to sell {playerName}? Sold players must be purchase back.'))";
                ClientScript.RegisterStartupScript(this.GetType(), "ConfirmationScript", script, true);

                Transfer(playerName, 3);
            }
        }
        protected void Middle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 2);
            }
            if (e.CommandName == "SellPlayer")
            {
                string playerName = e.CommandArgument.ToString();
                string script = $"if (confirm('Are you sure you want to sell {playerName}? Sold players must be purchase back.'))";
                ClientScript.RegisterStartupScript(this.GetType(), "ConfirmationScript", script, true);
                 Transfer(playerName, 2);
            }
        }
        protected void Defense_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 1);
            }
            if (e.CommandName == "SellPlayer")
            {
                string playerName = e.CommandArgument.ToString();

                string script = $"if (confirm('Are you sure you want to sell {playerName}? Sold players must be purchased back.'))";
                ClientScript.RegisterStartupScript(this.GetType(), "ConfirmationScript", script, true);
                Transfer(playerName, 1);
            }
        }
        protected void Keeper_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 0);
            }
            if (e.CommandName == "SellPlayer")
            {
                string playerName = e.CommandArgument.ToString();
                string script = $"if (confirm('Are you sure you want to sell {playerName}? Sold players must be purchase back.'))";
                ClientScript.RegisterStartupScript(this.GetType(), "ConfirmationScript", script, true);
                 Transfer(playerName, 0);
            }
        }
        private void Transfer(String playerName, int i)
        {

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select = "SELECT market_status FROM Player_Lis WHERE player_name = '"+playerName+"';";
            string update = "UPDATE Player_Lis SET market_status = @market_status WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand = new SqlCommand(select, con);
            SqlCommand updateCommand = new SqlCommand(update, con);

            string currentMarketStatus = selectCommand.ExecuteScalar().ToString();
            if (currentMarketStatus == "0")
            {
                updateCommand.Parameters.AddWithValue("@market_status", "1");
                changeSquadFormationIfNeed(playerName);
            }
            updateCommand.ExecuteNonQuery();
            con.Close();
            sendToMarket(playerName);
            if (i== 0)
            {
                Repeaterkeeper.DataSource = GetData(0);
                Repeaterkeeper.DataBind();
            }
            else if (i== 1)
            {
                Repeaterdefense.DataSource = GetData(1);
                Repeaterdefense.DataBind();
            }

            else if (i== 2)
            {
                Repeatermiddle.DataSource = GetData(2);
                Repeatermiddle.DataBind();
            }
            else
            {
                Repeaterforward.DataSource = GetData(3);
                Repeaterforward.DataBind();
            }
        }
        public void sendToMarket(string playerName)
        {

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select2 = "SELECT image,position,age,country,club_name,market_price,salary FROM Player_Lis WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand2 = new SqlCommand(select2, con);
            SqlDataReader reader = selectCommand2.ExecuteReader();
            if (reader.Read())
            {
                string image = reader["image"].ToString();
                image = image.Substring(1);
                string position = reader["position"].ToString();
                string age = reader["age"].ToString();
                string country = reader["country"].ToString();
                string clubName = reader["club_name"].ToString();
                string marketPrice = reader["market_price"].ToString();
                string salary = reader["salary"].ToString();
                reader.Close();
                string insert = "INSERT INTO market_table (player_name, player_image, position, age, country, current_club,current_club_image, market_price, salary, heighest_bid_club, heighest_bid_club_image, heighest_bid, status) VALUES (@playerName, @image, @position, @age, @country, @clubName,@clubImage, @marketPrice, @salary,'None', 'Images/default-team-logo(1).png', 0, 'Auction going');";
                SqlCommand insertCommand = new SqlCommand(insert, con);
                insertCommand.Parameters.AddWithValue("@playerName", playerName);
                insertCommand.Parameters.AddWithValue("@image", image);
                insertCommand.Parameters.AddWithValue("@position", position);
                insertCommand.Parameters.AddWithValue("@age", age);
                insertCommand.Parameters.AddWithValue("@country", country);
                insertCommand.Parameters.AddWithValue("@clubName", clubName);
                insertCommand.Parameters.AddWithValue("@clubImage", global_filepath);
                insertCommand.Parameters.AddWithValue("@marketPrice", marketPrice);
                insertCommand.Parameters.AddWithValue("@salary", salary);
                insertCommand.ExecuteNonQuery();
            }
            reader.Close();
            con.Close();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            btnUpload.Visible = false;
            fileUpload1.Visible = true;
            doneUpload.Visible = true;
        }
        protected void DoneUpload_Click(object sender, EventArgs e)
        {
            btnUpload.Visible = true;
            fileUpload1.Visible = false;
            doneUpload.Visible = false;

            string filepath = global_filepath;
            string filename = string.Empty;
            if (fileUpload1.HasFile)
            {
                filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
                fileUpload1.SaveAs(Server.MapPath("Images/" + filename));
                filepath = "Images/" + filename;
            }
            SqlConnection con = new SqlConnection(strcon1);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("UPDATE Manager_Lists set club_logo = @club_logo where club_name='" + club_name + "'", con);
            cmd.Parameters.AddWithValue("@club_logo", filepath);
            cmd.ExecuteNonQuery();
            con.Close();
            setImage();
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
                if(da.IsDBNull(3))
                {
                    global_filepath = "Images/default-team-logo(1).png";
                    Console.WriteLine("From Default");
                }
                else
                {
                    global_filepath = da.GetValue(3).ToString();
                    Console.WriteLine("From DB");
                }
                string script = "<script>$(document).ready(function() { readURL2('" + global_filepath + "'); });</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "SetImageSource", script);
                con.Close();
                return;
            }
        }
        protected void AddPlayerButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddPlayerRecord.aspx?type="+User_Type+"&club_name="+club_name+"");
        }

    }
}