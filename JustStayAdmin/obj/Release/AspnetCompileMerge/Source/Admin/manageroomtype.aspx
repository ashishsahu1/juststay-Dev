<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageroomtype.aspx.cs" Inherits="JustStayAdmin.Admin.manageroomtype" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageect" runat="server">
    <asp:HiddenField ID="hdTypeId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="roomtype.aspx">Room Type</a>
                </li>
                <li class="active-bre">Manage Room Type
                </li>
                <li class="page-back">
                    <a href="roomtype.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Room Type</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblroomtypemsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtroomtype" runat="server" CssClass="validate" MaxLength="100" />
                    <label for="txtatrctype">Room Type</label>
                    <asp:RequiredFieldValidator ID="rfvtxtroomtype" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtroomtype" ValidationGroup="valType">
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
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valType" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/roomtype.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
