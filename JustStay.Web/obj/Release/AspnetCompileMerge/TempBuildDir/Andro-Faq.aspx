<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Andro-Faq.aspx.cs" Inherits="JustStay.Web.Andro_Faq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Just Stay</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="shortcut icon" href="images/icon.png" />
    <link href="https://fonts.googleapis.com/css?family=Poppins%7CQuicksand:400,500,700" rel="stylesheet" />
    <link href="css/all.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/fonticons.css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/style.css" />

    <link rel="stylesheet" href="css/materialize.css" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/mob.css" />
    <link rel="stylesheet" href="css/animate.css" />
    <style>
        @media screen and (max-width: 992px) {
            .top-logo, .ed-com-t1-left {
                display: block;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <section>
        <div class="top-logo" data-spy="affix" data-offset-top="250">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="wed-logo">
                            <a href="#">
                                <img src="images/newlogo.jpg" alt="" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
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
                                               <%# Container.ItemIndex + 1 %>.<a data-toggle="collapse" href="#collapse<%#Eval("FAQId") %>"><%#Eval("Question") %></a>
                                            </h4>
                                        </div>
                                        <div id="collapse<%#Eval("FAQId") %>" class="collapse">
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
         <script src="js/jquery-latest.min.js"></script>
        <script src="js/jquery-ui.js"></script>
        <script src="js/bootstrap.js"></script>
    </form>
</body>
</html>
