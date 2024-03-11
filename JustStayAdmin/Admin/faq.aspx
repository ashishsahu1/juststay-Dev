<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="faq.aspx.cs" Inherits="JustStayAdmin.Admin.faq" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="faq.aspx">FAQ</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All FAQs</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblfaqlistmsg" runat="server"></asp:Label>
                            </div>
                            <div class="input-field">
                                <asp:DropDownList ID="drpAudience" runat="server" AppendDataBoundItems="true" AutoPostBack="false">
                                    <asp:ListItem Value="1" Text="Customer" />
                                    <asp:ListItem Value="2" Text="ATRC" />
                                </asp:DropDownList>

                                <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" CausesValidation="true"
                                    CssClass="waves-effect waves-light btn-large waves-input-wrapper" Text="Go"></asp:LinkButton>
                            </div>
                            <a class="dropdown-button drop-down-meta" href="#" data-activates="dr-users"><i class="material-icons">more_vert</i></a>
                            <ul id="dr-users" class="dropdown-content">
                                <li>
                                    <asp:LinkButton ID="lnkAddNew" runat="server" PostBackUrl="~/Admin/managefaq.aspx">Add New FAQ</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="gvFAQs" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnRowCommand="gvFAQs_RowCommand" OnRowDataBound="gvFAQs_RowDataBound"
                                    OnRowDeleting="gvFAQs_RowDeleting"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Question" HeaderText="Question" />
                                        <asp:BoundField DataField="Answer" HeaderText="Answer" />
                                        <asp:BoundField DataField="Sequence" HeaderText="Sequence No." />
                                        <asp:BoundField HeaderText="Inserted On" DataField="InsertedOn" DataFormatString="{0:d}" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/Admin/managefaq.aspx?Id={0}", new JustStayAdmin.Admin.BL.RC4().Encrypt(Eval("FAQId").ToString()))%>'><img src="images/edit.png" /></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete" CommandArgument='<%# Eval("FAQId").ToString() %>'><img src="images/delete.png" /></asp:LinkButton>
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

