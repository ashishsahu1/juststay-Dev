<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="refundtrasaction.aspx.cs" Inherits="JustStay.ATRC.refundtrasaction" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>

<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    <div class="data-table-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control" placeholder="From Date"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" placeholder="To Date"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:LinkButton ID="btnrcbSearch" runat="server" OnClick="btnrcbSearch_Click" CausesValidation="true"
                                    CssClass="btn btn-sm btn-primary" Text="Go"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>Refunds Bookings</h1>
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
                                <asp:GridView ID="gvrefund" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                    Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true"
                                    data-show-pagination-switch="true" data-show-refresh="true"
                                    data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                    data-cookie-id-table="RestChairBookingId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                            <ItemTemplate>
                                                <%#Eval("BookingDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NetAmount" HeaderText="Net Amt (Rs.)" />
                                        <asp:BoundField DataField="RefundAmt" HeaderText="Refund Amt (Rs.)" />
                                        <asp:BoundField DataField="RefundDate" HeaderText="Refund Date" />
                                        <asp:BoundField DataField="razorpay_payment_id" HeaderText="Payment-Id" />
                                        <asp:BoundField DataField="razor_refund_id" HeaderText="Refund-Id" />
                                        <asp:BoundField DataField="status" HeaderText="Status" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Refund Found.
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#main_txtfromdate').attr('readOnly', 'true');
            $('#main_txttodate').attr('readOnly', 'true');
            $('#main_txtfromdate').datepicker({
                "dateFormat": "mm-dd-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });

            $('#main_txttodate').datepicker({
                "dateFormat": "mm-dd-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });

            $('#main_txtfromdate').keypress(function (key) {
                if (key.charCode < 48 || key.charCode > 57) return false;
            });

            $('#main_txttodate').keypress(function (key) {
                if (key.charCode < 48 || key.charCode > 57) return false;
            });
        });

    </script>
</asp:Content>


