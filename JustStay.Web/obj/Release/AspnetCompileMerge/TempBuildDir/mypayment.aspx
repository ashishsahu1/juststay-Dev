<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="mypayment.aspx.cs" Inherits="JustStay.Web.mypayment" %>

<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphallbooking" runat="server">
    <section>
        <div class="db">
            <ulmenu:userleftmenu runat="server" id="UserleftMenu" />
            <div class="db-2">
                <div class="db-2-com db-2-main">
                    <h4>All Booking</h4>
                    <div class="db-2-main-com db-2-main-com-table" style="width: 100%; height: 800px; overflow: scroll">
                        <asp:GridView ID="grdallpayment" runat="server" AllowPaging="true" OnPageIndexChanging="grdallpayment_PageIndexChanging" PageSize="50" OnRowCommand="grdallpayment_RowCommand"
                            AutoGenerateColumns="false" CssClass="responsive-table" Width="100%">
                            <columns>
                                <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC">
                                    <ItemTemplate>
                                        <%#Eval("ATRCName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Date">
                                    <ItemTemplate>
                                        <%#Eval("BookingDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Booking Number" DataField="BookingNumber" />
                                 <asp:BoundField HeaderText="From Time" DataField="FromTime" />
                                 <asp:BoundField HeaderText="To Time" DataField="ToTime" />
                                 <asp:BoundField HeaderText="Amount" DataField="TotalAmount" />
                                 <asp:BoundField HeaderText="Mode" DataField="PaymentMode" />
                                 <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Status">
                                    <ItemTemplate>
                                     <asp:Label runat="server" ID="status" CssClass="db-done" Text='<%#Eval("IsSuccess") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkreceipt" runat="server" Text="Receipt" OnClick="lnkreceipt_Click" CommandName="receipt" CommandArgument='<%# Eval("RestChairBookingId").ToString() + "," + Eval("PaymentMode").ToString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
