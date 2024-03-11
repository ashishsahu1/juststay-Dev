<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="restchairprofiles.aspx.cs" Inherits="JustStayAdmin.Admin.restchairprofiles" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphatrclist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="restchairprofiles.aspx">Rest Chair Profiles</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All Rest Chair Profiles</h4>
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/managercprofile.aspx">Add New Rest Chair Profile</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdrcprofile" runat="server" OnRowCommand="grdrcprofile_RowCommand" OnRowDeleting="grdrcprofile_RowDeleting" AutoGenerateColumns="false" CssClass="table table-hover"
                                    Width="100%" DataKeyNames="RestChairProfileId">
                                    <Columns>
                                        <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                         <asp:BoundField DataField="ManagerName" HeaderText="Name" />
                                        <asp:BoundField DataField="ManagerMobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" />
                                        <asp:BoundField DataField="EndDate" HeaderText="End Date" />
                                        <asp:BoundField DataField="CheckInTime" HeaderText="Start Time" />
                                         <asp:BoundField DataField="CheckOutTime" HeaderText="End Time" />
                                          <asp:TemplateField HeaderText="Manage Rest Chairs">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkaddchair" runat="server" ToolTip="Add Chairs" ForeColor="Blue" PostBackUrl='<%# String.Format("~/Admin/restchairlist.aspx?rcpid={0}", Eval("RestChairProfileId"))%>'>Manage Rest Chairs</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" ForeColor="Blue" PostBackUrl='<%# String.Format("~/Admin/managercprofile.aspx?rcpid={0}", Eval("RestChairProfileId"))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="delete" CommandArgument='<%# Eval("RestChairProfileId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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

