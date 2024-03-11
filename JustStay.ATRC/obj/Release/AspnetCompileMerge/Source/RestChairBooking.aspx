<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="JustStay :: Rest Chair Bookings" CodeBehind="RestChairBooking.aspx.cs" Inherits="JustStay.ATRC.RestChairBooking" %>

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
                                <asp:DropDownList ID="drppaymentmode" runat="server" CssClass="form-control">
                                      <asp:ListItem Text="All" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                    <asp:ListItem Text="Pay At ATRC" Value="Pay At ATRC"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:LinkButton ID="btngo" runat="server" CssClass="btn btn-sm btn-primary" Text="Go!" OnClick="btngo_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>Rest Chair Bookings</h1>
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
                                    DataKeyNames="RestChairBookingId" OnRowCommand="grdrestchairbookings_RowCommand" OnRowDataBound="grdrestchairbookings_RowDataBound"
                                    Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                    data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                    data-cookie-id-table="RestChairBookingId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbookingdetails" runat="server" Text='<%#Eval("BookingDetails") %>'></asp:Label>
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
                                          <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Make Payment">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnpaymentdtatus" runat="server" Value='<%# Eval("PaymentMode") %>' />
                                                 <asp:HiddenField ID="hdnpaystatus" runat="server" Value='<%# Eval("ATRCPaystatus") %>' />
                                                <asp:Label ID="lblstatus" ForeColor="Green" Font-Bold="true" runat="server" Text='<%# Eval("ATRCPaystatus") + " at " + Eval("Paydate") %>' Visible="false"></asp:Label>
                                              <asp:LinkButton ID="lnkmakepay" Visible="false" runat="server" ToolTip="Make Payment" ForeColor="Blue" CommandName="Pay" CommandArgument='<%# Convert.ToString(Eval("RestChairBookingId")) + "," + Convert.ToString(Eval("RCPaymentId")) %>' Text="Make Payment"></asp:LinkButton>
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


