<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="JustStay.ATRC.Inbox" %>
<%@ Import Namespace="JustStay.CommonHub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdFromInbox" runat="server" />
    <script type="text/javascript">
        function ShowMail(mailId) {
            var isFromInbox = $("#" + '<%=hdFromInbox.ClientID %>').val();
            if (isFromInbox == '1')
                window.location.href = "ViewMail.aspx?Id=" + mailId + "&From=Inbox";
            else
                window.location.href = "ViewMail.aspx?Id=" + mailId + "&Mode=Sent";
        }
    </script>
    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="data-table-area mg-b-15">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>Inbox</h1>
                                        </div>
                                    </div>
                                    <div class="sparkline13-graph">
                                        <div class="datatable-dashv1-list custom-datatable-overright">
                                            <div id="toolbar">
                                                <asp:LinkButton ID="lnkDelete"  runat="server" Visible="false" CssClass="btn btn-default" OnClick="lnkDelete_Click" OnClientClick="javascript: return ConfirmDelete('#main_grdInbox');"><i class="fa fa-trash-o"></i> Delete</asp:LinkButton>
                                              <%--  <select class="form-control dt-tb">
                                                    <option value="">Export Basic</option>
                                                    <option value="all">Export All</option>
                                                    <option value="selected">Export Selected</option>
                                                </select>
                                              --%>   
                                            </div>

                                            <asp:GridView ID="grdInbox" runat="server" AutoGenerateColumns="false" class="table table-striped table-no-bordered" DataKeyNames="MessageId"
                                                Width="100%" data-toggle="table" data-pagination="true" data-search="true"  data-show-pagination-switch="true" OnRowDataBound="grdInbox_RowDataBound"
                                                data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                data-cookie-id-table="MessageId" data-show-export="true" data-click-to-select="true" data-toolbar="#toolbar" EmptyDataText="No Messages Found">
                                                <Columns>
                                                    <asp:TemplateField ControlStyle-Width="4%" HeaderStyle-Width="4%">
                                                        <HeaderTemplate>
                                                            <asp:CheckBox ID="ckSelectAll" onclick="CheckAllCheckBox(this,'#main_grdInbox');" runat="server" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbSelect" onclick="UnCheckSelectAll(this,'#main_grdInbox');" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a style="cursor:pointer" onclick='javascript:ShowMail("<%#Eval("MessageId") %>")'><%# ShortenEmail(50, Eval("FromEmail").ToString())%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a style="cursor:pointer" onclick='javascript:ShowMail("<%#Eval("MessageId") %>")'><%# Helper.CreateShortString(200, Eval("Subject").ToString())%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="InsertedOn" DataFormatString="{0: dd MMM HH:mm}" />

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
