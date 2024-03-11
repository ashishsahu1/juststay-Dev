<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="atrcaccount.aspx.cs" Inherits="JustStayAdmin.Admin.atrcaccount" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphatrcaccount">
    <asp:HiddenField ID="hdnatrcid" runat="server" Value="0" />
     <asp:HiddenField ID="hdnatrcaccountid" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrc.aspx">ATRC List</a>
                </li>
                <li class="active-bre"><a href="atrcaccount.aspx">ATRC Account</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>ATRC Account</h2>
            <div class="row">
                <div class="box-inn-sp">
                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    <div class="row">
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtbankname" runat="server" CssClass="form-control" placeholder="Bank Name"></asp:TextBox>
                        </div>
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtAccountNumber" runat="server" CssClass="form-control" placeholder="Account Number"></asp:TextBox>
                        </div>
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtIFSC" runat="server" CssClass="form-control" placeholder="IFSC"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control" placeholder="Account Name"></asp:TextBox>
                        </div>
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtBranch" runat="server" CssClass="form-control" placeholder="Branch"></asp:TextBox>
                        </div>
                    </div>
                     <div class="row">
                                <div class="box-inn-sp">
                                     <div class="input-field col s2">
                                    <asp:Button ID="btnsave" runat="server" Text="Save Account" CssClass="btn btn-info" OnClick="btnsave_Click" />
                                         </div>
                                </div>
                            </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
