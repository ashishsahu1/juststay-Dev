<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="changepassword.aspx.cs" Inherits="JustStay.Web.changepassword" %>
<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphchangepassword">
    <section>
        <div class="db">
            <ULMenu:UserleftMenu runat="server" ID="UserleftMenu" />
            <div class="db-2">
				<div class="db-2-com db-2-main">
					<h4>Change Password</h4><br />
                    <p style="padding-left:10px;"><asp:Label ID="lblmsg" runat="server" ForeColor="White"></asp:Label> </p>
					<div class="db-2-main-com db2-form-pay db2-form-com">
						<div class="col s12">
                            <div class="row">
								<div class="input-field col s12">
									 <asp:TextBox ID="txtnewpassword" runat="server" CssClass="validate" MaxLength="8" autocomplete="off"></asp:TextBox>
									<label>New Password</label>
                                  <asp:RequiredFieldValidator ID="rfvtxtnewpassword" runat="server" ControlToValidate="txtnewpassword" SetFocusOnError="true" ValidationGroup="pass"></asp:RequiredFieldValidator>
								</div>
							</div>
                             <div class="row">
								<div class="input-field col s12">
									 <asp:TextBox ID="txtconfirmPassword" runat="server" TextMode="Password" CssClass="validate" MaxLength="8" autocomplete="off"></asp:TextBox>
									<label>Confirm Password</label>
                                   <asp:RequiredFieldValidator ID="rfvtxtconfirmPassword" runat="server" ControlToValidate="txtconfirmPassword" SetFocusOnError="true" ValidationGroup="pass"></asp:RequiredFieldValidator>
								</div>
							</div>
							<div class="row">
								<div class="input-field col s12">
                                    <asp:Button ID="btnchangepassword" runat="server" OnClick="btnchangepassword_Click" ValidationGroup="pass" CssClass="waves-effect waves-light full-btn" Text="Change" />
									 </div>
							</div>
						</div>
					</div>
				</div>
			</div>
        </div>
    </section>
</asp:Content>