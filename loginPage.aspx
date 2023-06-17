<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="Labfootball.loginPage" %>

<!doctype html>
<html lang="en">
<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <link rel="stylesheet" href="style.css">
        <link href="prixima/css/styleWelcome.css" rel="stylesheet" />
  <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
  <link href="owl.carousel.min.css" rel="stylesheet" />
  <link href="owl.theme.default.min.css" rel="stylesheet" />
  <!-- Bootstrap CSS -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
      <style>
    body {
      background-color: #f8f9fa;
      font-size: 18px;
    }
    .image-container {
    position: relative;
    width: 100%;
    height: 0;
    padding-bottom: 75%; /* Adjust the value as per your needs to maintain the aspect ratio */
}
        .search-container {
            display: flex;
            align-items: center;
        }
        .search-container i{
            margin-top:27px;
            font-size: 22px;
        }
        #TextBox1
        {
            margin-right : 20px;
        }
        #username
        {
            color: cyan;
            font-size: 28px;
            font-family: "Playfair Display", Arial, serif;
        }
    </style>
  <title>Hello, world!</title>
</head>
<body>
      <header id="header" class="fixed-top">
    <div class="container-fluid">
      <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd">
        <div class="container-fluid">
          <a class="navbar-brand" href="#">
            <img src="Images/pngegg (2).png" alt="logo" style="width: 55px; height: auto;">
          </a>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
              <li class="nav-item">
                <a class="nav-link" aria-current="page" href="#">Football Today</a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="#">Home</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="d-flex">
            <button class="btn btn-outline-success login" type="submit"><a href="loginPage.aspx">Login</a></button>
            <button class="btn btn-outline-success register" type="submit"><a href="signUp.aspx">Register</a></button>
        </div>

      </nav>
    </div>
  </header>
<section class="vh-100">
    <div class="container py-5 h-100">
        <div class="row align-items-center">
            <div class="col-lg-6">
                <div class="image-container">
                    <img id="imageField" runat="server" src="Images/Coaching%20Manual-244-min.jpg" class="img-fluid" />
                </div>
            </div>
            <div class="col-lg-6 mt-5">
                <div class="section-title position-relative">
                    <h2>Login</h2>
                </div>
                <form runat="server">
                    <div class="form-group">
                        <label for="gender">Role:</label>
                        <div class="form-check form-check-inline">
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="roleGroup" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                            <label class="form-check-label" for="roleManager">
                                Manager
                            </label>
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="roleGroup" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" />
                            <label class="form-check-label" for="roleSupporter">
                                Supporter
                            </label>
                        </div>
                    </div>
                    <br />
                    <!-- Email input -->
                    <div class="form-outline mb-4">
                        <asp:TextBox ID="emailTextBox" class="form-control form-control-lg" runat="server"></asp:TextBox>
                        <label class="form-label" for="form1Example13">Email address</label>
                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-4">
                        <asp:TextBox ID="PasswordTextBox" class="form-control form-control-lg" runat="server" TextMode="Password"></asp:TextBox>
                        <label class="form-label" for="form1Example23">Password</label>
                    </div>

                    <div class="d-flex justify-content-around align-items-center mb-4">
                        <!-- Checkbox -->
                        <div class="form-check">
                            <asp:CheckBox ID="RememberMeCheckBox" runat="server" Checked />
                            <label class="form-check-label" for="form1Example3">Remember me</label>
                        </div>
                        <a href="#!">Forgot password?</a>
                    </div>

                    <!-- Submit button -->
                    <asp:Button CssClass="m-1 btn btn-block btn-outline-info btn-lg" ID="Login_Button" runat="server" Text="Login" OnClick="LoginButton_Click" />

                    <div class="divider d-flex align-items-center my-4">
                        <p class="text-center fw-bold mx-3 mb-0 text-muted">OR</p>
                    </div>

                    <div class="col-12">
                        <p>Don't have an account?<a href="signUp.aspx" data-bs-toggle="modal" data-bs-target="#exampleModal">Sign Up</a></p>
                    </div>
                </form>
            </div>
        </div>
    </div>
</section>

</body>
</html>