<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageroomlabel.aspx.cs" Inherits="JustStayAdmin.Admin.manageroomlabel" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageect" runat="server">
    <asp:HiddenField ID="hdRoomLabelId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="roomlabel.aspx">Room Label</a>
                </li>
                <li class="active-bre">Manage Room Label
                </li>
                <li class="page-back">
                    <a href="roomlabel.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Room Label</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblroomlabelmsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtname">
                        Room Label
                    </label>
                    <asp:TextBox ID="txtname" runat="server" CssClass="validate" MaxLength="100" />
                    <asp:RequiredFieldValidator ID="rfvname" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtname" ValidationGroup="valroomlabel">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div class="file-field">
                        <div class="btn">
                            <span>File</span>
                            <asp:FileUpload ID="rlImageUpload" runat="server" onchange="document.getElementById('append-small-btn1').value = this.value;ValidateIcon(this);" ClientIDMode="Static" />

                        </div>
                        <div class="file-path-wrapper">
                            <input type="text" id="append-small-btn1" placeholder="no file selected" />
                        </div>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvImage" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="rlImageUpload" ValidationGroup="valamentity" ErrorMessage="Icon Required!">
                    </asp:RequiredFieldValidator>
                    <br />
                    <span style="color: Red;" id="sp_rlImageUpload"></span>
                    <br />
                    <asp:Label ID="lblImageName" runat="server"></asp:Label>
                    <asp:Label ID="lblfilename" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true" OnClientClick="return ValidateRoomLabel();"
                        ValidationGroup="valroomlabel" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/roomlabel.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function ValidateRoomLabel() {
            var isVald = true;
            if (Page_ClientValidate("valroomlabel")) {
                if ($("#sp_rlImageUpload").text() != '') {
                    isVald = false;
                }
            }

            return isVald;
        }

        function ValidateIcon(value) {//Get reference of FileUpload.
            debugger;

            var fileUpload = $("#rlImageUpload")[0];
            var spError = $("#sp_rlImageUpload");
           
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
