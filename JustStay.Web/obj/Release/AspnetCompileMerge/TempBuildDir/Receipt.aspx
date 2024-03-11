<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="JustStay.Web.Receipt" %>

<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphallbooking" runat="server">
    <link href="css/receipt.css" rel="stylesheet" />
    <section>
        <div class="db">
            <ULMenu:UserleftMenu runat="server" ID="UserleftMenu" />
            <div class="db-2">
                <div class="db-2-com db-2-main">
                    <h4>RestChair Booking Receipt</h4>
                    <div class="col s12" id="gid">
                        <div class="row">
                            <div class="col s12">
                                <div class="widget-box">
                                    <div class="widget-header widget-header-larger">
                                        <div class="widget-title lighter">
                                            <img src='https://www.juststay.in/images/logo.png' alt='logo' style='float: left; padding-top: 0px;'></img>
                                            <h3 class="widget-title lighter"><%=strcompanyname %></h3>
                                            <span class="invoice-info-label"><%=strcompanysubheading %></span>
                                            <span class="invoice-info-label"><%=strcompanyaddress %></span>
                                            <span class="invoice-info-label"><%=strcompanymobile %></span>
                                            <span class="invoice-info-label">
                                                <%=strcompanyemail %></span>
                                            <span class="invoice-info-label"><%=strcompanywebsite %></span>
                                        </div>
                                        <div class="widget-toolbar no-border invoice-info">
                                            <span class="invoice-info-label">Date:</span>
                                            <span><%=strcurrentdate %></span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div class="widget-main padding-24">
                                            <div class="row">
                                                <div class="col s6">
                                                    <div class="row">
                                                        <div class="col-xs-11 label label-lg label-info arrowed-in arrowed-right">
                                                            <b>Customer Details</b>

                                                        </div>
                                                    </div>

                                                    <div>
                                                        <ul class="list-unstyled spaced">
                                                            <li>
                                                                <i class="ace-icon fa fa-caret-right blue"></i>&nbsp;&nbsp; <%=strcustname %>
                                                            </li>

                                                            <li>
                                                                <i class="ace-icon fa fa-caret-right blue"></i>&nbsp;&nbsp;<%=strcustmobileno %>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class="col s6">
                                                    <div class="row">
                                                        <div class="col-xs-11 label label-lg label-success arrowed-in arrowed-right">
                                                            <b>ATRC Details</b>
                                                        </div>
                                                    </div>
                                                    <ul class="list-unstyled  spaced">
                                                        <li>
                                                            <i class="ace-icon fa fa-caret-right green"></i>&nbsp;&nbsp;<%=stratrcname %>
                                                        </li>

                                                        <li>
                                                            <i class="ace-icon fa fa-caret-right green"></i>&nbsp;&nbsp;<%=stratrcmobileno %>
                                                        </li>
                                                        <li>
                                                            <i class="ace-icon fa fa-caret-right green"></i>&nbsp;&nbsp;<%=stratrcemail %>
                                                        </li>
                                                    </ul>
                                                </div>
                                                <table class="table table-striped table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th>Booking Date</th>
                                                            <th>Booking Number</th>
                                                            <th>From Time</th>
                                                            <th>To Time</th>
                                                            <th>Person</th>
                                                            <th>Hour</th>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td><%=strbookingdate %></td>
                                                        <td><%=strbookingnumber %></td>
                                                        <td><%=strfromtime %></td>
                                                        <td><%=strtotime %></td>
                                                        <td><%=strperson %></td>
                                                        <td><%=strhr %></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="col s12">
                                                <div class="row">
                                                    <div class="col-xs-11 label label-lg label-info arrowed-in arrowed-right">
                                                        <b>Payment Details</b>
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <table class="table table-striped table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th>Date</th>
                                                            <th>Des</th>
                                                            <th>Tax (%)</th>
                                                            <th>Amount (Rs.)</th>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td><%=strpaydate %></td>
                                                        <td><%=strpaydes %></td>
                                                        <td>0</td>
                                                        <td><%=strpayamt %></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="hr hr8 hr-double hr-dotted"></div>
                                            <div class="row">
                                                <div class="col s5 pull-right">
                                                    <h5 class="pull-right">Total Amount :<%=strtotalamount %></h5>
                                                </div>
                                                <div class="col s5 pull-left">From JustStay,</div>
                                            </div>
                                            <div class="row">
                                                <div class="col s5 pull-right">
                                                    <h5 class="pull-right">Total Tax : 0.00</h5>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col s5 pull-right">
                                                    <h4 class="pull-right">Grand Total: <%=strgrandtotal %></h4>
                                                </div>
                                            </div>
                                            <div class="space-6"></div>
                                            <div class="well">
                                                Thank you for Rest Chair Booking in Just Stay.
We believe you will be satisfied by our services.
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s2 pull-right">
                            <asp:LinkButton ID="btnexportpdf" CssClass="btn btn-primary" CausesValidation="false" runat="server" OnClientClick="gethtml();" OnClick="btnexportpdf_Click"><i class="fa fa-file-pdf-o"></i> PDF</asp:LinkButton>
                        </div>
                         <div class="col s2 pull-right">
                            <asp:LinkButton ID="btncancel" PostBackUrl="~/mypayment.aspx" CssClass="btn btn-primary" runat="server">Cancel </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:HiddenField ID="hdnbookingnumber" Value="0" runat="server" />

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

