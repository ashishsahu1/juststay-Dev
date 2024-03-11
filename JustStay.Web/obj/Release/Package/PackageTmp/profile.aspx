<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="profile.aspx.cs" Inherits="JustStay.Web.profile" %>

<asp:Content ID="cphprofile" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:HiddenField ID="hdLat" runat="server" Value="0" />
    <asp:HiddenField ID="hdLng" runat="server" Value="0" />
    <asp:HiddenField ID="hdnstar" runat="server" Value="0" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDdzuo_Q2vv97O3DJkjxSQl7VwFMsPys-k&libraries=places"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <section>
        <div class="rows inner_banner inner_banner_2">
            <div class="container">
                <h2><span><%=stratrcname %></span></h2>
                <ul>
                    <li><a href="home.aspx">Home</a>
                    </li>
                    <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                    <li><a href="#" class="bread-acti">ATRC Profile</a>
                    </li>
                </ul>
                <p><%=straddress %></p>
            </div>
        </div>
    </section>
    <section>
        <div class="rows banner_book" id="inner-page-title">
            <div class="container">
                <div class="banner_book_1">
                    <ul>
                        <li class="dl1"><%=strDate %></li>
                        <li class="dl2"><%=strTime %></li>
                        <li class="dl3"><%=strhour %></li>
                        <li class="dl4">
                            <asp:LinkButton ID="lnkbook" runat="server" OnClick="lnkbook_Click" CssClass="waves-effect waves-light tourz-sear-btn" Text="Book Now"></asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rows inn-page-bg com-colo">
            <div class="container inn-page-con-bg tb-space">
                <div class="col-md-9">

                    <div class="tour_head">
                        <h2><%=stratrcname %> 
                            <span class="tour_star">
                               <%-- <i class="fa fa-star" aria-hidden="true"></i>
                                <i class="fa fa-star" aria-hidden="true"></i>
                                <i class="fa fa-star" aria-hidden="true"></i>
                                <i class="fa fa-star" aria-hidden="true"></i>
                                <i class="fa fa-star-half-o" aria-hidden="true"></i>--%>
                                <%=rate %>
                            </span><span class="tour_rat"><asp:Label ID="lblrating" runat="server"></asp:Label></span></h2>
                    </div>

                    <div class="tour_head1 hotel-com-color">
                        <h3>About <%=stratrcname %> </h3>
                        <p><%=strabout %></p>
                    </div>
                    <div class="tour_head1">
                        <p>
                            <a data-toggle="modal" data-target="#mapmodel"><i class="fas fa-map" title="map"></i>View in map
                            </a>&nbsp;&nbsp; / &nbsp;&nbsp;
                           <a target="_blank" href="https://www.google.com/maps?saddr=My+Location&daddr=<%= GeoName %>"><i class="fas fa-map-marker-alt" style="color: #0a63ef;"></i>Get Direction
                           </a>&nbsp;&nbsp; / &nbsp;&nbsp;
                            <a href="tel:<%=mobileNumber %>"><i class="fa fa-mobile" aria-hidden="true" title="mobile"></i><%=mobileNumber %>
                            </a>
                        </p>
                    </div>
                    <div class="tour_head1 hotel-book-room">
                        <h3>Photo Gallery</h3>
                        <div id="myCarousel1" class="carousel slide" data-ride="carousel">
                            <ol class="carousel-indicators carousel-indicators-1">
                                <asp:Repeater ID="rptatrcimage" runat="server">
                                    <ItemTemplate>
                                        <li data-target="#myCarousel1" data-slide-to="<%# Eval("ATRCImageId") %>">
                                            <img src="/ATRCImages/<%# Eval("NewImageName") %>" alt="<%# Eval("NewImageName") %>">
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ol>

                            <div class="carousel-inner carousel-inner1" role="listbox">
                                <div class="item active">
                                    <img src="/ATRCImages/<%# Eval("ImageName") %>" alt="<%# Eval("ImageName") %>" width="460" height="345" />
                                </div>
                                <asp:Repeater ID="rptinnerimages" runat="server">
                                    <ItemTemplate>
                                        <div class="item">
                                            <img src="/ATRCImages/<%# Eval("NewImageName") %>" alt="<%# Eval("NewImageName") %>" width="460" height="345">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <a class="left carousel-control" href="#myCarousel1" role="button" data-slide="prev"><span><i class="fa fa-angle-left hotel-gal-arr" aria-hidden="true"></i></span></a>
                            <a class="right carousel-control" href="#myCarousel1" role="button" data-slide="next"><span><i class="fa fa-angle-right hotel-gal-arr hotel-gal-arr1" aria-hidden="true"></i></span></a>
                        </div>
                    </div>
                    <div class="tour_head1 hot-ameni">
                        <h3>Hotel Amenities</h3>
                        <ul><%=ATRCAmenities %></ul>
                    </div>
                    <div class="tour_head1 tout-map map-container">
                        <h3>Location</h3>
                        <div id="mapinner" style="height: 300px;"></div>
                    </div>

                    <div class="tour_head1 hot-ameni features">
                        <h3>Dinning Facility</h3>
                        <p><%=dinningfacility %></p>
                        <p><strong>Dining Time From:</strong>  &nbsp; <%=dinningfrom %></p>
                        <p><strong>Dining Time To:</strong>&nbsp; <%=dinningto %></p>
                    </div>
                    <div class="tour_head1 hot-ameni features">
                        <h3>Cuisines</h3>
                        <%=Cuisines %>
                    </div>
                    <div class="tour_head1 hot-ameni features">
                        <h3>Highlights</h3>
                        <%=Highlights %>
                    </div>

                    <div class="tour_head1 hot-ameni">
                        <h3>Contact</h3>
                        Customer Care:&nbsp; <a href="tel:+91 7972560068"><i class="fa fa-mobile"></i>&nbsp;&nbsp;+91 79 72 56 00 68</a>
                    </div>
                    <%-- <asp:UpdatePanel ID="uprating" runat="server">
                        <ContentTemplate>--%>
                    <div>
                        <div class="dir-rat">
                            <asp:Repeater ID="rptrating" runat="server">
                                <ItemTemplate>
                                    <div class="dir-rat-inn dir-rat-review">
                                        <div class="row">
                                            <div class="col-md-3 dir-rat-left">
                                                <img src="images/reviewer/4.jpeg" alt="">
                                                <p><%# Eval("Name") %><span><%# Eval("InsertedOn", "{0:MMMM d, yyyy}") %></span> </p>
                                            </div>
                                            <div class="col-md-9 dir-rat-right">
                                                <div class="dir-rat-star">
                                                 <%--   <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star-o" aria-hidden="true"></i>--%>
                                                    <%# StrRteting(Convert.ToInt32(Eval("Star"))) %>
                                                </div>
                                                <p><%# Eval("Description") %></p>
                                                <%--<ul>
                                            <li><a href="#"><span>Like</span><i class="fa fa-thumbs-o-up" aria-hidden="true"></i></a> </li>
                                            <li><a href="#"><span>Dis-Like</span><i class="fa fa-thumbs-o-down" aria-hidden="true"></i></a> </li>
                                            <li><a href="#"><span>Report</span> <i class="fa fa-flag-o" aria-hidden="true"></i></a></li>
                                            <li><a href="#"><span>Comments</span> <i class="fa fa-commenting-o" aria-hidden="true"></i></a></li>
                                            <li><a href="#"><span>Share Now</span>  <i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                            <li><a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
                                            <li><a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                            <li><a href="#"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>
                                            <li><a href="#"><i class="fa fa-youtube" aria-hidden="true"></i></a></li>
                                        </ul>--%>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="dir-rat-inn dir-rat-title">
                                <h3>Give rateing & Write Your Reviews Here...</h3>
                                <p>Your review's is very important to us. Give us reviews.</p>
                                <div class="rating-stars">
                                    <input type="radio" name="stars" id="star-null" />
                                    <input type="radio" name="stars" id="star-1" saving="1" data-start="1" checked="checked" onclick="rate(1);" />
                                    <input type="radio" name="stars" id="star-2" saving="2" data-start="2" checked="checked" onclick="rate(2);" />
                                    <input type="radio" name="stars" id="star-3" saving="3" data-start="3" checked="checked" onclick="rate(3);" />
                                    <input type="radio" name="stars" id="star-4" saving="4" data-start="4" checked="checked" onclick="rate(4);" />
                                    <input type="radio" name="stars" id="star-5" saving="5" checked="checked" onclick="rate(5);" />
                                    <section>
                                        <label for="star-1">
                                            <svg width="255" height="240" viewBox="0 0 51 48">
                                                <path d="m25,1 6,17h18l-14,11 5,17-15-10-15,10 5-17-14-11h18z"></path>
                                            </svg>
                                        </label>
                                        <label for="star-2">
                                            <svg width="255" height="240" viewBox="0 0 51 48">
                                                <path d="m25,1 6,17h18l-14,11 5,17-15-10-15,10 5-17-14-11h18z"></path>
                                            </svg>
                                        </label>
                                        <label for="star-3">
                                            <svg width="255" height="240" viewBox="0 0 51 48">
                                                <path d="m25,1 6,17h18l-14,11 5,17-15-10-15,10 5-17-14-11h18z"></path>
                                            </svg>
                                        </label>
                                        <label for="star-4">
                                            <svg width="255" height="240" viewBox="0 0 51 48">
                                                <path d="m25,1 6,17h18l-14,11 5,17-15-10-15,10 5-17-14-11h18z"></path>
                                            </svg>
                                        </label>
                                        <label for="star-5">
                                            <svg width="255" height="240" viewBox="0 0 51 48">
                                                <path d="m25,1 6,17h18l-14,11 5,17-15-10-15,10 5-17-14-11h18z"></path>
                                            </svg>
                                        </label>
                                    </section>
                                </div>
                            </div>
                            <div class="dir-rat-inn">
                                <div class="dir-rat-form">
                                    <div class="form-group col-md-6 pad-left-o">
                                        <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ControlToValidate="txtname" SetFocusOnError="true" ValidationGroup="rate"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6 pad-left-o">
                                        <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" placeholder="Enter Mobile" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtmobile" runat="server" ControlToValidate="txtmobile" SetFocusOnError="true" ValidationGroup="rate"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6 pad-left-o">
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server" ControlToValidate="txtemail" SetFocusOnError="true" ValidationGroup="rate"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-6 pad-left-o">
                                        <asp:TextBox ID="txtcity" runat="server" CssClass="form-control" placeholder="Enter City" MaxLength="30"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtcity" runat="server" ControlToValidate="txtcity" SetFocusOnError="true" ValidationGroup="rate"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-12 pad-left-o">
                                        <asp:TextBox ID="txtmsg" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="200" placeholder="Enter Message Here."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtmsg" runat="server" ControlToValidate="txtmsg" SetFocusOnError="true" ValidationGroup="rate"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-12 pad-left-o">
                                        <asp:LinkButton ID="lnksubmit" runat="server" CausesValidation="true" ValidationGroup="rate" CssClass="link-btn" OnClick="lnksubmit_Click" Text="Submit"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--   </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div class="col-md-3 tour_r">
                    <div class="tour_right tour_offer" style="display: none;">
                        <div class="band1">
                            <img src="images/offer.png" alt="" />
                        </div>
                        <p>Special Offer</p>
                        <h4>Rs.20<span class="n-td">
                            <span class="n-td-1">Rs.80</span>
                        </span>
                        </h4>
                        <a href="book.aspx?aid=<%= Request.QueryString["aid"] %>" class="link-btn">Book Now</a>
                    </div>

                    <div class="tour_right tour_incl tour-ri-com" id="binfopanel" runat="server" visible="false">
                        <h3>Booking Information</h3>
                        <ul>
                            <li><%=strfrom %></li>
                            <li><%=strto %></li>
                            <li><%=strDate %></li>
                            <li><%=strTime %></li>
                            <li><%=strhour %></li>
                        </ul>
                    </div>

                    <div class="tour_right head_right tour_social tour-ri-com" style="display: none;">
                        <h3>Share This ATRC</h3>
                        <ul>
                            <li><a href="https://www.facebook.com/dialog/share?app_id=145634995501895&display=popup&href=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2F&redirect_uri=https%3A%2F%2Fdevelopers.facebook.com%2Ftools%2Fexplorer" target="_blank"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                            <li><a href="#"><i class="fa fa-whatsapp" aria-hidden="true"></i></a></li>
                        </ul>
                    </div>

                    <div class="tour_right head_right tour_help tour-ri-com">
                        <h3>Help & Support</h3>
                        <div class="tour_help_1">
                            <h4 class="tour_help_1_call">Call Us Now</h4>
                            <h4><i class="fa fa-phone" aria-hidden="true"></i>+91 7972560068</h4>
                        </div>
                    </div>

                    <div class="tour_right tour_rela tour-ri-com" style="display: none;">
                        <h3>Popular ATRC</h3>
                        <%-- <div class="tour_rela_1">
                            <img src="images/related1.png" alt="" />
                            <h4>Dubai 7Days / 6Nights</h4>
                            <p>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text</p>
                            <a href="#" class="link-btn">View this Package</a>
                        </div>
                        <div class="tour_rela_1">
                            <img src="images/related2.png" alt="" />
                            <h4>Mauritius 4Days / 3Nights</h4>
                            <p>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text</p>
                            <a href="#" class="link-btn">View this Package</a>
                        </div>
                        <div class="tour_rela_1">
                            <img src="images/related3.png" alt="" />
                            <h4>India 14Days / 13Nights</h4>
                            <p>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text</p>
                            <a href="#" class="link-btn">View this Package</a>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="modal fade contact__form v2-search-form" id="modelsearch" tabindex="-1" role="dialog" style="top:0%;padding-top:100px;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"
                        data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="searchmodelheader">Just Stay
                    </h4>
                </div>
                <div class="modal-body">
                    <label for="from">Check In</label>
                    <input type="text" id="from" name="checkin" class="input-field" runat="server" readonly />
                    <br />
                    <label for="from">Time</label>
                    <input type="text" id="timepicker" class="input-field" runat="server" readonly />
                    <script>
                        $('#ContentPlaceHolder1_timepicker').timepicker({
                            icons: {
                                rightIcon: '<i class="material-icons"><i class="fa fa-clock-o" aria-hidden="true"></i></i>'
                            }
                        });
                    </script>
                    <br />
                    <asp:DropDownList ID="drpperson" runat="server" class="input-field select-wrapper">
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
                    <br />
                    <asp:DropDownList ID="drphour" runat="server" class="input-field select-wrapper">
                        <asp:ListItem Text="Hour" Value=""></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSearchRC" runat="server" CssClass="waves-effect waves-light tourz-sear-btn v2-ser-btn" Text="Continue Booking" OnClientClick="return ValidateSearch();" OnClick="btnSearchRC_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade contact__form v2-search-form" id="ratingpopup" tabindex="-1" role="dialog"
        aria-labelledby="searchmodelheader" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"
                        data-dismiss="modal">
                        <span aria-hidden="true">&times;</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h4 class="modal-title" id="ratingmodelheader">Just Stay
                    </h4>
                </div>
                <div class="modal-body">
                    <h2>Thank You.</h2>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="mapmodel" tabindex="-1" role="dialog" aria-labelledby="mapmodellable" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div id="map" style="height: 340px;"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery-ui.js"></script>
    <script>
        var map;
        var mapinner;
        function initMap() {
            debugger;
            var myLatlng = new google.maps.LatLng(parseFloat($("#<%=hdLat.ClientID%>").val()), parseFloat($("#<%=hdLng.ClientID%>").val()));
           map = new google.maps.Map(document.getElementById('map'), {
               center: myLatlng,
               zoom: 17
           });
           mapinner = new google.maps.Map(document.getElementById('mapinner'), {
               center: myLatlng,
               zoom: 17
           });

           var marker = new google.maps.Marker({
               position: myLatlng,
               title: '<%=stratrcname %>'
                });

            marker.setMap(map);
            marker.setMap(mapinner);
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            initMap();
            google.maps.event.trigger(map, 'resize');
            google.maps.event.trigger(mapinner, 'resize');
        });
        function rate(evt) {
            var star = evt;
            $('#ContentPlaceHolder1_hdnstar').val(star);
        }
        function showRatingModal() {
            $('.modal').modal();
            $('#ratingpopup').modal('open');
            $('.trigger-modal').modal();
        }
    </script>
    <script>
        function ShowPopup() {
            $('.modal').modal();
            $('#modelsearch').modal('open');
            $('.trigger-modal').modal();
        }
    </script>
</asp:Content>
