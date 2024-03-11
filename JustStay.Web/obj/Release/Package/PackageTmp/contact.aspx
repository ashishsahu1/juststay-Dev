<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="contact.aspx.cs" Inherits="JustStay.Web.contact" %>

<asp:Content ID="cphcontact" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <section>
        <div class="rows contact-map map-container">
            <iframe width="100%" height="600" src="https://maps.google.com/maps?width=100%&amp;height=600&amp;hl=en&amp;q=Sr.No.%2082%2F1%2F7%2C%20Pritam%20Plaza%2C%20Shop%20No.%206%2C%20Pimple%20Gurav%2C%20Pune%2C%20Maharashtra%2061+(Namo%20Services)&amp;ie=UTF8&amp;t=&amp;z=14&amp;iwloc=B&amp;output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" allowfullscreen></iframe>
        </div>
    </section>

    <section>
        <div class="form form-spac rows con-page">
            <div class="container">

                <div class="spe-title col-md-12">
                    <h2><span>Contact us</span></h2>
                    <div class="title-line">
                        <div class="tl-1"></div>
                        <div class="tl-2"></div>
                        <div class="tl-3"></div>
                    </div>
                    <p>World's leading Rest Chair Booking Service for short time. Book Rest Chair by JustStay and enjoy your short stay with amazing experience</p>
                </div>

                <div class="pg-contact">
                    <div class="col-md-4 col-sm-6 col-xs-12 new-con new-con1">
                        <h2>Just <span>Stay</span></h2>
                        <p>Just Stay is Any Time Refreshment Center booking service which allows travellers to book staying options available at highways at lowest costs on hourly basis across India. </p>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12 new-con new-con1">
                        <img src="images/1.png" alt="" />
                        <h4>Address</h4>
                        <p>
                            Sr.No. 82/1/7, Pritam Plaza, Shop No. 6,
                            <br />
                            Prabhat Nagar, Pimple Gurav, Pune, Maharashtra
                        </p>
                    </div>
                    <div class="col-md-4 col-sm-6 col-xs-12 new-con new-con3">
                        <img src="images/2.png" alt="" />
                        <h4>CONTACT INFO:</h4>
                        <p>
                            <a href="tel://9422085161" class="contact-icon">Phone: +94 22 08 51 61</a>
                            <br />
                            <a href="mailto:contact@juststay.in" class="contact-icon">Email: contact@juststay.in</a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="tr-regi-form">
                <h4>Get in touch with us</h4>
                <p>Fill below details.</p>
                <p>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtmsgname" runat="server" ClientIDMode="Static" MaxLength="20" CssClass="validate"></asp:TextBox>
                            <label>Name</label>
                            <asp:RequiredFieldValidator ID="rfvtxtmsgname" runat="server" ControlToValidate="txtmsgname" ValidationGroup="msg"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtmsgmobile" runat="server" ClientIDMode="Static" CssClass="validate"></asp:TextBox>
                            <label>Mobile</label>
                            <asp:RequiredFieldValidator ID="rfvtxtmsgmobile" runat="server" ControlToValidate="txtmsgmobile" ValidationGroup="msg"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="revtxtmsgmobile" runat="server" ErrorMessage="Enter valid mobile." ForeColor="Red" Display="Dynamic" ValidationExpression="^(\+\d{1,3}[- ]?)?\d{10}$" ValidationGroup="msg"
                                ControlToValidate="txtmsgmobile" SetFocusOnError="true">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:TextBox ID="txtmsg" runat="server" ClientIDMode="Static" MaxLength="100" CssClass="validate"></asp:TextBox>
                            <label>Message</label>
                            <asp:RequiredFieldValidator ID="rfvtxtmsg" runat="server" ControlToValidate="txtmsg" ValidationGroup="msg"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <asp:Button ID="btnsend" runat="server" Text="Send" OnClick="btnsend_Click" ValidationGroup="msg" CausesValidation="true"
                                CssClass="waves-effect waves-light btn-large full-btn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
