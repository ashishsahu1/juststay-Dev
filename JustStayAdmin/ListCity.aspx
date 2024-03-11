<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="City List | JustStay" CodeBehind="ListCity.aspx.cs" Inherits="JustStayAdmin.ListCity" %>

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
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9" style="float:right;">
                                            <asp:LinkButton ID="lnkAddNew" runat="server" class="btn btn-sm btn-primary login-submit-cs" PostBackUrl="~/ManageCity.aspx">Add New City</asp:LinkButton>
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
                                            <h1>City List</h1>
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

                                            <asp:GridView ID="gvCitys" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnRowCommand="gvCitys_RowCommand" OnRowDataBound="gvCitys_RowDataBound"
                                                OnRowDeleting="gvCitys_RowDeleting"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="CityId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="latitude" HeaderText="Latitude" />
                                                    <asp:BoundField DataField="latitude" HeaderText="Latitude" />
                                                    <asp:BoundField DataField="IsActive" HeaderText="IsActive" />
                                                    <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                                     <asp:TemplateField HeaderText="Add Location">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkaddlocation" runat="server" ToolTip="Add Locations" PostBackUrl='<%# String.Format("~/ManageLocation.aspx?cid={0}", Eval("CityId"))%>'><img src="img/addnew.png" tooltip="Add Locations" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/ManageCity.aspx?Id={0}", Eval("CityId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("CityId").ToString() %>'><img src="img/delete.png" /></asp:LinkButton>
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
