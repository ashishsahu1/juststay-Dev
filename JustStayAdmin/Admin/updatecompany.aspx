<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="updatecompany.aspx.cs" Inherits="JustStayAdmin.Admin.updatecompany" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphmanagecompany" runat="server">
    <asp:HiddenField ID="hdcompanyId" runat="server" Value="0" />
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre">Manage Company
                </li>
                <li class="page-back">
                    <a href="dashboard.aspx">
                        <i class="fa fa-backward" aria-hidden="true"></i>Back
                    </a>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>Manage Company Details</h2>
            <div style="padding-top: 20px; padding-bottom: 20px;">
                <asp:Label ID="lblcompanymsg" runat="server"></asp:Label>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtcompanyname" runat="server" class="validate" MaxLength="150" />
                    <label for="txtcompanyname">Company Name</label>
                    <asp:RequiredFieldValidator ID="rfvtxtcompanyname" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtcompanyname" ValidationGroup="valcomp">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtsubheading" runat="server" class="form-control" MaxLength="100" />
                    <label for="txtsubheading">Subheading</label>
                    <asp:RequiredFieldValidator ID="rfvtxtsubheading" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtsubheading" ValidationGroup="valcomp">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtaddress" runat="server" class="validate" MaxLength="200" />
                    <label for="txtaddress">Address</label>
                    <asp:RequiredFieldValidator ID="rfvtxtaddress" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtaddress" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtcontactperson" runat="server" class="validate" MaxLength="50" />
                    <label for="txtcontactperson">Contact Person</label>
                    <asp:RequiredFieldValidator ID="rfvtxtcontactperson" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtcontactperson" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtmobile" runat="server" class="validate" MaxLength="15" />
                    <label for="txtmobile">Mobile</label>
                    <asp:RequiredFieldValidator ID="rfvtxtmobile" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtmobile" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtlandline" runat="server" class="validate" MaxLength="15" />
                    <label for="txtlandline">Landline</label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtcity" runat="server" class="validate" MaxLength="50" />
                    <label for="txtcity">City</label>
                    <asp:RequiredFieldValidator ID="rfvtxtcity" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtcity" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtstate" runat="server" class="validate" MaxLength="50" />
                    <label for="txtstate">State</label>
                    <asp:RequiredFieldValidator ID="rfvtxtstate" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtstate" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtpincode" runat="server" class="validate" MaxLength="6" />
                    <label for="txtpincode">Pincode</label>
                    <asp:RequiredFieldValidator ID="rfvtxtpincode" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtpincode" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtemail" runat="server" class="validate" MaxLength="100" />
                    <label for="txtemail">Email </label>
                    <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtemail" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtgstin" runat="server" class="validate" MaxLength="20" />
                    <label for="txtgstin">GSTIN </label>
                    <asp:RequiredFieldValidator ID="rfvtxtgstin" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtgstin" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtwebsite" runat="server" class="validate" MaxLength="100" />
                    <label for="txtwebsite">Website </label>
                    <asp:RequiredFieldValidator ID="rfvtxtwebsite" runat="server"
                        Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                        ControlToValidate="txtwebsite" ValidationGroup="valcomp">
                   </asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtpan" runat="server" class="validate" MaxLength="10" />
                    <label for="txtcin">PAN </label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtcin" runat="server" class="validate" MaxLength="21" />
                    <label for="txtcin">CIN </label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" CausesValidation="true"
                        ValidationGroup="valcomp" CssClass="waves-effect waves-light btn-large" Text="Save"></asp:LinkButton>
                 
                </div>
            </div>
        </div>
    </div>
</asp:Content>

