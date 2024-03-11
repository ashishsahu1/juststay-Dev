<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="taxes.aspx.cs" Inherits="JustStayAdmin.Admin.taxes" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="taxes.aspx">Taxes</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All Taxes</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lbltaxmsg" runat="server"></asp:Label>
                            </div>
                            <asp:LinkButton ID="lnkAddNew" runat="server" Style="float: right;" CssClass="btn-primary" PostBackUrl="~/Admin/managetax.aspx">Add New Tax</asp:LinkButton>

                            <%--  <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/managetax.aspx">Add New Tax</asp:LinkButton>
                                </li>
                            </ul>--%>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvTaxes" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" OnRowDataBound="gvTaxes_RowDataBound"
                                    OnRowDeleting="gvTaxes_RowDeleting" DataKeyNames="TaxId"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="TaxName" HeaderText="Name" />
                                        <asp:BoundField DataField="CGST" HeaderText="CGST" />
                                        <asp:BoundField DataField="SGST" HeaderText="SGST" />
                                        <asp:BoundField DataField="MinAmount" HeaderText="Minimum Amt" />
                                        <asp:BoundField DataField="MaxAmount" HeaderText="Maximum Amt" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/managetax.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("TaxId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete"><img src="images/delete.png" /></asp:LinkButton>
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
