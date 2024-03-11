<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageAmenity.aspx.cs" Inherits="JustStayAdmin.ManageAmenity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <link href="css/form/all-type-forms.css" rel="stylesheet" />
    <asp:HiddenField ID="hdAmentityId" runat="server" Value="0" />
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
                                                        <label class="login2 pull-right pull-right-pro">Amenity Category:</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpCategories" class="form-control custom-select-value" runat="server">
                                                                <asp:ListItem Text="ATRC" Value="1" />
                                                                <asp:ListItem Text="Rest Room" Value="2" />
                                                                <asp:ListItem Text="Rest Chair" Value="3" />
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Amenity Name:</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtname" runat="server" class="form-control" MaxLength="100" />
                                                        <asp:RequiredFieldValidator ID="rfvname" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtname" ValidationGroup="valamentity">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Amenity Icon</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                            <div class="input append-small-btn">
                                                                <div class="file-button">
                                                                    Browse
                                                                            <asp:FileUpload ID="amImageUpload" runat="server" onchange="document.getElementById('append-small-btn1').value = this.value;ValidateIcon(this);" ClientIDMode="Static" />
                                                                </div>
                                                                <input type="text" id="append-small-btn1" placeholder="no file selected" />
                                                            </div>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="rfvImage" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="amImageUpload" ValidationGroup="valamentity" ErrorMessage="Icon Required!">
                                                        </asp:RequiredFieldValidator>
                                                        <br />
                                                        <span style="color: Red;" id="sp_amImageUpload"></span>
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
                                                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true" OnClientClick="return ValidateAmeninty();"
                                                                    ValidationGroup="valamentity" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ListAmenities.aspx">Cancel</asp:LinkButton>
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

        function ValidateAmeninty() {
            var isVald = true;
            if (Page_ClientValidate("valamentity")) {
                if ($("#sp_amImageUpload").text() != '') {
                    isVald = false;
                }
            }

            return isVald;
        }

        function ValidateIcon(value) {//Get reference of FileUpload.
            debugger;

            var fileUpload = $("#amImageUpload")[0];
            var spError = $("#sp_amImageUpload");
           
            var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(.png)$");
            if (regex.test(fileUpload.value.toLowerCase())) {  //Check whether the file is valid Image.
                
                if (typeof (fileUpload.files) != "undefined") { //Check whether HTML5 is supported.

                    var imgFile = fileUpload.files[0]                   

                    if (imgFile.size <= 4000) {  //check for size

                        //Initiate the FileReader object.
                        var reader = new FileReader();
                        //Read the contents of Image File.
                        reader.readAsDataURL(imgFile);
                        reader.onload = function (e) {
                            //Initiate the JavaScript Image object.
                            var image = new Image();
                            //Set the Base64 string return from FileReader as source.
                            image.src = e.target.result;
                            image.onload = function () {
                                //Determine the Height and Width.
                                var height = this.height;
                                var width = this.width;
                                if (height != 35 || width != 35) {
                                    $(spError).text("Height and Width must be 35px.");
                                    $("#" + value.id).val('');
                                    return false;
                                }
                                else {
                                    $(spError).text("");
                                    return true;
                                }
                            };
                        }
                    }
                    else {
                        $(spError).text("Please select image size less than 4 KB");
                        $("#" + value.id).val('');
                        return false;
                    }
                } else {
                    $(spError).text("This browser does not support HTML5.");
                    $("#" + value.id).val('');
                    return false;
                }
            } else {
                $(spError).text("Please select .png Image file.");
                $("#" + value.id).val('');
                return false;
            }
        }
    </script>
</asp:Content>

<%--https://www.aspsnippets.com/Articles/Validate-Check-dimensions-Height-and-Width-of-Image-before-Upload-using-HTML5-JavaScript-and-jQuery.aspx--%>