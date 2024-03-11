<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="JustStay.ATRC.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <title>Login | Just Stay - ATRC</title>
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.ico" />
    <link href="https://fonts.googleapis.com/css?family=Play:400,700" rel="stylesheet" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/form/all-type-forms.css" />
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="css/responsive.css" />
    <script>
        function login() {
            var obj = {};
            obj.uname = $.trim($('#username').val());
            obj.password = $.trim($('#password').val());
            $.ajax({
                type: "POST",
                url: "/login.aspx/dologin",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d == "1") {
                        window.location.href = '/ATRCRegistration.aspx';
                    }
                    else {
                        $('#lblerrorMsg').text("Invalid username & password.");
                        $('#username').text('');
                        $('#password').text('');
                    }
                },
                error: function (xhr, textStatus, error) {
                    $('#username').text('');
                    $('#password').text('');
                    $('#username').val('');
                    $('#password').val('');
                    $('#lblerrorMsg').text(error);
                }
            });
        }

        function enterEvent(e) {
            if (e.keyCode == 13) {
                login();
            }
        }
    </script>
</head>
<body>

    <div class="error-pagewrap">
        <div class="error-page-int">
            <div class="text-center m-b-md custom-login">
                <h3>JUST STAY - ATRC LOGIN</h3>
                <p>Log-in in the ATRC application!</p>
                <p>
                    <span class="help-block small" id="lblerrorMsg" style="color: red;"></span>
                </p>
            </div>
            <div class="content-error">
                <div class="hpanel">
                    <div class="panel-body">

                        <div class="form-group">
                            <label class="control-label" for="username">Username</label>
                            <input type="text" placeholder="Username" title="Username" required="" value="" name="username" id="username" class="form-control" />
                            <span class="help-block small" id="userspan"></span>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="password">Password</label>
                            <input type="password" title="Password" placeholder="******" required="" value="" name="password" id="password" class="form-control" onkeypress="javascript:enterEvent(event);" />
                            <span class="help-block small" id="passspan"></span>
                        </div>
                        <%--<asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click" Text="Login" CssClass="btn btn-success btn-block loginbtn" />--%>
                        <button class="btn btn-success btn-block loginbtn" onclick="login();">Login</button>
                       
                    </div>
                </div>
            </div>
            <div class="text-center login-footer">
                 <a href="forgotpassword.aspx">Forgot Password?</a><br /><br />
                <p>Copyright © 2018-2020 <a href="#">Namo Services-Pune</a>. All rights reserved. Developed by <a href="http://www.nmskaar.com" target="_blank">NMSKAAR INFOTECH</a></p>
            </div>
        </div>
    </div>
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>

</html>
