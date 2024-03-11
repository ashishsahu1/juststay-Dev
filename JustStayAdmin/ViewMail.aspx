<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewMail.aspx.cs" Inherits="JustStayAdmin.ViewMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hmMessageId" runat="server"  Value="0"/>
    <style>
        .font-extra-bold {
            font-weight: bold;
        }
    </style>
    <div class="mailbox-view-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="hpanel email-compose mailbox-view">
                        <div class="panel-heading hbuilt">

                            <div class="p-xs h4">
                                <small class="pull-right view-hd-ml"> <asp:Label ID="lblDate" runat="server"></asp:Label>
                                </small>Email view
                            </div>
                        </div>
                        <div class="border-top border-left border-right bg-light">
                            <div class="p-m custom-address-mailbox">

                                <div>
                                    <span class="font-extra-bold">Subject: </span>
                                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <span class="font-extra-bold">From: </span>
                                    <asp:Label ID="lblFrom" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <span class="font-extra-bold">To: </span>
                                    <asp:Label ID="lblTo" runat="server"></asp:Label>
                                </div>                                
                            </div>
                        </div>
                        <div class="panel-body panel-csm">
                            <div id="divMailContent" runat="server">
                            </div>
                        </div>

                        <div class="panel-footer text-right ft-pn">
                            <div class="btn-group active-hook">
                                 <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-default" OnClick="lnkBack_Click"><i class="fa fa-arrow-left"></i> Back</asp:LinkButton>
                                <asp:LinkButton ID="lnkReply" runat="server" CssClass="btn btn-default" OnClick="lnkReply_Click"><i class="fa fa-reply"></i> Reply</asp:LinkButton>
                                <asp:LinkButton ID="lnkForward" runat="server" CssClass="btn btn-default" OnClick="lnkForward_Click"><i class="fa fa-arrow-right"></i> Forward</asp:LinkButton>
                               <%-- <asp:LinkButton ID="lnkPrint" runat="server" CssClass="btn btn-default"><i class="fa fa-print"></i>Print</asp:LinkButton>--%>
                                <asp:LinkButton ID="lnkDelete"  runat="server" CssClass="btn btn-default" OnClick="lnkDelete_Click"><i class="fa fa-trash-o"></i> Remove</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
