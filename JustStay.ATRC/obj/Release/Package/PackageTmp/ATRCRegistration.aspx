<%@ Page Language="C#" AutoEventWireup="true" Title="JUST STAY | ATRC - Registration" EnableEventValidation="false" CodeBehind="ATRCRegistration.aspx.cs" Inherits="JustStay.ATRC.ATRCRegistration" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>ATRC Application Form | Just Stay</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.ico">
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,700,900" rel="stylesheet">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="css/owl.carousel.css">
    <link rel="stylesheet" href="css/owl.theme.css">
    <link rel="stylesheet" href="css/owl.transitions.css">
    <link rel="stylesheet" href="css/animate.css">
    <link rel="stylesheet" href="css/normalize.css">
    <link rel="stylesheet" href="css/meanmenu.min.css">
    <link rel="stylesheet" href="css/main.css">
    <link rel="stylesheet" href="css/educate-custon-icon.css">
    <link rel="stylesheet" href="css/morrisjs/morris.css">
    <link rel="stylesheet" href="css/scrollbar/jquery.mCustomScrollbar.min.css">
    <link rel="stylesheet" href="css/metisMenu/metisMenu.min.css">
    <link rel="stylesheet" href="css/metisMenu/metisMenu-vertical.css">
    <link rel="stylesheet" href="css/calendar/fullcalendar.min.css">
    <link rel="stylesheet" href="css/calendar/fullcalendar.print.min.css">
    <link rel="stylesheet" href="css/modals.css">
    <link rel="stylesheet" href="css/form/all-type-forms.css">
    <link rel="stylesheet" href="style.css">
    <link rel="stylesheet" href="css/responsive.css">
    <link href="css/code-editor/codemirror.css" rel="stylesheet" />
    <script src="js/vendor/modernizr-2.8.3.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="left-sidebar-pro">
            <nav id="sidebar" class="">
                <div class="sidebar-header">
                    <a href="login.aspx">
                        <img class="main-logo" src="img/logo/logo.png" alt="" /></a>
                    <strong><a href="login.aspx">
                        <img src="img/logo/logosn.png" alt="" /></a></strong>
                </div>
                <div class="left-custom-menu-adp-wrap comment-scrollbar">
                    <nav class="sidebar-nav left-sidebar-menu-pro">
                        <ul class="metismenu" id="menu1">
                            <li>
                                <a title="Joinus" href="https://www.juststay.in/joinus.aspx" aria-expanded="false" target="_blank">
                                    <span class="educate-icon educate-event icon-wrap sub-icon-mg" aria-hidden="true"></span>
                                    <span class="mini-click-non">Join Us</span></a>
                            </li>
                            <li>
                                <a title="Privey Policies" href="policies.aspx" aria-expanded="false" target="_blank">
                                    <span class="educate-icon educate-event icon-wrap sub-icon-mg" aria-hidden="true"></span>
                                    <span class="mini-click-non">Privey Policies</span></a>
                            </li>
                            <li>
                                <a title="Terms & Conditions" href="termsconditions.aspx" aria-expanded="false" target="_blank">
                                    <span class="educate-icon educate-event icon-wrap sub-icon-mg" aria-hidden="true"></span>
                                    <span class="mini-click-non">Terms & Conditions</span></a>
                            </li>
                            <li>
                                <a title="FAQs" href="faq.aspx" aria-expanded="false" target="_blank">
                                    <span class="educate-icon educate-event icon-wrap sub-icon-mg" aria-hidden="true"></span>
                                    <span class="mini-click-non">FAQs</span></a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </nav>
        </div>
        <div class="all-content-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="logo-pro">
                            <a href="index.html">
                                <img class="main-logo" src="img/logo/logo.png" alt="" /></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="header-advance-area">
                <div class="header-top-area">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="header-top-wraper">
                                    <div class="row">
                                        <div class="col-lg-1 col-md-0 col-sm-1 col-xs-12">
                                            <div class="menu-switcher-pro">
                                                <button type="button" id="sidebarCollapse" class="btn bar-button-pro header-drl-controller-btn btn-info navbar-btn">
                                                    <i class="educate-icon educate-nav"></i>
                                                </button>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-7 col-sm-6 col-xs-12">
                                            <div class="header-top-menu tabl-d-n">
                                                <ul class="nav navbar-nav mai-top-nav">
                                                    <li class="nav-item"><a href="https://www.juststay.in/home.aspx" class="nav-link">Home</a>
                                                    </li>
                                                    <li class="nav-item"><a href="https://www.juststay.in/about.aspx" class="nav-link">About</a>
                                                    </li>
                                                    <li class="nav-item"><a href="https://www.juststay.in/home.aspx#services" class="nav-link">Services</a>
                                                    </li>
                                                    <li class="nav-item"><a href="#" class="nav-link">Support</a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                                            <div class="header-right-info">
                                                <ul class="nav navbar-nav mai-top-nav header-right-menu">
                                                    <li class="nav-item dropdown">
                                                        <a href="#" data-toggle="dropdown" role="button" aria-expanded="false" class="nav-link dropdown-toggle"><i class="educate-icon educate-message edu-chat-pro" aria-hidden="true"></i><span class="indicator-ms"></span></a>
                                                        <div role="menu" class="author-message-top dropdown-menu animated zoomIn">
                                                            <div class="message-single-top">
                                                                <h1>Message</h1>
                                                            </div>
                                                            <ul class="message-menu">
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="message-img">
                                                                            <img src="img/contact/1.jpg" alt="">
                                                                        </div>
                                                                        <div class="message-content">
                                                                            <span class="message-date">16 Sept</span>
                                                                            <h2>Advanda Cro</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="message-img">
                                                                            <img src="img/contact/4.jpg" alt="">
                                                                        </div>
                                                                        <div class="message-content">
                                                                            <span class="message-date">16 Sept</span>
                                                                            <h2>Sulaiman din</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="message-img">
                                                                            <img src="img/contact/3.jpg" alt="">
                                                                        </div>
                                                                        <div class="message-content">
                                                                            <span class="message-date">16 Sept</span>
                                                                            <h2>Victor Jara</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="message-img">
                                                                            <img src="img/contact/2.jpg" alt="">
                                                                        </div>
                                                                        <div class="message-content">
                                                                            <span class="message-date">16 Sept</span>
                                                                            <h2>Victor Jara</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                            </ul>
                                                            <div class="message-view">
                                                                <a href="#">View All Messages</a>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="nav-item"><a href="#" data-toggle="dropdown" role="button" aria-expanded="false" class="nav-link dropdown-toggle"><i class="educate-icon educate-bell" aria-hidden="true"></i><span class="indicator-nt"></span></a>
                                                        <div role="menu" class="notification-author dropdown-menu animated zoomIn">
                                                            <div class="notification-single-top">
                                                                <h1>Notifications</h1>
                                                            </div>
                                                            <ul class="notification-menu">
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="notification-icon">
                                                                            <i class="educate-icon educate-checked edu-checked-pro admin-check-pro" aria-hidden="true"></i>
                                                                        </div>
                                                                        <div class="notification-content">
                                                                            <span class="notification-date">16 Sept</span>
                                                                            <h2>Advanda Cro</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="notification-icon">
                                                                            <i class="fa fa-cloud edu-cloud-computing-down" aria-hidden="true"></i>
                                                                        </div>
                                                                        <div class="notification-content">
                                                                            <span class="notification-date">16 Sept</span>
                                                                            <h2>Sulaiman din</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="notification-icon">
                                                                            <i class="fa fa-eraser edu-shield" aria-hidden="true"></i>
                                                                        </div>
                                                                        <div class="notification-content">
                                                                            <span class="notification-date">16 Sept</span>
                                                                            <h2>Victor Jara</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                                <li>
                                                                    <a href="#">
                                                                        <div class="notification-icon">
                                                                            <i class="fa fa-line-chart edu-analytics-arrow" aria-hidden="true"></i>
                                                                        </div>
                                                                        <div class="notification-content">
                                                                            <span class="notification-date">16 Sept</span>
                                                                            <h2>Victor Jara</h2>
                                                                            <p>Please done this project as soon possible.</p>
                                                                        </div>
                                                                    </a>
                                                                </li>
                                                            </ul>
                                                            <div class="notification-view">
                                                                <a href="#">View All Notification</a>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="nav-item">
                                                        <a href="#" data-toggle="dropdown" role="button" aria-expanded="false" class="nav-link dropdown-toggle">
                                                            <img src="img/manface.png" alt="" />
                                                            <span class="admin-name">
                                                                <asp:Label ID="lblusername" runat="server"></asp:Label></span>
                                                            <i class="fa fa-angle-down edu-icon edu-down-arrow"></i>
                                                        </a>
                                                        <ul role="menu" class="dropdown-header-top author-log dropdown-menu animated zoomIn">
                                                            <li>
                                                                <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click"><span class="edu-icon edu-locked author-log-ic"></span>Log Out</asp:LinkButton>
                                                            </li>
                                                        </ul>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mobile-menu-area">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="mobile-menu">
                                    <nav id="dropdown">
                                        <ul class="mobile-menu-nav">
                                            <li><a href="#">Join Us</a></li>
                                            <li><a href="#">Our Survey</a></li>
                                            <li><a href="#">Privacy Policies</a></li>
                                            <li><a href="#">Terms & Conditions</a></li>
                                            <li><a href="#">FAQs</a></li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="breadcome-area">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="breadcome-list single-page-breadcome text-center">
                                    <div class="row">
                                        <h3>Application Form For JUST STAY Rest Chair Establishment</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Basic Form Start -->
            <div class="basic-form-area mg-b-15">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="sparkline12-list">
                                <div class="sparkline12-graph">
                                    <div class="basic-login-form-ad">
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <div class="all-form-element-inner">

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Restaurant Name</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <asp:TextBox ID="txtRestName" runat="server" class="form-control" MaxLength="50" />
                                                                <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                                                    Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                    ControlToValidate="txtRestName" ValidationGroup="reg">
                                                                </asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                                <label class="login2 pull-right pull-right-pro">
                                                                    Category
                                                                </label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                                <div class="inline-checkbox-cs">
                                                                    <asp:CheckBoxList ID="chkCategory" runat="server" RepeatDirection="Horizontal" CssClass="checkbox-inline i-checks pull-left" DataTextField="Category" DataValueField="ATRCCategoryId">
                                                                    </asp:CheckBoxList>
                                                                    <asp:CustomValidator runat="server" ID="cvmCategorylist"
                                                                        ClientValidationFunction="ValidateCategories" SetFocusOnError="true"
                                                                        ForeColor="Red" Display="Dynamic" ValidationGroup="reg"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Promoter(s)/Owner(s) Name</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <asp:TextBox ID="txtOwnerName" runat="server" class="form-control" MaxLength="100" />
                                                                <asp:RequiredFieldValidator ID="rfvtxtOwnerName" runat="server"
                                                                    Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                    ControlToValidate="txtOwnerName" ValidationGroup="reg">
                                                                </asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Postal Address</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="200" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfv4" runat="server"
                                                                    Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                    ControlToValidate="txtAddress" ValidationGroup="reg">
                                                                </asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">State</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <div class="form-select-list">
                                                                    <asp:DropDownList ID="drpState" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="NameWithCode" DataValueField="StateId" />
                                                                    <asp:RequiredFieldValidator ID="rfvState" runat="server"
                                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="drpState" ValidationGroup="reg">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">City</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <div class="form-select-list">
                                                                    <asp:DropDownList ID="drpCity" class="form-control custom-select-value" runat="server" AppendDataBoundItems="false" onchange="BindLocations();" DataTextField="Name" DataValueField="CityId" />
                                                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server"
                                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="drpCity" ValidationGroup="reg">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Location</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <div class="form-select-list">
                                                                    <asp:DropDownList ID="drpLocation" class="form-control custom-select-value" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataTextField="Name" DataValueField="LocationId" />
                                                                    <asp:RequiredFieldValidator ID="rfvLocation" runat="server"
                                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="true" ForeColor="Red"
                                                                        ControlToValidate="drpLocation" ValidationGroup="reg">
                                                                    </asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Tel No.</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <asp:TextBox ID="txtTel" runat="server" MaxLength="15" CssClass="form-control" placeholder="Tel. No"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfv3" runat="server"
                                                                    Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtTel"
                                                                    ValidationGroup="reg">
                                                                </asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Email</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <asp:TextBox ID="txtemail" runat="server" MaxLength="100" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server"
                                                                    Display="Dynamic" SetFocusOnError="true" ForeColor="Red"
                                                                    ControlToValidate="txtemail" ValidationGroup="reg">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="regtxtEmail" runat="server" ErrorMessage="Invalid Email" Display="Dynamic"
                                                                    ControlToValidate="txtemail" ValidationGroup="reg" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    SetFocusOnError="true" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Promoter Mobile No.</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" MaxLength="10" placeholder="Mobile"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfv7" runat="server" Display="Dynamic"
                                                                    SetFocusOnError="true" ForeColor="Red"
                                                                    ControlToValidate="txtMobile" ValidationGroup="reg">
                                                                </asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="regaxMobile" runat="server" ControlToValidate="txtMobile" ValidationExpression="^[0-9]*$"
                                                                    SetFocusOnError="true" Display="Dynamic" ValidationGroup="reg"
                                                                    ErrorMessage="Enter Number Only!" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                                <label class="login2 pull-right pull-right-pro">
                                                                    About
                                                                </label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="code-editor-single shadow-reset">
                                                                    <textarea id="txtATRCDtails" runat="server"></textarea>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                                                <label class="login2 pull-right pull-right-pro">
                                                                    From where you got to know about us
                                                                </label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                                                <div class="inline-checkbox-cs">
                                                                    <asp:CheckBoxList ID="chkReferral" runat="server">
                                                                        <asp:ListItem Text="By referral" Value="1" />
                                                                        <asp:ListItem Text="Social Media" Value="2" />
                                                                        <asp:ListItem Text="Website" Value="3" />
                                                                        <asp:ListItem Text="Google Search" Value="4" />
                                                                    </asp:CheckBoxList>
                                                                    <asp:CustomValidator runat="server" ID="CustomValidator1" ErrorMessage="*"
                                                                        ClientValidationFunction="ValidateReferrals" SetFocusOnError="true"
                                                                        ForeColor="Red" Display="Dynamic" ValidationGroup="reg"></asp:CustomValidator>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Profile Photo</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                                    <div class="input append-small-btn">
                                                                        <div class="file-button">
                                                                            Browse
                                                                            <asp:FileUpload ID="profileImageUpload" runat="server"
                                                                                 onchange="document.getElementById('append-small-btn1').value = this.value;ValidateFile(this);" ClientIDMode="Static" />                                                                             
                                                                        </div>
                                                                        <input type="text" id="append-small-btn1" placeholder="no file selected" />
                                                                    </div>
                                                                </div>
                                                                <span style="color: Red;" id="sp_profileImageUpload"></span>
                                                                <asp:RequiredFieldValidator ID="rfvImage" runat="server" Display="Dynamic"
                                                                    SetFocusOnError="true" ForeColor="Red"
                                                                    ControlToValidate="profileImageUpload" ValidationGroup="reg" ErrorMessage="*">
                                                                </asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="form-group-inner">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                                <label class="login2 pull-right pull-right-pro">Upload Photographs</label>
                                                            </div>
                                                            <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                                <div class="file-upload-inner file-upload-inner-right ts-forms">
                                                                    <div class="input append-big-btn">
                                                                        <div id="FileUploadContainer" runat="server">
                                                                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="ValidateFile(this);" ClientIDMode="Static" /><br />
                                                                            <span style="color: Red;" id="sp_FileUpload1"></span>
                                                                        </div>
                                                                        <br />
                                                                        <br />
                                                                        <input id="Button1" onclick="AddFileUpload()" type="button" value="Add more photo" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group-inner">
                                                        <div class="login-btn-inner">
                                                            <div class="row">
                                                                <div class="col-lg-3"></div>
                                                                <div class="col-lg-9">
                                                                    <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                                        <asp:LinkButton ID="btnRegister" runat="server" OnClientClick="javascript:return ValidateRequired();" OnClick="btnRegister_Click" CausesValidation="true" ValidationGroup="reg" CssClass="btn btn-sm btn-primary login-submit-cs" Text="Save & Request for Approval"></asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkClose" runat="server" class="btn btn-white" PostBackUrl="~/login.aspx">Cancel</asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Basic Form End-->
            <div class="footer-copyright-area">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="footer-copy-right">
                                <p>Copyright © 2019-2020. All rights reserved. <a href="#">Namo Services-Pune</a>  Developed by <a href="http://www.nmskaar.com" target="_blank">nmskaar infotech</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            var counter = 0;
            var allValidImages = true;
            function AddFileUpload() {
               
                var div = document.createElement('DIV');
                div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +
                             '" type="file" onchange="ValidateFile(this);"/><span style="color:Red;" id="sp_file' + counter + '"></span>' +
                             '<input id="Button' + counter + '" type="button" style="width:100px;" ' +
                             'value="Remove" onclick = "RemoveFileUpload(this)" />';
               // alert(div.innerHTML);
                document.getElementById("FileUploadContainer").appendChild(div);
                counter++;
            }

            function RemoveFileUpload(div) {
                document.getElementById("FileUploadContainer").removeChild(div.parentNode);
            }

            function BindLocations() {
                var ddlLocations = $('#<%=drpLocation.ClientID%>');
                ddlLocations.empty();
                ddlLocations.append(new Option("Select Location", 0));
                var drpCity = $('#<%=drpCity.ClientID%>');
                var cityId = drpCity.val();
                debugger;
                if (cityId != 0) {
                    $.ajax({
                        type: "POST",
                        url: "ATRCRegistration.aspx/GetLocationsByCity",
                        data: "{ 'cityId':'" + cityId + "'}",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            debugger;
                            var jsdata = JSON.parse(data.d);
                            $.each(jsdata, function (key, value) {
                                ddlLocations.append(new Option(value.Name, value.LocationId));
                            });
                        },
                        error: function (data) {
                            alert("error found");
                        }
                    });
                }
            }
            function ValidateCategories(source, args) {
                debugger;
                var chkListModules = document.getElementById('<%= chkCategory.ClientID %>');
                var chkListinputs = chkListModules.getElementsByTagName("input");
                for (var i = 0; i < chkListinputs.length; i++) {
                    if (chkListinputs[i].checked) {
                        args.IsValid = true;
                        return;
                    }
                }
                args.IsValid = false;
            }
            function ValidateReferrals(source, args) {
                debugger;
                var chkListModules = document.getElementById('<%= chkReferral.ClientID %>');
                var chkListinputs = chkListModules.getElementsByTagName("input");
                for (var i = 0; i < chkListinputs.length; i++) {
                    if (chkListinputs[i].checked) {
                        args.IsValid = true;
                        return;
                    }
                }
                args.IsValid = false;
            }

            function ValidateFile(value) {
                debugger;
                var file = getNameFromPath($(value).val());
                if (file != null) {
                    var extension = file.substr((file.lastIndexOf('.') + 1));
                    switch (extension) {
                        case 'jpg':
                        case 'jpeg':
                        case 'png':
                        case 'bmp':
                        case 'gif':
                            flag = true;
                            break;
                        default:
                            flag = false;
                    }
                }

                var data = "sp_" + value.id;

                if (flag == false) {

                    $("#" + data).text("You can upload only jpg, jpeg, png, bmp and gif extension file Only");
                    $("#" + value.id).val('');
                    return false;
                }
                else {
                    $("#" + data).text("");
                }
            }

            function getNameFromPath(strFilepath) {
                var objRE = new RegExp(/([^\/\\]+)$/);
                var strName = objRE.exec(strFilepath);

                if (strName == null) {
                    return null;
                }
                else {
                    return strName[0];
                }
            }
            function ValidateRequired() {
                debugger;
                var Booleandata = true;
                if (Page_ClientValidate("reg")) {
                    var spans = $("[id*='sp_']");
                    for (var i = 0; i < spans.length; i++) {
                        if ($("#" + spans[i].id).text() != '') {
                            Booleandata = false;
                        }
                    }
                }
                return Booleandata;
            }
        </script>
        <script src="js/vendor/jquery-1.12.4.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/wow.min.js"></script>
        <script src="js/jquery-price-slider.js"></script>
        <script src="js/jquery.meanmenu.js"></script>
        <script src="js/owl.carousel.min.js"></script>
        <script src="js/jquery.sticky.js"></script>
        <script src="js/jquery.scrollUp.min.js"></script>
        <script src="js/scrollbar/jquery.mCustomScrollbar.concat.min.js"></script>
        <script src="js/scrollbar/mCustomScrollbar-active.js"></script>
        <script src="js/metisMenu/metisMenu.min.js"></script>
        <script src="js/metisMenu/metisMenu-active.js"></script>
        <script src="js/tab.js"></script>
        <script src="js/icheck/icheck.min.js"></script>
        <script src="js/icheck/icheck-active.js"></script>
        <script src="js/plugins.js"></script>
        <script src="js/main.js"></script>
        <script src="js/tawk-chat.js"></script>
        <!-- code editor JS
		============================================ -->
        <script src="js/code-editor/codemirror.js"></script>
        <script src="js/code-editor/code-editor.js"></script>
        <script src="js/code-editor/code-editor-active.js"></script>

    </form>
</body>

</html>
