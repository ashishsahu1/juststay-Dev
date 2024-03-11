<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="JustStay.ATRC.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <style type="text/css">
        .displaylabel {
            margin-top: 10px;
            display: inline-block;
        }
    </style>
    <asp:HiddenField ID="hdATRCId" runat="server" Value="0" />
    <asp:HiddenField ID="hdLocationId" runat="server" />

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
                                                        <label class="login2 pull-right pull-right-pro">
                                                            ATRC ID
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblATRCId" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">ATRC Name</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblATRCName" runat="server" CssClass="control-label displaylabel"></asp:Label>
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
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label ID="lblCategory" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Promoter(s)/Owner(s) Name
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <asp:Label ID="lblOwnerName" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Postal Address</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblAddress" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">State</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblState" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">City</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblCity" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Location</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblLocation" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Dining Facility</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblDiningFacility" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Dining Timings</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblDiningTimings" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner" id="divRestChairs" runat="server" visible="false">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Number Of rest chairs</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblChairs" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Rest Chair Timings</label>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <asp:Label ID="lblRCTimings" runat="server" CssClass="control-label displaylabel"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Amenities</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="inline-checkbox-cs">
                                                            <label>
                                                                <asp:CheckBox ID="chkParking" runat="server" class="pull-left" Enabled="false" />Parking                                                            
                                                            </label>
                                                            <label>
                                                                <asp:CheckBox ID="chkWifi" runat="server" class="pull-left" Enabled="false" />
                                                                WiFi
                                                            </label>
                                                            <label>
                                                                <asp:CheckBox ID="chkRestaurant" runat="server" class="pull-left" Enabled="false" />
                                                                Restaurant
                                                            </label>
                                                            <label>
                                                                <asp:CheckBox ID="chkCleanBath" runat="server" class="pull-left" Enabled="false" />
                                                                Clean Bathroom
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">About</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div id="divAbout" runat="server" class="control-label displaylabel" />
                                                    </div>
                                                </div>
                                            </div>

                                             <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Profile Image</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:Image ID="profileImg" runat="server" Visible="false" Height="50px" Width="50px" />
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Photos
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:GridView ID="grdATRCImages" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" EmptyDataText="No Photos found"
                                                            Width="100%" data-toggle="table" data-show-columns="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                            DataKeyNames="ATRCImageId" data-cookie-id-table="ATRCImageId" data-click-to-select="true" OnRowCommand="grdATRCImages_RowCommand" OnRowDataBound="grdATRCImages_RowDataBound" OnRowDeleting="grdATRCImages_RowDeleting">
                                                            <Columns>
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
                                                                            CommandArgument='<%# Eval("ATRCImageId").ToString() +","+Eval("NewImageName") %>'><img src="img/delete.png" /></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Upload Photographs</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                            <div class="input append-big-btn">
                                                                <div id="FileUploadContainer" runat="server">
                                                                     <asp:FileUpload ID="FileUpload1" runat="server" onchange="ValidateFile(this);" ClientIDMode="Static" /><br />
                                                                    <span style="color: Red;" id="sp_FileUpload1"></span>
                                                                </div>
                                                                <br />
                                                                <br />
                                                                 <input id="Button1" onclick="AddFileUpload()" type="button" value="Add more photo" />
                                                            </div>
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
                                                                 <asp:LinkButton ID="btnSave" runat="server" OnClientClick="javascript:return ValidateRequired();" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="reg" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ATRC.aspx">Cancel</asp:LinkButton>
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
    <script type="text/javascript">
        var counter = 0;
        var allValidImages = true;

        function AddFileUpload() {

            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                         '" type="file" onchange="ValidateFile(this);"/><span style="color:Red;" id="sp_file' + counter + '"></span>' +
                         '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                         'value="Remove" onclick = "RemoveFileUpload(this)" />';
            
            document.getElementById("main_FileUploadContainer").appendChild(div);
            counter++;
        }
        function RemoveFileUpload(div) {
            document.getElementById("main_FileUploadContainer").removeChild(div.parentNode);
        }


        function ValidateFile(value) {
            debugger;
            var file = getNameFromPath($(value).val());
            if (file != null) {
                var extension = file.substr((file.lastIndexOf('.') + 1));
                switch (extension) {
                    case 'jpg':
                    case 'JPG':
                    case 'jpeg':
                    case 'JPEG':
                    case 'png':
                    case 'PNG':
                    case 'bmp':
                    case 'BMP':
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
            
            var spans = $("[id*='sp_']");
         
                for (var i = 0; i < spans.length; i++) {
                    if ($("#" + spans[i].id).text() != '') {
                        Booleandata = false;
                    }
                
            }
            return Booleandata;
        }
    </script>
</asp:Content>
