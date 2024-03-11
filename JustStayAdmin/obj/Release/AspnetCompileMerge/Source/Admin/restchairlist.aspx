<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="restchairlist.aspx.cs" Inherits="JustStayAdmin.Admin.restchairlist" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="restchairlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="restchairprofiles.aspx">Rest Chair Profiles</a>
                </li>
                <li class="active-bre"><a href="restchairlist.aspx">Rest Chair List</a>
                </li>
                <li class="page-back">
                    <a href="restchairprofiles.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Rest Chair List</h4>
                        </div>
                        <div class="tab-inn tab-posi">
                            <div class="sb2-2-3">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="box-inn-sp">
                                            <div class="inn-title">
                                                <h4>Types Of Chairs</h4>
                                                <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                                                <ul id="dr-users" class="dropdown-content">
                                                    <li>
                                                        <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click">Add New Chairs</asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="tab-inn">
                                                <div class="table-responsive table-desi">
                                                    <asp:GridView ID="gvChairs" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                                                        DataKeyNames="ATRCRestChairId" OnRowCommand="gvChairs_RowCommand" OnRowDataBound="gvChairs_RowDataBound" OnRowDeleting="gvChairs_RowDeleting"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ChairName" HeaderText="Name" />
                                                            <asp:BoundField DataField="ChairCount" HeaderText="Chair Count" />
                                                            <asp:BoundField DataField="TypeName" HeaderText="Type" />
                                                            <%-- <asp:BoundField DataField="Price" HeaderText="Price" />--%>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/managerestchair.aspx?Id={0}&rcpId={1}", Eval("ATRCRestChairId"),Eval("RestChairProfileId"))%>'><img src="images/edit.png" /></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("ATRCRestChairId").ToString() %>' ToolTip="Delete" ForeColor="Blue" CommandName="Delete"><img src="images/delete.png" /></asp:LinkButton>
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
        </div>
    </div>
    <asp:HiddenField ID="hdnrcprofileid" runat="server" Value="0" />
</asp:Content>
