<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ATRCChairsList.ascx.cs" Inherits="JustStayAdmin.Controls.ATRCChairsList" %>
<div class="single-pro-review-area mt-t-30 mg-b-15">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
          <%--  <div class="basic-login-form-ad">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="all-form-element-inner">
                            <div class="form-group-inner">
                                <div class="row">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9" style="float: right;">
                                        <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click" class="btn btn-sm btn-primary login-submit-cs">Add New Tax</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="data-table-area mg-b-15">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="sparkline13-list">
                               
                                <div class="sparkline13-graph">
                                    <div class="datatable-dashv1-list custom-datatable-overright">
                                        <asp:GridView ID="gvChairs" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv"
                                            DataKeyNames="ATRCRestChairId"
                                            Width="100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true"
                                            data-show-pagination-switch="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                            data-cookie-id-table="ATRCRestChairId" data-show-export="true" data-click-to-select="true">
                                            <Columns>
                                                <asp:BoundField DataField="ChairName" HeaderText="Name" />
                                                <asp:BoundField DataField="TypeName" HeaderText="Chair Type" />
                                                <asp:BoundField DataField="ChairCount" HeaderText="Chair Count" />
                                                <asp:BoundField DataField="Description" HeaderText="Chair Description" />
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" PostBackUrl='<%# String.Format("~/ManageRestChair.aspx?Id={0}", Eval("ATRCRestChairId"))%>'><img src="img/edit.png" /></asp:LinkButton>
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
