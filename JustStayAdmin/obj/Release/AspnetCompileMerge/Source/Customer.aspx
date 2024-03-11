<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="Admin | Customer - Just Stay" CodeBehind="Customer.aspx.cs" Inherits="JustStayAdmin.Customer" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="data-table-area mg-b-15">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>Customer List</h1>
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
                                            <asp:GridView ID="grdCustomers" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                                DataKeyNames="CustomerId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                                data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="CustomerId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                    <asp:BoundField HeaderText="Gender" DataField="Gender" />
                                                    <asp:BoundField HeaderText="DOB" DataField="DOB" DataFormatString="{0:d}" />
                                                    <asp:BoundField HeaderText="Type" DataField="CustType" />
                                                    <asp:TemplateField HeaderText="Bookings">
                                                        <ItemTemplate>
                                                            <%#GetBookingsLink(int.Parse(Eval("CustomerId").ToString()),int.Parse(Eval("BookingCount").ToString())) %>
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
