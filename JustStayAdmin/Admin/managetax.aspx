<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managetax.aspx.cs" Inherits="JustStayAdmin.Admin.managetax" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageect" runat="server">
    <asp:HiddenField ID="hdTaxId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="taxes.aspx">Taxes</a>
                </li>
                <li class="active-bre">Manage Taxes
                </li>
                <li class="page-back">
                    <a href="taxes.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Taxes</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lbltaxesmsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtTaxName">Tax Name</label>
                    <asp:TextBox ID="txtTaxName" runat="server" class="form-control" MaxLength="100" />
                    <asp:RequiredFieldValidator ID="rfvtxtTaxName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtTaxName" ValidationGroup="valTax">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtCGST">CGST  %</label>
                    <asp:TextBox ID="txtCGST" runat="server" class="form-control" MaxLength="10" />
                    <asp:RequiredFieldValidator ID="rfvtxtCGST" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtCGST" ValidationGroup="valTax">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regaxtxtCGST" runat="server" ControlToValidate="txtCGST" ValidationExpression="^(\d+)?([.]?\d{0,2})?$"
                        SetFocusOnError="true" Display="Dynamic" ValidationGroup="valTax"
                        ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtSGST">SGST  %</label>
                    <asp:TextBox ID="txtSGST" runat="server" class="form-control" MaxLength="10" />
                    <asp:RequiredFieldValidator ID="rfvtxtSGST" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtSGST" ValidationGroup="valTax">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regaxtxtSGST" runat="server" ControlToValidate="txtSGST" ValidationExpression="^(\d+)?([.]?\d{0,2})?$"
                        SetFocusOnError="true" Display="Dynamic" ValidationGroup="valTax"
                        ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtMinAmt">Minimum Amount</label>
                    <asp:TextBox ID="txtMinAmt" runat="server" class="form-control" />
                    <asp:RequiredFieldValidator ID="rfvtxtMinAmt" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtMinAmt" ValidationGroup="valTax">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regaxMinAmt" runat="server" ForeColor="Red" Display="Dynamic"
                        SetFocusOnError="true" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                        ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                        ControlToValidate="txtMinAmt" ValidationGroup="valTax" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtMaxAmt">Maximum Amount</label>
                    <asp:TextBox ID="txtMaxAmt" runat="server" class="form-control" />
                    <asp:RequiredFieldValidator ID="rfvtxtMaxAmt" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtMaxAmt" ValidationGroup="valTax">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegxtxtMaxAmt" runat="server" ForeColor="Red" Display="Dynamic"
                        SetFocusOnError="true" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                        ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                        ControlToValidate="txtMaxAmt" ValidationGroup="valTax" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valTax" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/taxes.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
