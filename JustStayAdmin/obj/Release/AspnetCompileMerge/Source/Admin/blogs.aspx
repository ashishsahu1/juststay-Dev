<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="blogs.aspx.cs" Inherits="JustStayAdmin.Admin.blogs" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cpbloglist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="blogs.aspx">Blogs</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="input-field col s4">
                            <asp:DropDownList ID="drpCategories" runat="server" AutoPostBack="false"
                                DataTextField="Name" DataValueField="BlogCategoryId" />
                        </div>
                        <div class="input-field col s4">
                            <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CausesValidation="true"
                                CssClass="btn btn-info" Text="Go"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All Blogs</h4>
                            <div class="input-field">
                                <asp:LinkButton ID="lnkAddNew" style="float:right;" runat="server" PostBackUrl="~/Admin/manageblog.aspx" CssClass="btn btn-info">Add New Blog</asp:LinkButton>
                            </div>
                            <div>
                                <asp:Label ID="lblbloglistmsg" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdBlogs" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="grdBlogs_RowCommand" OnRowDataBound="grdBlogs_RowDataBound"
                                    OnRowDeleting="grdBlogs_RowDeleting" DataKeyNames="BlogId"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="BlogTitle" HeaderText="Blog Title" />
                                        <asp:BoundField DataField="BlogDate" HeaderText="Blog Date" DataFormatString="{0:d}" />
                                        <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/manageblog.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("BlogId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("BlogId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
