<%@ Page Language="C#" AutoEventWireup="true" Title="Admin | ATRC - Just Stay" MasterPageFile="~/Site1.Master" CodeBehind="ATRC.aspx.cs" Inherits="JustStayAdmin.ATRC" %>

<%@ Register Src="~/Controls/ATRCHeader.ascx" TagPrefix="uc1" TagName="ATRCHeader" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    <uc1:ATRCHeader runat="server" ID="ATRCHeader" />

    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="product-payment-inner-st">
                        <ul id="myTabedu1" class="tab-review-design">
                            <li class="active"><a href="#atrcrequest">ATRC Request List</a></li>
                            <li><a href="#approvedatrc">Approved ATRC List</a></li>
                            <li><a href="#rejectatrc">Rejected ATRC List</a></li>
                        </ul>
                        <div id="myTabContent" class="tab-content custom-product-edit">
                            <div class="product-tab-list tab-pane fade active in" id="atrcrequest">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="data-table-area mg-b-15">
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="sparkline13-list">
                                                            <div class="sparkline13-hd">
                                                                <div class="main-sparkline13-hd">
                                                                    <h1>ATRC Request List</h1>
                                                                </div>
                                                            </div>
                                                            <div class="sparkline13-graph">
                                                                <div class="datatable-dashv1-list custom-datatable-overright">
                                                                    <div id="toolbar">
                                                                        <select class="form-control dt-tb">
                                                                            <option value="">Export Basic</option>
                                                                            <option value="all">Export All</option>
                                                                            <option value="selected">Export Selected</option>
                                                                        </select>
                                                                    </div>

                                                                    <asp:GridView ID="gvatrcrequest" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnPreRender="GridView1_PreRender" OnRowCommand="gvatrcrequest_RowCommand"
                                                                        Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                                        data-cookie-id-table="ATRCId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                                                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                            <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                                                            <asp:BoundField DataField="LOCATION" HeaderText="LOCATION" />
                                                                            <asp:TemplateField HeaderText="Edit">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/UpdateATRC.aspx?id={0}", Eval("ATRCId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Approve">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkapproved" runat="server" ToolTip="Approve" ForeColor="Blue" CommandName="approve" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="img/approve.png" /></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Reject">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Reject" ForeColor="Blue" CommandName="reject" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="img/reject.png" /></asp:LinkButton>
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
                                    </div>
                                </div>
                            </div>
                            <div class="product-tab-list tab-pane fade" id="approvedatrc">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="data-table-area mg-b-15">
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="sparkline13-list">
                                                            <div class="sparkline13-hd">
                                                                <div class="main-sparkline13-hd">
                                                                    <h1>Approved ATRC List</h1>
                                                                </div>
                                                            </div>
                                                            <div class="sparkline13-graph">
                                                                <div class="datatable-dashv1-list custom-datatable-overright">
                                                                    <div id="approved_toolbar">
                                                                        <select class="form-control dt-tb">
                                                                            <option value="">Export Basic</option>
                                                                            <option value="all">Export All</option>
                                                                            <option value="selected">Export Selected</option>
                                                                        </select>
                                                                    </div>

                                                                    <asp:GridView ID="grdApprovedATRC" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnPreRender="grdApprovedATRC_PreRender" OnRowCommand="grdApprovedATRC_RowCommand"
                                                                        Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                                        data-cookie-id-table="ATRCId" data-show-export="true" data-click-to-select="true" data-toolbar="#approved_toolbar">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                                                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                            <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                                                            <asp:BoundField DataField="LOCATION" HeaderText="LOCATION" />
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <%#GetBookingsLink(int.Parse(Eval("ATRCId").ToString()),int.Parse(Eval("BookingCount").ToString())) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Edit">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" ForeColor="Blue" PostBackUrl='<%# String.Format("~/UpdateATRC.aspx?id={0}", Eval("ATRCId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Reject">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Reject" ForeColor="Blue" CommandName="reject" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="img/reject.png" /></asp:LinkButton>
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
                                    </div>
                                </div>
                            </div>
                            <div class="product-tab-list tab-pane fade" id="rejectatrc">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="data-table-area mg-b-15">
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="sparkline13-list">
                                                            <div class="sparkline13-hd">
                                                                <div class="main-sparkline13-hd">
                                                                    <h1>Rejected ATRC List</h1>
                                                                </div>
                                                            </div>
                                                            <div class="sparkline13-graph">
                                                                <div class="datatable-dashv1-list custom-datatable-overright">
                                                                    <div id="rejected_toolbar">
                                                                        <select class="form-control dt-tb">
                                                                            <option value="">Export Basic</option>
                                                                            <option value="all">Export All</option>
                                                                            <option value="selected">Export Selected</option>
                                                                        </select>
                                                                    </div>

                                                                    <asp:GridView ID="grdRejectedATRC" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnRowCommand="grdRejectedATRC_RowCommand"
                                                                        Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                                        data-cookie-id-table="ATRCId" data-show-export="true" data-click-to-select="true" data-toolbar="#rejected_toolbar">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ATRCName" HeaderText="ATRC" />
                                                                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                            <asp:BoundField DataField="CITY" HeaderText="CITY" />
                                                                            <asp:BoundField DataField="LOCATION" HeaderText="LOCATION" />
                                                                            <asp:TemplateField HeaderText="Edit">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" ForeColor="Blue" PostBackUrl='<%# String.Format("~/UpdateATRC.aspx?id={0}", Eval("ATRCId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Approve">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkApprove" runat="server" Text="Approve" ForeColor="Blue" CommandName="approve" CommandArgument='<%# Eval("ATRCId").ToString() %>'><img src="img/approve.png" /></asp:LinkButton>
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
