<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="home_m.aspx.cs" Inherits="Labfootball.home_m" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

           <script type="text/javascript">

           function readURL(input) {
               if (input.files && input.files[0]) {
                   var reader = new FileReader();

                   reader.onload = function (e) {
                       $('#imgview').attr('src', e.target.result);
                   };

                   reader.readAsDataURL(input.files[0]);
               }
           }
           function readURL2(imageUrl) {
                   $('#imgview').attr('src', imageUrl);
               }

           </script>

    <style>
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="main-content" id="main-content">

        <div class="banner-content">
            <video class="video-bg" autoplay muted loop>
                <source src="/Images/FIFA 23 Reveal Trailer - The World’s Game.mp4" type="video/mp4">
            </video> 
            <ul class="dynamic-txts">
                <li> <span data-text="Football">Football</span></li>
                <li> <span data-text="Today">Today</span></li>
            </ul>
        </div>

        <div class="intro-wrap">
                <div class="text-center">
                    <asp:Button ID="AddPlayerButton" runat="server" class="btn btn-primary bg" data-bs-toggle="modal" data-bs-target="#exampleModal" Text="+ Add More Players" OnClick="AddPlayerButton_Click"/>
                </div>
            <div class="player-intro-title">
                <h1>Goalkeeper</h1>
            </div>


            <div class="glide-testimonial"> 
                <div class="glide__track" data-glide-el="track"> 
                    <div class="slider d-flex"> 
                        <asp:Repeater ID="Repeaterkeeper" runat="server" OnItemCommand="Keeper_ItemCommand" OnItemDataBound="Repeaterkeeper_ItemDataBound">
                            <ItemTemplate>
                                <div class="slider-items">
                                    <div class="card">
                                        <div class="card-head-image">
                                            <img src="./Images/1.jpg" alt="Image" />
                                        </div>
                                        <div class="card-player-image">
                                            <asp:Image class="img-fluid playerimg" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                                        </div>
                                        <div class="card-header">
                                            <h4 class="player-title"><%# Eval("player_name") %></h4>
                                            <div class="row">
                                    <div class="col-md-12">
                                        <span><%# Eval("country") %></span>
                                    </div>
                                    <div class="col-12">
                                        <span><%# Eval("age") %> years</span>
                                    </div>
                                </div>
                                            <asp:LinkButton ID="LinkButton1" runat="server" class="cart-icon" CommandName="DisablePlayer" CommandArgument='<%# Eval("player_name") %>'>
                                                <i class="fa-solid fa-shopping-cart"></i>
                                            </asp:LinkButton>
                                            <a href="#">Read More</a>
                                            <asp:LinkButton ID="disablePlayer" runat="server" BackColor="Green" CommandName="DisablePlayer" CommandArgument='<%# Eval("player_name") %>'>
                                                <i class="fa-solid fa-ban"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                         </asp:Repeater>
                    </div>
                </div>
              
                <div class="glide__arrows" data-glide-el="controls"><!-- Use  this data-glide-el attributes for controls  -->
                   <button class="glide__arrow glide__arrow--left" data-glide-dir="<" style="cursor: pointer;"><i class="fas fa-arrow-left"></i></button><!-- Use  this data-glide-dir attributes "< or >" for direction else button maynot  work! -->
                   <button class="glide__arrow glide__arrow--right" data-glide-dir=">" style="cursor: pointer;"><i class="fas fa-arrow-right"></i></button>      
                </div>
            </div>

            <div class="player-intro-title">
                <h1>Defense</h1>
            </div>
            <div class="glide-defense"> 
                <div class="glide__track" data-glide-el="track"> 
                    <div class="slider d-flex"> 
                        <asp:Repeater ID="Repeaterdefense" runat="server" OnItemCommand="Defense_ItemCommand"  OnItemDataBound="Repeaterdefense_ItemDataBound">
                            <ItemTemplate>
                                <div class="slider-items">
                                    <div class="card">
                                        <div class="card-head-image">
                                            <img src="./Images/1.jpg" alt="Image" />
                                        </div>
                                        <div class="card-player-image">
                                            <asp:Image class="img-fluid playerimg" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                                        </div>
                                        <div class="card-header">
                                            <h4 class="player-title"><%# Eval("player_name") %></h4>
                                            <div class="row">
                                    <div class="col-md-12">
                                        <span><%# Eval("country") %></span>
                                    </div>
                                    <div class="col-12">
                                        <span><%# Eval("age") %> years</span>
                                    </div>
                                </div>
                                             <a href="#" class="cart-icon"><i class="fa-solid fa-shopping-cart"></i></a>
                                            <a href="#">Read More</a>
                                            <asp:LinkButton ID="disablePlayer" runat="server" CssClass="disable" CommandName="DisablePlayer" CommandArgument='<%# Eval("player_name") %>'>
                                                <i class="fa-solid fa-ban"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                         </asp:Repeater>
                    </div>
                </div>
                <div class="glide__arrows" data-glide-e1="controls"><!-- Use  this data-glide-el attributes for controls  -->
                  <button class="glide__arrow glide__arrow--left" data-glide-dir="<"><i class="fas fa-arrow-left"></i></button><!-- Use  this data-glide-dir attributes "< or >" for direction else button maynot  work! -->
                  <button class="glide__arrow glide__arrow--right" data-glide-dir=">"><i class="fas fa-arrow-right"></i></button>
                </div>
            </div>
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Player Details</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                   <h4>Player Name:</h4>
                    <p>Country</p>
                    <p>Age:</p>
            </div>
        </div>
    </div>
