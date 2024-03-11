<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="JustStay Admin :: Rest Chair Booking" CodeBehind="RestChairBooking.aspx.cs" Inherits="JustStayAdmin.RestChairBooking" %>

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
                                <div class="col-md-3">
                                    <asp:DropDownList ID="drpatrc" runat="server" CssClass="form-control" DataTextField="ATRCName" DataValueField="ATRCId"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:LinkButton ID="btngo" runat="server" CssClass="btn btn-sm btn-primary" OnClick="btngo_Click" Text="Go!"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>Rest Chairs Bookings</h1>
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
                                            <asp:GridView ID="grdrestchairbookings" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                                DataKeyNames="RestChairBookingId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                                data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="RestChairBookingId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblbookingdetails" runat="server" Text='<%#Eval("BookingDetails") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblatrcdetails" runat="server" Text='<%#Eval("ATRCDetails") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Booked Chairs" DataField="Chairs" />
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Customer Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcustdetails" runat="server" Text='<%#Eval("CustDetails") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpaymentdetails" runat="server" Text='<%#Eval("PayStatus") %>'></asp:Label>
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
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#main_txtfromdate').datepicker({
                "dateFormat": "dd-mm-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });

            $('#main_txttodate').datepicker({
                "dateFormat": "dd-mm-yy",
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
