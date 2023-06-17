<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Labfootball.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            </div>
          </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <li class="nav-item active"><a href="home_m.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
            <li class="nav-item"><a href="firstLogin.aspx"><i class="fa-solid fa-futbol"></i><span>Login</span></a></li>
            <li class="nav-item"><a href="firstRegistration.aspx"><i class="fa-regular fa-calendar-days"></i><span>SignUp</span></a></li>
            <li class="nav-item"><a href="ListManagers.aspx"><i class="fa-solid fa-ranking-star"></i><span>Club Lists</span></a></li>
</asp:Content>
