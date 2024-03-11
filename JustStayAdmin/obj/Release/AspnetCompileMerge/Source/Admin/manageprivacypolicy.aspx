<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageprivacypolicy.aspx.cs" Inherits="JustStayAdmin.Admin.manageprivacypolicy" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageblog" runat="server">
    <asp:HiddenField ID="hdprivacyid" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="blogs.aspx">Blogs</a>
                </li>
                <li class="active-bre">Manage Blog
                </li>
                <li class="page-back">
                    <a href="blogs.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Privacy Policy</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblprivacyplocymsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="validate" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
           
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valblog" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
      <script src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            CKEDITOR.replace('ContentPlaceHolder1_txtContent');
        }
    </script>
</asp:Content>