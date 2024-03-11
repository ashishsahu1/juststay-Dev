<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageRestChair.aspx.cs" Inherits="JustStayAdmin.ManageRestChair" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdRCId" runat="server" Value="0" />
    <asp:HiddenField ID="hdProfileId" runat="server" Value="0" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/js/data-table/bootstrap-table.js" />
            <asp:ScriptReference Path="~/js/data-table/data-table-active.js" />
        </Scripts>
    </asp:ScriptManager>

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
                                                        <label for="lblatrc" class="login2 pull-right pull-right-pro">ATRC</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:DropDownList ID="ddlatrc" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">RestChair Name</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtName" runat="server" class="form-control" MaxLength="100" placeholder="RestChair Name" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtName" ValidationGroup="valRC">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">RestChair Type</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="form-select-list">
                                                            <asp:DropDownList ID="drpTypes" class="form-control custom-select-value" runat="server" DataTextField="Name" DataValueField="TypeId" />
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
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Chair Description
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <textarea id="txtDetails" class="form-control" runat="server"></textarea>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Price
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">No. Of RestChair</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <div class="touchspin-inner">
                                                            <asp:TextBox ID="txtCount" runat="server" class="touchspin_hours" Text="0" />
                                                            <asp:RequiredFieldValidator ID="rfvCount" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                ControlToValidate="txtCount" ValidationGroup="valRC">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Chairs                                                       
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdChairs" runat="server" ShowFooter="true"
                                                                    AutoGenerateColumns="false" class="table table-hover table-striped table-bordered"
                                                                    CellSpacing="0" Width="100%" EmptyDataText="No" ShowHeaderWhenEmpty="true"
                                                                    OnRowCommand="grdChairs_RowCommand" OnRowDeleting="grdChairs_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Chair Number">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtChairNumber" class="form-control" runat="server" Text='<%#Eval("ChairNumber") %>' ValidationGroup="valchair" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvChairNumber" ValidationGroup="valchair" runat="server" ForeColor="Red"
                                                                                    ControlToValidate="txtChairNumber" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true" />
                                                                                <asp:HiddenField ID="hdChairId" runat="server" Value='<%#Eval("ChairId") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdChairChanges" runat="server" Value='<%# Eval("ChairSaved") %>' />
                                                                                <asp:LinkButton Text="Save" ValidationGroup="valchair" CausesValidation="true" runat="server" CommandName="AddNew" OnClientClick="javascript:MarkChairAsChanged(this);" />
                                                                                <asp:Image runat="server" Visible='<%# Eval("ChairSaved") %>' ImageUrl="img/correct.png" />
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:LinkButton runat="server" Text="Add" CommandName="New" />
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:CommandField ShowDeleteButton="True" ButtonType="Image" HeaderStyle-Width="5%" DeleteImageUrl="img/delete.png" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <asp:LinkButton runat="server" Text="Add" CommandName="New" />
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                                <asp:Label ID="lblRechedChairCount" runat="server" Text="You reached Number of chairs" ForeColor="Red" Visible="false" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

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
                                                        <asp:UpdatePanel ID="upaddDepartment" runat="server" RenderMode="Inline">
                                                            <ContentTemplate>

                                                                <asp:GridView ID="grdATRCImages" runat="server" AutoGenerateColumns="false" class="table table-striped" CssClass="gvv" EmptyDataText="No Photos found"
                                                                    Width="100%" data-toggle="table" data-show-columns="true" data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                                                                    DataKeyNames="AttachmentId" data-cookie-id-table="AttachmentId" data-click-to-select="true" OnRowCommand="grdATRCImages_RowCommand" OnRowDataBound="grdATRCImages_RowDataBound" OnRowDeleting="grdATRCImages_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Document">
                                                                            <ItemTemplate>
                                                                                <a href="/Utility/DownloadAttachment.aspx?From=AI&DocName=<%# Eval("DocNewName")%>">
                                                                                    <%#Eval("DocName")%></a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete"
                                                                                    CommandArgument='<%# Eval("AttachmentId").ToString() +","+Eval("DocNewName") %>'><img src="img/delete.png" /></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="ValidateImageFile(this);" ClientIDMode="Static" /><br />
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

    <script type="text/javascript">

        var counter = 0;
        var allValidImages = true;

        function AddFileUpload() {

            var div = document.createElement('DIV');
            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                '" type="file" onchange="ValidateImageFile(this);"/><span style="color:Red;" id="sp_file' + counter + '"></span>' +
                '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                'value="Remove" onclick = "RemoveFileUpload(this)" />';

            document.getElementById("main_FileUploadContainer").appendChild(div);
            counter++;
        }
        function RemoveFileUpload(div) {
            document.getElementById("main_FileUploadContainer").removeChild(div.parentNode);
        }


        function AddChairs() {
            var count = $("#txtCount").val();
            var i = 0;
            for (i = 0; i < count; i++) {

                var div = document.createElement('DIV');

                div.innerHTML = '<input id="txt' + i + '" name = "txt' + i +
                    '" type="text" class="form-control"/><span style="color:Red;" id="sp_txt' + i + '"></span>' +
                    '<input id="btn' + i + '" type="button" style="width:100px;" ' +
                    'value="Remove" onclick = "RemoveFileUpload(this)" />';

                document.getElementById("main_divChairs").appendChild(div);
            }
        }

        function MarkChairAsChanged(obj) {
            ($(obj).parent().parent().find("td:eq(1)").children()).val('true');
        }


        function ValidateRequired() {
            debugger;
            var Booleandata = true;
            if (Page_ClientValidate("valRC")) {
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


</asp:Content>
