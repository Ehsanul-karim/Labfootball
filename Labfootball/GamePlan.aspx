<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="GamePlan.aspx.cs" Inherits="Labfootball.GamePlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <script type="text/javascript">

               function readURL2(imgId, imageUrl) {
                   $('#' + imgId).attr('src', imageUrl);
               }
           function readURL3(imageUrl2) {
               $('#imgview2').attr('src', imageUrl2);
           }

               $(document).ready(function () {
                   // Add click event handler to player containers
                   $(".playground-player").click(function () {
                       // Remove 'selected' class from all player containers
                       $(".playground-player").removeClass("selected");

                       // Add 'selected' class to the clicked player container
                       $(this).addClass("selected");
                   });
               });

               $(document).ready(function () {
                   // Add click event handler to item containers
                   $(".item").click(function () {
                       // Remove 'selected' class from all item containers
                       $(".item").removeClass("selected");

                       // Add 'selected' class to the clicked item container
                       $(this).addClass("selected");
                   });
               });

           </script>
    <style>

          h2:after {
                 content: "";
                 display: block;
                 height: 2px;
                background-color: #FFF;
                margin-top: 5px;
            }
            .main-content {
                background-image: url('images/playground.jpg');
                background-size: cover;
                background-position: center;
                background-repeat: no-repeat;
                height: 100vh;
            }

            .card-wraper {
                height: 500px;
                margin: auto;
                width: 400px;
                overflow-y: scroll;
            }

            .card img {
                height: 80px;
                width: 80px;
                object-fit: cover;
                border-radius: 50%;
            }
            .playground {
                width: 500px;
                height: 600px;
                background-image: url('../../Images/footaball.png');
                background-size: contain;
                background-position: center;
                position: relative;
                background-repeat: no-repeat;
                margin: 10px;
            }
            .playground-player img{
                height: 70px;
                width: 70px;
                object-fit: cover;
                border-radius: 50%;
            }
            .item {
                text-align: center;
            }

            .item h6 {
                margin: 10px 0;
            }
            .player1 {
                transform: translate(100px, -230px);
            }

            .player2 {
                transform: translate(-170px, -230px);
            }

            .player3 {
                transform: translate(-70%, +5%);
            }

            .player4 {
                transform: translate(-32px, -290px);
            }

            .player5 {
                transform: translate(-110px, -90px);
            }
            .player6 {
                transform: translate(45px, -90px);
            }
            .player7 {
                transform: translate(-180px, 50px);
            }
            .player8 {
                transform: translate(-100px, 120px);
            }
            .player9 {
                transform: translate(20px, 120px);
            }
            .player10 {
                transform: translate(110px, 50px);
            }
            .player11 {
                transform: translate(-35px, 200px);
            }
.truncated-player-name {
    max-width: 7ch;
    font-size:13px;
    margin-left:12px;
}

.truncated-player-name .content-wrapper {
    white-space: nowrap;
    overflow: hidden;
    
}
.selected {
  border: 5px solid red; /* Example border style */
}
.row {
  position: relative;
}

.text-center {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
.SwapButton {
    display: inline-block; /* Add this line */
  border-radius: 50%;
  width: 60px;
  height:60px;
  background-color: white;
  border: none;
  cursor: pointer;
  transition: background-color 0.3s;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="main-content" id="main-content">

                    <div class="row">
                        <div class="col-md-6">
                            <h2  style="color:#023c07;padding: 20px;">Substitute Bench</h2>
                            <div class="card-wraper">
                                <div class="card">
                                    <div class="row">
                                        <asp:Repeater ID="RepeaterSubstitute" runat="server" OnItemCommand="Substitute_ItemCommand">
                                            <ItemTemplate>
                                                <div class="item col-md-6">
                                                    <asp:Image class="card-img-top" runat="server" ImageUrl='<%# Eval("image") %>' />
                                                    <h6><%# Eval("player_name") %></h6>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>                                                                             
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <h2 style="color:#023c07; padding: 20px;">Playing 11</h2>

                            <div class="playground" id="imageContainer">
                                <div class="playground-player player1">
                                    <asp:Image ID="playerImage1" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label1" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                                <div class="playground-player player2">
                                     <asp:Image ID="playerImage2" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label2" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                                <div class="playground-player player3">
                                    <asp:Image ID="playerImage3" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label3" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                                <div class="playground-player player4">
                                    <asp:Image ID="playerImage4" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label4" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                                <div class="playground-player player5">
                                    <asp:Image ID="playerImage5" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label5" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                               <div class="playground-player player6">
                                   <asp:Image ID="playerImage6" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label6" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                   
                                </div>
                               <div class="playground-player player7">
                                   <asp:Image ID="playerImage7" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label7" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>
                                </div>
                               <div class="playground-player player8">
                                   <asp:Image ID="playerImage8" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label8" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>                                </div>
                               <div class="playground-player player9">
                                   <asp:Image ID="playerImage9" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label9" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>                                </div>
                               <div class="playground-player player10">
                                   <asp:Image ID="playerImage10" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label10" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div>                                </div>
                               <div class="playground-player player11">
                                   <asp:Image ID="playerImage11" runat="server"  alt="Player Image" ImageUrl="~/Images/bg.png"/>
                                        <div class="truncated-player-name">
                                            <div class="content-wrapper">
                                                <asp:Label ID="Label11" runat="server" Text="Labellingggggggggggggg"></asp:Label>
                                            </div>
                                        </div> 
                               </div>
                            </div>
                        </div>
                            <div class="col-md-12 text-center">
                                    <asp:LinkButton ID="LinkButton2" CssClass="SwapButton" runat="server" BackColor="Green">
                                          <i class="fa-solid fa-shuffle"></i>
                                    </asp:LinkButton>
                            </div>
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
               <li class="nav-item"> <a id="homeLink" runat="server" href="home_m.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
             <li class="nav-item active"><a href="#"><i class="fa-sharp fa-solid fa-box"></i><span>Team Formation</span></a></li>
            
        </ul>
         <ul class="nav-links settings-menu">
            <li class="nav-item"> <a href="#"><i class="fa-solid fa-gear"></i><span>Settings</span></a></li>
            <li class="nav-item"> <a href="#"><i class="fa-solid fa-arrow-right-from-bracket"></i><span>Log out</span></a></li>
         </ul>
       </div>
</asp:Content>