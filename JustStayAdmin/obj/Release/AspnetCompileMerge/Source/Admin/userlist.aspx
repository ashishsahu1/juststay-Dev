<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="userlist.aspx.cs" Inherits="JustStayAdmin.Admin.userlist" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="userlist.aspx">User list</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All Users</h4>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvUsers_RowCommand" OnRowDataBound="gvUsers_RowDataBound"
                                    Width="100%" PageSize="50" AllowPaging="true" OnPageIndexChanging="gvUsers_PageIndexChanging" OnRowDeleting="gvUsers_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                         <asp:BoundField DataField="Username" HeaderText="UserName" />
                                        <asp:BoundField DataField="UserType" HeaderText="UserType" />
                                        <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                                        <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/manageuser.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("UserId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("UserId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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
