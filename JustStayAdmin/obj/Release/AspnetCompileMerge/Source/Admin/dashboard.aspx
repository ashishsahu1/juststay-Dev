<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="dashboard.aspx.cs" Inherits="JustStayAdmin.Admin.dashboard" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmain" runat="server">
    <div class="sb2-2">
        <!--== breadcrumbs ==-->
        <div class="sb2-2-2">
            <ul>
                <li><a href="index.html"><i class="fa fa-home" aria-hidden="true"></i>Home</a>
                </li>
                <li class="active-bre"><a href="#">Dashboard</a>
                </li>
                <li class="page-back"><a href="index.html"><i class="fa fa-backward" aria-hidden="true"></i>Back</a>
                </li>
            </ul>
        </div>
        <!--== DASHBOARD INFO ==-->
        <div class="sb2-2-1">
            <h2>Admin Dashboard</h2>
            <div class="db-2">
                <ul>
                    <li>
                        <div class="dash-book dash-b-1">
                            <h5>Total Customer</h5>
                            <h4><%=strtotalcustomer %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-2">
                            <h5>Total ATRC</h5>
                            <h4><%=strtotalatrc %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-3">
                            <h5>Total Bookings</h5>
                            <h4><%=strtotalbookings %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-2">
                            <h5>Total Online Bookings</h5>
                            <h4><%=strtotalonlinebookings %></h4>
                            <h5>Total Offline Bokings</h5>
                            <h4><%=strtotalofflinebookings %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-4">
                            <h5>Today's Booking</h5>
                            <h4><%=strtodaybooking %></h4>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="db-2">
                <ul>
                    <li>
                        <div class="dash-book dash-b-4">
                            <h5>Total Booking Amt.(Rs.)</h5>
                            <h4><%=strtotalbookingamt %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-4">
                            <h5>Total Online Booking Amt.(Rs.)</h5>
                            <h4><%=strtotalonlinebookingamt %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-4">
                            <h5>Total Pay-At-ATRC Booking Amt.(Rs.)</h5>
                            <h4><%=strtotalofflineamt %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-4">
                            <h5>Total ATRC Commission (Rs.)</h5>
                            <h4><%=strtotalatrccommission %></h4>
                        </div>
                    </li>
                    <li>
                        <div class="dash-book dash-b-4">
                            <h5>Total JS Commission (Rs.) </h5>
                            <h4><%=strtotaljscommission %></h4>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <!--== Todays Bookings ==-->
        <div class="sb2-2-3" id="tb">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Today's Bookings</h4>
                            <a  href="allrestchairbooking.aspx" style="float:right;">View All bookings</a>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdtodaysbooking" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No" ItemStyle-Width="100">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Booking Date" DataField="BookingDate" />
                                         <asp:BoundField HeaderText="Booking Number" DataField="BookingNumber" />
                                         <asp:BoundField HeaderText="ATRC" DataField="ATRCName" />
                                         <asp:TemplateField HeaderText="Customer">
                                            <ItemTemplate>
                                                <%# Eval("CustDetails") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField HeaderText="Booking Type" DataField="PaymentMode" />
                                         <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" ToolTip="View" PostBackUrl='<%# String.Format("~/Admin/view-booking.aspx?bid={0}&aid={1}", new JustStay.CommonHub.JSEDS().Encrypt(Eval("RestChairBookingId").ToString()),new JustStay.CommonHub.JSEDS().Encrypt(Convert.ToString(Eval("ATRCId"))))%>'><img src="images/view.png" /></asp:LinkButton>
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
</asp:Content>
