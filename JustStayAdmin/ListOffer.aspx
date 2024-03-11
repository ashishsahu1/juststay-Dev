<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListOffer.aspx.cs" Inherits="JustStayAdmin.ListOffer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="basic-login-form-ad">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="all-form-element-inner">
                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9" style="float: right;">
                                            <asp:LinkButton ID="lnkAddNew" runat="server" class="btn btn-sm btn-primary login-submit-cs" PostBackUrl="~/ManageOffer.aspx">Add New Offer</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="data-table-area mg-b-15">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>Offer List</h1>
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

                                            <asp:GridView ID="gvOffers" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" OnRowDataBound="gvOffers_RowDataBound"
                                                OnRowDeleting="gvOffers_RowDeleting" DataKeyNames="OfferId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true"
                                                 data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="OfferId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar">
                                                <Columns>
                                                   <%-- <asp:TemplateField HeaderText="Banner">
                                                        <ItemTemplate>
                                                            <a href="/Utility/DownloadAttachment.aspx?From=BN&DocName=<%# Eval("OfferImgNewName")%>">
                                                                <%#Eval("OfferImage")%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   --%>
                                                    <asp:ImageField DataImageUrlField="OfferImgNewName" ControlStyle-Height="100px" ControlStyle-Width="100px" DataImageUrlFormatString="http://atrc.juststay.in/BlogImages/{0}" />
                                                    <asp:BoundField DataField="Heading" HeaderText="Heading" />
                                                    <asp:BoundField DataField="SubHeading" HeaderText="Sub Heading" />
                                                     <asp:BoundField DataField="ShortDetail" HeaderText="Short Detail" />
                                                      <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:d}"/>
                                                      <asp:BoundField DataField="EndDate" HeaderText="End Date" DataFormatString="{0:d}"/>
                                                    <asp:BoundField HeaderText="" DataField="OfferImgNewName" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/ManageOffer.aspx?Id={0}", Eval("OfferId"))%>'><img src="img/edit.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete"><img src="img/delete.png" /></asp:LinkButton>
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
</asp:Content>
