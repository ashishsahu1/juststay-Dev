<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageuser.aspx.cs" Inherits="JustStayAdmin.Admin.manageuser" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageuser" runat="server">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="userlist.aspx">User List</a>
                </li>
                <li class="active-bre">Manage User
                </li>
                <li class="page-back">
                    <a href="userlist.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage User</h2>
            <div style="padding-top:20px;padding-bottom:20px;">           
                 <asp:Label ID="lblusermsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtname" runat="server" CssClass="validate"></asp:TextBox>
                    <label for="txtname">Name</label>
                    <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ControlToValidate="txtname" SetFocusOnError="true" ValidationGroup="manageuser"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtmobile" runat="server" CssClass="validate"></asp:TextBox>
                    <label for="txtmobile">Mobile</label>
                    <asp:RequiredFieldValidator ID="rfvtxtmobile" runat="server" ControlToValidate="txtmobile" SetFocusOnError="true" ValidationGroup="manageuser"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtmobile" runat="server" ValidationGroup="manageuser" ForeColor="Red"
                        ControlToValidate="txtmobile" ErrorMessage="enter valid mobile number!"
                        ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtemail" runat="server" CssClass="validate"></asp:TextBox>
                    <label for="txtemail">Email</label>
                    <asp:RegularExpressionValidator ID="revtxtemail" runat="server" ControlToValidate="txtemail" ValidationGroup="manageuser"
                        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        Display="Dynamic" ErrorMessage="Invalid email address" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:CheckBox ID="chkisactive" runat="server" Text="Is Active?" ClientIDMode="Static" CssClass="filled-in" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:Button ID="btnmanageuser" runat="server" Text="Update" OnClick="btnmanageuser_Click" ValidationGroup="manageuser" CausesValidation="true"
                        CssClass="waves-effect waves-light btn-large" />
                    <asp:LinkButton ID="lnkusercancel" runat="server" PostBackUrl="~/Admin/userlist.aspx" CssClass="waves-effect waves-light btn-large">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
