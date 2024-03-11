<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumb.ascx.cs" Inherits="JustStayAdmin.Controls.Breadcrumb" %>

<!--=======start breadcrumb-->
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="true" />
<asp:SiteMapPath ID="SiteMapPath1" runat="server" PathSeparator=" > " RenderCurrentNodeAsLink="false">
</asp:SiteMapPath>
<!--End breadcrumb-->
<div class="clear">
</div>
