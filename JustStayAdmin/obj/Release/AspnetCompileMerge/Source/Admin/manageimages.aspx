<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="manageimages.aspx.cs" Inherits="JustStayAdmin.Admin.manageimages" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphimageslist">
    <asp:HiddenField ID="imgid" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="manageimages.aspx">ATRC Images</a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-3">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-inn-sp">
                        <div class="inn-title">
                            <h4>All ATRC Images</h4>
                            <div style="padding-top: 20px; padding-bottom: 20px;">
                                <asp:Label ID="lblatrcimagesmsg" runat="server"></asp:Label>
                            </div>
                            <div class="input-field">
                                <asp:DropDownList ID="drpatrc" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="ATRCName" DataValueField="ATRCId">
                                </asp:DropDownList>

                                <asp:LinkButton ID="btnSearch" runat="server" CausesValidation="true" OnClick="btnSearch_Click"
                                    CssClass="waves-effect waves-light btn-large waves-input-wrapper" Text="Go"></asp:LinkButton>

                            </div>
                        </div>
                        <div class="tab-inn">
                            <div class="table-responsive table-desi">
                                <asp:GridView ID="grdATRCImages" runat="server" AutoGenerateColumns="false"
                                    CssClass="table table-hover" EmptyDataText="No Photos found" OnRowCommand="grdATRCImages_RowCommand"
                                    Width="100%"
                                    DataKeyNames="ATRCImageId">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Document">
                                            <ItemTemplate>
                                                <a href="../Utility/DownloadAttachment.aspx?From=AI&DocName=<%# Eval("NewImageName")%>">
                                                    <%#Eval("ImageName")%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <img src='<%# path.ToString() + "" + Eval("NewImageName") %>' runat="server" style="width: 50px; height: 50px;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IsSD" HeaderText="Is Set" />
                                        <asp:TemplateField HeaderText="Set to Short Destination">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkAdd" runat="server" ToolTip="Set to Short Destination" ForeColor="Blue" CommandName="Add" Text="Set"
                                                    CommandArgument='<%# Eval("ATRCImageId").ToString() %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkisprofile" runat="server" Text="Is Profile?"  Checked='<%# Eval("IsProfile") %>' CssClass="filled-in"  /> 
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
    <div class="modal fade" id="myModalSD" role="dialog" tabindex="-1"
        aria-labelledby="sdmodelheader" aria-hidden="true">
        <div class="modal-header">
            <h4 class="modal-title" id="sdmodelheader">Manage SD and Profile Images
            </h4>
        </div>
        <div class="modal-body">

            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="input-field" MaxLength="20"
                placeholder="Enter Name"></asp:TextBox>
            <br />

            <asp:Label ID="lbldes" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtdec" runat="server" CssClass="input-field" MaxLength="100"
                placeholder="Enter Dec"></asp:TextBox>
            <br />

            <asp:CheckBox ID="chkset" runat="server" Checked="true" Text="Is Set?" CssClass="filled-in" ClientIDMode="Static" />


        </div>
        <div class="modal-footer" style="border-top: none;">
            <a href="manageimages.aspx" class="waves-effect waves-light btn-large">Close</a>
            <asp:Button ID="btnsaveSD" runat="server" Text="Save" OnClick="btnsaveSD_Click" CssClass="waves-effect waves-light btn-large" />
        </div>
    </div>

    <script>
        function openModal() {
            $('.modal').modal();
            $('#myModalSD').modal('open');
            $('.trigger-modal').modal();
        }
    </script>
</asp:Content>

