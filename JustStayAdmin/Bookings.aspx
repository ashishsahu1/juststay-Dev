<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="JustStayAdmin.Bookings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
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
                                            <h1>ATRC Booking History</h1>
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
                                            <asp:GridView ID="grdBookings" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                                DataKeyNames="CustomerId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                                data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="CustomerId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="Customer" />
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                    <asp:BoundField DataField="CustType" HeaderText="Type" />
                                                     <asp:BoundField DataField="BookingNumber" HeaderText="Number" />
                                                    <asp:BoundField HeaderText="BookingDate" DataField="BookingDate" DataFormatString="{0: dd/MM/yy}" />
                                                    <asp:BoundField HeaderText="Hours" DataField="Hour" />
                                                    <asp:BoundField HeaderText="FromTime" DataField="FromTime" DataFormatString="{0: HH:mm tt}" />
                                                    <asp:BoundField HeaderText="ToTime" DataField="ToTime" DataFormatString="{0: HH:mm tt}" />
                                                    <asp:BoundField HeaderText="Persons" DataField="Persons" />
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
