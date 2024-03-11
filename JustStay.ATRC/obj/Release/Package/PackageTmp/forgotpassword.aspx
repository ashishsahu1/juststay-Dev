<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="JustStay.ATRC.forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <title>Forgot Password | Just Stay ART Center</title>
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
</head>
<body>
    <form runat="server" id="form1">
        <div class="error-pagewrap">
            <div class="error-page-int">
                <div class="text-center m-b-md custom-login">
                    <h3>Forgot Pasword</h3>
                    <p>
                        <span class="help-block small" id="lblerrorMsg" runat="server"></span>
                    </p>
                </div>
                <div class="content-error">
                    <div class="hpanel">
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="control-label" for="username">Email</label>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="txtemail" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>

                            <asp:Button ID="btnsend" runat="server" OnClick="btnsend_Click" Text="Send Email" CssClass="btn btn-success btn-block loginbtn" CausesValidation="true" />
                        </div>
                    </div>
                </div>
                <div class="text-center login-footer">
                    <a href="login.aspx">Go to Login >> </a> <br /><br />
                    <p>Copyright © 2018-2020 <a href="#">Namo Services-Pune</a>. All rights reserved. Developed by <a href="http://www.nmskaar.com" target="_blank">NMSKAAR INFOTECH</a></p>
                </div>
            </div>
        </div>
        <script src="js/vendor/jquery-1.12.4.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/main.js"></script>
    </form>
</body>
</html>
