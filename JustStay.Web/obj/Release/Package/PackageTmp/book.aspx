<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="book.aspx.cs" Inherits="JustStay.Web.book" %>

<asp:Content ID="chpbook" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:HiddenField ID="hdnhtml" Value="" runat="server" />
    <asp:HiddenField ID="hdntotalcost" runat="server" Value="0" />
    <asp:HiddenField ID="hdnselectedchair" runat="server" Value="" />
    <asp:HiddenField ID="hdnchairarray" runat="server" Value="" />
    <asp:HiddenField ID="hdnrcbid" runat="server" Value="0" />
    <asp:HiddenField ID="hdnrcpaymentid" runat="server" Value="0" />
    <asp:HiddenField ID="hdnorderid" runat="server" Value="0" />
     <asp:HiddenField ID="hdnfromtime" runat="server" Value="0" />
      <asp:HiddenField ID="hdndate" runat="server" Value="" />
    <section>
        <div class="search-top">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="search-form">
                            <div class="main-header">
                                  <div class="book-back">
                                         <a onclick="getNear();" id="lnknear" class="waves-effect waves-light">
                                         <img src="images/left-arrow-new.png" />Back</a>
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
                                                var url = "atrc.aspx?ml=" + Enpt(minlatitude) + "&mxl=0&mlg=" + Enpt(minlongitude) + "&mxlg=0&Mode=NEARBY&Date=<%=Request.QueryString["Date"]%>&Time=<%=Request.QueryString["Time"]%>";
                                                window.location.href = url;
                                            }
                                        </script>
                                </div>
                                <div class="book-header">
                                    <%=strDate %>
								 </div>
                                <div class="book-header">
								 <%=strTime %></div>
                                <div class="book-header">
								 <%=strhour %></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="tr-register">
            <div class="tr-regi-form v2-search-form">
                <p>Book your Rest Chair Now!!!!</p>
                <br />
                <div class="contact__form">
                    <div class="alert alert-success contact__msg" style="display: none" role="alert">
                        Thank you for arranging a wonderful trip for us! Our team will contact you shortly!
                    </div>
                    <div class="chair-selection grouping">
                        <div class="type-1">

                            <div class="row">
                                <div class="col-xs-12">
                                    <label class="heading-title">CHAIR SELECTION</label>
                                </div>
                            </div>

                        </div>
                        <div class="type-2">
                            <div class="row">
                                <div style="float: right;">

                                    <span class="status unbooked">
                                        <i class="fas fa-chair"></i>Available
                                    </span>
                                    <span class="status booked">
                                        <i class="fas fa-chair"></i>Booked &nbsp;&nbsp;
                                    </span>
                                </div>
                            </div>
                            <div class="row" id="myrpt">
                                <asp:Repeater ID="rptrestchairtypes" runat="server">
                                    <ItemTemplate>
                                        <div class="col-xs-5 divfirst" id='<%# Eval("ATRCRestChairId") %>'>
                                            <label><%# Eval("Name") %></label>
                                        </div>
                                        <div class="col-xs-7 cos">
                                            <input id="hdncost" runat="server" type="hidden" class="clscost" value='<%#Eval("Price")%>' />
                                            <asp:Label ID="lblchair" runat="server" Text='<%# Eval("Restchair") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="row mb20">
                            <div class="col-xs-4 col-sm-3">
                                Total Cost
                            </div>
                            <div class="col-xs-8 col-sm-9">
                                <label class="totalhrs">
                                    <asp:Label ID="lblhr" runat="server"></asp:Label>
                                    hr  
                                </label>
                                <label class="totalrs">
                                    <asp:Label ID="lbltotalcost" runat="server"></asp:Label>
                                    RS 
                                                        <span class="viewDetails" title="view details">details <i class="down-arrow"></i></span>
                                </label>
                                <table class="table costdetailsTable" id="tblbooking">
                                    <tr>
                                        <td colspan="3">(*Including all taxes)</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <table class="table price-table" id="tblchairbooking" runat="server">
                            <tbody>
                                <tr>
                                    <td>Chair Charges</td>
                                    <td>RS.&nbsp;<asp:Label ID="lblchairchagre" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Discount</td>
                                    <td>0.00</td>
                                </tr>
                                <tr>
                                    <td>Sub Total</td>
                                    <td>RS.&nbsp;<asp:Label ID="lblsubtotal" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>GST (0%)</td>
                                    <td>0.00</td>
                                </tr>
                                <tr>
                                    <td>Convenience fee</td>
                                    <td>0.00</td>
                                </tr>
                                <tr>
                                    <td>Taxes &amp; Fees</td>
                                    <td>0.00</td>
                                </tr>
                                <tr>
                                    <td>Total Amount</td>
                                    <td>RS.&nbsp;<asp:Label ID="lbltotalamt" runat="server"></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <asp:Button ID="btnconfirm" runat="server" OnClick="btnconfirm_Click" OnClientClick="OnBooking();return ValidateBooking();" Text="Continue Pay Online" CssClass="waves-effect waves-light tourz-sear-btn v2-ser-btn" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                          <asp:Button ID="btnpayatrc" runat="server" OnClick="btnpayatrc_Click" OnClientClick="OnBooking();return ValidateBooking();" Text="Pay At ATRC" CssClass="waves-effect waves-light tourz-sear-btn v2-ser-btn" />
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script>
        function BookChair() {
            var lblhr = $("#ContentPlaceHolder1_lblhr").text();
            var currentRow = 0;
            var chairvalue = "";
            var cost = 0;
            var aaryhtml = [];
            var aarychairid = [];
            $('.chairBook input[type=checkbox]').on('change', function (e) {
                if ($(this).is(":checked")) {
                    $(this).next().addClass('book');
                    $(this).attr('checked', 'checked');
                    currentRow = $(this).parents(".cos");
                    chairvalue = $(this).val();
                    cost = currentRow.find('[id*=hdncost]').val();
                    var array = chairvalue.split('_');
                    var sss = lblhr + ' * ' + cost;
                    var strr = '<tr><td>' + array[1].toString() + '</td>' + '<td>' + sss + '</td>' + '<td class="cal">' + parseInt(lblhr) * parseInt(cost) + '</td></tr>';
                    aaryhtml.push(strr);
                    var chairid = $(this).attr("id");
                    aarychairid.push(chairid);

                }
                else if ($(this).is(":not(:checked)")) {
                    $(this).next().removeClass('book');
                    $(this).prop('checked', false);
                    $(this).removeAttr('checked');
                    currentRow = $(this).parents(".cos");
                    chairvalue = $(this).val();
                    cost = currentRow.find('[id*=hdncost]').val();
                    var array = chairvalue.split('_');
                    var sss = lblhr + ' * ' + cost;
                    var strr = '<tr><td>' + array[1].toString() + '</td>' + '<td>' + sss + '</td>' + '<td class="cal">' + parseInt(lblhr) * parseInt(cost) + '</td></tr>';
                    const index = aaryhtml.indexOf(strr);
                    if (index > -1) {
                        aaryhtml.splice(index, 1);
                    }
                    var chairid = $(this).attr("id");
                    const indixchairid = aarychairid.indexOf(chairid);
                    if (indixchairid > -1) {
                        aarychairid.splice(indixchairid, 1);
                    }
                }
                $("#tblbooking").find("tr:gt(0)").remove();
                $('#tblbooking tr:last').after(aaryhtml.join());
                var total = 0;
                $('#tblbooking tr td.cal').each(function () {
                    var amt = $(this).text();
                    total += parseInt(amt);
                });
                $("#ContentPlaceHolder1_lbltotalcost").text(total);
                $("#ContentPlaceHolder1_hdnhtml").val(aaryhtml.join());
                $("#ContentPlaceHolder1_hdntotalcost").val(total);
                $("#ContentPlaceHolder1_lblchairchagre").text(total);
                $("#ContentPlaceHolder1_lblsubtotal").text(total);
                $("#ContentPlaceHolder1_lbltotalamt").text(total);
                $("#ContentPlaceHolder1_hdnselectedchair").val(JSON.stringify(aarychairid));
            })
        }

        function OnBooking() {
            var arraychairid = [];
            $('.chairBook input[type=checkbox]').each(function () {
                if ($(this).is(":checked")) {
                    var chairvalue = $(this).val();
                    var chairid = chairvalue.split('_');
                    arraychairid.push(chairid[0]);
                }
            });
            $("#ContentPlaceHolder1_hdnchairarray").val(arraychairid);
        }

        function ValidateBooking() {
            var strdate = $('#ContentPlaceHolder1_hdndate').val();
            var strtime = $('#ContentPlaceHolder1_hdnfromtime').val();
           // alert(strdate);
            //alert(strtime);
            var dt = new Date();
            var currenttime = dt.getHours() + ":" + dt.getMinutes();
            //alert(currenttime);

            var stt = new Date(strdate + " " + strtime);
            stt = stt.getTime();

            var endt = new Date(dt + " " + currenttime);
            endt = endt.getTime();


            var valid = true;
            var total = $('#ContentPlaceHolder1_hdntotalcost').val();
            if (total == 0) {
                valid = false;
                alert('Please Select Chair to Book!!!');
            }
            else if (stt < endt)
            {
                valid = false;
                alert('Booking time should be greater then current time!!!');
            }
            return valid;
        }


        $(document).ready(function () {
            BookChair();
        })
    </script>

</asp:Content>
