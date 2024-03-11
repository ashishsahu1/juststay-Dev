<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="viewatrcbill.aspx.cs" Inherits="JustStayAdmin.Admin.viewatrcbill" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphnewcourse">
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <asp:HiddenField ID="hdnamount" runat="server" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrcbilllist.aspx">ATRC Bill List</a>
                </li>
            </ul>
        </div>

        <div class="row">
            <ul class="nav navbar-right panel_toolbox">
            <%--    <li>
                    <asp:LinkButton ID="lnkpay" runat="server" Text="Pay Amount to ATRC" OnClick="lnkpay_Click"></asp:LinkButton></li>
                <li>
                    <asp:LinkButton ID="lnksendtoclient" runat="server" Text="Send Invoice to Client" OnClick="lnksendtoclient_Click"></asp:LinkButton></li>--%>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-file"></i>Report</a>
                    <ul class="dropdown-menu" role="menu">
                        <li>
                            <asp:LinkButton ID="btnexcel" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexcel_Click"><i class="fa fa-file-excel-o"></i> Excel</asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="btnexportpdf" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexportpdf_Click"><i class="fa fa-file-pdf-o"></i> PDF</asp:LinkButton>
                        </li>
                    </ul>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
        <div class="row">
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

                                <%--
                                <div style="float: left;">
                                   
                                </div>
                                <div style="float: right;">
                                   
                                </div>--%>
                            </div>
                        </div>
                        <div class="inn-title" style="text-align: center;">
                            <h4>Bill / Invoice</h4>
                            <strong>
                                <asp:Label ID="lbldaterange" runat="server"></asp:Label></strong>
                        </div>
                        <div class="inn-title">
                            <div class="row" style="border: 1px solid #808080;">
                                <table width="100%" border="1">
                                    <tr>
                                        <td style="float: left;">
                                            <h5>Bill To:</h5>
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
    <asp:HiddenField ID="HiddenField1" runat="server" />
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
    <asp:HiddenField ID="hfGridHtml" runat="server" />
    <script type="text/javascript">
        function gethtml() {
            var data = "";
            data = $("#gid").html();
            $("#ContentPlaceHolder1_hfGridHtml").val("");
            $("#ContentPlaceHolder1_hfGridHtml").val(data);
        }
    </script>
</asp:Content>
