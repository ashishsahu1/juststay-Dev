<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JustStayAdmin.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JustStay :: Admin Login</title>
    <link rel="shortcut icon" href="images/favicon.ico" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600|Quicksand:300,400,500" rel="stylesheet" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/mob.css" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/materialize.css" />
</head>
<body>
    <div class="blog-login">
        <div class="blog-login-in">
            <form id="form1" runat="server">
                <img src="images/newlogo.jpg" alt="juststay logo" />
                <asp:Label ID="lblerrorMsg" runat="server" ForeColor="Red"></asp:Label>
                <div class="row">
                    <div class="input-field col s12">
                        <asp:TextBox ID="txtusername" runat="server" CssClass="validate"></asp:TextBox>
                        <label for="username">User Name</label>
                        <asp:RequiredFieldValidator ID="rfvtxtusername" runat="server" ControlToValidate="txtusername" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s12">
                        <asp:TextBox ID="txtpassword" runat="server" CssClass="validate" TextMode="Password"></asp:TextBox>
                        <label for="password">Password</label>
                        <asp:RequiredFieldValidator ID="rfvtxtpassword" runat="server" ControlToValidate="txtpassword" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s12">
                        <asp:LinkButton ID="lnklogin" runat="server" OnClick="lnklogin_Click" CausesValidation="true" CssClass="waves-effect waves-light btn-large btn-log-in">Login</asp:LinkButton>
                    </div>
                </div>

            </form>
            <div style="margin-top: 10px; text-align: center;">
                <p style="margin-bottom: 15px;">Copyright © 2018-2020 <a href="#">Namo Services-Pune</a>All rights reserved. Developed by <a href="#">nmskaar infotech</a></p>
            </div>
        </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/materialize.min.js"></script>
    <script src="js/custom.js"></script>
</body>
</html>
