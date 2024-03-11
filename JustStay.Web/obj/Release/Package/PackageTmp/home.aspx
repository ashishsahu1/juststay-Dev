<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="JustStay.Web.home" %>

<%@ Import Namespace="JustStay.CommonHub" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphhome" runat="server">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <style>
        .input-icons i {
            position: absolute;
        }

        .input-icons {
            width: 100%;
        }

        .icon {
            padding: 6px;
            color: #EF5555;
            text-align: center;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            text-align: center;
        }

        #ContentPlaceHolder1_from {
            padding-left: 23px;
        }

        .material-icons {
            font-size: 18px;
        }

        .gj-timepicker-md {
            font-size: 18px;
        }
    </style>
    <asp:HiddenField ID="hdToLat" runat="server" Value="0" />
    <asp:HiddenField ID="hdToLng" runat="server" Value="0" />
    <asp:HiddenField ID="hdFromLat" runat="server" Value="0" />
    <asp:HiddenField ID="hdFromLng" runat="server" Value="0" />
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <section>
        <div class="v2-hom-search">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <div class="v2-ho-se-ri">
                            <h5>WORLD'S LEADING SERVICE TO STAY FOR A SHORT PERIOD</h5>
                            <h1>SHORT STAY! BOOK REST CHAIR BY JUSTSTAY</h1>
                            <p>SHORT STAY | ON HIGHWAY | REGULAR & HOURLY BOOKING | EV CHARGING</p>
                            <div class="tourz-hom-ser v2-hom-ser">
                                <ul>
                                    <li>
                                        <a href="home.aspx" class="waves-effect waves-light btn-large tourz-pop-ser-btn">
                                            <img src="images/rest-icon-10.png" alt="" />
                                            Rest Chair</a>
                                    </li>
                                    <li>
                                        <a href="commingsoon.aspx" class="waves-effect waves-light btn-large tourz-pop-ser-btn">
                                            <img src="images/EV-icon.png" alt="" />
                                            EV Charging</a>
                                    </li>
                                    <li>
                                        <a href="commingsoon.aspx" class="waves-effect waves-light btn-large tourz-pop-ser-btn">
                                            <img src="images/reat hourly basis.png" alt="" />ROOM Hourly</a>
                                    </li>
                                    <li>
                                        <a href="commingsoon.aspx" class="waves-effect waves-light btn-large tourz-pop-ser-btn">
                                            <img src="images/restroom-icon-10.png" alt="" />Regular</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="">
                            <div class="contact__form v2-search-form">
                                <div class="row searchbar">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="txtfrom" runat="server" placeholder="From Place"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <a onclick="getLocation();" id="btncurrentlocation">
                                            <img src="images/btnCurrentLocation.png" alt="Current Location" /></a>

                                        <a onclick="getNear();" id="lnknearby">
                                            <img src="images/btnNearme.png" alt="Near Me" /></a>


                                        <script>
                                            function getNear() {
                                                if (navigator.geolocation) {
                                                    navigator.geolocation.getCurrentPosition(getPosition);
                                                } else {
                                                    // x.innerHTML = "Geolocation is not supported by this browser.";
                                                }
                                            }
                                            function getPosition(position) {
                                                var minlatitude = position.coords.latitude;
                                                var minlongitude = position.coords.longitude;
                                                var url = "atrc.aspx?ml=" + Enpt(minlatitude) + "&mxl=0&mlg=" + Enpt(minlongitude) + "&mxlg=0&Mode=NEARBY&Date=<%=strDate%>&Time=<%=strTime%>";
                                                window.location.href = url;
                                            }
                                        </script>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:TextBox ID="txtTO" runat="server" placeholder="To Place"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-icons">
                                        <div class="input-field col s6">
                                            <i class="material-icons icon">date_range</i>
                                            <input type="text" id="from" name="checkin" runat="server" placeholder="Date" readonly />
                                        </div>
                                    </div>
                                    <div class="input-field col s6">
                                        <input type="text" id="timepicker" runat="server" placeholder="Time" readonly />
                                        <script>
                                            $('#ContentPlaceHolder1_timepicker').timepicker(
                                                {
                                                    icons: {
                                                        rightIcon: '<i class="material-icons icon">access_time</i>'
                                                    }
                                                });
                                        </script>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="input-field col s6">
                                        <asp:DropDownList ID="drpperson" runat="server">
                                            <asp:ListItem Text="Person" Value=""></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="input-field col s6">
                                        <asp:DropDownList ID="drphour" runat="server">
                                            <asp:ListItem Text="Hour" Value=""></asp:ListItem>
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="input-field col s12">
                                        <asp:Button ID="btnSearchRestChair" runat="server" CssClass="waves-effect waves-light tourz-sear-btn v2-ser-btn" Text="Search" OnClientClick="return ValidateSearch();" OnClick="btnSearchRestChair_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rows pad-bot-redu tb-space">
            <div class="container">
                <div class="spe-title">
                    <h2>Trending <span>Short Stay Destinations</span></h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                </div>
                <div>
                    <asp:Repeater ID="rptSD" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 col-sm-6 col-xs-12 b_packages">
                                <%--   <div class="band">
                            <img src="images/band.png" alt="" />
                        </div>--%>
                                <div class="v_place_img">
                                    <img src="/ATRCImages/<%# Eval("NewImageName") %>" alt="Rest Chair ATRC" title="Rest Chair ATRC" />
                                </div>
                                <div class="b_pack rows">
                                    <div class="col-md-8 col-sm-8">
                                        <h4><a href="Profile.aspx?aid=<%# new JSEDS().Encrypt(Eval("ATRCId").ToString()) %>"><%# Eval("ATRCName") %></a></h4>
                                    </div>
                                    <div class="col-md-4 col-sm-4 pack_icon">
                                        <ul>
                                            <li>
                                                <img src="images/clock.png" alt="Date" title="Dining From: <%# Eval("DiningFromTime") %> Dining To:<%# Eval("DiningToTime") %>" />
                                            </li>
                                            <li>
                                                <a href="profile.aspx?aid=<%# new JSEDS().Encrypt(Eval("ATRCId").ToString()) %>">
                                                    <img src="images/info.png" alt="Details" title="View more details" />
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
        <div class="tb-space tour-consul">
            <div class="container">
                <div class="col-md-6">
                    <span class="to-con-1">BOOK REST CHAIR NOW!</span>
                    <h2>Take Rest on Highway! Book REST-CHAIR by JUSTSTAY</h2>
                    <p>Are you travel on highway side and want to take rest for an hour. Book your rest chair by Just Stay. Enjoy your stay.</p>
                    <span class="to-con-2">Help line: +91 79 72 56 00 68</span>
                    <div class="ho-con-cont">
                        <a class="to-con-3 link-btn" onclick="getNear();">Book Rest Chair Now</a>
                        <a href="contact.aspx" class="to-con-4 link-btn">Contact Now</a>
                    </div>
                </div>
                <div class="col-md-6 ho-vid">
                    <img src="images/gettouch.jpg" alt="" />
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rows pla pad-bot-redu tb-space">
            <div class="pla1 p-home container">
                <div class="spe-title spe-title-1">
                    <h2>Why to Book with <span>Just Stay</span></h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                </div>
                <div class="popu-places-home">
                    <div class="col-md-6 col-sm-6 col-xs-12 place">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <i class="fa fa-money icon-large" style="font-size: 150px; color: #EF5555;"></i>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <h3><span>Booking Cost</span></h3>
                            <p>Lowest &amp; Same booking cost for 24 hours guaranteed.</p>
                        </div>
                    </div>
                    <!-- POPULAR PLACES 2 -->
                    <div class="col-md-6 col-sm-6 col-xs-12 place">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <i class="fa fa-bed icon-large" style="font-size: 150px; color: #EF5555;"></i>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <h3><span>Best Staying Options</span></h3>
                            <p>Best in class staying option designed by JustStay <sub>TM</sub></p>
                        </div>
                    </div>
                </div>
                <div class="popu-places-home">

                    <div class="col-md-6 col-sm-6 col-xs-12 place">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <i class="fa fa-android icon-large" style="font-size: 150px; color: #EF5555;"></i>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <h3><span>Android App Support</span></h3>
                            <p>Hustle-free booking through android application.</p>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12 place">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <i class="fa fa-clock-o icon-large" style="font-size: 150px; color: #EF5555;"></i>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <h3><span>Hourly Booking </span></h3>
                            <p>Booking on hourly basis</p>
                        </div>
                    </div>
                </div>
                <div class="popu-places-home">

                    <div class="col-md-6 col-sm-6 col-xs-12 place">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <i class="fa fa-shield icon-large" style="font-size: 150px; color: #EF5555;"></i>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <h3><span>High Security</span></h3>
                            <p>100% safety &amp; Security 24X7 assistance</p>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12 place">
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <i class="fa fa-cutlery icon-large" style="font-size: 150px; color: #EF5555;"></i>
                        </div>
                        <div class="col-md-6 col-sm-12 col-xs-12">
                            <h3><span>Food &amp; Snacks</span></h3>
                            <p>Medical, mechanical, food &amp; snacks, Massage Facility and much more.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="foot-mob-sec tb-space">
            <div class="rows container">

                <div class="col-md-6 col-sm-6 col-xs-12 family">
                    <img src="images/android.jpg" alt="" />
                </div>

                <div class="col-md-6 col-sm-6 col-xs-12">

                    <div class="foot-mob-app">
                        <h2>Have you tried our mobile app?</h2>
                        <p>World's leading rest chair and hotel Booking website. Book rest chair on highway and enjoy your stay with distinctive experience</p>
                        <ul>
                            <li><i class="fa fa-check" aria-hidden="true"></i>Easy Rest Chair Booking</li>
                            <li><i class="fa fa-check" aria-hidden="true"></i>Easy Hotel Booking</li>
                            <li><i class="fa fa-check" aria-hidden="true"></i>Easy EV Charging Station Booking</li>
                            <li><i class="fa fa-check" aria-hidden="true"></i>Distinctive Experience</li>
                            <li><i class="fa fa-check" aria-hidden="true"></i>Reviews and Ratings</li>
                            <li><i class="fa fa-check" aria-hidden="true"></i>Manage your Bookings, Enquiry and Reviews</li>
                        </ul>
                        <a href="#">
                            <img src="images/android.png" alt="" />
                        </a>
                        <%-- <a href="#">
                            <img src="images/apple.png" alt="">
                        </a>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:HiddenField ID="hdnfr" runat="server" Value="" />
    <asp:HiddenField ID="hdnto" runat="server" Value="" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDdzuo_Q2vv97O3DJkjxSQl7VwFMsPys-k&libraries=places"></script>
    <script>
        var input = document.getElementById('ContentPlaceHolder1_txtfrom');
        if (input != "" && input != null) {
            var autocomplete = new google.maps.places.Autocomplete(input, { types: ['(cities)'], componentRestrictions: { country: "in" } });
            google.maps.event.addListener(autocomplete, 'place_changed', function () {
                var place = autocomplete.getPlace();
                $("#" + '<%=hdFromLat.ClientID%>').val(place.geometry.location.lat());
               $("#" + '<%=hdFromLng.ClientID%>').val(place.geometry.location.lng());
               $("#" + '<%=hdnfr.ClientID%>').val(place.formatted_address);
           });
        }

        var inputTo = document.getElementById('ContentPlaceHolder1_txtTO');
        if (inputTo != null && inputTo != "") {
            var autocompleteTo = new google.maps.places.Autocomplete(inputTo, { types: ['(cities)'], componentRestrictions: { country: "in" } });
            google.maps.event.addListener(autocompleteTo, 'place_changed', function () {
                var toPlace = autocompleteTo.getPlace();
                $("#" + '<%=hdToLat.ClientID%>').val(toPlace.geometry.location.lat());
               $("#" + '<%=hdToLng.ClientID%>').val(toPlace.geometry.location.lng());
               $("#" + '<%=hdnto.ClientID%>').val(toPlace.formatted_address);
           });
        }
    </script>
    <script>
        $(document).ready(function () {
            $('#ContentPlaceHolder1_txtfrom').on('change', function () {
                var txtfr = $("#ContentPlaceHolder1_txtfrom").val();
                var hdnfr = $("#ContentPlaceHolder1_hdnfr").val();
                if (txtfr != hdnfr) {
                    $("#ContentPlaceHolder1_txtfrom").val('');
                }
                else {
                    $("#ContentPlaceHolder1_txtfrom").val(hdnfr)
                }
            });
            $('#ContentPlaceHolder1_txtTO').on('change', function () {
                var txtto = $("#ContentPlaceHolder1_txtTO").val();
                var hdnto = $("#ContentPlaceHolder1_hdnto").val();
                if (txtto != hdnto) {
                    $('#ContentPlaceHolder1_txtTO').val('');
                }
                else {
                    $("#ContentPlaceHolder1_txtTO").val(hdnto)
                }
            });
        });
        function ValidateSearch() {
            var isValid = true;
            $("#ContentPlaceHolder1_txtfrom,#ContentPlaceHolder1_txtTO,#ContentPlaceHolder1_from,#ContentPlaceHolder1_timepicker,#ContentPlaceHolder1_drpperson").each(function () {
                if ($.trim($(this).val()) == "" || $.trim($(this).val()) == null) {
                    isValid = false;
                    $(this).css({
                        "border": "0.5px solid #EF5555"
                    });
                }
                else {
                    $(this).css({
                        "border": ""
                    });
                }
            });

            return isValid;
        }
    </script>
</asp:Content>
