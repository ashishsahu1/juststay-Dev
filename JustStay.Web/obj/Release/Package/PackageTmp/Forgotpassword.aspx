<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Forgotpassword.aspx.cs" Inherits="JustStay.Web.Forgotpassword" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="chpforgotpassword" runat="server">
    <section>
        <div class="tr-register">
            <div class="tr-regi-form">
                <h4>Forget Password</h4>
                <p>
                    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label></p>
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s12">
                                <asp:TextBox ID="txtForgotMobile" runat="server" CssClass="validate" MaxLength="10" ClientIDMode="Static" onkeydown="return (event.keyCode!=13);" />
                            <label>Enter Mobile No.</label>
                            <asp:RequiredFieldValidator ID="rfvtxtForgotMobile" runat="server" ValidationGroup="forget"
                                ControlToValidate="txtForgotMobile" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revtxtForgotMobile" runat="server" ErrorMessage="Enter only interger." ForeColor="Red" Display="Dynamic" ValidationExpression="(^[0][1-9]+)|([1-9]\d*)" ValidationGroup="forget"
                                ControlToValidate="txtForgotMobile" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:Button ID="btnforgetpassword" runat="server" Text="Submit" 
                                CssClass="waves-effect waves-light btn-large full-btn" 
                                OnClick="btnforgetpassword_Click" ValidationGroup="forget" />
                        </div>
                    </div>
                </div>
                <p>
                    <a href="SignIn.aspx">Sign-In</a> | Are you a new user ? <a href="SignUp.aspx">Register</a>
                </p>
            </div>
        </div>
    </section>
</asp:Content>