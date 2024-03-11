<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="SignUp.aspx.cs" Inherits="JustStay.Web.SignUp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphSignUp" runat="server">
    <section>
        <div class="tr-register">
            <div class="tr-regi-form" id="divSignUp" runat="server">
                <h4>Sign-Up here!</h4>
                <p>It's free and always will be.</p>
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="validate" MaxLength="50" autocomplete="off"></asp:TextBox>
                            <label>Name</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtUserMobile" runat="server" CssClass="validate" onBlur="javascript:validateMobile();"
                                MaxLength="10" autocomplete="off"></asp:TextBox>
                            <label>Mobile</label>
                            <script type="text/javascript">
                                function validateMobile() {
                                    CheckMobileExist('<%=txtUserMobile.ClientID %>', 'spnDuplicateCustMobile');
                                }
                            </script>
                            <span id='spnDuplicateCustMobile' style="display: none; color: Red; float: left;">Mobile Already Exist</span>
                            <asp:RegularExpressionValidator ID="revtxtUserMobile" runat="server" ErrorMessage="Enter valid mobile." ForeColor="Red" Display="Dynamic" ValidationExpression="(^[0][1-9]+)|([1-9]\d*)" ValidationGroup="signup"
                                ControlToValidate="txtUserMobile" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="validate" MaxLength="50" autocomplete="off" ClientIDMode="Static"
                                onBlur="javascript:checkemail(this);" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                            <label>Email</label>
                            <script type="text/javascript">
                                function checkemail(val) {
                                    if (val != '' && val != null)
                                        CheckEmailExist('<%=txtEmail.ClientID %>', 'spnDuplicateEmail', 3);
                                }
                            </script>
                            <span id='spnDuplicateEmail' style="display: none; color: Red; float: left;">Email Already Exist</span>
                            <asp:RegularExpressionValidator ID="revtxtEmail" runat="server" ErrorMessage="Please Enter Valid Email" Display="Dynamic"
                                ValidationGroup="signup" ControlToValidate="txtEmail"
                                ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:Button ID="btnSignUp" runat="server" CausesValidation="true" ValidationGroup="signup" OnClientClick="return ValidateSignUp('ContentPlaceHolder1_txtUsername','ContentPlaceHolder1_txtUserMobile');" CssClass="waves-effect waves-light btn-large full-btn" Text="Register" OnClick="btnSignUp_Click" />
                        </div>
                    </div>
                </div>
                <p>
                    Are you a already member ? <a href="SignIn.aspx">Click to Login</a>
                </p>
            </div>
            <div class="tr-regi-form" style="display: none;" id="divOTP" runat="server">
                <h4>Verify Mobile Number!</h4>
                <p>Enter OTP here & set Password.</p>
                <p>
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </p>
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtOTP" runat="server" CssClass="validate" MaxLength="10" AutoCompleteType="Disabled"
                                autocomplete="off" onkeydown="return (event.keyCode!=13);" />
                            <label>OTP</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="validate" MaxLength="8" TextMode="Password" AutoCompleteType="Disabled"
                                autocomplete="off" onkeydown="return (event.keyCode!=13);" />
                            <label>Password</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="validate" MaxLength="8" TextMode="Password" AutoCompleteType="Disabled"
                                autocomplete="off" onkeydown="return (event.keyCode!=13);" />
                            <label>Confirm Password</label>
                            <span id='spn_PwdMatch' style="display: none; color: Red; float: left;">Password and Confirm Password must match!</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:Button ID="lnkVerifyOTP" runat="server" OnClick="lnkVerifyOTP_Click" OnClientClick="return ValidatePassword('ContentPlaceHolder1_txtOTP','ContentPlaceHolder1_txtPassword','ContentPlaceHolder1_txtConfirmPassword','spn_PwdMatch');"
                                CssClass="waves-effect waves-light btn-large full-btn" Text="Verify OTP" />
                            <div style="display: none;" id="divresendbtn">
                                <asp:Button ID="lnkResendOTP" runat="server" OnClick="lnkResendOTP_Click" CssClass="btn-large full-btn" Text="Re-send OTP" />
                            </div>
                        </div>
                    </div>
                </div>
                <p>
                    Are you a already member ? <a href="SignIn.aspx">Click to Login</a>
                </p>
            </div>
        </div>
    </section>
</asp:Content>
