<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="addnewjsbill.aspx.cs" Inherits="JustStay.ATRC.addnewjsbill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdnjsbillid" runat="server" Value="0" />
    <style>
        .headrow {
            margin-bottom: 10px;
        }
    </style>
    <div class="data-table-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="row headrow">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="form-control" placeholder="From Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtfromdate" runat="server" ControlToValidate="txtfromdate" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" placeholder="To Date"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="rfvtxttodate" runat="server" ControlToValidate="txttodate" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtbillno" runat="server" CssClass="form-control" placeholder="Bill No"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfvtxtbillno" runat="server" ControlToValidate="txtbillno" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtbilldate" runat="server" CssClass="form-control" placeholder="Bill Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtbilldate" runat="server" ControlToValidate="txtbilldate" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row headrow">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-3 col-sm-3">
                                <asp:DropDownList ID="drppaymentby" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                    <asp:ListItem Text="Account Transfer" Value="Account Transfer"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:Button ID="btnjscbillreport" runat="server" Text="Generate JS Bill / Invoice" CssClass="btn btn-sm btn-primary" OnClick="btnjscbillreport_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>New JS Bill / Invoice</h1>
                            </div>
                        </div>
                        <div class="sparkline13-graph">
                            <div class="datatable-dashv1-list custom-datatable-overright">
                                <asp:GridView ID="grdapyatrcbill" runat="server" AutoGenerateColumns="false" class="table table-striped"
                                    OnRowDataBound="grdapyatrcbill_RowDataBound" ShowFooter="true" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="srno" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Perticulars">
                                            <ItemTemplate>
                                                <%# ((string)Eval("Perticulars")) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Mode">
                                            <ItemTemplate>
                                                <%# Eval("PaymentMode") %>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label runat="server" Text="Totals (Rs.)" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Amt (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("NetAmount")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblTotalAmount" runat="server" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="GST %(Rs.)" DataField="GST" />
                                        <asp:TemplateField HeaderText="JS Commisssion (30%) (Rs.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJSCommission" runat="server" Text='<%#Eval("JSCommission")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="padding: 0 0 5px 0; color: black;">
                                                    <asp:Label ID="lblJSCommissionTotal" runat="server" />
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row headrow">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txttotalamount" runat="server" CssClass="form-control" placeholder="Total Amount"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtpaidamount" runat="server" CssClass="form-control" placeholder="Paid Amount"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:TextBox ID="txtbalance" runat="server" CssClass="form-control" placeholder="Balance"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row headrow">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="col-md-3 col-sm-3">
                                <asp:CheckBox ID="chkispaid" runat="server" Text="Is Paid?" />
                            </div>
                        </div>
                    </div>
                    <div class="row headrow">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Button ID="btnsave" runat="server" Text="Save Bill" CssClass="btn btn-info" OnClick="btnsave_Click" />
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
                "dateFormat": "mm-dd-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });

            $('#main_txttodate').datepicker({
                "dateFormat": "mm-dd-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });
            $('#main_txtbilldate').datepicker({
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
            $('#main_txtbilldate').keypress(function (key) {
                if (key.charCode < 48 || key.charCode > 57) return false;
            });
        });

    </script>
     <script>
         $(document).ready(function () {
             $('#main_txtpaidamount').change(function () {
                 var balance = 0;
                 var totalamt = $('#main_txttotalamount').val();
                 var paidAmt = $('#main_txtpaidamount').val();
                 balance = parseFloat(totalamt) - parseFloat(paidAmt);
                 $('#main_txtbalance').val(balance.toFixed(2));
                 //$('#ContentPlaceHolder1_txtbalance').trigger('change');
             });
         });
    </script>
</asp:Content>
