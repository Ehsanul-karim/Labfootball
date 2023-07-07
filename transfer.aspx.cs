using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Labfootball
{
    public partial class transfer : System.Web.UI.Page
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
            settingslink.HRef = $"Settings.aspx?type={User_Type}&club_name={club_name}";
            session_club.Text = club_name;
            setImage();
            if (!IsPostBack)
            {
                DataTable marketData = FetchMarketTableDataFromDatabase();
                marketTableRepeater.DataSource = marketData;
                marketTableRepeater.DataBind();
            }
        }

        private DataTable FetchMarketTableDataFromDatabase()
        {
            DataTable marketData = new DataTable();
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT [player_name], [player_image], [position], [age], [country], [current_club], [current_club_image], [market_price], [salary], [heighest_bid_club], [heighest_bid_club_image], [heighest_bid], [status] FROM [WebProject].[dbo].[market_table]";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(marketData);
            }
            return marketData;
        }

        protected string GetPlayerStatusCssClass(string status)
        {
            if (status.Equals("Aution going"))
            {
                return "active going_player";
            }
            else if (status.Equals("Unsold"))
            {
                return "active unsold_player";
            }
            else
            {
                return "active solded_player";
            }
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
        protected void PlaceBid_Command(object sender, CommandEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)((LinkButton)sender).NamingContainer;           
            TextBox txtHeighestBid = (TextBox)item.FindControl("txtHeighestBid");
            txtHeighestBid.Enabled = true;
            txtHeighestBid.Text="";

            LinkButton PlaceBid = (LinkButton)item.FindControl("PlaceBid");

            LinkButton Restore = (LinkButton)item.FindControl("Restore");

            LinkButton Accept = (LinkButton)item.FindControl("Accept");

            LinkButton BidDone = (LinkButton)item.FindControl("BidDone");

            PlaceBid.Visible = false;
            Restore.Visible = false;
            Accept.Visible = false;
            BidDone.Visible = true;
        }
         protected void BidDone_Command(object sender, CommandEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)((LinkButton)sender).NamingContainer;

            LinkButton PlaceBid = (LinkButton)item.FindControl("PlaceBid");
            LinkButton Restore = (LinkButton)item.FindControl("Restore");

            LinkButton Accept = (LinkButton)item.FindControl("Accept");

            LinkButton BidDone = (LinkButton)item.FindControl("BidDone");

            PlaceBid.Visible = true;
            Restore.Visible = true;
            Accept.Visible = true;
            BidDone.Visible = false;
            TextBox txtHeighestBid = (TextBox)item.FindControl("txtHeighestBid");
            txtHeighestBid.Enabled = false;
            string playerName = e.CommandArgument.ToString();
            string prevclub = findPrevClub(playerName);

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();

            if (prevclub.Equals(club_name))
            {
                SqlCommand update1 = new SqlCommand("UPDATE Player_Lis set market_price = @market_price where player_name='"+playerName+"'", con);
                int heighestBid;
                int.TryParse(txtHeighestBid.Text.Trim(), out heighestBid);
                update1.Parameters.AddWithValue("@market_price", heighestBid);
                update1.ExecuteNonQuery();
                SqlCommand update2 = new SqlCommand("UPDATE market_table set market_price = @market_price where player_name='"+playerName+"'", con);
                update2.Parameters.AddWithValue("@market_price", heighestBid);
                update2.ExecuteNonQuery();
            }
            else
            {
                SqlCommand update1 = new SqlCommand("UPDATE market_table set heighest_bid_club = @heighest_bid_club, heighest_bid_club_image = @heighest_bid_club_image, heighest_bid = @heighest_bid  where player_name='"+playerName+"'", con);
                int heighestBid;
                int.TryParse(txtHeighestBid.Text.Trim(), out heighestBid);
                update1.Parameters.AddWithValue("@heighest_bid_club", club_name);
                update1.Parameters.AddWithValue("@heighest_bid_club_image", global_filepath2);
                update1.Parameters.AddWithValue("@heighest_bid", heighestBid);
                update1.ExecuteNonQuery();
            }

            con.Close();
            DataTable marketData = FetchMarketTableDataFromDatabase();
            marketTableRepeater.DataSource = marketData;
            marketTableRepeater.DataBind();
        }

        protected void Restore_Command(object sender, CommandEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)((LinkButton)sender).NamingContainer;

            string playerName = e.CommandArgument.ToString();
            TextBox txtHeighestBid = (TextBox)item.FindControl("txtHeighestBid");
            string prevclub = findPrevClub(playerName);
            string status = "Unsold";

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();

            if (prevclub.Equals(club_name))
            {

                    SqlCommand update1 = new SqlCommand("UPDATE market_table set status = @status where player_name='"+playerName+"'", con);
                    update1.Parameters.AddWithValue("@status", status);
                    update1.ExecuteNonQuery();
                    DataTable marketData = FetchMarketTableDataFromDatabase();
                    marketTableRepeater.DataSource = marketData;
                    marketTableRepeater.DataBind();
                    SqlCommand delete = new SqlCommand("DELETE from market_table WHERE player_name = '" + playerName +"'", con);
                    delete.ExecuteNonQuery();
                    SqlCommand update2 = new SqlCommand("UPDATE Player_Lis set club_name = @club_name,market_status=0 where player_name='"+playerName+"'", con);
                    update2.Parameters.AddWithValue("@club_name", club_name);
                    update2.ExecuteNonQuery();
                
            }
            else
            {
                Response.Write("<script>alert('The Player is from another Team');</script>");
            }

            con.Close();
        }

        protected void Accept_Command(object sender, CommandEventArgs e)
        {
            RepeaterItem item = (RepeaterItem)((LinkButton)sender).NamingContainer;

            string playerName = e.CommandArgument.ToString();
            TextBox txtHeighestBid = (TextBox)item.FindControl("txtHeighestBid");
            Label Label1 = (Label)item.FindControl("Label1");
            string prevclub = findPrevClub(playerName);
            string newclub = findNewClub(playerName);
            int heightest = findHeighest(playerName);
            string status = "Sold";

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();

            if (prevclub.Equals(club_name))
            {
                if(Label1.Text.Equals("None"))
                {
                    Response.Write("<script>alert('No one still Place a price for this player');</script>");
                }
                else
                {
                    SqlCommand update1 = new SqlCommand("UPDATE market_table set status = @status where player_name='"+playerName+"'", con);
                    update1.Parameters.AddWithValue("@status", status);
                    update1.ExecuteNonQuery();
                    DataTable marketData = FetchMarketTableDataFromDatabase();
                    marketTableRepeater.DataSource = marketData;
                    marketTableRepeater.DataBind();
                    SqlCommand delete = new SqlCommand("DELETE from market_table WHERE player_name = '" + playerName +"'", con);
                    delete.ExecuteNonQuery();
                    SqlCommand update2 = new SqlCommand("UPDATE Player_Lis set club_name = @club_name,market_price=@market_price,market_status=0 where player_name='"+playerName+"'", con);
                    update2.Parameters.AddWithValue("@club_name", newclub);
                    update2.Parameters.AddWithValue("@market_price", heightest);
                    update2.ExecuteNonQuery();
                }
            }
            else
            {
                Response.Write("<script>alert('The Player is from another Team');</script>");
            }

            con.Close();
        }

        protected void marketTableRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "upd")
            {
                
                // Update command logic

                // Perform necessary actions
            }
            else if (e.CommandName == "res")
            {
                // Restore command logic

                // Perform necessary actions
            }
            else if (e.CommandName == "acpt")
            {
                // Accept command logic
                // Perform necessary actions
            }
        }
        private string findPrevClub(string playerName)
        {
            String prev_club=String.Empty;

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select2 = "SELECT current_club FROM market_table WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand2 = new SqlCommand(select2, con);
            SqlDataReader reader = selectCommand2.ExecuteReader();
            if (reader.Read())
            {
                prev_club = reader["current_club"].ToString();
            }
            reader.Close();
            con.Close();
                return prev_club;
        }
        private string findNewClub(string playerName)
        {
            String new_club = String.Empty;

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select2 = "SELECT heighest_bid_club FROM market_table WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand2 = new SqlCommand(select2, con);
            SqlDataReader reader = selectCommand2.ExecuteReader();
            if (reader.Read())
            {
                new_club = reader["heighest_bid_club"].ToString();
            }
            reader.Close();
            con.Close();
            return new_club;
        }
        private int findHeighest(string playerName)
        {
            int bid=0;

            SqlConnection con = new SqlConnection(strcon1);
            con.Open();
            string select2 = "SELECT heighest_bid FROM market_table WHERE player_name = '"+playerName+"';";
            SqlCommand selectCommand2 = new SqlCommand(select2, con);
            SqlDataReader reader = selectCommand2.ExecuteReader();
            if (reader.Read())
            {
                bid = reader.GetInt32(0);
            }
            reader.Close();
            con.Close();
            return bid;
        }
        
    }
}