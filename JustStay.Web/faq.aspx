<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="faq.aspx.cs" Inherits="JustStay.Web.faq" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphfaq" runat="server">
    <section>
        <div class="form-spac rows">
            <div class="container">
                <div class="spe-title col-md-12">
                    <h2>Frequency Asked <span>Questions</span></h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="rows book_poly">
                        <div class="panel-group" id="accordion">
                            <asp:Repeater ID="rptFaq" runat="server">
                                <ItemTemplate>
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse<%#Eval("FAQId") %>"><%#Eval("Question") %></a>
                                            </h4>
                                        </div>
                                        <div id="collapse<%#Eval("FAQId") %>" class="panel-collapse collapse in">
                                            <div class="panel-body">
                                                    <%# Eval("Answer").ToString()%>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            </div>
    </section>
</asp:Content>
