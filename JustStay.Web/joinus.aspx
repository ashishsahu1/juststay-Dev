<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="joinus.aspx.cs" Inherits="JustStay.Web.joinus" %>
<%@ Import Namespace="JustStay.CommonHub" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="cphjoinus">
    <asp:HiddenField ID="hdnid" runat="server" Value="0" />
    <section>
        <div>
            <div>
                <div>
                    <div class="slider fullscreen">
                        <ul class="slides">
                            <li>
                                <img src="images/join-banner-1.jpg" alt="" />
                                <!-- random image -->
                                <div class="caption center-align slid-cap">
                                    <h5 class="light grey-text text-lighten-3">" Take Rest For the Best "</h5>
                                    <h2>Booking for ATRC is started Join us as ATRC Today!</h2>
                                    <a href="#joinus" class="waves-effect waves-light">JOIN US NOW!</a>
                                </div>
                            </li>
                            <li>
                                <img src="images/joinus-banner-2.jpg" alt="" />
                                <!-- random image -->
                                <div class="caption center-align slid-cap">
                                    <h5 class="light grey-text text-lighten-3">" Take Rest For the Best "</h5>
                                    <h2>"Investment in travel is an investment in yourself"  - Mattew Karsten</h2>
                                    <a href="#joinus" class="waves-effect waves-light">JOIN US NOW!</a>
                                </div>
                            </li>
                            <li>
                                <img src="images/joinus-banner-3.jpg" alt="" />
                                <!-- random image -->
                                <div class="caption center-align slid-cap">
                                    <h5 class="light grey-text text-lighten-3">" Take Rest For the Best "</h5>
                                    <h2>Join Just Stay as ATRC and invest in your fulfillment.</h2>
                                    <a href="#joinus" class="waves-effect waves-light">JOIN US NOW!</a>
                                </div>
                            </li>
                            <li>
                                <img src="images/join-banner-4.jpg" alt="" />
                                <!-- random image -->
                                <div class="caption center-align slid-cap">
                                    <h5 class="light grey-text text-lighten-3">" Take Rest For the Best "</h5>
                                    <h2>"We travel not to escape life, but for life not to escape us, Because travel need rest! "</h2>
                                    <a href="#joinus" class="waves-effect waves-light">JOIN US NOW!</a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rows pad-bot-redu tb-space hom2-ban-pack">
            <div class="container">
                <div>
                    <asp:Repeater ID="rptSD" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-sm-6 col-xs-12 b_packages wow fadeInUp" data-wow-duration="0.5s">
                                <div class="v_place_img">
                                    <img src="/ATRCImages/<%# Eval("NewImageName") %>" alt="ATRC" title="ATRC">
                                </div>
                                <div class="b_pack rows">
                                    <div class="col-md-8 col-sm-8">
                                        <h4><a href="Profile.aspx?atrcid=<%# Eval("ATRCId") %>"><%# Eval("SDName") %></a></h4>
                                    </div>
                                    <div class="col-md-4 col-sm-4 pack_icon">
                                        <ul>
                                            <li>
                                                    <img src="images/clock.png" alt="Date" title="Dining From: <%# Eval("DiningFromTime") %> Dining To:<%# Eval("DiningToTime") %>">
                                            </li>
                                            <li>
                                                <a href="profile.aspx?aid=<%# new JSEDS().Encrypt(Eval("ATRCId").ToString()) %>">
                                                    <img src="images/info.png" alt="Details" title="View more details">
                                                </a>
                                            </li>
                                            <li>
                                                    <img src="images/map.png" alt="Location" title="<%# Eval("Address") %>" />
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rows inn-page-bg com-colo">
            <div class="container inn-page-con-bg tb-space pad-bot-redu" id="inner-page-title">
                <div class="spe-title col-md-12">
                    <h2>JOIN US TODAY as <span>ATRC</span></h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                    <p>" Help us today for make India Safe to Traval & Stay ! " <strong>JUST STAY Committed to Offer</strong></p>

                </div>
                <div class="tips_travel_1">
                    <ul>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <i class="fa fa-shield" aria-hidden="true"></i>
                                <h4>100% lifetime assistance on every step</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <i class="fa fa-money" aria-hidden="true"></i>
                                <h4>Financial Assistance & low investmant cost</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <i class="fa fa-android" aria-hidden="true"></i>
                                <h4>Booking by android application & hassle-free opration app for ATRC</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <i class="fa fa-line-chart" aria-hidden="true"></i>
                                <h4>100% growth on booking rate & revenue</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <i class="fa fa-user" aria-hidden="true"></i>
                                <h4>Community of regular returning customer</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <i class="fa fa-handshake-o" aria-hidden="true"></i>
                                <h4>Complete transperency & long term business relationship</h4>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rows inn-page-bg com-colo">
            <div class="container inn-page-con-bg tb-space pad-bot-redu" id="inner-page-title">
                <div class="spe-title col-md-12">
                    <h2>Perks being <span>ATRC</span></h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                </div>
                <div class="tips_travel_1">
                    <ul>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <img src="images/success.png" />
                                <h4>Contribution to reduce accidents in India by 20%</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <img src="images/success.png" />
                                <h4>Increase Safty and Security of India travellers</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <img src="images/success.png" />
                                <h4>Make confortable ride & stay of Indian family members</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <img src="images/success.png" />
                                <h4>Make use of hotel services to its fullest</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <img src="images/success.png" />
                                <h4>Have a long term customer relationship with honest reviews & ratings</h4>
                            </div>
                        </li>
                        <li class="col-md-4 col-sm-4">
                            <div class="tips_travel_2">
                                <img src="images/success.png" />
                                <h4>Help to create local job opportunites in India</h4>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
    <section id="joinus">
        <div class="form tb-space pad-top-o">
            <div class="rows container">
                <div class="spe-title">
                    <h2>Booking For ATR Center is started!</h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                    <p>JOIN ATRC (Any Time Refreshment Center) here by filling below details!</p>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12 form_1">
                    
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                   
                    <div class="v2-search-form">
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:TextBox ID="txtname" runat="server" CssClass="autocomplete" MaxLength="50"></asp:TextBox>
                                <label for="txtname">Name</label>
                                <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ControlToValidate="txtname" SetFocusOnError="true" ValidationGroup="joinus"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:TextBox ID="txtmobile" runat="server" CssClass="autocomplete" MaxLength="10" autocomplete="off" onBlur="javascript:validateMobile(this);"></asp:TextBox>
                                <label for="txtmobile">Mobile</label>
                                <asp:RequiredFieldValidator ID="rfvtxtmobile" runat="server" ControlToValidate="txtmobile" SetFocusOnError="true" ValidationGroup="joinus"></asp:RequiredFieldValidator>
                                <script type="text/javascript">
                                    function validateMobile(mobile) {
                                        if (mobile != '' && mobile != null) {
                                            CheckMobileExist('<%=txtmobile.ClientID %>', 'spnDuplicateCustMobile');
                                        }
                                      }
                                </script>
                                <span id='spnDuplicateCustMobile' style="display: none; color: Red; float: left;">Mobile Already Exist</span><br />
                                 <asp:RegularExpressionValidator ID="revtxtmobile" runat="server" ErrorMessage="Enter valid mobile." ForeColor="Red" Display="Dynamic" ValidationExpression="^(\+\d{1,3}[- ]?)?\d{10}$" ValidationGroup="joinus"
                                ControlToValidate="txtmobile" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:TextBox ID="txtemail" runat="server" CssClass="autocomplete" MaxLength="50" autocomplete="off" ClientIDMode="Static"
                                    onBlur="javascript:checkemail(this);" onkeydown="return (event.keyCode!=13);"></asp:TextBox>
                                <label for="txtemail">Email</label>
                                <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server" ControlToValidate="txtemail" SetFocusOnError="true" ValidationGroup="joinus"></asp:RequiredFieldValidator>
                                <script type="text/javascript">
                                    function checkemail(val) {
                                        if (val != '' && val != null)
                                            CheckEmailExist('<%=txtemail.ClientID %>', 'spnDuplicateEmail', 2);
                                         }
                                </script>
                                <span id='spnDuplicateEmail' style="display: none; color: Red; float: left;">Email Already Exist</span><br />
                                 <asp:RegularExpressionValidator ID="revtxtemail" runat="server" ErrorMessage="Please Enter Valid Email" Display="Dynamic"
                                ValidationGroup="joinus" ControlToValidate="txtemail"
                                ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="(\w+[.|\w])*@(\w+[.])*(com$|in$|co.in$|net$)">
                            </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:TextBox ID="txtaddress" runat="server" CssClass="autocomplete" MaxLength="100"></asp:TextBox>
                                <label for="txtaddress">Address</label>
                                <asp:RequiredFieldValidator ID="rfvtxtaddress" runat="server" ControlToValidate="txtaddress" SetFocusOnError="true" ValidationGroup="joinus"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <asp:Button ID="btnsand" runat="server" Text="Submit" CssClass="waves-effect waves-light tourz-sear-btn v2-ser-btn" OnClick="btnsand_Click" ValidationGroup="joinus" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12 family">
                    <img src="images/joinus-form.jpg" alt="" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
