<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassword.aspx.cs" Inherits="Labfootball.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
     <link rel="icon" type="image/jpeg" href="Images/my%20website%20logo.jpeg">
    <title>Forgot Password</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
            color: #333;
        }

        p {
            text-align: center;
            margin-bottom: 20px;
            color: #666;
        }

        form {
            display: flex;
            flex-direction: column;
        }

        label {
            font-weight: bold;
            margin-bottom: 10px;
            color: #333;
        }

        input[type="email"] {
            padding: 10px;
            border-radius: 3px;
            border: 1px solid #ccc;
            margin-bottom: 15px;
        }

        #submit {
            background-color: #007bff;
            color: #fff;
            padding: 10px;
            border-radius: 3px;
            border: none;
            cursor: pointer;
        }

        #submit:hover {
            background-color: #0056b3;
        }

        p:last-child {
            text-align: center;
            margin-top: 20px;
            color: #666;
        }

        .thank-you {
            text-align: center;
            color: #007bff;
            font-weight: bold;
            margin-top: 20px;
        }

        a {
            color: #007bff;
            text-decoration: none;
        }

        a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h1>Forgot Password</h1>
                     <div class="form-group" style="display:flex">
                        <div class="form-check form-check-inline">
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="roleGroup" AutoPostBack="true" />
                            <label class="form-check-label" for="roleManager">
                                Manager
                            </label>
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="roleGroup" AutoPostBack="true" />
                            <label class="form-check-label" for="roleSupporter">
                                Supporter
                            </label>
                        </div>
                    </div>
        <p>Please enter your email address to reset your password.</p>
        <form action="reset-password.php" method="POST">
            <label for="email">Email address:</label>            
            <asp:TextBox ID="emailTextBox" runat="server" CssClass="form-control" TextMode="Email" Required="true"></asp:TextBox>
            <asp:Button ID="submit" runat="server" Text="Reset Password" OnClick="submit_Click" />
            <input type="hidden" id="passwordfield" runat="server" />
             <p class="thank-you" id="thankYouLabel" runat="server" style="display: none;"></p>
        </form>
        <p>Remember your password? <a href="loginPage.aspx">Sign In</a></p>
    </div>

    </form>
</body>
</html>
