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

namespace Labfootball
{
    public partial class GamePlan : System.Web.UI.Page
    {
        String club_name = String.Empty;
        String User_Type = String.Empty;
        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        static string global_filepath2;
        private string imgId;
        DataTable subdataTable = new DataTable();

        static int f=0, m=0, d=0,g=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            club_name = "Barcelona";
            session_club.Text = club_name;
            setImage();
            if (!IsPostBack)
            {
                subdataTable = GetData();
                RepeaterSubstitute.DataSource = subdataTable;
                RepeaterSubstitute.DataBind();
                PopulatePlaying11AndSubstitutes();
            }
        }
        private void PopulatePlaying11AndSubstitutes()
        {
            DataTable dataTable = GetForwardsData();
            for (int i = 1; i <= dataTable.Rows.Count; i++)
            {
                string imageUrl = dataTable.Rows[i - 1]["image"].ToString();
                string position = dataTable.Rows[i - 1]["position"].ToString();
                string charName = dataTable.Rows[i - 1]["player_name"].ToString();
                    if(string.Compare(playerImage4.ImageUrl, "~/Images/bg.png")==0)
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
                        SendToSubstitute(imageUrl,charName);
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
                    SendToSubstitute(imageUrl, charName);
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
                    SendToSubstitute(imageUrl, charName);
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
                    SendToSubstitute(imageUrl, charName);
                }
            }
        }

        private DataTable GetForwardsData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Forward' AND  injury=0";

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
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Mid-Fielder' AND  injury=0";

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
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Defence' AND  injury=0";

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
                string query = "SELECT player_name, position, image FROM Player_Lis WHERE club_name='" + club_name + "' AND position='Goal-Keeper' AND  injury=0";

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



        private DataTable GetData()
        {
            using (SqlConnection connection = new SqlConnection(strcon1))
            {
                string query = "SELECT image, player_name FROM Player_Lis where club_name='" + club_name + "' and injury=1;";

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
        protected void Substitute_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void SendToSubstitute(String imageurl, string playerName)
        {
            DataRow newRow = subdataTable.NewRow();
            newRow["image"] = ""+imageurl;
            newRow["player_name"] = ""+playerName;
            subdataTable.Rows.Add(newRow);

            RepeaterSubstitute.DataSource = subdataTable;
            RepeaterSubstitute.DataBind();

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

        protected string GetTruncatedPlayerName(object playerName)
        {
            string name = playerName.ToString();
            if (name.Length > 7)
            {
                name = name.Substring(0, 7); // Truncate the player name to 7 characters
            }
            return name;
        }
    }
}