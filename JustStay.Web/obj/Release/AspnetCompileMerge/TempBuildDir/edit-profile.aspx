<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="edit-profile.aspx.cs" Inherits="JustStay.Web.edit_profile" %>

<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphprofile">
   <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://unpkg.com/gijgo@1.9.13/js/gijgo.min.js" type="text/javascript"></script>
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <section>
        <div class="db">
            <ULMenu:UserleftMenu runat="server" ID="UserleftMenu" />
            <div class="db-2">
				<div class="db-2-com db-2-main">
					<h4>Edit My Profile </h4>
					<div class="db-2-main-com db2-form-pay db2-form-com">
						<div class="col s12">
                            <div class="row">
								<div class="input-field col s12">
                                    <asp:TextBox ID="txtname" runat="server" CssClass="validate" MaxLength="50"></asp:TextBox>
									<label>Name</label>
                               <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ControlToValidate="txtname" SetFocusOnError="true" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
								</div>
							</div>
							<div class="row">
								<div class="input-field col s12">
                                    <asp:TextBox ID="txtusername" runat="server" CssClass="validate" Enabled="false"></asp:TextBox>
									<label>User Name</label>
								</div>
							</div>
							<div class="row">
								<div class="input-field col s12">
									 <asp:TextBox ID="txtpassword" runat="server" CssClass="validate" Enabled="false"></asp:TextBox>
									<label>Password</label>
								</div>
							</div>
                            <div class="row">
								<div class="input-field col s12">
									 <asp:TextBox ID="txtaddres" runat="server" CssClass="validate" MaxLength="100"></asp:TextBox>
									<label>Address</label>
								</div>
							</div>
							<div class="row">
								<div class="input-field col s12 m6">
								<asp:TextBox ID="txtemail" runat="server" CssClass="validate" MaxLength="50"></asp:TextBox>
									<label>Email</label>
                              <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server" ControlToValidate="txtemail" SetFocusOnError="true" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
								</div>
								<div class="input-field col s12 m6">
									<asp:TextBox ID="txtmobile" runat="server" CssClass="validate" MaxLength="15"></asp:TextBox>
									<label>Mobile</label>
                               <asp:RequiredFieldValidator ID="rfvtxtmobile" runat="server" ControlToValidate="txtmobile" SetFocusOnError="true" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
								</div>
							</div>
						<div class="row">
								<div class="input-field col s12 m6">
								<asp:TextBox ID="txtDOB" runat="server" CssClass="validate"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvdob" runat="server" ControlToValidate="txtDOB" SetFocusOnError="true" ForeColor="Red" ValidationGroup="user"></asp:RequiredFieldValidator>
								</div>
								<div class="input-field col s12 m6">
									<asp:RadioButtonList ID="rdogender" runat="server">
                                        <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
									</asp:RadioButtonList>
									
								</div>
							</div>
							<%--<div class="row db-file-upload">
								<div class="file-field input-field">
									<div class="db-up-btn"> <span>File</span>
										<input type="file" runat="server" id="fileuploader" /> </div>
									<div class="file-path-wrapper">
										<input class="file-path validate" type="text" runat="server" id="filetext" /> </div>
								</div>
							</div>--%>
							<div class="row">
								<div class="input-field col s12">
                                    <asp:Button ID="btnedit" runat="server" OnClick="btnedit_Click" ValidationGroup="user" CssClass="waves-effect waves-light full-btn" Text="Update" />
									 </div>
							</div>
						</div>
					</div>
				</div>
			</div>
            </div>
        </section>
     <script>
         $('#ContentPlaceHolder1_txtDOB').datepicker();
    </script>
</asp:Content>
