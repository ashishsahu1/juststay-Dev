<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="onlinepayment.aspx.cs" Inherits="JustStay.ATRC.onlinepayment" %>

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
                                  <asp:TextBox ID="txtrcsearch" runat="server" CssClass="form-control" placeholder="Serach Name, Mobile"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                 <asp:LinkButton ID="btnrcbSearch" runat="server" OnClick="btnrcbSearch_Click" CausesValidation="true"
                                    CssClass="btn btn-sm btn-primary" Text="Go"></asp:LinkButton>
                                 <asp:LinkButton ID="lnkreset" runat="server" OnClick="lnkreset_Click" CausesValidation="true"
                                    CssClass="btn btn-sm btn-primary" Text="Reset"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>Online Payment Details</h1>
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
                                <asp:GridView ID="gvonlinepayment" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" ShowFooter="true"
                                    DataKeyNames="RCPaymentId"  OnRowDataBound="gvonlinepayment_RowDataBound"
                                    Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                    data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                    data-cookie-id-table="RestChairBookingId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
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
                                        <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" DataFormatString="{0:dd-M-yyyy}" />
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Trasaction">
                                            <ItemTemplate>
                                                <%#Eval("orderid") + ", " + Eval("razorpay_payment_id") %>
                                            </ItemTemplate>
                                             <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label runat="server" Text="Total (Rs.)" ForeColor="Black" Font-Bold="true" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("TotalAmount")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblTotalAmount" runat="server" ForeColor="Black" Font-Bold="true" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Razor Fees (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalRazorFees" runat="server" Text='<%#Eval("TotalRazorFees")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblTotalRazorFeesTotal" runat="server" ForeColor="Black" Font-Bold="true" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Credit Amount (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaidAmtfromRazor" runat="server" Text='<%#Eval("PaidAmtfromRazor")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblPaidAmtfromRazorTotal" runat="server" ForeColor="Black" Font-Bold="true" />
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
                                                    <asp:Label ID="lblATRCCommissionTotal" runat="server" ForeColor="Black" Font-Bold="true" />
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
                                                    <asp:Label ID="lblJuststayCommissionTotal" runat="server" ForeColor="Black" Font-Bold="true" />
                                                </div>
                                            </FooterTemplate>
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


