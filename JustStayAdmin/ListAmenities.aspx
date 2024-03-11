<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListAmenities.aspx.cs" Inherits="JustStayAdmin.ListAmenities" %>

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
                                            <label class="login2 pull-right pull-right-pro">Amenity Category</label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <div class="form-select-list">
                                                <asp:DropDownList ID="drpCategories" class="form-control custom-select-value" runat="server">
                                                    <asp:ListItem Text="ATRC" Value="1" />
                                                    <asp:ListItem Text="Rest Room" Value="2" />
                                                    <asp:ListItem Text="Rest Chair" Value="3" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9" style="float: right;">
                                             <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CausesValidation="true"
                                                CssClass="btn btn-sm btn-primary login-submit-cs" Text="Go"></asp:LinkButton>                                           
                                            <asp:LinkButton ID="lnkAddNew" runat="server" class="btn btn-sm btn-primary login-submit-cs" PostBackUrl="~/ManageAmenity.aspx">Add New Amenity</asp:LinkButton>
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
                                            <h1>Amenity List</h1>
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

                                            <asp:GridView ID="gvAmenities" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnRowCommand="gvAmenities_RowCommand" OnRowDataBound="gvAmenities_RowDataBound"
                                                OnRowDeleting="gvAmenities_RowDeleting"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true"
                                                data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="AmenityId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:ImageField DataImageUrlField="IconFileUrl" ItemStyle-Width="50px" />
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/ManageAmenity.aspx?Id={0}", Eval("AmenityId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("AmenityId").ToString() %>'><img src="img/delete.png" /></asp:LinkButton>
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
