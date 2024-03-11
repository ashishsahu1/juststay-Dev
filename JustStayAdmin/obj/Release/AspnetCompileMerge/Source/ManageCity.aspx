<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" Title="Manage City | JustStay" CodeBehind="ManageCity.aspx.cs" Inherits="JustStayAdmin.ManageCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="cphmain" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdCityId" runat="server" Value="0" />
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
                                                        <label class="login2 pull-right pull-right-pro">City Name:</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtcityname" runat="server" class="form-control" MaxLength="100" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtcityname" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtcityname" ValidationGroup="valcity">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                        <label class="login2 pull-right pull-right-pro">
                                                            Latitude
                                                        </label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                        <asp:TextBox ID="txtlatitude" runat="server" class="form-control" MaxLength="22" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtlatitude" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtlatitude" ValidationGroup="valcity">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Longitude</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:TextBox ID="txtlongitude" runat="server" class="form-control" MaxLength="22" />
                                                        <asp:RequiredFieldValidator ID="rfvtxtlongitude" runat="server"
                                                            Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                            ControlToValidate="txtlongitude" ValidationGroup="valcity">
                                                        </asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                        <label class="login2 pull-right pull-right-pro">Is Active</label>
                                                    </div>
                                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                        <asp:CheckBox ID="chkisactive" runat="server" Checked="true" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group-inner">
                                                <div class="login-btn-inner">
                                                    <div class="row">
                                                        <div class="col-lg-3"></div>
                                                        <div class="col-lg-9">
                                                            <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                                                                    ValidationGroup="valcity" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save"></asp:LinkButton>
                                                                <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/ListCity.aspx">Cancel</asp:LinkButton>
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
</asp:Content>
