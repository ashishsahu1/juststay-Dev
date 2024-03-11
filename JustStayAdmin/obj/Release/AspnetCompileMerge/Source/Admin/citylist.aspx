<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="citylist.aspx.cs" Inherits="JustStayAdmin.Admin.citylist" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="citylist.aspx">City list</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All City</h4>
                           
                                    <asp:LinkButton ID="lnkAddNew" runat="server" style="float:right;" CssClass="btn-primary" PostBackUrl="~/Admin/managecity.aspx">Add New City</asp:LinkButton>
                               
                           <%-- <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/managecity.aspx">Add New City</asp:LinkButton>
                                </li>
                            </ul>--%>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvCitys" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvCitys_RowCommand" OnRowDataBound="gvCitys_RowDataBound"
                                    OnRowDeleting="gvCitys_RowDeleting" Width="100%" PageSize="50" AllowPaging="true" OnPageIndexChanging="gvCitys_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="latitude" HeaderText="Latitude" />
                                        <asp:BoundField DataField="longitude" HeaderText="Longitude" />
                                        <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                                        <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                        <asp:TemplateField HeaderText="Add Location">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkaddlocation" runat="server" Text="Add Location" style="color:blue;" ToolTip="Add Locations" PostBackUrl='<%# String.Format("~/Admin/ManageLocation.aspx?cid={0}",new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("CityId").ToString()))%>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/ManageCity.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("CityId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("CityId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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
