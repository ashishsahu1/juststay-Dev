<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="allbooking.aspx.cs" Inherits="JustStay.Web.allbooking" %>

<%@ Import Namespace="JustStay.CommonHub" %>
<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphallbooking" runat="server">
    <style>
        table, th, td {
            border: 0.2px solid #eaedef;
        }
    </style>
    <section>
        <div class="db">
            <ULMenu:UserleftMenu runat="server" ID="UserleftMenu" />
            <div class="db-2">
                <div class="db-2-com db-2-main">
                    <h4>All Booking</h4>
                    <div class="row">
                        <div class="col s12">
                            <ul>
                                <li class="col s6"><asp:LinkButton ID="lnkonlinetab" runat="server" ClientIDMode="Static" CausesValidation="false" OnClick="lnkonlinetab_Click">Online Pay Bookings</asp:LinkButton></li>
                                <li class="col s6"><asp:LinkButton ID="lnkpayatatrctab" runat="server" ClientIDMode="Static" CausesValidation="false" OnClick="lnkpayatatrctab_Click">Pay-At-ATRC Pay Bookings</asp:LinkButton></li>
                            </ul>
                        </div>
                        <div id="online" class="col s12" runat="server">
                            <div class="db-2-main-com db-2-main-com-table">
                                <p>Total Bookings:&nbsp;&nbsp;<strong><%=stronlinebooking %></strong> </p>
                                <asp:GridView ID="grdallbooking" runat="server" AllowPaging="true" PageSize="100" OnRowDataBound="grdallbooking_RowDataBound"
                                    AutoGenerateColumns="false" CssClass="responsive-table" OnRowCancelingEdit="grdallbooking_RowCancelingEdit" 
                                    OnPageIndexChanging="grdallbooking_PageIndexChanging" Width="100%" border="1">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                            <ItemTemplate>
                                                <%#Eval("BookingDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC Details">
                                            <ItemTemplate>
                                                <%#Eval("ATRCDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Booked Chairs" DataField="Chairs" />
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
                                            <ItemTemplate>
                                                <%#Eval("PayStatus") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkviewdetails" runat="server" Text="view" OnClick="lnkviewdetails_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId")%>' CommandName="view"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cancel Booking">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbookingcancel" runat="server" Text="Cancel Booking" OnClick="lnkbookingcancel_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId") + "," + Eval("IsSuccess") + "," + Eval("BookingDate") + "," + Eval("FromTime")+ "," + Eval("ToTime")+ "," + Eval("PaymentMode") + "," + Eval("IsCancel")%>' CommandName="cancel"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="payatatrc" class="col s12" runat="server" visible="false">
                             <div class="db-2-main-com db-2-main-com-table">
                                <p>Total Bookings:&nbsp;&nbsp;<strong><%=strpayatrcbooking %></strong> </p>
                                <asp:GridView ID="grdpayatrc" runat="server" AllowPaging="true" PageSize="100" OnRowDataBound="grdpayatrc_RowDataBound"
                                    AutoGenerateColumns="false" CssClass="responsive-table" OnRowCancelingEdit="grdpayatrc_RowCancelingEdit" OnPageIndexChanging="grdpayatrc_PageIndexChanging" Width="100%" border="1">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                            <ItemTemplate>
                                                <%#Eval("BookingDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC Details">
                                            <ItemTemplate>
                                                <%#Eval("ATRCDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Booked Chairs" DataField="Chairs" />
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
                                            <ItemTemplate>
                                                <%#Eval("PayStatus") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" Text="view" OnClick="lnkviewdetails_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId")%>' CommandName="view"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cancel Booking">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkcancel" runat="server" Text="Cancel Booking" OnClick="lnkcancel_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId") + "," + Eval("IsSuccess") + "," + Eval("BookingDate") + "," + Eval("FromTime")+ "," + Eval("ToTime")+ "," + Eval("PaymentMode") + "," + Eval("IsCancel")%>' CommandName="cancel"></asp:LinkButton>
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
    </section>
</asp:Content>
