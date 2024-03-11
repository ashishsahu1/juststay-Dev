<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="blog.aspx.cs" Inherits="JustStay.Web.blog" %>
<%@ Import Namespace="JustStay.CommonHub" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphblog" runat="server">
    <section>
        <div class="rows inner_banner inner_banner_1">
            <div class="container">
                <h2><span>Best Rest Chair -</span> Service in your City</h2>
                <ul>
                    <li><a href="home.aspx">Home</a> </li>
                    <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                    <li><a href="blog.aspx" class="bread-acti">Blog Posts</a> </li>
                </ul>
                <p>Book Rest Chair and enjoy your travel with restful experience</p>
            </div>
        </div>
    </section>
    <section>
        <div class="rows inn-page-bg com-colo">
            <div class="container inn-page-con-bg tb-space pad-bot-redu-5" id="inner-page-title">
                <div class="spe-title col-md-12">
                    <h2>Rest Chair <span>Blog</span> Posts</h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                    <p>Rest Chair Service is one of the unique service first time in India</p>
                </div>
                <div class="rows">
                    <asp:Repeater ID="rtpblog" runat="server">
                        <ItemTemplate>
                            <div class="posts">
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <img src="/BlogImages/<%# Eval("BlogImageNewName")%>" alt="" />
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                    <h3><%#Eval("BlogTitle") %></h3>
                                    <h5><span class="post_author">Author: Admin (Juststay)</span><span class="post_date">Date: <%# Convert.ToDateTime(Eval("BlogDate")).ToString("MMM dd,yy") %></span><span class="post_city">City: Pune</span></h5>
                                    <p><%#Helper.CreateShortString(175, Eval("BlogContent").ToString()) %></p>
                                   
                                    <a href="fullblog.aspx?bid=<%#Eval("BlogId") %>" class="link-btn">Read more</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
