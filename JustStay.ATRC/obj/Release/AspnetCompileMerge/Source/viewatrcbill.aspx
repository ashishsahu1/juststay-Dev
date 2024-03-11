<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="viewatrcbill.aspx.cs" Inherits="JustStay.ATRC.viewatrcbill" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    <asp:HiddenField ID="hdnamount" runat="server" Value="0" />
    <div class="data-table-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="sparkline13-list">
                        <div class="sparkline13-hd">
                            <div class="main-sparkline13-hd">
                                <h1>All Juststay Bills</h1>
                            </div>
                            <div style="float: right;">
                                <asp:LinkButton ID="btnexcel" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexcel_Click"><i class="fa fa-file-excel-o"></i> Excel</asp:LinkButton>
                                <asp:LinkButton ID="btnexportpdf" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexportpdf_Click"><i class="fa fa-file-pdf-o"></i> PDF</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="row">
                        <div class="sparkline13-list">
                            <div class="sparkline13-graph">
                                <div class="datatable-dashv1-list custom-datatable-overright">
                                    <div class="table table-responsive" id="gid">
                                        <div class="col-md-12">
                                            <div class="box-inn-sp">
                                                <div class="inn-title">
                                                    <div class="row">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td style="float: left;">
                                                                    <h3><%=strCompanyName %></h3>
                                                                    <p><%=strsubheading %></p>
                                                                    <p><%=straddress %></p>
                                                                    <p><%=strmobile %> / <%=stremail %></p>
                                                                    <p><%=strwebsite %></p>
                                                                    <p>GSTIN: <%=strgstin %></p>
                                                                </td>
                                                                <td style="float: right;">
                                                                    <img src='https://jstyadmin.juststay.in/Admin/images/newlogo.jpg' alt='logo' width='200' style='float: left; padding-top: 0px;' />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="inn-title" style="text-align: center;">
                                                    <h4>Bill / Invoice</h4>
                                                    <strong>
                                                        <asp:Label ID="lbldaterange" runat="server"></asp:Label></strong>
                                                </div>
                                                <div class="inn-title">
                                                    <div class="row" style="border: 1px solid #808080;">
                                                        <table width="100%" border="0">
                                                            <tr>
                                                                <td style="float: left;">
                                                                    <p><strong>Bill To:</strong></p>
                                                                    <p><%=stratrcname %> (<%=stratrcnumber %>)</p>
                                                                    <p><%=strownername %></p>
                                                                    <p><%=stratrcaddress %></p>
                                                                    <p><%=stratrcmobile %> / <%=stratrcemail %></p>
                                                                </td>
                                                                <td style="float: right;">
                                                                    <p>Bill No:<%=strbillno %></p>
                                                                    <p>BillDate: <%=strbilldate %></p>
                                                                    <p>Bill From: <%=strfromdate %></p>
                                                                    <p>Bill To: <%=strtodate %></p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="tab-inn">
                                                        <div class="col-sm-6 text-left">
                                                            <asp:Label ID="totalrecord" runat="server" ForeColor="Black" CssClass="total-records"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="tab-inn">
                                                    <asp:GridView ID="grdATRCOnlineBill" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                                                        PageSize="100" AllowPaging="true" ShowFooter="true"
                                                        CssClass="table table-hover table-striped table-bordered"
                                                        CellSpacing="0" OnPageIndexChanging="grdATRCOnlineBill_PageIndexChanging" OnRowDataBound="grdATRCOnlineBill_RowDataBound">
                                                        <PagerStyle CssClass="pagination-ys" />
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
                                                            <asp:TemplateField HeaderText="ATRC Commisssion 70% (Rs.)">
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
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="row">
                                                    <div class="tab-inn">
                                                        <div class="table-responsive">
                                                            <table class="table">
                                                                <tr>
                                                                    <td><strong>Amount in Words: </strong>
                                                                        <asp:Label Style="font-size: 15px;" ID="totalamountword" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="text-align: right; float: right;">
                                                                        <div style="border: 1px solid #808080; width: 150px;">
                                                                            <p style="text-align: right; padding-top: 10px; padding-right: 5px;"><strong>&#8377;&nbsp;&nbsp;<asp:Label Style="font-size: 15px;" ID="totalamount" runat="server"></asp:Label></strong></p>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left; float: left;">
                                                                        <p>
                                                                            <b>Terms & Conditions:</b><br />
                                                                            1.Payment will transfer within 7 days after one month<br />
                                                                            2.a sa sasasasasasa sas<br />
                                                                            3.asasas sa sasasas sasasa<br />
                                                                            4.Subject to Pune Juridiction.
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: left; float: right;">
                                                                        <p><b>GST Summary:</b></p>
                                                                        <br />
                                                                        <table border="1" class="table table-striped- table-bordered table-hover table-checkable" id="dtsalechild">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th rowspan="2">HSN/SAC</th>
                                                                                    <th rowspan="2">Taxable Value</th>
                                                                                    <th colspan="2">Central Tax</th>
                                                                                    <th colspan="2">State Tax</th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Rate</th>
                                                                                    <th>Amount</th>
                                                                                    <th>Rate</th>
                                                                                    <th>Amount</th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tfoot>
                                                                                <tr>
                                                                                    <th>-</th>
                                                                                    <th><%=strfinalamt %></th>
                                                                                    <th>0</th>
                                                                                    <th>0</th>
                                                                                    <th>0</th>
                                                                                    <th>0</th>
                                                                                </tr>
                                                                            </tfoot>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p>
                                                                            <b>Declaration:</b><br />
                                                                            We declare that this invoice shows the actual price of the goods described and that all particulars are true and correct.
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p>
                                                                            <b>For Namo Services,</b><br />
                                                                            <br />
                                                                            <br />
                                                                            Authorised Signatory
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <p style="text-align: center;">
                                                            This is a computer generated invoice
                                                        </p>
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
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfGridHtml" runat="server" />
    <script type="text/javascript">
        function gethtml() {
            var data = "";
            data = $("#gid").html();
            $("#main_hfGridHtml").val("");
            $("#main_hfGridHtml").val(data);
        }
    </script>
</asp:Content>

