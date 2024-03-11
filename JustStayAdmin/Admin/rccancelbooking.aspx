<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="rccancelbooking.aspx.cs" Inherits="JustStayAdmin.Admin.rccancelbooking" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cpcancelrequestlist">
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="rccancelbooking.aspx">Cancelled/Refund Bookings</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="input-field col s3">
                            <asp:DropDownList ID="drpatrc" runat="server" CssClass="validate" DataTextField="ATRCName" DataValueField="ATRCId"></asp:DropDownList>
                        </div>
                        <div class="input-field col s3">
                            <input id="txtfromdate" runat="server" placeholder="From Date" />
                        </div>
                        <div class="input-field col s3">
                            <input id="txttodate" runat="server" placeholder="To Date" />
                        </div>
                        <div class="input-field col s3">
                            <asp:LinkButton ID="btnrcbSearch" runat="server" OnClick="btnrcbSearch_Click" CausesValidation="true"
                                CssClass="waves-effect waves-light btn-large" Text="Go"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Cancelled / Refund Bookings</h4>
                        </div>
                        <div class="tab-inn tab-posi">
                            <ul class="tabs">
                                <li class="tab col s3">
                                    <asp:Button Text="Make Refund" BorderStyle="None" ID="Tab1" class="active" runat="server"
                                        OnClick="Tab1_Click" />
                                </li>
                                <li class="tab col s3">
                                    <asp:Button Text="Refunds" BorderStyle="None" ID="Tab2" runat="server"
                                        OnClick="Tab2_Click" />
                                </li>
                            </ul>
                            <asp:HiddenField ID="hdnrefundis" Value="0" runat="server" />
                            <asp:MultiView ID="MainView" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <div class="col s12 tab-pad">
                                        <div class="table-responsive table-desi">
                                            <asp:GridView ID="gvonlinecancelled" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                                                Width="100%" OnRowDataBound="gvonlinecancelled_RowDataBound" OnPageIndexChanging="gvonlinecancelled_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                                        <ItemTemplate>
                                                            <%#Eval("BookingDetails") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Customer">
                                                        <ItemTemplate>
                                                            <%#Eval("CustDetails") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
                                                        <ItemTemplate>
                                                            <%#Eval("PayStatus") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="NetAmount" HeaderText="Net Amt (Rs.)" />
                                                    <asp:BoundField DataField="TotalRazorFees" HeaderText="Razor Fees (Rs.)" />
                                                    <asp:BoundField DataField="PaidAmtfromRazor" HeaderText="Credit Amt (Rs.)" />
                                                    <asp:BoundField DataField="ATRCCommission" HeaderText="ATRC Commission (Rs.)" />
                                                    <asp:BoundField DataField="JustStayCommission" HeaderText="JustStay Commission (Rs.)" />
                                                    <asp:BoundField DataField="RefundAmt" HeaderText="Refund Amt (Rs.)" />
                                                    <asp:TemplateField HeaderText="Make Refund">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkrefund" runat="server" ForeColor="Blue" Text="Make Refund" OnClick="lnkrefund_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("RCPaymentId")+","+ Eval("IsRefund")+","+ Eval("razorpay_payment_id") + "," + Eval("RefundAmt")%>' CommandName="refund"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    No Recent Bookings to Cancel.
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <asp:GridView ID="gvrefund" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnPageIndexChanging="gvrefund_PageIndexChanging"
                                        Width="100%">
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
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $('#ContentPlaceHolder1_txtfromdate').datepicker({
            uiLibrary: 'bootstrap', size: 'small',
            icons: {
                rightIcon: '<i class="material-icons">date_range</i>',
                previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
            }
        });
        $('#ContentPlaceHolder1_txttodate').datepicker({
            uiLibrary: 'bootstrap', size: 'small',
            icons: {
                rightIcon: '<i class="material-icons">date_range</i>',
                previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
            }
        });
    </script>
</asp:Content>
