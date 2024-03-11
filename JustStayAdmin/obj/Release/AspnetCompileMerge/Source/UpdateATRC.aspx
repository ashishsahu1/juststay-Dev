<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="Admin | UpdateATRC - Just Stay" CodeBehind="UpdateATRC.aspx.cs" Inherits="JustStayAdmin.UpdateATRC" EnableEventValidation="false" %>

<%@ Register Src="~/Controls/ATRCHeader.ascx" TagPrefix="uc1" TagName="ATRCHeader" %>


<asp:Content ContentPlaceHolderID="head" runat="server" ID="cphhead"></asp:Content>
<asp:Content ContentPlaceHolderID="main" runat="server" ID="cphmain">
    
    <uc1:ATRCHeader runat="server" ID="ATRCHeader" />

    <link href="css/code-editor/codemirror.css" rel="stylesheet" />
    <link href="css/form/all-type-forms.css" rel="stylesheet" />
    <asp:HiddenField ID="hdATRCId" runat="server" />
    <asp:HiddenField ID="hdRCProfileId" runat="server" Value="0" />
    <asp:HiddenField ID="hdLocationId" runat="server" />
    <asp:HiddenField ID="hdRestChairId" runat="server" />
    <asp:HiddenField ID="hdLat" runat="server" />
    <asp:HiddenField ID="hdLng" runat="server" />

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
                                                   <%-- <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9" style="float: right;">
                                                        <asp:LinkButton ID="lnkCreateRCProfile" runat="server" class="btn btn-sm btn-primary login-submit-cs" OnClick="lnkCreateRCProfile_Click" Text="Create Rest Chair Profile" />
                                                    </div>--%>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Restaurant Name</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtRestName" runat="server" class="form-control" MaxLength="50" />
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtRestName" ValidationGroup="reg">
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
                                                            <asp:CheckBoxList ID="chkCategory" runat="server" RepeatDirection="Horizontal" CssClass="pull-left" DataTextField="Category" DataValueField="ATRCCategoryId">
                                                            </asp:CheckBoxList>
                                                            <asp:CustomValidator runat="server" ID="cvmCategorylist"
                                                                ClientValidationFunction="ValidateCategories" SetFocusOnError="true"
                                                                ForeColor="Red" Display="Dynamic" ValidationGroup="reg"></asp:CustomValidator>
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
                                                            ControlToValidate="txtOwnerName" ValidationGroup="reg">
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
                                                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="200" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv4" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtAddress" ValidationGroup="reg">
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
                                                                ControlToValidate="drpState" ValidationGroup="reg">
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
                                                                ControlToValidate="drpCity" ValidationGroup="reg">
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
                                                            <asp:DropDownList ID="drpLocation" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="Name" DataValueField="LocationId" onChange="SetLocation();" />
                                                            <asp:RequiredFieldValidator ID="rfvLocation" runat="server"
                                                                Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="drpLocation" ValidationGroup="reg">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Geographic Location</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:TextBox ID="txtGeoLoc" runat="server" ClientIDMode="Static" CssClass="form-control" placeholder="Geo Location"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="drpLocation" ValidationGroup="reg">
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
                                                            ValidationGroup="reg">
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
                                                            ControlToValidate="txtemail" ValidationGroup="reg">
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
                                                            ControlToValidate="txtMobile" ValidationGroup="reg">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="regaxMobile" runat="server" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$"
                                                            SetFocusOnError="true" Display="Dynamic" ValidationGroup="reg"
                                                            ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            From where you got to know about us
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                        <div class="inline-checkbox-cs">
                                                            <asp:CheckBoxList ID="chkReferral" runat="server">
                                                                <asp:ListItem Text="By referral" Value="1" />
                                                                <asp:ListItem Text="Social Media" Value="2" />
                                                                <asp:ListItem Text="Website" Value="3" />
                                                                <asp:ListItem Text="Google Search" Value="4" />
                                                            </asp:CheckBoxList>
                                                            <asp:CustomValidator runat="server" ID="CustomValidator1"
                                                                ClientValidationFunction="ValidateReferrals" SetFocusOnError="true"
                                                                ForeColor="Red" Display="Dynamic" ValidationGroup="reg"></asp:CustomValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Amenities
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                        <div class="inline-checkbox-cs">
                                                            <asp:CheckBoxList ID="chkAmenities" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="pull-left" DataTextField="Name" DataValueField="AmenityId">
                                                            </asp:CheckBoxList>
                                                        </div>
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
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Dining Timings
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                                        From
                                                        <asp:TextBox ID="txtDiningFrom" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                                        To
                                                        <asp:TextBox ID="txtDiningTo" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <%--<div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Number Of Rest Chairs
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtNumberOfchair" runat="server" CssClass="form-control" MaxLength="5" placeholder="Number Of Rest Chairs"></asp:TextBox>
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

                                                    </div>
                                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                                        To
                                                        <asp:TextBox ID="txtToTime" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>--%>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Highlights
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                        <div class="inline-checkbox-cs">
                                                            <asp:CheckBoxList ID="chkHighlights" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="pull-left" DataTextField="Name" DataValueField="HighlightId">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Cuisines
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                        <div class="inline-checkbox-cs">
                                                            <asp:CheckBoxList ID="chkCuisines" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" CssClass="pull-left" DataTextField="Name" DataValueField="CuisineId">
                                                            </asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            About
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <div class="code-editor-single shadow-reset">
                                                            <textarea id="txtATRCDtails" runat="server"></textarea>
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
                                                        <asp:Image ID="profileImg" Visible="false" runat="server" Height="150px" Width="150px" Style="margin-bottom: 5px;" />
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

                                                        <asp:Label ID="lblProfileImage" runat="server" Visible="false" />
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
    <script src="js/vendor/jquery-1.12.4.min.js"></script>
    <!-- code editor JS
		============================================ -->
    <script src="js/code-editor/codemirror.js"></script>
    <script src="js/code-editor/code-editor.js"></script>
    <script src="js/code-editor/code-editor-active.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#main_txtToTime").timepicker({
                scrollbar: true
            });

            $("#main_txtFromTime").timepicker({
                scrollbar: true
            });

            $("#main_txtDiningFrom").timepicker({
                scrollbar: true,
                startTime: '10:00'
            });

            $("#main_txtDiningTo").timepicker({
                scrollbar: true,
                startTime: '23:00'
            });


        });

        var counter = 0;
        var allValidImages = true;

        function AddFileUpload() {

            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                         '" type="file" onchange="ValidateFile(this);"/><span style="color:Red;" id="sp_file' + counter + '"></span>' +
                         '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                         'value="Remove" onclick = "RemoveFileUpload(this)" />';
           // alert(div.innerHTML);
            document.getElementById("main_FileUploadContainer").appendChild(div);
            counter++;
        }
        function RemoveFileUpload(div) {
            document.getElementById("main_FileUploadContainer").removeChild(div.parentNode);
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
                    url: "UpdateATRC.aspx/GetLocationsByCity",
                    data: "{ 'cityId':'" + cityId + "'}",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        debugger;
                        var jsdata = JSON.parse(data.d);
                        $.each(jsdata, function (key, value) {
                            ddlLocations.append(new Option(value.Name, value.LocationId));
                        });

                        ddlLocations.val($('#<%=hdLocationId.ClientID%>').val());
                    },
                    error: function (data) {
                        alert("error found");
                    }
                });
            }
        }

        function SetLocation() {
            var dlLocation = $('#<%=drpLocation.ClientID%>');
            $('#<%=hdLocationId.ClientID%>').val(dlLocation.val());
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
        function ValidateReferrals(source, args) {
            debugger;
            var chkListModules = document.getElementById('<%= chkReferral.ClientID %>');
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
                    case 'JPG':
                    case 'jpeg':
                    case 'JPEG':
                    case 'png':
                    case 'PNG':
                    case 'bmp':
                    case 'BMP':
                    case 'gif':
                    case 'GIF':
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
                debugger;
                for (var i = 0; i < spans.length; i++) {
                    if ($("#" + spans[i].id).text() != '') {
                        Booleandata = false;
                    }
                }
            }
            return Booleandata;
        }
    </script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAFh08Wj9TUCJ5fRtlN_4UvkJahbLDSNfM&libraries=places"></script>
    <script>
        // var d = degrees_to_radians(10.12);
        var input = document.getElementById('<%=txtGeoLoc.ClientID %>');
          var autocomplete = new google.maps.places.Autocomplete(input, { types: ['(cities)'], componentRestrictions: { country: "in" } });
        autocomplete.setFields(["place_id", "geometry"]);
        
        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            debugger;
            var place = autocomplete.getPlace();

            $("#" + '<%=hdLat.ClientID%>').val(place.geometry.location.lat());// degrees_to_radians(place.geometry.location.lat());
            $("#" + '<%=hdLng.ClientID%>').val(place.geometry.location.lng());// degrees_to_radians(place.geometry.location.lng());
        });

    </script>


</asp:Content>
