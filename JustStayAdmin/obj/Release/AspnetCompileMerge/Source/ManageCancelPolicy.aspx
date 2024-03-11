<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageCancelPolicy.aspx.cs" Inherits="JustStayAdmin.ManageCancelPolicy" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <!-- touchspin CSS
		============================================ -->
    <link rel="stylesheet" href="css/touchspin/jquery.bootstrap-touchspin.min.css">
   
    <asp:HiddenField ID="hdPolicyId" runat="server" Value="0" />
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
                                                        <label class="login2 pull-right pull-right-pro">Policy Name</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" MaxLength="100" placeholder="Policy Name" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtName" ValidationGroup="valPolicy">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Policy Type</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpTypes" class="form-control custom-select-value" runat="server">
                                                                <asp:ListItem Text="Standard" Value="1" />
                                                                <asp:ListItem Text="Customized" Value="2" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Policy Text
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <textarea id="txtDetails" runat="server"></textarea>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                     <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Time
                                                        </label>
                                                    </div>   
                                                    <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            From
                                                        </label>
                                                    </div>                                                                                                   
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">                                                        
                                                        <div class="touchspin-inner">
                                                            <label>Hours</label>
                                                            <asp:TextBox ID="txtFromHours" runat="server" class="touchspin_hours" /> 
                                                             <asp:RequiredFieldValidator ID="rfvtxtFromHours" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtFromHours" ValidationGroup="valPolicy" />                                                                                                                                              
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                        <div class="touchspin-inner">
                                                            <label>Minutes</label>
                                                            <asp:TextBox ID="txtFromMin"  runat="server" CssClass="touchspin_minutes"/> 
                                                               <asp:RequiredFieldValidator ID="rfvtxtFromMin" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtFromMin" ValidationGroup="valPolicy" />                                                                                   
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                   <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">                                                            
                                                        </label>
                                                    </div>
                                                     <div class="col-lg-1 col-md-1 col-sm-1 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            To
                                                        </label>
                                                    </div>                                                                                                   
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">                                                        
                                                        <div class="touchspin-inner">
                                                            <label>Hours</label>
                                                            <asp:TextBox ID="txtToHours" runat="server" class="touchspin_hours" />                                                            
                                                              <asp:RequiredFieldValidator ID="rfvtxtToHours" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtToHours" ValidationGroup="valPolicy" />                        
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                        <div class="touchspin-inner">
                                                            <label>Minutes</label>
                                                            <asp:TextBox ID="txtToMinutes"  runat="server" CssClass="touchspin_minutes"/> 
                                                            <asp:RequiredFieldValidator ID="rfvtxtToMinutes" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtToMinutes" ValidationGroup="valPolicy">
                                                        </asp:RequiredFieldValidator>                                                           
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Apply After</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:CheckBox ID="chkApplyAfter" runat="server" /> Date & Time of Booking
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Apply Before</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:CheckBox ID="chkApplyBefore" runat="server" />  Date & Time of Check-In
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Refund Value</label>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                        <asp:TextBox ID="txtRefundPer" runat="server" class="form-control" MaxLength="100" CssClass="touchspin_percentage" />
                                                        <asp:RequiredFieldValidator ID="rfvRefundPer" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtRefundPer" ValidationGroup="valPolicy">
                                                        </asp:RequiredFieldValidator>
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
                                                                        ValidationGroup="valPolicy" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ListCancelPolicies.aspx">Cancel</asp:LinkButton>
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

     <!-- touchspin JS
		============================================ -->
    <script src="js/touchspin/jquery.bootstrap-touchspin.min.js"></script>
    <script src="js/touchspin/touchspin-active.js"></script>
   
    <script type="text/javascript">

        window.onload = function () {
            CKEDITOR.replace('main_txtDetails', {});
        }

        $(document).ready(function () {

            $("#main_txtToTime").timepicker({
                timeFormat: 'hh:mm',
                maxHours: 100,
                scrollbar: true
            });

            $("#main_txtFromTime").timepicker({
                scrollbar: true
            });

        });

    </script>

</asp:Content>
