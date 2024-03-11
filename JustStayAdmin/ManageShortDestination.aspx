<%@ Page Language="C#" AutoEventWireup="true" Title="Manage Shrot Destination | Just Stay" MasterPageFile="~/Site1.Master" CodeBehind="ManageShortDestination.aspx.cs" Inherits="JustStayAdmin.ManageShortDestination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="imgid" runat="server" Value="0" />
    <div class="single-pro-review-area mt-t-30 mg-b-15">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="basic-login-form-ad">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="all-form-element-inner">
                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <label class="login2 pull-right pull-right-pro">Select ATRC: </label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <div class="form-select-list">
                                                <asp:DropDownList ID="drpatrc" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="ATRCName" DataValueField="ATRCId">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-9">
                                            <asp:LinkButton ID="btnSearch" runat="server" CausesValidation="true" OnClick="btnSearch_Click"
                                                CssClass="btn btn-sm btn-primary login-submit-cs" Text="Go"></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="data-table-area mg-b-15">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="sparkline13-list">
                                    <div class="sparkline13-hd">
                                        <div class="main-sparkline13-hd">
                                            <h1>ATRC Images List</h1>
                                        </div>
                                    </div>
                                    <div class="table-responsive">
                                        <asp:GridView ID="grdATRCImages" runat="server" AutoGenerateColumns="false" 
                                            CssClass="table table-hover table-striped table-bordered" EmptyDataText="No Photos found" OnRowCommand="grdATRCImages_RowCommand"
                                            Width="100%"  
                                            DataKeyNames="ATRCImageId">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Document">
                                                    <ItemTemplate>
                                                        <a href="/Utility/DownloadAttachment.aspx?From=AI&DocName=<%# Eval("NewImageName")%>">
                                                            <%#Eval("ImageName")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:ImageField DataImageUrlField="NewImageName" ControlStyle-Height="100px" ControlStyle-Width="100px" DataImageUrlFormatString="http://atrc.juststay.in/ATRCImages/{0}" />
                                                <asp:BoundField DataField="IsSD" HeaderText="Is Set" />
                                                <asp:TemplateField HeaderText="Set to Short Destination">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkAdd" runat="server" ToolTip="Set to Short Destination" ForeColor="Blue" CommandName="Add" Text="Set"
                                                            CommandArgument='<%# Eval("ATRCImageId").ToString() %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModalSD" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                    &times;</button>
                <h4 class="modal-title">
                    Add Image Details</h4>
            </div>
            <div class="modal-body">
                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                    <div class="form-group">
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="20"
                            placeholder="Enter Name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lbldes" runat="server" Text="Description"></asp:Label>
                        <asp:TextBox ID="txtdec" runat="server" CssClass="form-control" MaxLength="100"
                            placeholder="Enter Dec"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblset" runat="server" Text="Is Set"></asp:Label>
                        <asp:CheckBox ID="chkset" runat="server" Checked="true"  />
                    </div>
                </div>
            </div>
            <div class="modal-footer" style="border-top:none;">
                <asp:Button ID="btnsaveSD" runat="server" Text="Save" OnClick="btnsaveSD_Click" CssClass="btn btn-primary" />
                <button type="button" class="btn btn-primary" data-dismiss="modal">
                    Close</button>
            </div>
        </div>
    </div>
</div>

    <script type='text/javascript'>
    function openModal() {
        $('[id*=myModalSD]').modal('show');
    }   
</script>
</asp:Content>
