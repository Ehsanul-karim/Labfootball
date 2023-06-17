<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="Labfootball.signUp" %>

<!DOCTYPE html>
<html>
<head>
  <title>Registration Form</title>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
  <style>
    body {
      background-color: #f8f9fa;
      padding: 20px;
    }
    
    .container {
      max-width: 400px;
      margin: 0 auto;
      background-color: #ffffff;
      border-radius: 5px;
      padding: 20px;
      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    }
    
    h2 {
      text-align: center;
      margin-bottom: 30px;
    }
    
    .form-group {
      margin-bottom: 20px;
    }
    
    .social-btn {
      display: block;
      text-align: center;
      margin-bottom: 10px;
    }
  </style>
</head>
<body>
  <div class="container">
    <form id="form1" runat="server">
    <h2>Registration Form</h2>
      <div class="form-group">
        <label for="NameTextBox" id="NameLabel" runat="server">Club Name:</label>
        <asp:TextBox ID="NameTextBox" class="form-control" runat="server" placeholder="Enter Club Name"></asp:TextBox>
      </div>
      <div class="form-group">
        <label for="email">Email:</label>
        <asp:TextBox ID="EmailTextBox" class="form-control" runat="server" placeholder="Enter your email"></asp:TextBox>
      </div>
      <div class="form-group">
        <label for="password">Password:</label>
          <asp:TextBox ID="passwwordTextBox"  class="form-control" runat="server" placeholder="Enter your password" TextMode="Password"></asp:TextBox>
      </div>
      <div class="form-group">
        <label for="confirmPassword">Confirm Password:</label>
           <asp:TextBox ID="passwwordTextBox2"  class="form-control" runat="server" placeholder="Confirm your password" TextMode="Password"></asp:TextBox>
      </div>

<div class="form-group">
    <label for="gender">Role : </label>
    <div class="form-check form-check-inline">
        <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="roleGroup" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
        <label class="form-check-label" for="roleManager">
            Manager
        </label>
    </div>
    <div class="form-check form-check-inline">
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="roleGroup" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
        <label class="form-check-label" for="roleSupporter">
            Supporter
        </label>
    </div>
</div>
      <div class="form-group" id="clubGroup" runat="server">
        <label for="club">Club:</label>
        <asp:DropDownList CssClass="form-control" ID="clubList1" runat="server">
            <asp:ListItem Value="Select club" Selected>Select club</asp:ListItem>
        </asp:DropDownList> 
      </div>
         <asp:Button CssClass="m-1 btn btn-block btn-outline-info" ID="Register_Button" runat="server" Text="Register" OnClick="AccountAddButton_Click" />
      <hr>
      <div class="text-center">
        <div class="col-12">
          <p>Already have an account?<a href="loginPage.aspx" data-bs-toggle="modal" data-bs-target="#exampleModal">Signin</a></p>
      </div>
        <p>Or connect with:</p>
        <a href="#" class="btn btn-primary social-btn">
          <i class="fab fa-facebook-f mr-2"></i> Sign in with Facebook
        </a>
        <a href="#" class="btn btn-danger social-btn">
          <i class="fab fa-google mr-2"></i> Sign in with Google
        </a>
      </div>
    </form>
  </div
