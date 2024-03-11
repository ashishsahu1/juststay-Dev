<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="atrcrequest.aspx.cs" Inherits="JustStayAdmin.Admin.atrcrequest" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cpbloglist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrcrequest.aspx">ATRC Request</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>ATRC Requests</h4>
                             <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblatrcmsg" runat="server"></asp:Label>
                            </div>
                              <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/manageatrc.aspx">Add New ATRC Profile</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-inn tab-posi">
                            <ul class="tabs">
                                <li class="tab col s3"><a class="active" href="#atrcrequest">ATRC Request</a>
                                </li>
                                <li class="tab col s3"><a href="#approvatrc">Approved ATRC</a>
                                </li>
                                <li class="tab col s3"><a href="#rejectatrc">Rejected ATRC</a>
                                </li>
                            </ul>
                            <div id="atrcrequest" class="col s12 tab-pad">
                                <div class="table-responsive table-desi">
                                    <asp:GridView ID="gvatrcrequest" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnPreRender="GridView1_PreRender" OnRowCommand="gvatrcrequest_RowCommand"
                                        Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                            <%--<asp:BoundField DataField="LOCATION" HeaderText="LOCATION" />--%>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/manageatrc.aspx?id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approve">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkapproved" runat="server" ToolTip="Approve" ForeColor="Blue" CommandName="approve" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="images/approve.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reject">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Reject" ForeColor="Blue" CommandName="reject" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="images/reject.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>

                            <div id="approvatrc" class="col s12 tab-pad">
                                <div class="table-responsive table-desi">
                                    <asp:GridView ID="grdApprovedATRC" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnPreRender="grdApprovedATRC_PreRender" OnRowCommand="grdApprovedATRC_RowCommand"
                                        Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                         <%--   <asp:BoundField DataField="LOCATION" HeaderText="LOCATION" />--%>
                                           <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%#GetBookingsLink(int.Parse(Eval("ATRCId").ToString()),int.Parse(Eval("BookingCount").ToString())) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" ForeColor="Blue" PostBackUrl='<%# String.Format("~/Admin/manageatrc.aspx?id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reject">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Reject" ForeColor="Blue" CommandName="reject" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="images/reject.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="rejectatrc" class="col s12 tab-pad">
                                <div class="table-responsive table-desi">
                                    <asp:GridView ID="grdRejectedATRC" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="grdRejectedATRC_RowCommand"
                                        Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                            <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                         <%--   <asp:BoundField DataField="LOCATION" HeaderText="LOCATION" />--%>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" ForeColor="Blue" PostBackUrl='<%# String.Format("~/Admin/manageatrc.aspx?id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approve">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkApprove" runat="server" Text="Approve" ForeColor="Blue" CommandName="approve" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="images/approve.png" /></asp:LinkButton>
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
</asp:Content>

