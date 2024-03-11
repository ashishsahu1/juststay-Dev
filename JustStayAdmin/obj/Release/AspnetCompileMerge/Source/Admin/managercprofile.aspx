<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managercprofile.aspx.cs" Inherits="JustStayAdmin.Admin.managercprofile" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cprcp">
    <asp:HiddenField ID="hdnrcprofileid" runat="server" Value="0" />
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="restchairprofiles.aspx">Add New Rest Chair Profile</a>
                </li>
                <li class="page-back">
                    <a href="restchairprofiles.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>Add New Rest Chair Profile</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblrcpmsg" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="tab-inn tab-posi">
                            <ul class="tabs">
                                <li class="tab col s3"><a class="active" href="#General">General</a>
                                </li>
                            </ul>
                            <div id="General" class="col s12 tab-pad">
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:DropDownList ID="drpatrc" runat="server" DataTextField="ATRCName" DataValueField="ATRCId">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvdrpatrc" runat="server" InitialValue="0"
                                            SetFocusOnError="true"
                                            ControlToValidate="drpatrc" ValidationGroup="rcp">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <label for="txtATRCManagerName">ATRC Manager Name</label>
                                        <asp:TextBox ID="txtATRCManagerName" runat="server" CssClass="validate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtATRCManagerName" runat="server" InitialValue="0"
                                            SetFocusOnError="true"
                                            ControlToValidate="txtATRCManagerName" ValidationGroup="rcp">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <label for="txtManagerNumber">Manager Mobile Number</label>
                                        <asp:TextBox ID="txtManagerNumber" runat="server" CssClass="validate"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtManagerNumber" runat="server"
                                            SetFocusOnError="true"
                                            ControlToValidate="txtManagerNumber" ValidationGroup="rcp">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <label for="txtTelNumber">ATRC Telephone Number</label>
                                        <asp:TextBox ID="txtTelNumber" runat="server" CssClass="validate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <div class="input-field col s6">
                                            <span>Rest Chair Start Date</span>
                                            <input id="txtrcstartdate" runat="server"  placeholder="Start Date" />
                                            <asp:RequiredFieldValidator ID="rfvtxtrcstartdate" runat="server"
                                                SetFocusOnError="true"
                                                ControlToValidate="txtrcstartdate" ValidationGroup="rcp">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="input-field col s6">
                                            <span>Rest Chair End Date</span>
                                            <input id="txtrcenddate" runat="server"  placeholder="End Date" />
                                            <asp:RequiredFieldValidator ID="rfvtxtrcenddate" runat="server"
                                                SetFocusOnError="true"
                                                ControlToValidate="txtrcenddate" ValidationGroup="rcp">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <div class="input-field col s6">
                                            <span>Rest Chair Start Time</span>
                                            <asp:TextBox ID="txtrcstarttime" runat="server" CssClass="validate"></asp:TextBox>
                                            <script>
                                                $('#ContentPlaceHolder1_txtrcstarttime').timepicker(
                                                    {
                                                        icons: {
                                                            rightIcon: '<i class="material-icons icon">access_time</i>'
                                                        }
                                                    });
                                            </script>
                                            <asp:RequiredFieldValidator ID="rfvtxtrcstarttime" runat="server"
                                                SetFocusOnError="true"
                                                ControlToValidate="txtrcstarttime" ValidationGroup="rcp">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                        <div class="input-field col s6">
                                            <span>Rest Chair End Time</span>
                                            <asp:TextBox ID="txtrcendtime" runat="server" CssClass="validate"></asp:TextBox>
                                            <script>
                                                $('#ContentPlaceHolder1_txtrcendtime').timepicker(
                                                     {
                                                         icons: {
                                                             rightIcon: '<i class="material-icons icon">access_time</i>'
                                                         }
                                                     });
                                            </script>
                                            <asp:RequiredFieldValidator ID="rfvtxtrcendtime" runat="server"
                                                SetFocusOnError="true"
                                                ControlToValidate="txtrcendtime" ValidationGroup="rcp">
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <span>ATRC Rest Chair Policy</span>
                                        <asp:TextBox ID="txtAtrcPolicy" runat="server" TextMode="MultiLine" CssClass="validate" />
                                        <asp:RequiredFieldValidator ID="rfvtxtAtrcPolicy" runat="server"
                                            SetFocusOnError="true"
                                            ControlToValidate="txtAtrcPolicy" ValidationGroup="policy">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <span>Cancellation Policy</span>
                                        <asp:CheckBoxList ID="chkPolicy" runat="server" DataTextField="PolicyName" DataValueField="PolicyId">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <span>Account Status</span>
                                        <asp:CheckBox ID="chkAccountStatus" runat="server" ClientIDMode="Static" Text="Is Active" CssClass="filled-in" />
                                        <asp:HiddenField runat="server" Value="1" ID="hdAcStatus" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:LinkButton ID="btnsavegeneral" OnClick="btnsavegeneral_Click" runat="server" CausesValidation="true" ValidationGroup="rcp" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/restchairprofiles.aspx">Cancel</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            CKEDITOR.replace('ContentPlaceHolder1_txtAtrcPolicy');
        }
    </script>
    <script>
        $("#ContentPlaceHolder1_chkAccountStatus").change(function () {
            if ($(this).prop("checked") == true) {
                $(document.getElementById('<%=hdAcStatus.ClientID%>')).val("0");
            } else {
                $(document.getElementById('<%=hdAcStatus.ClientID%>')).val("1");
            }
        });
    </script>
     <script>
         $('#ContentPlaceHolder1_txtrcstartdate').datepicker({
             uiLibrary: 'bootstrap', size: 'small',
             icons: {
                 rightIcon: '<i class="material-icons">date_range</i>',
                 previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                 nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
             }
         }); 
         $('#ContentPlaceHolder1_txtrcenddate').datepicker({
             uiLibrary: 'bootstrap', size: 'small',
             icons: {
                 rightIcon: '<i class="material-icons">date_range</i>',
                 previousMonth: '<i class="material-icons">keyboard_arrow_left</i>',
                 nextMonth: '<i class="material-icons">keyboard_arrow_right</i>'
             }
         });
     </script>
</asp:Content>


