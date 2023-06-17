<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="match-schedule.aspx.cs" Inherits="Labfootball.match_schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="main-content" id="main-content">
        <div class="match-tabs">
            <li class="tab-link">
                <a href="#match-date">Match By Date</a>
            </li>
            <li class="tab-link">
                <a href="#match-group">Match By Group</a>
            </li>
        </div>
        <h1 class="section-heading">Match By Date</h1>
        <div class="row">
            <div class="col-3">
                <div class="match">
                    <div class="match-info">
                        <h4>Match Number<span class="badge">1</span> </h4>
                    </div>
                    <div class="flags">
                        <div class="home-flag">
                            <img src="./Images/Chicago-Fire-logo-500x300.png" alt="${match.home_team}" class="flag" />
                        <h3 class="home-team">Chicago F.C.</h3>
                        </div>
                        <span class="vs">
                        VS
                        </span>
                        <div class="away-flag">
                        <img src="./Images/Olympique-Lyonnais-logo-500x338.png" alt="${match.away_team}" class="flag" />
                        <h3 class="home-team">Olympique Lyon</h3>
                        </div>
                    </div>
                    <div class="time-area">
                        <div class="time">
                            <h4 class="month">January</h4>
                            <h4 class="day">Tue</h4>
                            <h4 class="date">22</h4>
                        </div>
                        <h4 class="match-time">1:00 AM</h4>
                    </div>
                </div>
            </div>

            <div class="col-3">
                <div class="match">
                    <div class="match-info">
                        <h4>Match Number<span class="badge">1</span> </h4>
                    </div>
                    <div class="flags">
                        <div class="home-flag">
                            <img src="./Images/Chicago-Fire-logo-500x300.png" alt="${match.home_team}" class="flag" />
                        <h3 class="home-team">Chicago F.C.</h3>
                        </div>
                        <span class="vs">
                        VS
                        </span>
                        <div class="away-flag">
                        <img src="./Images/Olympique-Lyonnais-logo-500x338.png" alt="${match.away_team}" class="flag" />
                        <h3 class="home-team">Olympique Lyon</h3>
                        </div>
                    </div>
                    <div class="time-area">
                        <div class="time">
                            <h4 class="month">January</h4>
                            <h4 class="day">Tue</h4>
                            <h4 class="date">22</h4>
                        </div>
                        <h4 class="match-time">1:00 AM</h4>
                    </div>
                </div>
            </div>

            <div class="col-3">
                <div class="match">
                    <div class="match-info">
                        <h4>Match Number<span class="badge">1</span> </h4>
                    </div>
                    <div class="flags">
                        <div class="home-flag">
                            <img src="./Images/Chicago-Fire-logo-500x300.png" alt="${match.home_team}" class="flag" />
                        <h3 class="home-team">Chicago F.C.</h3>
                        </div>
                        <span class="vs">
                        VS
                        </span>
                        <div class="away-flag">
                        <img src="./Images/Olympique-Lyonnais-logo-500x338.png" alt="${match.away_team}" class="flag" />
                        <h3 class="home-team">Olympique Lyon</h3>
                        </div>
                    </div>
                    <div class="time-area">
                        <div class="time">
                            <h4 class="month">January</h4>
                            <h4 class="day">Tue</h4>
                            <h4 class="date">22</h4>
                        </div>
                        <h4 class="match-time">1:00 AM</h4>
                    </div>
                </div>
            </div>
        </div>

        <h1 class="section-heading">Match By Group</h1>
        <div class="row">
            <div class="col-3">
                <div class="match">
                    <div class="match-info">
                        <h4>Match Number<span class="badge">1</span> </h4>
                    </div>
                    <div class="flags">
                        <div class="home-flag">
                            <img src="./Images/Chicago-Fire-logo-500x300.png" alt="${match.home_team}" class="flag" />
                        <h3 class="home-team">Chicago F.C.</h3>
                        </div>
                        <span class="vs">
                        VS
                        </span>
                        <div class="away-flag">
                        <img src="./Images/Olympique-Lyonnais-logo-500x338.png" alt="${match.away_team}" class="flag" />
                        <h3 class="home-team">Olympique Lyon</h3>
                        </div>
                    </div>
                    <div class="time-area">
                        <div class="time">
                            <h4 class="month">January</h4>
                            <h4 class="day">Tue</h4>
                            <h4 class="date">22</h4>
                        </div>
                        <h4 class="match-time">1:00 AM</h4>
                    </div>
                </div>
            </div>

            <div class="col-3">
                <div class="match">
                    <div class="match-info">
                        <h4>Match Number<span class="badge">1</span> </h4>
                    </div>
                    <div class="flags">
                        <div class="home-flag">
                            <img src="./Images/Chicago-Fire-logo-500x300.png" alt="${match.home_team}" class="flag" />
                        <h3 class="home-team">Chicago F.C.</h3>
                        </div>
                        <span class="vs">
                        VS
                        </span>
                        <div class="away-flag">
                        <img src="./Images/Olympique-Lyonnais-logo-500x338.png" alt="${match.away_team}" class="flag" />
                        <h3 class="home-team">Olympique Lyon</h3>
                        </div>
                    </div>
                    <div class="time-area">
                        <div class="time">
                            <h4 class="month">January</h4>
                            <h4 class="day">Tue</h4>
                            <h4 class="date">22</h4>
                        </div>
                        <h4 class="match-time">1:00 AM</h4>
                    </div>
                </div>
            </div>

            <div class="col-3">
                <div class="match">
                    <div class="match-info">
                        <h4>Match Number<span class="badge">1</span> </h4>
                    </div>
                    <div class="flags">
                        <div class="home-flag">
                            <img src="./Images/Chicago-Fire-logo-500x300.png" alt="${match.home_team}" class="flag" />
                        <h3 class="home-team">Chicago F.C.</h3>
                        </div>
                        <span class="vs">
                        VS
                        </span>
                        <div class="away-flag">
                        <img src="./Images/Olympique-Lyonnais-logo-500x338.png" alt="${match.away_team}" class="flag" />
                        <h3 class="home-team">Olympique Lyon</h3>
                        </div>
                    </div>
                    <div class="time-area">
                        <div class="time">
                            <h4 class="month">January</h4>
                            <h4 class="day">Tue</h4>
                            <h4 class="date">22</h4>
                        </div>
                        <h4 class="match-time">1:00 AM</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <li class="nav-item"><a href="home.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item"><a href="transfer.aspx"><i class="fa-solid fa-futbol"></i><span>Market Place</span></a></li>
            <li class="nav-item active"><a href="match-schedule.aspx"><i class="fa-regular fa-calendar-days"></i><span>Match Schedule</span></a></li>
            <li class="nav-item"><a href="point_table.aspx"><i class="fa-solid fa-ranking-star"></i><span>Point Table</span></a></li>
</asp:Content>