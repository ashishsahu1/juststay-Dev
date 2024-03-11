<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListBlog.aspx.cs" Inherits="JustStayAdmin.ListBlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="basic-login-form-ad">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="all-form-element-inner">
                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <label class="login2 pull-right pull-right-pro">Blog Category</label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <div class="form-select-list">
                                                <asp:DropDownList ID="drpCategories" class="form-control custom-select-value" runat="server" AutoPostBack="false"
                                                    DataTextField="Name" DataValueField="BlogCategoryId" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CausesValidation="true"
                                                CssClass="btn btn-sm btn-primary login-submit-cs" Text="Go"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkAddNew" runat="server" class="btn btn-sm btn-primary login-submit-cs" PostBackUrl="~/ManageBlog.aspx">Add Blog</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="data-table-area mg-b-15">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>Blog List</h1>
                                        </div>
                                    </div>
                                    <div class="sparkline13-graph">
                                        <div class="datatable-dashv1-list custom-datatable-overright">
                                            <div id="toolbar">
                                                <select class="form-control dt-tb">
                                                    <option value="">Export Basic</option>
                                                    <option value="all">Export All</option>
                                                    <option value="selected">Export Selected</option>
                                                </select>
                                            </div>

                                            <asp:GridView ID="grdBlogs" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnRowCommand="grdBlogs_RowCommand" OnRowDataBound="grdBlogs_RowDataBound"
                                                OnRowDeleting="grdBlogs_RowDeleting" DataKeyNames="BlogId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                                 data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="BlogId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                    <asp:BoundField DataField="BlogTitle" HeaderText="Blog Title" />
                                                    <asp:BoundField DataField="BlogDate" HeaderText="Blog Date" DataFormatString="{0:d}" />                                                   
                                                    <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                                     <asp:BoundField HeaderText="" DataField="BlogImageNewName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/ManageBlog.aspx?Id={0}", Eval("BlogId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("BlogId").ToString() %>'><img src="img/delete.png" /></asp:LinkButton>
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
            </div>
        </div>
    </div>
</asp:Content>
