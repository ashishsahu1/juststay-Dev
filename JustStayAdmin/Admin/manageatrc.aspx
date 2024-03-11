<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageatrc.aspx.cs" Inherits="JustStayAdmin.Admin.manageatrc" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageuser" runat="server">
    <link href="css/gijgo.min.css" rel="stylesheet" />
    <script src="js/jquery.min.js"></script>
    <script src="js/gijgo.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <asp:HiddenField ID="hdATRCId" runat="server" Value="0" />
    <asp:HiddenField ID="hdLocationId" runat="server" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="atrc.aspx">ATRC</a>
                </li>
                <li class="active-bre">Manage ATRC
                </li>
                <li class="page-back">
                    <a href="atrc.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage ATRC</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblatrcmsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtRestName">Restaurant Name</label>
                    <asp:TextBox ID="txtRestName" runat="server" CssClass="validate" MaxLength="50" />
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtRestName" ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>Category</span>
                    <asp:CheckBoxList ID="chkCategory" runat="server" RepeatDirection="Horizontal" DataTextField="Category" DataValueField="ATRCCategoryId">
                    </asp:CheckBoxList>
                    <asp:CustomValidator runat="server" ID="cvmCategorylist"
                        ClientValidationFunction="ValidateCategories" SetFocusOnError="true"
                        ForeColor="Red" Display="Dynamic" ErrorMessage="Select atleast one..!!" ValidationGroup="reg"></asp:CustomValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="drpatrctype" runat="server" DataTextField="Name" DataValueField="ATRCTypeId">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvdrpatrctype" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="drpatrctype" ValidationGroup="reg" ErrorMessage="Required..!!" InitialValue="0">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtOwnerName">Promoter(s)/Owner(s) Name</label>
                    <asp:TextBox ID="txtOwnerName" runat="server" CssClass="validate" MaxLength="100" />
                    <asp:RequiredFieldValidator ID="rfvtxtOwnerName" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtOwnerName" ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>Postal Address</span>
                    <asp:TextBox ID="txtAddress" Rows="2" Columns="2" runat="server" MaxLength="200" CssClass="validate"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtAddress" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtAddress" ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>State</span>
                    <asp:DropDownList ID="drpState" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="NameWithCode" DataValueField="StateId" />
                    <asp:RequiredFieldValidator ID="rfvState" runat="server"
                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="drpState" ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>City</span>
                    <asp:DropDownList ID="drpCity" runat="server" AppendDataBoundItems="false" DataTextField="Name" DataValueField="CityId" /><%--onchange="BindLocations();" --%>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="drpCity" ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row" style="display: none;">
                <div class="input-field col s12">
                    <span>Location</span>
                    <asp:DropDownList ID="drpLocation" runat="server" DataTextField="Name" DataValueField="LocationId" />
                    <%--  <%if (!IsPostBack)
                        {%>
                    <asp:RequiredFieldValidator ID="rfvLocation" runat="server"
                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="drpLocation" ValidationGroup="reg" ErrorMessage="Required..!!"> 
                                                            </asp:RequiredFieldValidator>
                    <%}%>--%>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtGeoLocation">Geo Location</label>
                    <asp:TextBox ID="txtGeoLocation" runat="server" CssClass="validate"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col s12">
                    <div class="input-field col s6">
                        <label for="txtlatitude">Latitude</label>
                        <asp:TextBox ID="txtlatitude" runat="server" CssClass="validate"></asp:TextBox>
                    </div>
                    <div class="input-field col s6">
                        <label for="txtlongitude">Longitude</label>
                        <asp:TextBox ID="txtlongitude" runat="server" CssClass="validate"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtTel">Tel No.</label>
                    <asp:TextBox ID="txtTel" runat="server" MaxLength="15" CssClass="validate"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtTel" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtTel"
                        ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtemail">Email</label>
                    <asp:TextBox ID="txtemail" runat="server" MaxLength="100" CssClass="validate"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtemail" ErrorMessage="Required..!!" ValidationGroup="reg">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regtxtEmail" runat="server" ErrorMessage="Invalid Email" Display="Dynamic"
                        ControlToValidate="txtemail" ValidationGroup="reg" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>

                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtMobile">Promoter Mobile No.</label>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="validate" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv7" runat="server" Display="Dynamic"
                        SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtMobile" ValidationGroup="reg" ErrorMessage="Required..!!">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regaxMobile" runat="server" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$"
                        SetFocusOnError="true" Display="Dynamic" ValidationGroup="reg"
                        ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>

                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>About</span>
                    <textarea id="txtATRCDtails" runat="server" maxlength="500"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>Dining Facilities</span>
                    <asp:RadioButtonList ID="rblDining" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Veg" Value="1" />
                        <asp:ListItem Text="Non-Veg" Value="2" />
                        <asp:ListItem Text="Both" Value="3" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div class="col s6">
                        Dining From
                        <asp:TextBox ID="txtDiningFrom" runat="server" CssClass="validate"></asp:TextBox>
                        <script>
                            $('#ContentPlaceHolder1_txtDiningFrom').timepicker(
                                {
                                    icons: {
                                        rightIcon: '<i class="material-icons icon">access_time</i>'
                                    }
                                });
                        </script>
                    </div>
                    <div class="col s6">
                        Dining To
                        <asp:TextBox ID="txtDiningTo" runat="server" CssClass="validate"></asp:TextBox>
                        <script>
                            $('#ContentPlaceHolder1_txtDiningTo').timepicker(
                                {
                                    icons: {
                                        rightIcon: '<i class="material-icons icon">access_time</i>'
                                    }
                                });
                        </script>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>Amenities
                    </span>
                    <asp:CheckBoxList ID="chkAmenities" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="pull-left" DataTextField="Name" DataValueField="AmenityId">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>Highlights
                    </span>
                    <asp:CheckBoxList ID="chkHighlights" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" DataTextField="Name" DataValueField="HighlightId">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span>Cuisines
                    </span>
                    <asp:CheckBoxList ID="chkCuisines" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" DataTextField="Name" DataValueField="CuisineId">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:Image ID="profileImg" Visible="false" runat="server" Height="150px" Width="150px" Style="margin-bottom: 5px;" />
                    <div class="file-field">
                        <div class="btn">
                            <span>ATRC Profile Photo</span>
                            <asp:FileUpload ID="profileImageUpload" runat="server" onchange="document.getElementById('append-small-btn1').value = this.value;ValidateFile(this);" />
                        </div>
                        <div class="file-path-wrapper">
                            <input type="text" id="append-small-btn1" placeholder="no file selected" />
                        </div>
                    </div>
                    <span style="color: Red;" id="sp_profileImageUpload"></span>
                    <%--  <asp:RequiredFieldValidator ID="rfvImage" runat="server" Display="Dynamic"
                        SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="profileImageUpload" ValidationGroup="reg" ErrorMessage="*">
                    </asp:RequiredFieldValidator>--%>
                    <asp:Label ID="lblProfileImage" runat="server" Visible="false" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s6">
                    <%-- <div class="file-field" id="FileUploadContainer">
                        <div class="btn">
                            <span>ATRC Images</span>
                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="document.getElementById('filename').value = this.value;ValidateFile(this);" ClientIDMode="Static" /><br />
                        </div>
                        <div class="file-path-wrapper">
                            <input type="text" id="filename" placeholder="no file selected" />
                        </div>
                        <span style="color: Red;" id="sp_FileUpload1"></span>
                    </div>
                    <input id="Button1" onclick="AddFileUpload()" type="button" value="Add more photo" />--%>

                    <div id="FileUploadContainer" runat="server">
                        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                        <asp:Label ID="lblfilename" runat="server" Visible="false"></asp:Label>

                    </div>
                    <br />
                    <input id="Button1" onclick="AddFileUpload()" type="button" value="Add more file" />


                </div>
                <div class="input-field col s6">
                    <asp:GridView ID="grdATRCImages" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" EmptyDataText="No Photos found"
                        Width="100%" DataKeyNames="ATRCImageId" OnRowDeleting="grdATRCImages_RowDeleting" OnRowCommand="grdATRCImages_RowCommand" OnRowDataBound="grdATRCImages_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Image">
                                <ItemTemplate>
                                    <img src='<%# path.ToString() + "" + Eval("NewImageName") %>' runat="server" style="width: 50px; height: 50px;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Document">
                                <ItemTemplate>
                                    <a href="/Utility/DownloadAttachment.aspx?From=AI&DocName=<%# Eval("NewImageName")%>">
                                        <%#Eval("ImageName")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InsertedOn" HeaderText="Uploaded On" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete"
                                        CommandArgument='<%# Eval("ATRCImageId").ToString() +","+Eval("NewImageName") %>'><img src="images/delete.png" /></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>


            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnRegister" OnClick="btnRegister_Click" runat="server" OnClientClick="javascript:return ValidateRequired();" CausesValidation="true" ValidationGroup="reg" CssClass="waves-effect waves-light btn-large" Text="Submit"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/atrc.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdMode" runat="server" />
    <asp:HiddenField ID="hdLocalityId" runat="server" />

    <asp:HiddenField ID="hdLat" runat="server" />
    <asp:HiddenField ID="hdLng" runat="server" />
    <script type="text/javascript">
        var counter = 1;
        function AddFileUpload() {
            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                '" type="file" /><br />' +
                '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                'value="Remove" onclick = "RemoveFileUpload(this)" />';

            document.getElementById("ContentPlaceHolder1_FileUploadContainer").appendChild(div);
            counter++;
        }

        function RemoveFileUpload(div) {
            document.getElementById("ContentPlaceHolder1_FileUploadContainer").removeChild(div.parentNode);

        }
      <%--  function BindLocations() {
            var ddlLocations = $('#<%=drpLocation.ClientID%>');
            ddlLocations.empty();
            ddlLocations.append(new Option("Select Location", 0));
            var drpCity = $('#<%=drpCity.ClientID%>');
            var cityId = drpCity.val();
            if (cityId != 0) {
                $.ajax({
                    type: "POST",
                    url: "manageatrc.aspx/GetLocationsByCity",
                    data: "{ 'cityId':'" + cityId + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        debugger;
                        var jsdata = JSON.parse(data.d);
                        alert(jsdata);
                        $.each(jsdata, function (key, value) {
                            ddlLocations.append(new Option(value.Name, value.LocationId));
                        });
                    },
                    error: function (data) {
                        alert("error found");
                    }
                });
            }
        }--%>
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
    <%--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDdzuo_Q2vv97O3DJkjxSQl7VwFMsPys-k&libraries=places"></script>
    <script>
        // var d = degrees_to_radians(10.12);
        var input = document.getElementById('<%=txtGeoLocation.ClientID %>');
        var autocomplete = new google.maps.places.Autocomplete(input, { types: ['(cities)'], componentRestrictions: { country: "in" } });
        autocomplete.setFields(["place_id", "geometry"]);

        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            var place = autocomplete.getPlace();

            $("#" + '<%=hdLat.ClientID%>').val(place.geometry.location.lat());// degrees_to_radians(place.geometry.location.lat());
            $("#" + '<%=hdLng.ClientID%>').val(place.geometry.location.lng());// degrees_to_radians(place.geometry.location.lng());
        });

        getLocation();

        function getLocation() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    //
                    $("#" + '<%=hdLat.ClientID%>').val(position.coords.latitude);
                    $("#" + '<%=hdLng.ClientID%>').val(position.coords.longitude);
                });
            } else {
                document.getElementById("Label1").value = "Geolocation is not supported by this browser.";
            }
        }
    </script>--%>
</asp:Content>
