<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofile.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="JustStay.Web.myprofile" %>

<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphprofile">
    <section>
        <div class="db">
            <ULMenu:UserleftMenu runat="server" ID="UserleftMenu" />
            <div class="db-2">
                <div class="db-2-com db-2-main">
                    <h4>My Profile</h4>
                    <div class="db-2-main-com db-2-main-com-table">
                        <table class="responsive-table">
                            <tbody>
                                <tr>
                                    <td>Name</td>
                                    <td>:</td>
                                    <td><%=strname %></td>
                                </tr>
                                 <tr>
                                    <td>User Name</td>
                                    <td>:</td>
                                    <td><%=strusername %></td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td>:</td>
                                    <td><%=strpassword %></td>
                                </tr>
                                <tr>
                                    <td>Email</td>
                                    <td>:</td>
                                    <td><%=stremail %></td>
                                </tr>
                                <tr>
                                    <td>Mobile</td>
                                    <td>:</td>
                                    <td><%=strMobile %></td>
                                </tr>
                                <tr>
                                    <td>Date of birth</td>
                                    <td>:</td>
                                    <td><%=strdob %></td>
                                </tr>
                                <tr>
                                    <td>Address</td>
                                    <td>:</td>
                                    <td><%=straddress %></td>
                                </tr>
                                <tr>
                                    <td>Status</td>
                                    <td>:</td>
                                    <td><span class="db-done"><%=strisactive %></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="db-mak-pay-bot">
                            <a href="edit-profile.aspx" class="waves-effect waves-light btn-large">Edit my profile</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
