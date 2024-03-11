<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="jsbilllist.aspx.cs" Inherits="JustStayAdmin.Admin.jsbilllist" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
       <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrcbilllist.aspx">List of Bills from ATRC</a>
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
                            <h4>List of Bills From ATRC</h4>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvjsbilllist" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" 
                                 Width="100%" PageSize="50" AllowPaging="true">
                                    <Columns>
                                        <asp:BoundField DataField="BillDate" HeaderText="Bill Date" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="BillNo" HeaderText="Bill No" />   
                                        <asp:BoundField DataField="ATRCName" HeaderText="ATRC Name" />
                                        <asp:BoundField DataField="PaymentBy" HeaderText="Payment By" />
                                        <asp:BoundField DataField="TotalAmount" HeaderText="Bill Amt(Rs.)" />
                                        <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amt(Rs.)" />
                                        <asp:BoundField DataField="IsPaid" HeaderText="Is Paid?" />
                                         <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" ToolTip="View Bill" PostBackUrl='<%# String.Format("~/Admin/viewJSbill.aspx?Id={0}&fr={1}&to={2}&atrcid={3}", new JustStayAdmin.RC4().Encrypt(Eval("JSBillId").ToString()),Convert.ToString(Eval("BillFrom")),Convert.ToString(Eval("BillTo")),new JustStayAdmin.RC4().Encrypt(Convert.ToString(Eval("ATRCId"))))%>'><img src="images/view.png" /></asp:LinkButton>
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