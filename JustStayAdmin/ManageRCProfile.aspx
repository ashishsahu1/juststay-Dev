<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageRCProfile.aspx.cs" Inherits="JustStayAdmin.ManageRCProfile" %>
<%@ Register Src="~/Controls/ATRCChairsList.ascx" TagName="RestChairs" TagPrefix="RC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <link href="css/form/Radio_Status.css" rel="stylesheet" />
    <!-- chosen CSS
		============================================ -->
    <link rel="stylesheet" href="css/chosen/bootstrap-chosen.css" />

    <asp:HiddenField ID="hdRCProfileId" runat="server" Value="0" />

    <asp:HiddenField ID="hdATRCId" runat="server" Value="0" />
    <div class="basic-form-area mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="admintab-wrap edu-tab1 mg-t-30">
                        <ul class="nav nav-tabs custom-menu-wrap custon-tab-menu-style1" id="rctabs">
                            <li class="active"><a data-toggle="tab" href="#TabProfileDetails"><span class="edu-icon edu-analytics tab-custon-ic"></span>General</a>
                            </li>
                            <li id="liPolicy"><a data-toggle="tab" href="#TabPolicies"><span class="edu-icon edu-analytics-arrow tab-custon-ic"></span>Policy</a>
                            </li>
                            <li id="liChairs"><a data-toggle="tab" href="#TabPlan"><span class="edu-icon edu-analytics-bridge tab-custon-ic"></span>Rest Chair</a>
                            </li>
                            <li><a data-toggle="tab" href="#TabPricing"><span class="edu-icon edu-analytics-bridge tab-custon-ic"></span>Pricing</a>
                            </li>
                        </ul>
                        <div class="tab-content">
                            <div id="TabProfileDetails" class="tab-pane in active animated flipInX custon-tab-style1">
                                <div class="sparkline12-list">
                                    <div class="sparkline12-graph">
                                        <div class="basic-login-form-ad">
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div class="all-form-element-inner">
                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">Manager Name</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <asp:TextBox ID="txtManagerName" runat="server" class="form-control" MaxLength="100" placeholder="Manager Name" />
                                                                    <asp:RequiredFieldValidator ID="rfvtxtManagerName" runat="server"
                                                                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="txtManagerName" ValidationGroup="valProfile">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">Manager Mobile No.</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" MaxLength="10" placeholder="Mobile"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfv7" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="txtMobile" ValidationGroup="valProfile">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="regaxMobile" runat="server" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$"
                                                                        SetFocusOnError="true" Display="Dynamic" ValidationGroup="valProfile"
                                                                        ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">ATRC Tel No.</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <asp:TextBox ID="txtTel" runat="server" MaxLength="15" CssClass="form-control" placeholder="Tel. No"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfv3" runat="server"
                                                                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtTel"
                                                                        ValidationGroup="valProfile">
                                                                    </asp:RequiredFieldValidator>
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
                                                                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="txtStartDate" ValidationGroup="valProfile">
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
                                                                    <asp:RequiredFieldValidator ID="rfvtxtEndDate" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="txtEndDate" ValidationGroup="valProfile">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                                    <label class="login2 pull-right pull-right-pro">
                                                                        Rest Chairs Timings
                                                                    </label>
                                                                </div>
                                                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                                    From
                                                                 <asp:TextBox ID="txtFromTime" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtFromTime" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="txtFromTime" ValidationGroup="valProfile">
                                                                    </asp:RequiredFieldValidator>

                                                                </div>
                                                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                                                    To
                                                        <asp:TextBox ID="txtToTime" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtToTime" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="txtToTime" ValidationGroup="valProfile">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div>
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">Status</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <div class="btn-group" data-toggle="buttons">
                                                                        <asp:RadioButton ID="rbActive" runat="server" CssClass="btn btn-default-green btn-xs active" Text="Active" />
                                                                        <asp:RadioButton ID="rbInactive" runat="server" CssClass="btn btn-default-red btn-xs" Text="In Active" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group-inner">
                                                            <div class="login-btn-inner">
                                                                <div class="row">
                                                                    <div class="col-lg-3"></div>
                                                                    <div class="col-lg-9">
                                                                        <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                            <asp:LinkButton ID="btnSaveProfile" runat="server" OnClientClick="javascript:return ValidateRequired();" OnClick="btnSaveProfile_Click" CausesValidation="true" ValidationGroup="valProfile" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" OnClick="lnkClose_Click">Cancel</asp:LinkButton>
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
                            <div id="TabPolicies" class="tab-pane animated flipInX custon-tab-style1">
                                <div class="sparkline12-list">
                                    <div class="sparkline12-graph">
                                        <div class="basic-login-form-ad">
                                            <div class="row">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <div class="all-form-element-inner">
                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">ATRC Policy</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <textarea id="txtATRCPolicy" runat="server"></textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">Cancellation Policy</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <textarea id="txtCancellationPolicy" runat="server"></textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                    <label class="login2 pull-right pull-right-pro">Cancellation Policy</label>
                                                                </div>
                                                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                    <div class="chosen-select-single">
                                                                        <asp:DropDownList ID="drpCancellationPolicies" data-placeholder="Select Policy" runat="server" class="chosen-select" multiple="" TabIndex="-1"
                                                                            DataValueField="PolicyId" DataTextField="PolicyName" />                                                                        
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group-inner">
                                                            <div class="login-btn-inner">
                                                                <div class="row">
                                                                    <div class="col-lg-3"></div>
                                                                    <div class="col-lg-9">
                                                                        <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                            <asp:LinkButton ID="lnkSavePolicy" runat="server" OnClick="lnkSavePolicy_Click" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkCancel" runat="server" class="btn btn-white" OnClick="lnkClose_Click">Cancel</asp:LinkButton>
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
                            <div id="TabPlan" class="tab-pane animated flipInX custon-tab-style1">

                                <div class="btn-group" data-toggle="buttons">
                                    <asp:RadioButton ID="RadioButton1" runat="server" CssClass="btn btn-default-green btn-xs active" Text="Active" />
                                    <asp:RadioButton ID="RadioButton2" runat="server" CssClass="btn btn-default-red btn-xs" Text="In Active" />
                                </div>

                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                            <label class="login2 pull-right pull-right-pro">End Date</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <div class="btn-group" data-toggle="buttons">
                                                <asp:RadioButton ID="RadioButton3" runat="server" CssClass="btn btn-default-green btn-xs active" Text="Active" />
                                                <asp:RadioButton ID="RadioButton4" runat="server" CssClass="btn btn-default-red btn-xs" Text="In Active" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                               <RC:RestChairs Id="s" runat="server" />

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="js/vendor/jquery-1.12.4.min.js"></script>

    <!-- chosen JS
		============================================ -->
    <script src="js/chosen/chosen.jquery.js"></script>
    <script src="js/chosen/chosen-active.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {

            $("#main_txtToTime").timepicker({
                scrollbar: true
            });

            $("#main_txtFromTime").timepicker({
                scrollbar: true
            });


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

            $(".nav .disabled>a").on("click", function (e) {
                e.preventDefault();
                return false;
            });

            //$("#main_drpCancellationPolicies").chosen().change(function (e, params) {
            //    values = $("#main_drpCancellationPolicies").chosen().val();
            //    //values is an array containing all the results.
            //});
          
            //$('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
            //    localStorage.setItem('activeTab', $(e.target).attr('href'));
            //});
            //var activeTab = localStorage.getItem('activeTab');
            //alert(activeTab);
            //if (activeTab) {
            //    $('#rctabs a[href="' + activeTab + '"]').tab('show');
            //}
        });

        function DisableProfileTabs() {
            $("#liPolicy").addClass("disabled");
            $("#liChairs").addClass("disabled");
        }

        function ShowRestChairs()
        {
            $('#rctabs a[href="#TabPlan"]').tab('show');
         //   $("#liChairs").addClass("active"); //current is the id of the tab
        }

        function SetPolicies()
        {
            $(".chosen-select").val(["4"]);
            $(".chosen-select").trigger('chosen:updated.chosen');
            $("#main_drpCancellationPolicies").val(4);
            $("#main_drpCancellationPolicies").trigger('chosen:updated');
        }
    </script>

</asp:Content>
