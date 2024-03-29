﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="Just Stay :: Customer Rest Chair Bookings" CodeBehind="RestChairCustomerBookings.aspx.cs" Inherits="JustStay.ATRC.RestChairCustomerBookings" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>

<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    <div class="data-table-area mg-b-15">
        <div class="container-fluid">
             <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control" placeholder="From Date"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" placeholder="To Date"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:LinkButton ID="btngo" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btngo_Click" Text="Go!"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>Customer Bookings List</h1>
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
                                <asp:GridView ID="grdCustomerBookings" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                    DataKeyNames="CustomerId"
                                    Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                    data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                    data-cookie-id-table="CustomerId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                    <Columns>
                                        <asp:BoundField DataField="BookingNumber" HeaderText="BookingNumber" />
                                        <asp:BoundField DataField="BookingDate" HeaderText="BookingDate" />
                                         <asp:BoundField DataField="FromTime" HeaderText="FromTime" />
                                         <asp:BoundField DataField="ToTime" HeaderText="ToTime" />
                                         <asp:BoundField DataField="Person" HeaderText="Person" />
                                         <asp:BoundField DataField="Hour" HeaderText="Hour" />
                                        <asp:BoundField DataField="NetAmount" HeaderText="NetAmount" />
                                        <asp:BoundField DataField="BookingStatus" HeaderText="Status" />
                                         <asp:BoundField DataField="MerchantTxnId" HeaderText="MerchantTxnId" />
                                          <asp:BoundField DataField="IsSuccess" HeaderText="IsSuccess" /> 
                                        <asp:BoundField DataField="PaymentMode" HeaderText="PaymentMode" />
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
