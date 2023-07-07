<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="Labfootball.transfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
               <script type="text/javascript">
               
               function readURL3(imageUrl2) {
                    $('#imgview2').attr('src', imageUrl2);
               }

               </script>
    <style>
        .people{
            width:150px;
        }
        td .spbutton {
            outline: none;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            padding: 10px;
            color: white;
            text-decoration:none;
        }
        .board_wrap .bidprice {
    font-weight: 400;
    font-size: 12px;
    color: #787d8d;
    width:75px;
        }
        .board_wrap .bidSetter {
    font-weight: 600;
    font-size: 14px;
}
        </style>
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
                        <th style="text-align:center">Status</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="marketTableRepeater" runat="server"  OnItemCommand="marketTableRepeater_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="people">
                                    <img src='<%# Eval("player_image") %>' alt="PlayerImage" />
                                        <div class="people-de">
                                            <h5><%# Eval("player_name") %></h5>
                                            <p>
                                            <%# Eval("position") %> <br />
                                            <%# Eval("age") %> years, <%# Eval("country") %>
                                            </p>
                                        </div>
                                </td>
                    <td class="people-des">
                        <div class="player-des">
                            <img src='<%# Eval("current_club_image") %>' alt="currentClub" />
                            <h5><%# Eval("current_club") %></h5>
                        </div>
                    </td>
                    <td class="market-value"><%# Eval("market_price") %>m</td>
                    <td class="fee"><%# Eval("salary") %>m</td>
                    <td>
                        <div class="bit_setter">
                            <img src='<%# Eval("heighest_bid_club_image") %>' alt="HeighestClub" />
                            <div class="highest_bid">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("heighest_bid_club") %>' CssClass="bidSetter"></asp:Label>
                                <asp:TextBox ID="txtHeighestBid" runat="server" Text='<%# Eval("heighest_bid") + "m(€)" %>' Enabled="false" CssClass="bidprice"></asp:TextBox>
                            </div>
                        </div>
                    </td>
                    <td class='<%# GetPlayerStatusCssClass((string)Eval("status")) %>'>
                        <p> <%# Eval("status") %></p>
                    </td>
                    <td id="editing" runat="server">
                                        <asp:LinkButton ID="PlaceBid" BackColor=#0298cf CssClass="spbutton" runat="server" OnCommand="PlaceBid_Command">
                                             <i class="fa-solid fa-pen-to-square"></i>
                                         </asp:LinkButton>
                                         <asp:LinkButton ID="BidDone" BackColor=#0298cf CssClass="spbutton" runat="server" CommandName="upd" Visible="false" CommandArgument='<%# Eval("player_name") %>' OnCommand="BidDone_Command">
                                             <i class="fa-solid fa-o"></i>
                                         </asp:LinkButton>
                                         <asp:LinkButton ID="Restore" BackColor="Red" CssClass="spbutton" runat="server" CommandName="res" CommandArgument='<%# Eval("player_name") %>'  OnCommand="Restore_Command">
                                             <i class="fa-solid fa-rotate-right"></i>
                                         </asp:LinkButton>
                                         <asp:LinkButton ID="Accept" BackColor=#252525 CssClass="spbutton" runat="server" CommandName="acpt" CommandArgument='<%# Eval("player_name") %>'  OnCommand="Accept_Command">
                                             <i class="fa-solid fa-check"></i>
                                        </asp:LinkButton>
                                
                    </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div class="sidebar" id="sidebar">
        <div class="club-content">
            <img src=""  id="imgview2" alt="club Image"  class="img-fluid"  style="width:100px; border-radius: 50%;" />
            <h4><asp:Label ID="session_club" runat="server" Text=""></asp:Label></h4> 
        </div>
        <ul class="nav-links">
               <li class="nav-item"><a id="homeLink" runat="server" href="home_m.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item active"><a href="transfer.aspx"><i class="fa-solid fa-futbol"></i><span>Market Place</span></a></li>
            
        </ul>
         <ul class="nav-links settings-menu">
            <li class="nav-item"> <a  id="settingslink" runat="server" href="settings.aspx"><i class="fa-solid fa-gear"></i><span>Settings</span></a></li>
            <li class="nav-item"> <a href="WelcomePage.aspx"><i class="fa-solid fa-arrow-right-from-bracket"></i><span>Log out</span></a></li>
         </ul>
       </div>
</asp:Content>