</div>
            <div class="player-intro-title">
                <h1>Mid-Fielder</h1>
            </div>
            <div class="glide-middle"> 
                <div class="glide__track" data-glide-el="track"> 
                    <div class="slider d-flex"> 
                        <asp:Repeater ID="Repeatermiddle" runat="server" OnItemCommand="Middle_ItemCommand"  OnItemDataBound="Repeatermiddle_ItemDataBound">
                            <ItemTemplate>
                                <div class="slider-items">
                                    <div class="card">
                                        <div class="card-head-image">
                                            <img src="./Images/1.jpg" alt="Image" />
                                        </div>
                                        <div class="card-player-image">
                                            <asp:Image class="img-fluid playerimg" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                                        </div>
                                        <div class="card-header">
                                            <h4 class="player-title"><%# Eval("player_name") %></h4>
                                            <div class="row">
                                    <div class="col-md-12">
                                        <span><%# Eval("country") %></span>
                                    </div>
                                    <div class="col-12">
                                        <span><%# Eval("age") %> years</span>
                                    </div>
                                </div>
                                            <a href="#" class="cart-icon"><i class="fa-solid fa-shopping-cart"></i></a>
                                            <a href="#">Read More</a>
                                            <asp:LinkButton ID="disablePlayer" runat="server" Class="disable" CommandName="DisablePlayer" CommandArgument='<%# Eval("player_name") %>'>
                                                <i class="fa-solid fa-ban"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                         </asp:Repeater>
                    </div>
                </div>
                <div class="glide__arrows" data-glide-e1="controls"><!-- Use  this data-glide-el attributes for controls  -->
                  <button class="glide__arrow glide__arrow--left" data-glide-dir="<"><i class="fas fa-arrow-left"></i></button><!-- Use  this data-glide-dir attributes "< or >" for direction else button maynot  work! -->
                  <button class="glide__arrow glide__arrow--right" data-glide-dir=">"><i class="fas fa-arrow-right"></i></button>
                </div>
            </div>
            <div class="player-intro-title">
                <h1>Attackers</h1>
            </div>

            <div class="glide-attack"> 
                <div class="glide__track" data-glide-el="track"> 
                    <div class="slider d-flex"> 
                        <asp:Repeater ID="Repeaterforward" runat="server" OnItemCommand="Forward_ItemCommand"  OnItemDataBound="Repeaterkeeper_ItemDataBound">
                            <ItemTemplate>
                                <div class="slider-items">
                                    <div class="card">
                                        <div class="card-head-image">
                                            <img src="./Images/1.jpg" alt="Image" />
                                        </div>
                                        <div class="card-player-image">
                                            <asp:Image class="img-fluid playerimg" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                                        </div>
                                        <div class="card-header">
                                            <h4 class="player-title"><%# Eval("player_name") %></h4>
                                            <div class="row">
                                    <div class="col-md-12">
                                        <span><%# Eval("country") %></span>
                                    </div>
                                    <div class="col-12">
                                        <span><%# Eval("age") %> years</span>
                                    </div>
                                </div>
                                            <a href="#" class="cart-icon"><i class="fa-solid fa-shopping-cart"></i></a>
                                            <a href="#">Read More</a>
                                            <asp:LinkButton ID="disablePlayer" runat="server" Class="disable" CommandName="DisablePlayer" CommandArgument='<%# Eval("player_name") %>'>
                                                <i class="fa-solid fa-ban"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                         </asp:Repeater>
                    </div>
                </div>
                <div class="glide__arrows" data-glide-e1="controls"><!-- Use  this data-glide-el attributes for controls  -->
                  <button class="glide__arrow glide__arrow--left" data-glide-dir="<"><i class="fas fa-arrow-left"></i></button><!-- Use  this data-glide-dir attributes "< or >" for direction else button maynot  work! -->
                  <button class="glide__arrow glide__arrow--right" data-glide-dir=">"><i class="fas fa-arrow-right"></i></button>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <div class="sidebar" id="sidebar">
        <div class="club-content">
            <img src=""  id="imgview" alt="club Image"  class="img-fluid"  style="width:100px; border-radius: 50%;" />
            <h4><asp:Label ID="session_club" runat="server" Text=""></asp:Label></h4> 
            <br>
            <asp:FileUpload ID="fileUpload1" runat="server" style="padding: 2px;" Visible="false" onChange="readURL(this);" BackColor="#e5e4e2"  class="form-control"  />
            <asp:Button ID="btnUpload" runat="server" Text="Upload Profile Image" Visible="false" style="background-color: #4CAF50; color: white; padding: 2.5px 5px; border: none; cursor: pointer;" OnClick="btnUpload_Click" />
            <asp:Button ID="doneUpload" runat="server" Text="Done" Visible="false" style="background-color: #463E3F; color: white; padding: 2.5px 5px; border: none; cursor: pointer;" OnClick="DoneUpload_Click"/>
        </div>
    <ul class="nav-links">
    <li class="nav-item active"><a href="#"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item"><a href="transfer.aspx"><i class="fa-solid fa-futbol"></i><span>Market Place</span></a></li>
            <li class="nav-item"><a href="match-schedule.aspx"><i class="fa-regular fa-calendar-days"></i><span>Match Schedule</span></a></li>
            <li class="nav-item"><a href="point_table.aspx"><i class="fa-solid fa-ranking-star"></i><span>Point Table</span></a></li>
    </ul>
     <ul class="nav-links settings-menu">
            <li class="nav-item"> <a href="#"><i class="fa-solid fa-gear"></i><span>Settings</span></a></li>
            <li class="nav-item"> <a href="firstLogin.aspx"><i class="fa-solid fa-arrow-right-from-bracket"></i><span>Log out</span></a></li>
     </ul>
    </div>
</asp:Content>