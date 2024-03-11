<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageOffer.aspx.cs" Inherits="JustStayAdmin.ManageOffer" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdOfferId" runat="server" Value="0" />
    <link href="css/form/all-type-forms.css" rel="stylesheet" />
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
                                                        <label class="login2 pull-right pull-right-pro">Heading</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtHeading" runat="server" class="form-control" MaxLength="100" />
                                                        <asp:RequiredFieldValidator ID="rfvHeading" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtHeading" ValidationGroup="valoffer">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Sub Heading</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtSubHeading" runat="server" class="form-control" MaxLength="100" />
                                                        <asp:RequiredFieldValidator ID="rfvSubHeading" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtSubHeading" ValidationGroup="valoffer">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Short Detail</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtShortDetail" runat="server" class="form-control" MaxLength="100" />
                                                        <asp:RequiredFieldValidator ID="rfvShortDetail" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtShortDetail" ValidationGroup="valoffer">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Details
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <textarea id="txtDetails" runat="server"></textarea>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Start Date</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtStartDate" runat="server" class="form-control" />
                                                        <asp:RequiredFieldValidator ID="rfvDate" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtStartDate" ValidationGroup="valoffer">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">End Date</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtEndDate" runat="server" class="form-control" />
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Offer Image</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                            <div class="input append-small-btn">
                                                                <div class="file-button">
                                                                    Browse
                                                                            <asp:FileUpload ID="offerImageUpload" runat="server" onchange="document.getElementById('append-small-btn1').value = this.value;" />
                                                                </div>
                                                                <input type="text" id="append-small-btn1" placeholder="no file selected" />
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <asp:Label ID="lblImageName" runat="server"></asp:Label>
                                                        <asp:Label ID="lblfilename" runat="server" Visible="false"></asp:Label>
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
                                                                    ValidationGroup="valoffer" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ListOffer.aspx">Cancel</asp:LinkButton>
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
    <script type="text/javascript">
        window.onload = function () {
            CKEDITOR.replace('main_txtDetails', {});
        }

        $(document).ready(function () {
            $('#main_txtStartDate').datepicker({
                "dateFormat": "dd-mm-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });
           
            $('#main_txtEndDate').datepicker({
                "dateFormat": "dd-mm-yy",
                "keyboardNavigation": false,
                "autoclose": true
            });

            $('#main_txtStartDate').keypress(function (key) {
                if (key.charCode < 48 || key.charCode > 57) return false;
            });

            $('#main_txtEndDate').keypress(function (key) {
                if (key.charCode < 48 || key.charCode > 57) return false;
            });
        });

    </script>
</asp:Content>
