<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="payment.aspx.cs" Inherits="JustStay.Web.payment" %>
<asp:Content ID="chpbook" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <section>
    <div class="search-top">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="search-form">
					 <div class="main-header">
						 <div class="book-header">
							<%=strDate %>
							</div>
							 <div class="book-header">
								  <%=strTime %> 
							</div>
							 <div class="book-header">
                                    <%=strhour %> 
						</div>
                        </div>
                    </div>
                </div>
            </div>
        </div></div>
         </section>
    <section>
        <div class="tr-register">
            <div class="tr-regi-form v2-search-form">
                <p>Make a Payment and Book you Rest Chair Now!!!!</p>
                <br />
                <div class="contact__form">
                    <div class="alert alert-success contact__msg" style="display: none" role="alert">
                        Thank you for arranging a wonderful trip for us! Our team will contact you shortly!
                    </div>
                    <div class="chair-selection grouping">
                        <div class="type-1">

                            <div class="row">
                                <div class="col-xs-12">
                                    <label class="heading-title">PAYMENT DETAILS</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtbname" runat="server" CssClass="validate"></asp:TextBox>
                            <label>Enter your name</label>
                        </div>
                    </div>
                   
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtbmobile" runat="server" CssClass="validate"></asp:TextBox>
                            <label>Enter your mobile</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtbemail" runat="server" CssClass="validate"></asp:TextBox>
                            <label>Enter your email</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <div style="padding-top:10px;font-size:18px;float:left;">
                                 Total Amount: <strong>RS.<%=strtotalcost %></strong>  
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                              
                          
                            <div style="padding-top:10px;font-size:18px;float:left;">
                                  <input type="checkbox" id="chkagree" checked="checked" />
                                	
                                I agree with <a href="termsconditions.aspx" target="_blank">Terms &amp; Condition</a> &nbsp;&nbsp;<a href="privacypolicy.aspx" target="_blank">Privacy Policy</a>
                            </div>
                        </div>
                    </div>
                      
                    <div class="row">
                        <div class="input-field col s12">
                          <asp:Button ID="Button1" runat="server" Text="Pay Online Now" OnClientClick="razorpay(event);" CssClass="waves-effect waves-light tourz-sear-btn v2-ser-btn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <asp:HiddenField ID="hdntotalcost" runat="server" Value="0" />
     <asp:HiddenField ID="hdnorderid" runat="server" Value="0" />
     <asp:HiddenField ID="hdnrcbid" runat="server" Value="0" />
     <asp:HiddenField ID="hdnrcpaymentid" runat="server" Value="0" />
     <asp:HiddenField ID="hdnatrcid" runat="server" Value="0" />

    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/jquery-ui.js"></script>
   
      <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
        <script>
            function ValidateAgreement() {
                var valid = true;
                if ($('#chkagree').is(":not(:checked)")) {
                    valid = false;
                    alert('Please read and agree Terms & Conditions.');
                }
                return valid;
            }
            function razorpay(e)
            {
                if (ValidateAgreement()) {
                    var cost = $('#ContentPlaceHolder1_hdntotalcost').val();
                    var orderid = $('#ContentPlaceHolder1_hdnorderid').val();
                    var name = $('#ContentPlaceHolder1_txtbname').val();
                    var email = $('#ContentPlaceHolder1_txtbemail').val();
                    var mobile = $('#ContentPlaceHolder1_txtbmobile').val();
                    var bid = $('#ContentPlaceHolder1_hdnrcbid').val();
                    var rcpid = $('#ContentPlaceHolder1_hdnrcpaymentid').val();
                    var aid = $('#ContentPlaceHolder1_hdnatrcid').val();
                    var options = {
                        "key": "rzp_live_LqnrevWLxsVNfm",
                        "amount": cost,
                        "currency": "INR",
                        "name": "Reshma Kshirsagar",
                        "description": "Just Stay Rest Chair Payment",
                        "image": "https://www.juststay.in/images/logo.png",
                        "order_id": orderid,
                        "handler": function (response) {
                            var payid = Enpt(response.razorpay_payment_id);
                            var orderid = Enpt(response.razorpay_order_id);
                            var signature = Enpt(response.razorpay_signature);
                            $.ajax({
                                type: "POST",
                                dataType: "json",
                                contentType: "application/json; charset=utf-8",
                                url: "/payment.aspx/Insert",
                                data: '{"orderid":"' + orderid + '","payid":"' + payid + '","signature":"' + signature + '","rcpid":"' + Enpt(rcpid) + '"}',
                                success: function (result, status, xhr) {
                                    window.location = "view-booking.aspx?bid=" + Enpt(bid) + "&aid=" + Enpt(aid);
                                },
                                error: function (xhr, status, error) {
                                    alert(status);
                                }
                            });
                        },
                        "prefill": {
                            "name": name,
                            "email": email,
                            "contact": mobile
                        },
                        "notes": {
                            "address": "note value"
                        },
                        "theme": {
                            "color": "#F37254"
                        }
                    };
                    var rzp1 = new Razorpay(options);
                    rzp1.open();
                    e.preventDefault();
                }
                
            }
        </script>
</asp:Content>