<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="customer.aspx.cs" Inherits="JustStayAdmin.Admin.customer" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphcustomerlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="customer.aspx">Customer list</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All Customers</h4>
                             <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblcustmsg" runat="server"></asp:Label>
                            </div>
                             <div class="input-field">
                               <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control"></asp:TextBox>

                                <asp:LinkButton ID="btncustSearch" runat="server" OnClick="btncustSearch_Click" CausesValidation="true"
                                    CssClass="waves-effect waves-light btn-large" Text="Go"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvcustomer" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowCommand="gvcustomer_RowCommand" OnRowDataBound="gvcustomer_RowDataBound"
                                    Width="100%" DataKeyNames="UserId" PageSize="50" AllowPaging="true" OnPageIndexChanging="gvcustomer_PageIndexChanging" OnRowDeleting="gvcustomer_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField HeaderText="Gender" DataField="Gender" />
                                        <asp:BoundField HeaderText="DOB" DataField="DOB" DataFormatString="{0:d}" />
                                        <asp:BoundField HeaderText="Type" DataField="CustType" />
                                        <asp:TemplateField HeaderText="Bookings">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbooking" runat="server" ToolTip="Bookings" PostBackUrl='<%# String.Format("~/Admin/restchairbooking.aspx?Id={0}", new JustStay.CommonHub.JSEDS().Encrypt(Eval("CustomerId").ToString()))%>'><%# Eval("BookingCount") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("UserId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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

