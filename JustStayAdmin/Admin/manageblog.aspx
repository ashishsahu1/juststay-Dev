<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageblog.aspx.cs" Inherits="JustStayAdmin.Admin.manageblog" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageblog" runat="server">
     <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <asp:HiddenField ID="hdBlogId" runat="server" Value="0" />
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
            <h2>Manage Blog</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblblogmsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="drpCategories" runat="server" AutoPostBack="false"
                        DataTextField="Name" DataValueField="BlogCategoryId" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtTitle">Blog Title</label>
                    <asp:TextBox ID="txtTitle" runat="server" class="validate" MaxLength="100" />
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtTitle" ValidationGroup="valblog">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                     <input id="txtBlogDate" runat="server"  placeholder="Blog Date"/>
                    <asp:RequiredFieldValidator ID="rfvtxtBlogDate" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtBlogDate" ValidationGroup="valblog">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtContent">Blog Content</label>
                    <asp:TextBox ID="txtContent" runat="server" CssClass="validate" TextMode="MultiLine" MaxLength="4000"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div class="file-field">
                        <div class="btn">
                            <span>File</span>
                            <asp:FileUpload ID="blogImageUpload" runat="server" onchange="document.getElementById('append-small-btn1').value = this.value;" />
                        </div>
                        <div class="file-path-wrapper">
                            <input type="text" id="append-small-btn1" placeholder="no file selected" />
                        </div>
                    </div>
                    <asp:Label ID="lblImageName" runat="server"></asp:Label>
                    <asp:Label ID="lblfilename" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valblog" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/blogs.aspx">Cancel</asp:LinkButton>
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
      <script>
          $('#ContentPlaceHolder1_txtBlogDate').datepicker({
              uiLibrary: 'bootstrap', size: 'small',
              icons: {
                  rightIcon: '<i class="material-icons">date_range</i>',
                  previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                  nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
              }
          });
      </script>
</asp:Content>

