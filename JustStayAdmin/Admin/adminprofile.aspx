<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="adminprofile.aspx.cs" Inherits="JustStayAdmin.Admin.adminprofile" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanagecompany" runat="server">
    <asp:HiddenField ID="hduserId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre">Manage Admin Profile
                </li>
                <li class="page-back">
                    <a href="dashboard.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Admin Profile</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lbladminprofilemsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtadminname" runat="server" class="validate" MaxLength="50" />
                    <label for="txtadminname">Name</label>
                    <asp:RequiredFieldValidator ID="rfvtxtadminname" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtadminname" ValidationGroup="valadmin">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtadminaddress" runat="server" class="form-control" MaxLength="100" />
                    <label for="txtadminaddress">Address</label>
                    <asp:RequiredFieldValidator ID="rfvtxtadminaddress" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtadminaddress" ValidationGroup="valadmin">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtadminmobile" runat="server" class="validate" MaxLength="15" />
                    <label for="txtadminmobile">Mobile</label>
                    <asp:RequiredFieldValidator ID="rfvtxtadminmobile" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtadminmobile" ValidationGroup="valadmin">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtadminemail" runat="server" class="validate" MaxLength="50" />
                    <label for="txtadminemail">Email</label>
                    <asp:RequiredFieldValidator ID="rfvtxtadminemail" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtadminemail" ValidationGroup="valadmin">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnUpdateAdmin" runat="server" OnClick="btnUpdateAdmin_Click" CausesValidation="true"
                        ValidationGroup="valadmin" CssClass="waves-effect waves-light btn-large" Text="Update"></asp:LinkButton>
                 
                </div>
            </div>
        </div>
    </div>
</asp:Content>

