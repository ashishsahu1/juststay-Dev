<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managerestchair.aspx.cs" Inherits="JustStayAdmin.Admin.managerestchair" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanagerestchair" runat="server">

    <asp:HiddenField ID="hdATRCRCId" runat="server" Value="0" />
    <asp:HiddenField ID="hdRCProfileId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="restchairprofiles.aspx">Rest Chair Profiles</a>
                </li>
                <li class="active-bre"><a href="managerestchair.aspx">Manage Rest Chair</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>AddNew Rest Chairs</h2>

            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="ddlatrc" runat="server" CssClass="validate">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtName">
                        Rest Chair Name
                    </label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="validate" MaxLength="100" placeholder="RestChair Name" />
                    <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtName" ValidationGroup="valRC">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="drpTypes" class="validate" runat="server" DataTextField="Name" DataValueField="TypeId" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="chkAmenities">
                        Amenities
                    </label>
                    <asp:CheckBoxList ID="chkAmenities" runat="server" DataTextField="Name" DataValueField="AmenityId">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtDetails">
                        Description
                    </label>
                    <textarea id="txtDetails" class="validate" runat="server"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtPrice">Price</label>
                    <asp:TextBox ID="txtPrice" class="validate" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <label for="txtCount">
                        No. Of RestChair
                    </label>
                    <asp:TextBox ID="txtCount" runat="server" class="validate" Text="0" />
                    <asp:RequiredFieldValidator ID="rfvCount" runat="server" Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtCount" ValidationGroup="valRC">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s8">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                        <ContentTemplate>
                            <asp:GridView ID="grdChairs" runat="server" ShowFooter="true"
                                AutoGenerateColumns="false" class="table-bordered"
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
                                            <asp:Image runat="server" Visible='<%# Eval("ChairSaved") %>' ImageUrl="~/Admin/images/correct.png" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton runat="server" Text="Add Chair" CommandName="New" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Image" HeaderStyle-Width="5%" HeaderText="Delete" DeleteImageUrl="~/Admin/images/delete.png" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:LinkButton runat="server" Text="Add Chair" CommandName="New" />
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Label ID="lblRechedChairCount" runat="server" Text="You reached Number of chairs" ForeColor="Red" Visible="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:UpdatePanel ID="upaddDepartment" runat="server" RenderMode="Inline">
                        <ContentTemplate>
                            <asp:GridView ID="grdATRCImages" runat="server" AutoGenerateColumns="false" class="table-bordered" EmptyDataText="No Photos found"
                                Width="100%" DataKeyNames="AttachmentId" OnRowCommand="grdATRCImages_RowCommand" OnRowDataBound="grdATRCImages_RowDataBound" OnRowDeleting="grdATRCImages_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <a href="/Utility/DownloadAttachment.aspx?From=AI&DocName=<%# Eval("DocNewName")%>">
                                                <%#Eval("DocName")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkReject" runat="server" ToolTip="Delete" ForeColor="Blue" CommandName="Delete"
                                                CommandArgument='<%# Eval("AttachmentId").ToString() +","+Eval("DocNewName") %>'><img src="images/delete.png" /></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <div class="input append-big-btn">
                        <div id="FileUploadContainer" runat="server">
                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="ValidateImageFile(this);" ClientIDMode="Static" />
                            <br />
                            <span style="color: Red;" id="sp_FileUpload1"></span>
                        </div>
                        <br />
                        <br />
                        <input id="Button1" onclick="AddFileUpload()" type="button" value="Add more photo" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClientClick="javascript:return ValidateRequired();" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="reg" CssClass="btn btn-white" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" OnClick="lnkClose_Click">Cancel</asp:LinkButton>
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
                '" type="file" onchange="ValidateImageFile(this);"/><span style="color:Red;" id="sp_file' + counter + '"></span>' +
                '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                'value="Remove" onclick="RemoveFileUpload(this)" />';

            document.getElementById("ContentPlaceHolder1_FileUploadContainer").appendChild(div);
            counter++;
        }
        function RemoveFileUpload(div) {
            document.getElementById("ContentPlaceHolder1_FileUploadContainer").removeChild(div.parentNode);
        }


        function AddChairs() {
            var count = $("#txtCount").val();
            var i = 0;
            for (i = 0; i < count; i++) {

                var div = document.createElement('DIV');

                div.innerHTML = '<input id="txt' + i + '" name = "txt' + i +
                    '" type="text" class="form-control"/><span style="color:Red;" id="sp_txt' + i + '"></span>' +
                    '<input id="btn' + i + '" type="button" style="width:100px;" ' +
                    'value="Remove" onclick="RemoveFileUpload(this)" />';

                document.getElementById("ContentPlaceHolder1_divChairs").appendChild(div);
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
        function ValidateImageFile(value) {
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
    </script>
</asp:Content>
