<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageTax.aspx.cs" Inherits="JustStayAdmin.ManageTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdTaxId" runat="server" Value="0"/>
    <div class="basic-form-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="sparkline12-list">
                        <div class="sparkline12-graph">
                            <div class="basic-login-form-ad">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="all-form-element-inner">
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Tax Name</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtTaxName" runat="server" class="form-control" MaxLength="100" placeholder="Tax Name" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtTaxName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtTaxName" ValidationGroup="valTax">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Tax Rate (CGST)</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtCGST" runat="server" class="form-control" MaxLength="10" placeholder="CGST" />
                                                        %
                                                        <asp:RequiredFieldValidator ID="rfvtxtCGST" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtCGST" ValidationGroup="valTax">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="regaxtxtCGST" runat="server" ControlToValidate="txtCGST" ValidationExpression="^[0-9]*$"
                                                            SetFocusOnError="true" Display="Dynamic" ValidationGroup="valTax"
                                                            ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Tax Rate (SGST)</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtSGST" runat="server" class="form-control" MaxLength="10" placeholder="SGST" />
                                                        %
                                                        <asp:RequiredFieldValidator ID="rfvtxtSGST" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtSGST" ValidationGroup="valTax">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="regaxtxtSGST" runat="server" ControlToValidate="txtSGST" ValidationExpression="^[0-9]*$"
                                                            SetFocusOnError="true" Display="Dynamic" ValidationGroup="valTax"
                                                            ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group-inner">
                                                    <div class="row">
                                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                            <label class="login2 pull-right pull-right-pro">Minimum Amount</label>
                                                        </div>
                                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtMinAmt" runat="server" class="form-control" placeholder="Minimum Amount" />
                                                            <asp:RequiredFieldValidator ID="rfvtxtMinAmt" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="txtMinAmt" ValidationGroup="valTax">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="regaxMinAmt" runat="server" ForeColor="Red" Display="Dynamic"
                                                                SetFocusOnError="true" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                                                ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                                                                ControlToValidate="txtMinAmt" ValidationGroup="valTax" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-group-inner">
                                                    <div class="row">
                                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                            <label class="login2 pull-right pull-right-pro">Maximum Amount</label>
                                                        </div>
                                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                            <asp:TextBox ID="txtMaxAmt" runat="server" class="form-control" placeholder="Maximum Amount" />
                                                            <asp:RequiredFieldValidator ID="rfvtxtMaxAmt" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="txtMaxAmt" ValidationGroup="valTax">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegxtxtMaxAmt" runat="server" ForeColor="Red" Display="Dynamic"
                                                                SetFocusOnError="true" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                                                ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                                                                ControlToValidate="txtMaxAmt" ValidationGroup="valTax" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-group-inner">
                                                    <div class="login-btn-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3"></div>
                                                            <div class="col-lg-9">
                                                                <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                                                                        ValidationGroup="valTax" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ListTax.aspx">Cancel</asp:LinkButton>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
