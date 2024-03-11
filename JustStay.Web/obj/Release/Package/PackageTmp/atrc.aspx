<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="atrc.aspx.cs" Inherits="JustStay.Web.atrc" %>

<asp:Content ID="chpatrc" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:HiddenField ID="hdFromLat" runat="server" />
    <asp:HiddenField ID="hdFromLng" runat="server" />
    <asp:HiddenField ID="hdnatrcid" runat="server" Value="0" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDdzuo_Q2vv97O3DJkjxSQl7VwFMsPys-k&libraries=places"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/gijgo.min.js" type="text/javascript"></script>
    <link href="css/gijgo.min.css" rel="stylesheet" type="text/css" />
    <section class="hot-page2-alp hot-page2-pa-sp-top all-hot-bg">
        <div class="container">
            <div class="row inner_banner inner_banner_3 bg-none">
                <div class="hot-page2-alp-tit">
                    <h1>Any Time Refreshment Centers (REST CHAIRS ATRC)</h1>
                    <ul>
                        <li><a href="home.aspx">Home</a> </li>
                        <li><i class="fa fa-angle-right" aria-hidden="true"></i></li>
                        <li><a href="atrc.aspx" class="bread-acti">ATRC</a> </li>
                    </ul>
                    <p>Take Rest on Rest Chair by hourly basis</p>
                </div>
            </div>
            <div class="row">
                <div class="hot-page2-alp-con">
                    <div class="col-md-3 hot-page2-alp-con-left">
                        <div class="hot-page2-alp-con-left-1">
                            <h3>Sort By</h3>
                        </div>
                        <div class="hot-page2-hom-pre hot-page2-alp-left-ner-notb divSorting">
                            <ul>
                                <li>
                                    <a href="javascript:void(0)" data-sort-by="veg">
                                        <div class="hot-page2-hom-pre-1 hot-page2-alp-cl-1-1">
                                            <img src="images/veg.png" alt="" />
                                        </div>
                                        <div class="hot-page2-hom-pre-2 hot-page2-alp-cl-1-2">
                                            <h5>Pure Veg</h5>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)" data-sort-by="nonveg">
                                        <div class="hot-page2-hom-pre-1 hot-page2-alp-cl-1-1">
                                            <img src="images/nonveg.png" alt="" />
                                        </div>
                                        <div class="hot-page2-hom-pre-2 hot-page2-alp-cl-1-2">
                                            <h5>Non Veg</h5>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)" data-sort-by="both">
                                        <div class="hot-page2-hom-pre-1 hot-page2-alp-cl-1-1">
                                            <img src="images/veg.png" alt="" />
                                            <img src="images/nonveg.png" alt="" />
                                        </div>
                                        <div class="hot-page2-hom-pre-2 hot-page2-alp-cl-1-2">
                                            <h5>Both</h5>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="hot-page2-alp-l3 hot-page2-alp-l-com divAmentities">
                            <h4><i class="fa fa-heart-o" aria-hidden="true"></i>Hotel Amenities</h4>
                            <div class="hot-page2-alp-l-com1 hot-page2-alp-p5">
                                <div class="divAmentities">
                                    <asp:Repeater ID="rptaminities" runat="server">
                                        <ItemTemplate>
                                            <ul>
                                                <li>
                                                    <div>
                                                        <input id="<%# Eval("Value") %>" class="styled" type="checkbox" value="<%# Eval("Value") %>">
                                                        <%# Eval("Text") %>
                                                    </div>
                                                </li>
                                            </ul>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9 hot-page2-alp-con-right">
                        <div class="hot-page2-alp-con-right-1">
                            <div class="row">
                                <div id="divATRC">
                                    <asp:Repeater runat="server" ID="rptatrcsearch">
                                        <ItemTemplate>
                                            <div class="hot-page2-alp-r-list grid-item <%# Eval("AmtForFilter")%>">
                                                <div class="col-md-3 hot-page2-alp-r-list-re-sp">
                                                    <a href="javascript:void(0);">
                                                        <div class="hot-page2-hli-1">
                                                            <img src="/ATRCImages/<%# Eval("ProfileImageNewName")%>" alt="">
                                                        </div>
                                                        <div class="hom-hot-av-tic hom-hot-av-tic-list">Available Chair: <%# Eval("AvailableChair") %> </div>
                                                    </a>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="hot-page2-alp-ri-p2">
                                                        <asp:LinkButton ID="lnkView" OnClientClick="SetTarget();" runat="server" OnClick="lnkviewprofile_Click" CommandArgument='<%# Eval("ATRCId")%>'><h3><%# Eval("ATRCName") %></h3></asp:LinkButton>
                                                        <ul>
                                                            <li><%#Eval("Address") %></li>
                                                            <li><%#Eval("Mobile") %></li>
                                                            <li><%# Eval("Details") %></li>
                                                            <li>
                                                                <%#SetDinings(int.Parse(Eval("DiningFacility").ToString())) %>
                                                            </li>
                                                        </ul>
                                                        <label class="geoname" style="display: none;"><%# Eval("GeoLocationName") %></label>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="hot-page2-alp-ri-p3">
                                                        <div class="hot-page2-alp-r-hot-page-rat"><%# Eval("Ratings") %></div>
                                                        <span class="hot-list-p3-1">One hour rate</span> <span class="hot-list-p3-2">RS.<%# Eval("BasicPrice")%></span>
                                                        <span class="hot-list-p3-1">Available Chair: &nbsp;<%# Eval("AvailableChair") %><br />
                                                            Booked Chair: &nbsp; <%# Eval("BookedChair") %>
                                                        </span>
                                                        <span class="hot-list-p3-4">
                                                            <asp:LinkButton OnClientClick="document.forms[0].target = '_blank';" ID="lnkviewprofile" runat="server" OnClick="lnkviewprofile_Click" CommandArgument='<%# Eval("ATRCId")%>' class="hot-page2-alp-quot-btn">Explore</asp:LinkButton>

                                                            <asp:LinkButton ID="lnkViewDetails" runat="server" OnClick="lnkViewDetails_Click" CommandArgument='<%# Eval("ATRCId")%>' class="hot-page2-alp-quot-btn">Book Now</asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-xs-12 col-sm-12 col-md-12">
                                                    <div class="divDistance">
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div>
                                    <asp:Label ID="lblNoDataFound" runat="server" Visible="false" Text="No ATRC Found.."></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <div class="modal fade contact__form v2-search-form" id="modelsearch" tabindex="-1" role="dialog" style="padding-top: 50px;"
        aria-labelledby="searchmodelheader">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close"
                        data-dismiss="modal">
                        <span aria-hidden="true">&times;</span>
                        <span class="sr-only">Close</span>
                    </button>
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

    <script src="js/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
            // SetSearchFields();
            var $container = $('#divATRC'),
                $checkboxes = $('.divAmentities input');

            $container = $container.isotope({
                itemSelector: '.grid-item',
                getSortData: {
                    veg: '.veg',
                    nonveg: '.nonveg',
                    both: '.both'
                }
            });

            $('.divSorting').on('click', 'a', function () {
                var sortByValue = $(this).attr('data-sort-by');
                $container.isotope({ sortBy: sortByValue, sortAscending: false });
            });

            $checkboxes.change(function () {
                var filters = [];

                $checkboxes.filter(':checked').each(function () {
                    filters.push(this.value);
                });

                filters = filters.join(', ');
                $container.isotope({ filter: filters });
            });

            GeDistance();
        });

    </script>

    <script>
        function GeDistance() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    console.log("Lat " + position.coords.latitude);
                    console.log("Lng " + position.coords.longitude);
                    $("#" + '<%=hdFromLat.ClientID%>').val(position.coords.latitude);
                    $("#" + '<%=hdFromLng.ClientID%>').val(position.coords.longitude);
                    CalculateDistace(position.coords.latitude, position.coords.longitude);
                });
            } else {
                div1.html('Geolocation is not supported by this browser.');
                //document.getElementById("Label1").value = "Geolocation is not supported by this browser.";
            }

        }

        function CalculateDistace(latitude, longitude) {
            var origin = { lat: latitude, lng: longitude };
            var destination = '';

            $('div.grid-item', '#divATRC').each(function () {
                destination = $(this).find('.geoname').text();
                var div1 = $(this).find('.divDistance');
                debugger;

                var service = new google.maps.DistanceMatrixService;
                service.getDistanceMatrix({
                    origins: [origin],
                    destinations: [destination],
                    travelMode: 'DRIVING',
                    unitSystem: google.maps.UnitSystem.METRIC,
                    avoidHighways: false,
                    avoidTolls: false
                }, function (response, status) {
                    if (status !== 'OK') {
                        alert('Error was: ' + status);
                    } else {
                        div1.html('Distance from you - ' + response.rows[0].elements[0].distance.text + ' in ' + response.rows[0].elements[0].duration.text);
                    }
                });

            });
        }
    </script>
    <script>
        function SetTarget() {
            document.forms[0].target = "_blank";
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
