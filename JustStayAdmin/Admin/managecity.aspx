<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="managecity.aspx.cs" Inherits="JustStayAdmin.Admin.managecity" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanageuser" runat="server">
    <asp:HiddenField ID="hdCityId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="citylist.aspx">City List</a>
                </li>
                <li class="active-bre">Manage City
                </li>
                <li class="page-back">
                    <a href="citylist.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage City</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblcitymsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtcityname" runat="server" class="validate" MaxLength="100" />
                    <label for="txtname">Name</label>
                    <asp:RequiredFieldValidator ID="rfvtxtcityname" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtcityname" ValidationGroup="valcity">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtlatitude" runat="server" class="form-control" MaxLength="22" />
                    <label for="txtlatitude">Latitude</label>
                    <asp:RequiredFieldValidator ID="rfvtxtlatitude" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtlatitude" ValidationGroup="valcity">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtlongitude" runat="server" class="validate" MaxLength="22" />
                    <label for="txtlongitude">Longitude</label>
                    <asp:RequiredFieldValidator ID="rfvtxtlongitude" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtlongitude" ValidationGroup="valcity">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:CheckBox ID="chkisactive" runat="server" Text="Is Active?" ClientIDMode="Static" CssClass="filled-in" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valcity" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                    <asp:LinkButton ID="lnkClose" runat="server" class="waves-effect waves-light btn-large" PostBackUrl="~/Admin/citylist.aspx">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
