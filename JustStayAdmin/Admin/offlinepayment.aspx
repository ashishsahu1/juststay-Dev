<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="offlinepayment.aspx.cs" Inherits="JustStayAdmin.Admin.offlinepayment" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphoninepayment">
     <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="offlinepayment.aspx">Offline Payment Details</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                         <div class="inn-title">
                            <h4>Offline Payment Details</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div class="input-field">
                                <asp:DropDownList ID="drpatrc" runat="server" CssClass="validate" DataTextField="ATRCName" DataValueField="ATRCId"></asp:DropDownList>
                            </div>
                            <div class="input-field">
                                 <input id="txtfromdate" runat="server"  placeholder="From Date"/>
                            </div>
                            <div class="input-field">
                                 <input id="txttodate" runat="server"  placeholder="To Date"/>
                            </div>
                            <div class="input-field">
                                <asp:TextBox ID="txtrcsearch" runat="server" CssClass="validate" placeholder="Serach bookings"></asp:TextBox>

                                <asp:LinkButton ID="btnrcbSearch" runat="server" OnClick="btnrcbSearch_Click" CausesValidation="true"
                                    CssClass="waves-effect waves-light btn-large" Text="Go"></asp:LinkButton>
                                 <asp:LinkButton ID="lnkrest" runat="server" OnClick="lnkrest_Click" CausesValidation="true"
                                    CssClass="waves-effect waves-light btn-large" Text="Reset"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                  <p>Total Payments:&nbsp;&nbsp;<strong><%=strpayments %></strong> </p>
                                <asp:GridView ID="gvofflinepayment" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"  ShowFooter="true"
                                    Width="100%" DataKeyNames="RCPaymentId" PageSize="50" AllowPaging="true" OnRowDataBound="gvofflinepayment_RowDataBound" OnPageIndexChanging="gvofflinepayment_PageIndexChanging">
                                  <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Customer">
                                    <ItemTemplate>
                                        <%#Eval("Name") + " - " + Eval("Mobile") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC">
                                            <ItemTemplate>
                                                <%#Eval("ATRCName") + " - " + Eval("BookingNumber") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" DataFormatString="{0:dd-M-yyyy}" />
                                <asp:TemplateField HeaderText="Total Amount (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("TotalAmount")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblTotalAmount" runat="server" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                       
                                     <asp:TemplateField HeaderText="ATRC Commisssion (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblATRCCommission" runat="server" Text='<%#Eval("ATRCCommission")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblATRCCommissionTotal" runat="server" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Juststay Commission (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJuststayCommission" runat="server" Text='<%#Eval("JustStayCommission")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblJuststayCommissionTotal" runat="server" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                               <%-- <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
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
                                        <asp:LinkButton ID="lnkbookingcancel" runat="server" Text="Cancel Booking" OnClick="lnkbookingcancel_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId") + "," + Eval("IsSuccess") + "," + Eval("BookingDate") + "," + Eval("FromTime")+ "," + Eval("ToTime")+ "," + Eval("PaymentMode")%>' CommandName="cancel"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                                </asp:GridView>
                            </div>
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