<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageatrctype.aspx.cs" Inherits="JustStayAdmin.Admin.manageatrctype" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageect" runat="server">
    <asp:HiddenField ID="hdTypeId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrctype.aspx">ATRC Type</a>
                </li>
                <li class="active-bre">Manage ATRC Type
                </li>
                <li class="page-back">
                    <a href="atrctype.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage ATRC Type</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblatrctypemsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtatrctype" runat="server" class="validate" MaxLength="100" />
                    <label for="txtatrctype">ATRC Type</label>
                    <asp:RequiredFieldValidator ID="rfvtxtatrctype" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtatrctype" ValidationGroup="valType">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="validate" TextMode="MultiLine" Columns="6" Rows="6" MaxLength="500"></asp:TextBox>
                    <label for="txtContent">Description</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="valType" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/atrctype.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
