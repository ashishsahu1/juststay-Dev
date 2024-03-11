<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="billsfromjuststay.aspx.cs" Inherits="JustStay.ATRC.billsfromjuststay" %>

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
                                <asp:DropDownList ID="drpispaid" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Paid" Value="True"></asp:ListItem>
                                         <asp:ListItem Text="UnPaid" Value="False"></asp:ListItem>
                                     </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <asp:Button ID="btngo" runat="server" Text="Go!" CssClass="btn btn-sm btn-primary" OnClick="btngo_Click" />
                             
                            </div>
                        </div>
                    </div>
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>All Bills From Just Stay</h1>
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
                                <asp:GridView ID="gvbillfromjslist" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                    DataKeyNames="ATRCBillId"  
                                    Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true"
                                    data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                    data-cookie-id-table="ATRCBillId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                    <Columns>
                                         <asp:BoundField DataField="BillDate" HeaderText="Bill Date" DataFormatString="{0:d}" />
                                           <asp:BoundField DataField="BillNo" HeaderText="Bill No" />   
                                        <asp:BoundField DataField="ATRCName" HeaderText="Name" />
                                        <asp:BoundField DataField="PaymentBy" HeaderText="Payment By" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amt(Rs.)" />
                                          <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amt(Rs.)" />
                                           <asp:BoundField DataField="IsPaid" HeaderText="Is Paid?" />
                                         <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" ToolTip="View Bill" PostBackUrl='<%# String.Format("~/viewatrcbill.aspx?Id={0}&fr={1}&to={2}&atrcid={3}", new JustStay.ATRC.RC4().Encrypt(Eval("ATRCBillId").ToString()),Convert.ToString(Eval("BillFrom")),Convert.ToString(Eval("BillTo")),new JustStay.ATRC.RC4().Encrypt(Convert.ToString(Eval("ATRCId"))))%>'><img src="img/view.png" /></asp:LinkButton>
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
