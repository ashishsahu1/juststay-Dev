<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="atrcbilllist.aspx.cs" Inherits="JustStayAdmin.Admin.atrcbilllist" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
       <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrcbilllist.aspx">List of Bills ATRC</a>
                </li>
            </ul>
        </div>
         <div class="sb2-2-3">
            <div class="row">
                <div class="box-inn-sp">
                    <div class="input-field col s2">
                        <asp:DropDownList ID="drpatrc" runat="server" DataTextField="ATRCName" DataValueField="ATRCId"></asp:DropDownList>
                    </div>
                    <div class="input-field col s2">
                        <input id="txtfromdate" runat="server" placeholder="From Date" />

                    </div>
                    <div class="input-field col s2">
                        <input id="txttodate" runat="server" placeholder="To Date" />

                    </div>
                      <div class="input-field col s2">
                      <asp:DropDownList ID="drpispaid" runat="server">
                          <asp:ListItem Text="Paid" Value="True"></asp:ListItem>
                          <asp:ListItem Text="UnPaid" Value="False"></asp:ListItem>
                      </asp:DropDownList>
                          </div>
                    <div class="input-field col s2">
                        <asp:Button ID="btngo" runat="server" Text="Go!" CssClass="btn btn-info" OnClick="btngo_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>List of Bills to ATRC</h4>
                            <div class="input-field">
                                <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/addnewatrcbill.aspx" CssClass="waves-effect waves-light btn-large waves-input-wrapper">Add New ATRC Bill</asp:LinkButton>
                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvatrcbilllist" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowDataBound="gvatrcbilllist_RowDataBound"
                                 Width="100%" PageSize="50" AllowPaging="true" OnRowCommand="gvatrcbilllist_RowCommand" OnRowDeleting="gvatrcbilllist_RowDeleting">
                                    <Columns>
                                         <asp:BoundField DataField="BillDate" HeaderText="Bill Date" DataFormatString="{0:d}" />
                                           <asp:BoundField DataField="BillNo" HeaderText="Bill No" />   
                                        <asp:BoundField DataField="ATRCName" HeaderText="Name" />
                                        <asp:BoundField DataField="PaymentBy" HeaderText="Payment By" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Bill Amt(Rs.)" />
                                          <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amt(Rs.)" />
                                           <asp:BoundField DataField="IsPaid" HeaderText="Is Paid?" />
                                         <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" ToolTip="View Bill" PostBackUrl='<%# String.Format("~/Admin/viewatrcbill.aspx?Id={0}&fr={1}&to={2}&atrcid={3}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCBillId").ToString()),Convert.ToString(Eval("BillFrom")),Convert.ToString(Eval("BillTo")),new JustStayAdmin.Admin.BL.RC4().Encrypt(Convert.ToString(Eval("ATRCId"))))%>'><img src="images/view.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/addnewatrcbill.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("ATRCBillId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("ATRCBillId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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
