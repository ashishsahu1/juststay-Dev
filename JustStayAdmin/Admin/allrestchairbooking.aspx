<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="allrestchairbooking.aspx.cs" Inherits="JustStayAdmin.Admin.allrestchairbooking" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphcustomerlist">
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="allrestchairbooking.aspx">All Rest Chair Bookings</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                            <div class="input-field col s2">
                                <asp:DropDownList ID="drpatrc" runat="server" CssClass="validate" DataTextField="ATRCName" DataValueField="ATRCId"></asp:DropDownList>
                            </div>
                            <div class="input-field col s2">
                                <input id="txtfromdate" runat="server" placeholder="From Date" />
                            </div>
                            <div class="input-field col s2">
                                <input id="txttodate" runat="server" placeholder="To Date" />
                            </div>
                            <div class="input-field col s4">
                                <asp:TextBox ID="txtrcsearch" runat="server" CssClass="validate" placeholder="Serach bookings"></asp:TextBox>
                            </div>
                            <div class="input-field col s2">
                                <asp:LinkButton ID="btnrcbSearch" runat="server" OnClick="btnrcbSearch_Click" CausesValidation="true"
                                    CssClass="btn btn-info" Text="Go"></asp:LinkButton>
                            </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All Rest Chair Booking</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblrestchairmsg" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <%--  <p>Total Bookings:&nbsp;&nbsp;<strong><%=strbooking %></strong> </p>--%>
                                <asp:GridView ID="grdrestchairbookings" runat="server" AutoGenerateColumns="false" CssClass="table-responsive"
                                    DataKeyNames="RestChairBookingId"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblbookingdetails" runat="server" Text='<%#Eval("BookingDetails") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblatrcdetails" runat="server" Text='<%#Eval("ATRCDetails") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Booked Chairs" DataField="Chairs" />
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Customer Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcustdetails" runat="server" Text='<%#Eval("CustDetails") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpaymentdetails" runat="server" Text='<%#Eval("PayStatus") %>'></asp:Label>
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
