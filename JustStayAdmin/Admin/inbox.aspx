<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="inbox.aspx.cs" Inherits="JustStayAdmin.Admin.inbox" %>

<%@ Import Namespace="JustStay.CommonHub" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphuserlist">
    <asp:HiddenField ID="hdFromInbox" runat="server" />
    <style>
        .textbold {
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        function ShowMail(mailId) {
            var isFromInbox = $("#" + '<%=hdFromInbox.ClientID %>').val();
            if (isFromInbox == '1')
                window.location.href = "viewmail.aspx?Id=" + mailId + "&From=Inbox";
            else
                window.location.href = "viewmail.aspx?Id=" + mailId + "&Mode=Sent";
        }
    </script>
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="inbox.aspx">Inbox</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Inbox</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblinboxmsg" runat="server"></asp:Label>
                            </div>
                            <div class="input-field">
                                <asp:LinkButton ID="lnkDelete" runat="server" Visible="false" OnClick="lnkDelete_Click" OnClientClick="javascript: return ConfirmDelete('#ContentPlaceHolder1_grdInbox');"><i class="fa fa-trash-o"></i> Delete</asp:LinkButton>

                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdInbox" runat="server" AutoGenerateColumns="false" class="table table-hover" DataKeyNames="MessageId"
                                    Width="100%" OnRowDataBound="grdInbox_RowDataBound" EmptyDataText="No Messages Found">
                                    <Columns>
                                        <asp:TemplateField ControlStyle-Width="4%" HeaderStyle-Width="4%">
                                            <HeaderTemplate>
                                           <asp:CheckBox ID="ckSelectAll" CssClass="filled-in" ClientIDMode="Static" Text="Select All" onclick="CheckAllCheckBox(this,'#ContentPlaceHolder1_grdInbox');" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbSelect" CssClass="filled-in" ClientIDMode="Static" Text='<%# ShortenEmail(50, Eval("FromEmail").ToString())%>'  onclick="UnCheckSelectAll(this,'#ContentPlaceHolder1_grdInbox');" runat="server" />
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <%--   <asp:TemplateField>
                                            <ItemTemplate>
                                                <a style="cursor: pointer" onclick='javascript:ShowMail("<%#Eval("MessageId") %>")'></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a style="cursor: pointer" onclick='javascript:ShowMail("<%#Eval("MessageId") %>")'><%#Helper.CreateShortString(200, Eval("Subject").ToString())%></a>
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
    <script>
        function CheckAllCheckBox(selectAllCheckbox, gridViewId) {
            $('td :checkbox:enabled', gridViewId).prop("checked", selectAllCheckbox.checked);
        }
        function UnCheckSelectAll(selectCheckbox, gridViewId) {
            if (!selectCheckbox.checked)
                $('th :checkbox', gridViewId).prop("checked", false);
        }
    </script>
</asp:Content>

