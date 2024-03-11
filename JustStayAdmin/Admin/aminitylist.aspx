<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="aminitylist.aspx.cs" Inherits="JustStayAdmin.Admin.aminitylist" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="aminitylist.aspx">Amenity List</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="box-inn-sp">
                    <div class="input-field col s4">
                        <asp:DropDownList ID="drpCategories" runat="server">
                            <asp:ListItem Text="--Select Aminity Category--" Value="0" />
                            <asp:ListItem Text="ATRC" Value="1" />
                            <asp:ListItem Text="Rest Room" Value="2" />
                            <asp:ListItem Text="Rest Chair" Value="3" />
                        </asp:DropDownList>
                    </div>
                    <div class="input-field col s4">
                        <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click"
                            CssClass="btn btn-info" Text="Go"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="box-inn-sp">
                    <div class="inn-title">
                        <h4>All Amenity</h4>
                        <div class="input-field">
                            <asp:LinkButton ID="lnkAddNew" runat="server"  style="float:right;" PostBackUrl="~/Admin/manageaminity.aspx" CssClass="btn btn-info">Add New Amenity</asp:LinkButton>
                        </div>
                          <div style="padding-top: 20px; padding-bottom: 20px;">
                            <asp:Label ID="lblaminitylistmsg" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="tab-inn">
                        <div class="table-responsive table-desi">
                            <asp:GridView ID="gvAmenities" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvAmenities_RowCommand" OnRowDataBound="gvAmenities_RowDataBound"
                                OnRowDeleting="gvAmenities_RowDeleting"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:ImageField DataImageUrlField="IconFileUrl" ItemStyle-Width="50px" />
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/manageaminity.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("AmenityId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("AmenityId").ToString() + "," + Eval("IconFileName").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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
</asp:Content>

