<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="viewmail.aspx.cs" Inherits="JustStayAdmin.Admin.viewmail" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanagefaq" runat="server">
    <asp:HiddenField ID="hmMessageId" runat="server" Value="0" />
    <style>
        .font-extra-bold {
            font-weight: bold;
        }
    </style>
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="inbox.aspx">Inbox</a>
                </li>
                <li class="active-bre">View mail
                </li>
                <li class="page-back">
                    <a href="inbox.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>View Mail</h2>
            <asp:Label ID="lblDate" runat="server" style="float:right;"></asp:Label>
            <div class="row">
                <div class="input-field col s12">
                   <span>Subject: </span>
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>

                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>From: </span>
                    <asp:Label ID="lblFrom" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>To: </span>
                    <asp:Label ID="lblTo" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div id="divMailContent" runat="server">
                    </div>
                     <asp:GridView ID="grdattachments" runat="server" Border="0" AutoGenerateColumns="false" CssClass="table table-hover" 
                                Width="100%" DataKeyNames="AttachmentId" OnRowCommand="grdattachments_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Attachments">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkdownload" runat="server" style="color:blue;" CommandName="download" CommandArgument='<%# Eval("DocNewName").ToString() %>'><%#Eval("DocName")%></asp:LinkButton>
                                            <%--<a href="/Utility/DownloadAttachment.aspx?DocName=<%# Eval("DocNewName")%>" >
                                             </a>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-default" OnClick="lnkBack_Click"><i class="fa fa-arrow-left"></i> Back</asp:LinkButton>
                    <asp:LinkButton ID="lnkReply" runat="server" CssClass="btn btn-default" OnClick="lnkReply_Click"><i class="fa fa-reply"></i> Reply</asp:LinkButton>
                    <asp:LinkButton ID="lnkForward" runat="server" CssClass="btn btn-default" OnClick="lnkForward_Click"><i class="fa fa-arrow-right"></i> Forward</asp:LinkButton>
                    <asp:LinkButton ID="lnkDelete" runat="server" CssClass="btn btn-default" OnClick="lnkDelete_Click"><i class="fa fa-trash-o"></i> Remove</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

