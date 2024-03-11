<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="fullblog.aspx.cs" Inherits="JustStay.Web.fullblog" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphfullblog" runat="server">
    <section>
        <div class="rows inn-page-bg com-colo">
            <div class="container inn-page-con-bg tb-space pad-bot-redu-5" id="inner-page-title">
                <div class="rows">
                    <div class="posts">
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <img src="/BlogImages/<%=strimagename%>" alt="" />
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <h3><%=strblogtitle %></h3>
                            <h5><span class="post_author">Author: Admin (Juststay)</span><span class="post_date">Date: <%=strdate %></span><span class="post_city">City: Pune</span></h5>
                           <%-- <div class="post-btn">
                                <ul>
                                    <li><a href="#"><i class="fa fa-facebook fb1"></i>Share On Facebook</a>
                                    </li>
                                    <li><a href="#"><i class="fa fa-twitter tw1"></i>Share On Twitter</a>
                                    </li>
                                    <li><a href="#"><i class="fa fa-google-plus gp1"></i>Share On Google Plus</a>
                                    </li>
                                </ul>
                            </div>--%>
                            <p>
                                <%=strcontent %>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
