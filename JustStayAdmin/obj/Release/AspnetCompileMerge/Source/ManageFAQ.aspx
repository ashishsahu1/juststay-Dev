<%@ Page Title="Manage FAQ | JustStay" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageFAQ.aspx.cs" Inherits="JustStayAdmin.ManageFAQ" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cphmain" ContentPlaceHolderID="main" runat="server">
    <link href="css/code-editor/codemirror.css" rel="stylesheet" />
    <asp:HiddenField ID="hdFAQId" runat="server"  Value="0"/>

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
                                                        <label class="login2 pull-right pull-right-pro">Audience</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpAudience" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false">
                                                                <asp:ListItem Value="1" Text="Customer" />
                                                                <asp:ListItem Value="2" Text="ATRC" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Question</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtquestion" runat="server" class="form-control" MaxLength="500" />
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtquestion" ValidationGroup="valfaq">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Answer
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="code-editor-single shadow-reset">
                                                            <textarea id="txtFAQAnswer" runat="server"></textarea>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Sequence No.</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtSequence" runat="server" class="form-control" MaxLength="10" />
                                                        <asp:RequiredFieldValidator ID="rfvSeq" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtSequence" ValidationGroup="valfaq">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rev11" runat="server" ControlToValidate="txtSequence"
                                                            ValidationExpression="^[0-9]*$" SetFocusOnError="true" Display="Dynamic" ValidationGroup="valfaq"
                                                            ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
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
                                                                    ValidationGroup="valfaq" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ListFAQ.aspx">Cancel</asp:LinkButton>
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

     <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <!-- code editor JS
		============================================ -->
    <script src="js/code-editor/codemirror.js"></script>
    <script src="js/code-editor/code-editor.js"></script>
    <script src="js/code-editor/code-editor-active.js"></script>

    <script>
        var editor_three = CodeMirror.fromTextArea(document.getElementById("main_txtFAQAnswer"), {
            lineNumbers: true,
            matchBrackets: true,
            styleActiveLine: true
        });


    </script>

</asp:Content>
