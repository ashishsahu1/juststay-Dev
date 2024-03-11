<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="atrc.aspx.cs" Inherits="JustStayAdmin.Admin.atrc" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphatrclist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrc.aspx">All ATRCs</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All ATRCs</h4>
                            <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/manageatrc.aspx">Add New ATRC</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdApprovedATRC" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                     <asp:TemplateField HeaderText="Bank Account">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbankaccount" runat="server" ToolTip="Bank Account" ForeColor="Blue" PostBackUrl='<%# String.Format("~/Admin/atrcaccount.aspx?id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCId").ToString()))%>'>Bank Account</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" ForeColor="Blue" PostBackUrl='<%# String.Format("~/Admin/manageatrc.aspx?id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="delete" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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
