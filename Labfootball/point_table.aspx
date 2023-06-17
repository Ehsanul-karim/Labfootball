<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="point_table.aspx.cs" Inherits="Labfootball.point_table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="main-content" id="main-content">
        <h3 class="i-name">Point Table</h3>
        <h3 class="season">Season <br> <p class="year">2022-23</p></h3>

        <div class="board_wrap">
            <table class="content_table" width="100%">
                <thead>
                    <tr>
                        <th class="club_head" style="width: 500px;">Club</th>
                        <th class="MP_head" style="width: 40px;">MP</th>
                        <th class="W_head"  style="width: 40px;">W</th>
                        <th class="W_head"  style="width: 40px;">D</th>
                        <th class="W_head"  style="width: 40px;">L</th>
                        <th class="W_head"  style="width: 40px;">GF</th>
                        <th class="W_head"  style="width: 40px;">GA</th>
                        <th class="W_head"  style="width: 40px;">GD</th>
                        <th class="W_head"  style="width: 60px;">Pts</th>
                        <th class="W_head">Last 5</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="club">
                            <p class="club-no">1</p>
                            <img src="Images/PSG.jpeg" alt="" />
                            <h5>Paris Saint-Germain F.C.</h5>
                        </td>
                        <td class="MP">
                            <h5>26</h5>
                        </td>
                        <td class="W">
                            <h5>22</h5>
                        </td>
                        <td class="D">
                            <h5>3</h5>
                        </td>
                        <td class="L">
                            <h5>3</h5>
                        </td>
                        <td class="GF">
                            <h5>66</h5>
                        </td>
                        <td class="GA">
                            <h5>26</h5>
                        </td>
                        <td class="GD">
                            <h5>40</h5>
                        </td>
                        <td class="PTS">
                            <h5>69</h5>
                        </td>
                        <td class="Last_5">
                            <div class="rating">
                                <input type="checkbox" name="Last_5">
                                <input type="checkbox" name="Last_5">
                                <input type="checkbox" name="Last_5">
                                <input type="checkbox" name="Last_5">
                                <input type="checkbox" name="Last_5">                                
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="club">
                            <p class="club-no">1</p>
                            <img src="Images/PSG.jpeg" alt="" />
                            <h5>Paris Saint-Germain F.C.</h5>
                        </td>
                        
                    </tr>





                </tbody>
            </table>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li class="nav-item"><a href="home.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item"><a href="transfer.aspx"><i class="fa-solid fa-futbol"></i><span>Market Place</span></a></li>
            <li class="nav-item"><a href="match-schedule.aspx"><i class="fa-regular fa-calendar-days"></i><span>Match Schedule</span></a></li>
            <li class="nav-item active"><a href="point_table.aspx"><i class="fa-solid fa-ranking-star"></i><span>Point Table</span></a></li>

</asp:Content>
