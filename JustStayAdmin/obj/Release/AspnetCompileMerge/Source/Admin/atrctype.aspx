<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="atrctype.aspx.cs" Inherits="JustStayAdmin.Admin.atrctype" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphatrctype">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrctype.aspx">ATRC Types</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All ATRC Type</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblatrctypemsg" runat="server"></asp:Label>
                            </div>
                            <asp:LinkButton ID="lnkaddatrctype" style="float:right;" CssClass="btn-primary" runat="server" PostBackUrl="~/Admin/manageatrctype.aspx">Add New ATRC Type</asp:LinkButton>
                            <%--<a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkaddatrctype" runat="server" PostBackUrl="~/Admin/manageatrctype.aspx">Add New ATRC Type</asp:LinkButton>
                                </li>
                            </ul>--%>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvTypes" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ShowHeader="true"
                                    OnRowCommand="gvTypes_RowCommand" OnRowDataBound="gvTypes_RowDataBound" OnRowDeleting="gvTypes_RowDeleting"
                                    Width="100%" EmptyDataText="No Data Found">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Description" HeaderText="Description" HtmlEncode="false" />
                                        <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/manageatrctype.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("TypeId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("TypeId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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
