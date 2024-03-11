<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="restchairbooking.aspx.cs" Inherits="JustStayAdmin.Admin.restchairbooking" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphcustomerlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="customer.aspx">Customer list</a>
                </li>
                <li class="active-bre"><a href="restchairbooking.aspx">Rest Chair Bookings - </a>(<asp:Label ID="lblcustname" runat="server"></asp:Label>)
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="box-inn-sp">
                    <div class="input-field col s3">
                        <asp:DropDownList ID="drppaymentmode" runat="server">
                            <asp:ListItem Text="--All Payment Mode--" Value=""></asp:ListItem>
                            <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                            <asp:ListItem Text="Pay At ATRC" Value="Pay At ATRC"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-field col s3">
                        <asp:TextBox ID="txtrcsearch" runat="server" placeholder="Serach bookings" CssClass="validate"></asp:TextBox>
                    </div>
                    <div class="input-field col s3">
                        <asp:LinkButton ID="btnrcbSearch" runat="server" OnClick="btnrcbSearch_Click" CausesValidation="true"
                            CssClass="btn btn-info" Text="Go"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box-inn-sp">
                    <div class="inn-title">
                        <h4>All Rest Chair Booking</h4>
                    </div>
                    <div class="tab-inn">
                        <div class="table-responsive table-desi">
                            <p>Total Bookings:&nbsp;&nbsp;<strong><%=strbooking %></strong> </p>
                            <asp:GridView ID="gvrestchair" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowDataBound="gvrestchair_RowDataBound"
                                Width="100%" DataKeyNames="CustomerId" PageSize="50" AllowPaging="true" OnPageIndexChanging="gvrestchair_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Booking Details">
                                        <ItemTemplate>
                                            <%#Eval("BookingDetails") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="ATRC Details">
                                        <ItemTemplate>
                                            <%#Eval("ATRCDetails") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Booked Chairs" DataField="Chairs" />
                                    <asp:TemplateField ItemStyle-Wrap="true" HeaderStyle-Wrap="true" HeaderText="Payment Details">
                                        <ItemTemplate>
                                            <%#Eval("PayStatus") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkviewdetails" runat="server" Text="view" OnClick="lnkviewdetails_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId") + "," + Eval("CustomerId")%>' CommandName="view"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cancel Booking">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbookingcancel" runat="server" Text="Cancel Booking" OnClick="lnkbookingcancel_Click" CommandArgument='<%#Eval("RestChairBookingId")+","+ Eval("ATRCId") + "," + Eval("IsSuccess") + "," + Eval("BookingDate") + "," + Eval("FromTime")+ "," + Eval("ToTime")+ "," + Eval("PaymentMode")%>' CommandName="cancel"></asp:LinkButton>
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
</asp:Content>
