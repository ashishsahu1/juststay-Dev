<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="SignIn.aspx.cs" Inherits="JustStay.Web.SignIn" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphSignIn" runat="server">
    <section>
        <div class="tr-register">
            <div class="tr-regi-form">
                <h4>Sign In</h4>
                <p>It's free and always will be.</p>
                <p>
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label></p>
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" CssClass="validate" autocomplete="off" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                            <label>Mobile</label>
                              <asp:RegularExpressionValidator ID="revtxtMobile" runat="server" ErrorMessage="Enter only interger." ForeColor="Red" Display="Dynamic" ValidationExpression="(^[0][1-9]+)|([1-9]\d*)" ValidationGroup="signin"
                                ControlToValidate="txtMobile" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="validate" autocomplete="off" TextMode="Password" MaxLength="8" onkeypress="javascript:enterLoginEvent(event);"></asp:TextBox>
                            <label>Password</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:Button ID="btnLogin" runat="server" OnClientClick="return CheckSignInValidation('ContentPlaceHolder1_txtMobile','ContentPlaceHolder1_txtPassword');" Text="Sign-In"
                                CssClass="waves-effect waves-light btn-large full-btn" OnClick="btnLogin_Click"  ValidationGroup="signin" />
                        </div>
                    </div>
                </div>
                <p>
                    <a href="Forgotpassword.aspx">forgot password</a> | Are you a new user ? <a href="SignUp.aspx">Register</a>
                </p>
              <%--  <div class="soc-login">
                    <h4>Sign in using</h4>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnkgoogle" runat="server" OnClick="lnkSigninGoogle_Click"><i class="fa fa-google-plus gp1"></i> Google</asp:LinkButton>
                        </li>
                        <li><a href="#"><i class="fa fa-facebook fb1"></i>Facebook</a> </li>
                        <li><a href="#"><i class="fa fa-twitter tw1"></i>Twitter</a> </li>

                    </ul>
                </div>--%>
            </div>
        </div>
    </section>
</asp:Content>
