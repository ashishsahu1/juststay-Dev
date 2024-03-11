<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CreateATRCProfile.aspx.cs" Inherits="JustStayAdmin.CreateATRCProfile" %>

<%@ Register Src="~/Controls/ATRCHeader.ascx" TagPrefix="uc1" TagName="ATRCHeader" %>

<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
        
    <uc1:ATRCHeader runat="server" ID="ATRCHeader" />

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
                                                        <label class="login2 pull-right pull-right-pro">Restaurant Name</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtRestName" runat="server" class="form-control" MaxLength="50" />
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtRestName" ValidationGroup="reg" ErrorMessage="Required..!!">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Category
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                        <div class="inline-checkbox-cs">
                                                            <asp:CheckBoxList ID="chkCategory" runat="server" RepeatDirection="Horizontal" CssClass="checkbox-inline i-checks pull-left" DataTextField="Category" DataValueField="ATRCCategoryId">
                                                            </asp:CheckBoxList>
                                                            <asp:CustomValidator runat="server" ID="cvmCategorylist"
                                                                ClientValidationFunction="ValidateCategories" SetFocusOnError="true"
                                                                ForeColor="Red" Display="Dynamic" ErrorMessage="Select atleast one..!!" ValidationGroup="reg"></asp:CustomValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Promoter(s)/Owner(s) Name</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtOwnerName" runat="server" class="form-control" MaxLength="100" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtOwnerName" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtOwnerName" ValidationGroup="reg" ErrorMessage="Required..!!">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Postal Address</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" MaxLength="200" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv4" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtAddress" ValidationGroup="reg" ErrorMessage="Required..!!">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">State</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpState" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="NameWithCode" DataValueField="StateId" />
                                                            <asp:RequiredFieldValidator ID="rfvState" runat="server"
                                                                Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="drpState" ValidationGroup="reg" ErrorMessage="Required..!!">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">City</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpCity" class="form-control custom-select-value" runat="server" AppendDataBoundItems="false" onchange="BindLocations();" DataTextField="Name" DataValueField="CityId" />
                                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                                                Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="drpCity" ValidationGroup="reg" ErrorMessage="Required..!!">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Location</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpLocation" name="drpLocation" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="Name" DataValueField="LocationId" />
                                                            <%if (!IsPostBack)
                                                                {%>
                                                            <asp:RequiredFieldValidator ID="rfvLocation" runat="server"
                                                                Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="drpLocation" ValidationGroup="reg" ErrorMessage="Required..!!"> 
                                                            </asp:RequiredFieldValidator> <%}%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Geo Location</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:TextBox ID="txtGeoLocation" runat="server" CssClass="form-control" placeholder="GEO Location"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvGeolocation" runat="server"
                                                                Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="txtGeoLocation" ValidationGroup="reg" ErrorMessage="Required..!!"> 
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Tel No.</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtTel" runat="server" MaxLength="15" CssClass="form-control" placeholder="Tel. No"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv3" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtTel"
                                                            ValidationGroup="reg" ErrorMessage="Required..!!">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Email</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtemail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtemail" ErrorMessage="Required..!!" ValidationGroup="reg">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="regtxtEmail" runat="server" ErrorMessage="Invalid Email" Display="Dynamic"
                                                            ControlToValidate="txtemail" ValidationGroup="reg" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Promoter Mobile No.</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" MaxLength="10" placeholder="Mobile"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv7" runat="server" Display="Dynamic"
                                                            SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtMobile" ValidationGroup="reg" ErrorMessage="Required..!!">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="regaxMobile" runat="server" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$"
                                                            SetFocusOnError="true" Display="Dynamic" ValidationGroup="reg"
                                                            ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Dining Facilities</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="bt-df-checkbox">
                                                            <asp:RadioButtonList ID="rblDining" class="pull-left" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Text="Veg" Value="1" />
                                                                <asp:ListItem Text="Non-Veg" Value="2" />
                                                                <asp:ListItem Text="Both" Value="3" />
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Profile Photo</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                            <div class="input append-small-btn">
                                                                <div class="file-button">
                                                                    Browse
                                                                            <asp:FileUpload ID="profileImageUpload" runat="server"
                                                                                onchange="document.getElementById('append-small-btn1').value = this.value;ValidateFile(this);" ClientIDMode="Static" />
                                                                </div>
                                                                <input type="text" id="append-small-btn1" placeholder="no file selected" />
                                                            </div>
                                                        </div>
                                                        <span style="color: Red;" id="sp_profileImageUpload"></span>
                                                        <asp:RequiredFieldValidator ID="rfvImage" runat="server" Display="Dynamic"
                                                            SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="profileImageUpload" ValidationGroup="reg" ErrorMessage="*">
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
                                                                <asp:LinkButton OnClick="btnRegister_Click" ID="btnRegister" runat="server" OnClientClick="javascript:return ValidateRequired();" CausesValidation="true" ValidationGroup="reg" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Submit"></asp:LinkButton>
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
    <asp:HiddenField ID="hdMode" runat="server" />
    <asp:HiddenField ID="hdLocalityId" runat="server" />

    <asp:HiddenField ID="hdFromLat" runat="server" />
    <asp:HiddenField ID="hdFromLng" runat="server" />
    <asp:HiddenField ID="hdToLat" runat="server" />
    <asp:HiddenField ID="hdToLng" runat="server" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAFh08Wj9TUCJ5fRtlN_4UvkJahbLDSNfM&libraries=places"></script>

    <script type="text/javascript">
        var counter = 0;
        var allValidImages = true;
        function AddFileUpload() {

            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                '" type="file" onchange="ValidateFile(this);"/><span style="color:Red;" id="sp_file' + counter + '"></span>' +
                '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                'value="Remove" onclick = "RemoveFileUpload(this)" />';
            alert(div.innerHTML);
            document.getElementById("FileUploadContainer").appendChild(div);
            counter++;
        }

        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
        }

        function BindLocations() {
            var ddlLocations = $('#<%=drpLocation.ClientID%>');
             ddlLocations.empty();
             ddlLocations.append(new Option("Select Location", 0));
             var drpCity = $('#<%=drpCity.ClientID%>');
            var cityId = drpCity.val();
            if (cityId != 0) {
                $.ajax({
                    type: "POST",
                    url: "CreateATRCProfile.aspx/GetLocationsByCity",
                    data: "{ 'cityId':'" + cityId + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        debugger;
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            ddlLocations.append(new Option(value.Name, value.LocationId));
                        });
                    },
                    error: function (data) {
                        alert("error found");
                    }
                });
            }
        }
        function ValidateCategories(source, args) {
            debugger;
            var chkListModules = document.getElementById('<%= chkCategory.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
        function ValidateFile(value) {
            debugger;
            var file = getNameFromPath($(value).val());
            if (file != null) {
                var extension = file.substr((file.lastIndexOf('.') + 1));
                switch (extension) {
                    case 'jpg':
                    case 'jpeg':
                    case 'png':
                    case 'bmp':
                    case 'gif':
                        flag = true;
                        break;
                    default:
                        flag = false;
                }
            }

            var data = "sp_" + value.id;

            if (flag == false) {

                $("#" + data).text("You can upload only jpg, jpeg, png, bmp and gif extension file Only");
                $("#" + value.id).val('');
                return false;
            }
            else {
                $("#" + data).text("");
            }
        }

        function getNameFromPath(strFilepath) {
            var objRE = new RegExp(/([^\/\\]+)$/);
            var strName = objRE.exec(strFilepath);

            if (strName == null) {
                return null;
            }
            else {
                return strName[0];
            }
        }
        function ValidateRequired() {
            debugger;
            var Booleandata = true;
            if (Page_ClientValidate("reg")) {
                var spans = $("[id*='sp_']");
                for (var i = 0; i < spans.length; i++) {
                    if ($("#" + spans[i].id).text() != '') {
                        Booleandata = false;
                    }
                }
            }
            return Booleandata;
        }
    </script>

    <script>
        // var d = degrees_to_radians(10.12);
        var input = document.getElementById('<%=txtGeoLocation.ClientID %>');
        var autocomplete = new google.maps.places.Autocomplete(input, { types: ['(cities)'], componentRestrictions: { country: "in" } });
        autocomplete.setFields(["place_id", "geometry"]);

        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            var place = autocomplete.getPlace();

            $("#" + '<%=hdFromLat.ClientID%>').val(place.geometry.location.lat());// degrees_to_radians(place.geometry.location.lat());
            $("#" + '<%=hdFromLng.ClientID%>').val(place.geometry.location.lng());// degrees_to_radians(place.geometry.location.lng());
        });

        getLocation();

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    //
                    $("#" + '<%=hdFromLat.ClientID%>').val(position.coords.latitude);
                    $("#" + '<%=hdFromLng.ClientID%>').val(position.coords.longitude);
                });
            } else {
                document.getElementById("Label1").value = "Geolocation is not supported by this browser.";
            }
        }
    </script>
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/wow.min.js"></script>
    <script src="js/jquery-price-slider.js"></script>
    <script src="js/jquery.meanmenu.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/jquery.sticky.js"></script>
    <script src="js/jquery.scrollUp.min.js"></script>
    <script src="js/scrollbar/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="js/scrollbar/mCustomScrollbar-active.js"></script>
    <script src="js/metisMenu/metisMenu.min.js"></script>
    <script src="js/metisMenu/metisMenu-active.js"></script>
    <script src="js/tab.js"></script>
    <script src="js/icheck/icheck.min.js"></script>
    <script src="js/icheck/icheck-active.js"></script>
    <script src="js/plugins.js"></script>
    <script src="js/main.js"></script>
    <script src="js/tawk-chat.js"></script>
    <!-- code editor JS
		============================================ -->
    <script src="js/code-editor/codemirror.js"></script>
    <script src="js/code-editor/code-editor.js"></script>
    <script src="js/code-editor/code-editor-active.js"></script>

</asp:Content>
