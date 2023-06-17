<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="PlayerRecord.aspx.cs" Inherits="Labfootball.PlayerRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="main-content" id="main-content">
                
                <div class="container">
                    <div class ="row">
                        <div class="col-md-6 mx-auto">
                        
                            <div class="card">
                                <div class ="card-body">
                                    <div class="row">
                                        <div class="col">
                                            <center>
                                                <img width="150px" src="Images/user_male_26px.png" />
                                            </center>
                                        </div>
                                    </div>
                                     <div class="row">
                                        <div class="col">
                                            <center>
                                                <h3>Player Details</h3>

                                            </center>
                                        </div>
                                    </div>
                                  <div class="row">
                                        <div class="col">
                                            <hr>
                                        </div>
                                    </div>
                                  <div class="row">
                                        <div class="col">
                                            <div class="form-group">
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Player ID"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        
                        </div>
                    </div>
               </div>
        



        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <li class="nav-item active"><a href="home.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item"><a href="transfer.aspx"><i class="fa-solid fa-futbol"></i><span>Market Place</span></a></li>
            <li class="nav-item"><a href="match-schedule.aspx"><i class="fa-regular fa-calendar-days"></i><span>Match Schedule</span></a></li>
            <li class="nav-item"><a href="point_table.aspx"><i class="fa-solid fa-ranking-star"></i><span>Point Table</span></a></li>
</asp:Content>
