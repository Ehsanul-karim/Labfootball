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

namespace Labfootball
{
    public partial class home_m : System.Web.UI.Page
    {
        String club_name = String.Empty;
        String User_Type = String.Empty;

        string strcon1 = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {
            club_name = Request.QueryString["club_name"].ToString().Trim();
            User_Type = Request.QueryString["type"].ToString().Trim();

            session_club.Text = club_name;
            if (User_Type.Equals("Manager"))
            {
                btnUpload.Visible = true;
                fileUpload1.Visible = false;
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
                string query = "SELECT image, player_name, age, country , injury FROM Player_Lis where club_name='" + club_name + "' and position='"+position+"';";
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
        protected void Forward_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 3);
            }
        }
        protected void Middle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 2);
            }
        }
        protected void Defense_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 1);
            }
        }
        protected void Keeper_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DisablePlayer")
            {
                string playerName = e.CommandArgument.ToString();
                changeInjuryStatus(playerName, 0);
            }
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
                    global_filepath = "Images/default-team-logo%20(1).png";
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