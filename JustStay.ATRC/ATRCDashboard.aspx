<%@ Page Language="C#" AutoEventWireup="true" Title="ATRC | Dashboard" MasterPageFile="~/Site1.Master" CodeBehind="ATRCDashboard.aspx.cs" Inherits="JustStay.ATRC.ATRCDashboard" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    <div id="startmodel" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">ATRC Approval process is in progress.......</h4>
                </div>
                <div class="modal-body">
                    <p>
                        Dear ATRC,<br />
                        <br />
                        Thank you for your interest in JUSTSTAY<br />
                        <br />
                        We are physically verifying your request for ATRC.<br />
                        It will take next 24 hours for verification.
                   
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="widget-program-bg">
        <div class="container-fluid">
            <div class="row mg-b-15">
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbggreen bg-1 responsive-mg-b-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Bookings</h3>
                                <p class="text-big font-light">
                                    <%=strtotalbooking %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbgblue bg-2 responsive-mg-b-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Online Bookings</h3>
                                <p class="text-big font-light">
                                    <%=strtotalonlinebooking %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbgyellow bg-3 responsive-mg-b-30 res-tablet-mg-t-30 dk-res-t-pro-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Pay-At-ATRC Bookings</h3>
                                <p class="text-big font-light">
                                    <%=strtotalpayatrcbooking %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbgred bg-4 res-tablet-mg-t-30 dk-res-t-pro-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Today's Bookings</h3>
                                <p class="text-big font-light">
                                    <%=strtotaltodaysbooking %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mg-b-15">
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbggreen bg-1 responsive-mg-b-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Booking Amount(Rs.)</h3>
                                <p class="text-big font-light">
                                    <%=strtotalbookingamount %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbgblue bg-2 responsive-mg-b-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Online Booking Amount(Rs.)</h3>
                                <p class="text-big font-light">
                                    <%=strtotalonlinebookingamount %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbgyellow bg-3 responsive-mg-b-30 res-tablet-mg-t-30 dk-res-t-pro-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total Pay-At-ATRC Amt(Rs.)</h3>
                                <p class="text-big font-light">
                                    <%=strtotalpayatatrcamount %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
                    <div class="hpanel shadow-inner hbgred bg-4 res-tablet-mg-t-30 dk-res-t-pro-30">
                        <div class="panel-body">
                            <div class="text-center content-bg-pro">
                                <h3>Total ATRC Commission</h3>
                                <p class="text-big font-light">
                                    <%=strtotalatrccommission %>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="program-widget-bc mg-t-30 mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="hpanel shadow-inner responsive-mg-b-30">
                        <div class="panel-body">
                            <div class="table-responsive wd-tb-cr">
                                <asp:GridView ID="grdtodaysbooking" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" Width="100%">
                                    <columns>
                                        <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Booking Date" DataField="BookingDate" />
                                         <asp:BoundField HeaderText="Booking Number" DataField="BookingNumber" />
                                         <asp:BoundField HeaderText="ATRC" DataField="ATRCName" />
                                         <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <%# Eval("CustDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField HeaderText="Booking Type" DataField="PaymentMode" />
                                         <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" ToolTip="View" PostBackUrl='<%# String.Format("~/viewbooking.aspx?bid={0}&aid={1}", Eval("RestChairBookingId").ToString(),Convert.ToString(Eval("ATRCId")))%>'><img src="images/view.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function showstart() {
            $('#startmodel').modal('show');
        }
    </script>
</asp:Content>

