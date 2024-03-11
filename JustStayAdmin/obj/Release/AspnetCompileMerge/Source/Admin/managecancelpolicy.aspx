<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managecancelpolicy.aspx.cs" Inherits="JustStayAdmin.Admin.managecancelpolicy" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageect" runat="server">
    <asp:HiddenField ID="hdPolicyId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="cancellationpolicy.aspx">Cancellation Policy</a>
                </li>
                <li class="active-bre"><a href="managecancelpolicy.aspx">Manage Cancellation Policy</a>
                </li>
                <li class="page-back">
                    <a href="cancellationpolicy.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Cancellation Policy</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblcancellationplocy" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtName">Policy Name</label>
                    <asp:TextBox ID="txtName" runat="server" class="validate" MaxLength="100" />
                    <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtName" ValidationGroup="valPolicy">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="drpTypes" runat="server">
                        <asp:ListItem Text="Standard" Value="1" />
                        <asp:ListItem Text="Customized" Value="2" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtDetails">Description</label>
                    <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" Columns="6" Rows="6" CssClass="validate"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtFromHours">From Hours</label>
                    <asp:TextBox ID="txtFromHours" runat="server" CssClass="validate" />
                    <asp:RequiredFieldValidator ID="rfvtxtFromHours" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtFromHours" ValidationGroup="valPolicy" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtFromMin">From Minutes</label>
                    <asp:TextBox ID="txtFromMin" runat="server" CssClass="validate" />
                    <asp:RequiredFieldValidator ID="rfvtxtFromMin" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtFromMin" ValidationGroup="valPolicy" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtToHours">To Hours</label>
                    <asp:TextBox ID="txtToHours" runat="server" class="validate" />
                    <asp:RequiredFieldValidator ID="rfvtxtToHours" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtToHours" ValidationGroup="valPolicy" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtToMinutes">To Minutes</label>
                    <asp:TextBox ID="txtToMinutes" runat="server" CssClass="validate" />
                    <asp:RequiredFieldValidator ID="rfvtxtToMinutes" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtToMinutes" ValidationGroup="valPolicy">
                                                        </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:CheckBox ID="chkApplyAfter" runat="server" ClientIDMode="Static" Text="Is Apply After Date & Time of Booking" CssClass="filled-in" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:CheckBox ID="chkApplyBefore" runat="server" ClientIDMode="Static" Text="Is Apply Before Date & Time of Check-In" CssClass="filled-in" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtRefundPer">Refund Value</label>
                    <asp:TextBox ID="txtRefundPer" runat="server" class="validate" MaxLength="100" CssClass="touchspin_percentage" />
                    <asp:RequiredFieldValidator ID="rfvRefundPer" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtRefundPer" ValidationGroup="valPolicy">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valPolicy" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/cancellationpolicy.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

