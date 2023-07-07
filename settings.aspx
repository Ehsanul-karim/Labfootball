<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="Labfootball.settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
             <script type="text/javascript">
               
               function readURL3(imageUrl2) {
                    $('#imgview2').attr('src', imageUrl2);
               }

              </script>
    <style>
        .button-container {
    display: flex;
    justify-content: center;
}

.column {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.vertical-button {
    width: 100%; /* Button width set to 100% of column */
    margin-bottom: 10px; /* Spacing between buttons */
}
        .change-password-form {
            max-width: 400px;
            padding: 20px;
            background-color: #f7f7f7;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    position: relative;
    left: 35%;
        }

        .form-field {
            margin-bottom: 15px;
        }

        .form-label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .form-input {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        .submit-button {
            display: block;
            width: 100%;
            padding: 10px;
            background-color: #0298cf;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="main-content" id="main-content">
        <h3 class="i-name">Settings</h3>
       <div class="change-password-form">
            <div class="form-field">
                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-field">
                <asp:Label ID="lblNewPassword" runat="server" Text="New Password:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-field">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-input"></asp:TextBox>
            </div>

            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="submit-button" OnClick="btnChangePassword_Click" />
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
        </ul>
         <ul class="nav-links settings-menu">
            <li class="nav-item active"> <a href="#"><i class="fa-solid fa-gear"></i><span>Settings</span></a></li>
            <li class="nav-item"> <a href="WelcomePage.aspx"><i class="fa-solid fa-arrow-right-from-bracket"></i><span>Log out</span></a></li>
         </ul>
       </div>
</asp:Content>
