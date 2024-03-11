<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="addnewatrcbill.aspx.cs" Inherits="JustStayAdmin.Admin.addnewatrcbill" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphnewcourse">
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <asp:HiddenField ID="hdnatrcbillid" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrcbilllist.aspx">ATRC Bill List</a>
                </li>
                <li class="active-bre"><a href="addnewatrcbill.aspx">Add New ATRC Bill</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Add New ATRC Bill</h2>
            <div class="row">
                <div class="box-inn-sp">
                    <div class="row">
                        <div class="input-field col s4">
                            <asp:DropDownList ID="drpatrc" runat="server" DataTextField="ATRCName" DataValueField="ATRCId"></asp:DropDownList>
                        </div>
                        <div class="input-field col s4">
                            <input id="txtfromdate" runat="server" placeholder="From Date" />
                        </div>
                        <div class="input-field col s4">
                            <input id="txttodate" runat="server" placeholder="To Date" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtbillno" runat="server" CssClass="form-control" placeholder="Bill No"></asp:TextBox>
                        </div>
                        <div class="input-field col s4">
                            <input id="txtbilldate" runat="server" placeholder="Bill Date" />
                        </div>
                        <div class="input-field col s4">
                            <asp:DropDownList ID="drppaymentby" runat="server">
                                <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                <asp:ListItem Text="Account Transfer" Value="Account Transfer"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">

                        <div class="input-field col s4">
                            <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" placeholder="Description"></asp:TextBox>
                        </div>
                        <div class="input-field col s4">
                            <asp:Button ID="btnatrcbillreport" runat="server" Text="Generate ATRC Bill / Invoice" CssClass="btn btn-info" OnClick="btnatrcbillreport_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="table table-responsive" id="gid">
                    <div class="col-md-12">
                        <div class="box-inn-sp">
                            <div class="inn-title" style="text-align: center;">
                                <h4>Bookings / Trasactions</h4>
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
                                    CellSpacing="0" OnRowDataBound="grdATRCOnlineBill_RowDataBound">
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
                                <div class="box-inn-sp">
                                    <div class="input-field col s2">
                                        <asp:TextBox ID="txttotalamount" runat="server" CssClass="form-control" placeholder="Total Amount"></asp:TextBox>
                                    </div>
                                    <div class="input-field col s2">
                                        <asp:TextBox ID="txtpaidamount" runat="server" CssClass="form-control" placeholder="Paid Amount"></asp:TextBox>
                                    </div>
                                    <div class="input-field col s2">
                                        <asp:TextBox ID="txtbalance" runat="server" CssClass="form-control" placeholder="Balance"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                  <div class="box-inn-sp">
                                <div class="input-field col s2">
                                        <asp:CheckBox ID="chkispaid" runat="server" Text="Is Paid?" />
                                </div>
                                      </div>
                            </div>
                            <div class="row">
                                <div class="box-inn-sp">
                                     <div class="input-field col s2">
                                    <asp:Button ID="btnsave" runat="server" Text="Save Bill" CssClass="btn btn-info" OnClick="btnsave_Click" />
                                         </div>
                                </div>
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
        $('#ContentPlaceHolder1_txtbilldate').datepicker({
            uiLibrary: 'bootstrap', size: 'small',
            icons: {
                rightIcon: '<i class="material-icons">date_range</i>',
                previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
            }
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#ContentPlaceHolder1_txtpaidamount').change(function () {
                var balance = 0;
                var totalamt = $('#ContentPlaceHolder1_txttotalamount').val();
                var paidAmt = $('#ContentPlaceHolder1_txtpaidamount').val();
                balance = parseFloat(totalamt) - parseFloat(paidAmt);
                $('#ContentPlaceHolder1_txtbalance').val(balance.toFixed(2));
                //$('#ContentPlaceHolder1_txtbalance').trigger('change');
            });
        });
    </script>
</asp:Content>
