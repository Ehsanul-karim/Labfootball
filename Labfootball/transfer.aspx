<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="Labfootball.transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="main-content" id="main-content">
        <h3 class="i-name">Transfer</h3>

        <div class="values">
            <div class="val-box">
                <i class="fas fa-users"> </i>
                <div>
                    <h3>8237</h3>
                    <span>New Users</span>
                </div>
            </div>
            <div class="val-box">
                <i class="fas fa-shopping-cart"> </i>
                <div>
                    <h3>8237</h3>
                    <span>New Users</span>
                </div>
            </div>
            <div class="val-box">
                <i class="fas fa-bacon"> </i>
                <div>
                    <h3>8237</h3>
                    <span>New Users</span>
                </div>
            </div>
            <div class="val-box">
                <i class="fas fa-dollar-sign"> </i>
                <div>
                    <h3>8237</h3>
                    <span>New Users</span>
                </div>
            </div>
        </div>
        <div class="board_wrap">
            <table class="content_table" width="100%">
                <thead>
                    <tr>
                        <th>Player</th>
                        <th>Previous Club</th>
                        <th>Market Value(€)</th>
                        <th>Fee(€)</th>
                        <th>Heighest Bid</th>
                        <th>Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/RealMadrid.png" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active solded_player" id="sold">
                            <p>Sold</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/RealMadrid.png" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active going_player" id="going">
                            <p>Aution going</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/RealMadrid.png" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active unsold_player" id="going">
                            <p>Unsold</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/PSG.jpeg" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active going_player" id="going">
                            <p>Aution going</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/PSG.jpeg" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active going_player" id="going">
                            <p>Aution going</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/PSG.jpeg" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active solded_player" id="sold">
                            <p>Sold</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/PSG.jpeg" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active solded_player" id="sold">
                            <p>Sold</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                    <tr>
                        <td class="people">
                            <img src="Images/mesi.png" alt="" />
                            <div class="people-de">
                                <h5>Lionel Messi</h5>
                                <p>
                                    Attacker <br />
                                    24 years, Argentina
                                </p>
                            </div>
                        </td>
                        <td class="people-des">
                            <div class="player-des">
                                <img src="Images/PSG.jpeg" alt="" />
                                <h5>Paris Saint-Germain F.C.</h5>
                            </div>
                        </td>
                        <td class="market-value">75.00m</td>
                        <td class="fee">6.36m</td>
                        <td>
                            <div class ="bit_setter">
                             <img src="Images/PSG.jpeg" alt="" />
                                <div class="highest_bid">
                                  <h5>Real Madrid</h5>
                                    <p>72.00m(€)</p>
                                </div>
                            </div>
                        </td>
                        <td class="active solded_player" id="sold">
                            <p>Sold</p>
                        </td>
                        <td>
                            <button><i class="fa-solid fa-pen-to-square"></i></button>
                            <button><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li class="nav-item"><a href="home.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item active"><a href="transfer.aspx"><i class="fa-solid fa-futbol"></i><span>Market Place</span></a></li>
            <li class="nav-item"><a href="match-schedule.aspx"><i class="fa-regular fa-calendar-days"></i><span>Match Schedule</span></a></li>
            <li class="nav-item"><a href="point_table.aspx"><i class="fa-solid fa-ranking-star"></i><span>Point Table</span></a></li>

</asp:Content>