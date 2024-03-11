<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageaminity.aspx.cs" Inherits="JustStayAdmin.Admin.manageaminity" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageuser" runat="server">
    <asp:HiddenField ID="hdAmentityId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="aminitylist.aspx">Amenity List</a>
                </li>
                <li class="active-bre">Manage Amenity
                </li>
                <li class="page-back">
                    <a href="aminitylist.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Amenity</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblaminitymsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="drpCategories" runat="server">
                        <asp:ListItem Text="ATRC" Value="1" />
                        <asp:ListItem Text="Rest Room" Value="2" />
                        <asp:ListItem Text="Rest Chair" Value="3" />
                    </asp:DropDownList>
                    <label for="drpCategories">Select Category</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtname" runat="server" class="validate" MaxLength="50" />
                    <label for="txtname">Amenity Name</label>
                    <asp:RequiredFieldValidator ID="rfvname" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtname" ValidationGroup="valamentity">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div class="file-field">
                        <div class="btn">
                            <span>File</span>
                            <asp:FileUpload ID="amImageUpload" runat="server" onchange="document.getElementById('append-small-btn1').value = this.value;ValidateIcon(this);" ClientIDMode="Static" />

                        </div>
                        <div class="file-path-wrapper">
                            <input class="file-path validate" type="text" id="append-small-btn1" placeholder="Upload Amenity Icon" />
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
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true" OnClientClick="return ValidateAmeninty();"
                        ValidationGroup="valamentity" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/aminitylist.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
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
        function ValidateIcon(value) {
            debugger;

            var fileUpload = $("#amImageUpload")[0];
            var spError = $("#sp_amImageUpload");

            var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(.png)$");
            if (regex.test(fileUpload.value.toLowerCase())) {

                if (typeof (fileUpload.files) != "undefined") {

                    var imgFile = fileUpload.files[0]

                    if (imgFile.size <= 4000) {
                        var reader = new FileReader();
                        reader.readAsDataURL(imgFile);
                        reader.onload = function (e) {
                            var image = new Image();
                            image.src = e.target.result;
                            image.onload = function () {
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

