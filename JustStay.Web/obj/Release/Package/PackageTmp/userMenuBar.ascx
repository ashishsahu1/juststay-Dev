<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userMenuBar.ascx.cs" Inherits="JustStay.Web.userMenuBar" %>
<div class="db-l">
    <div class="db-l-1">
        <ul>
            <li>
                <img src="images/profile img.jpg" alt="" />
            </li>
        </ul>
    </div>
    <div class="db-l-2">
        <ul>
            <li>
                <a href="allbooking.aspx">
                    <img src="images/icon/dbl8.png" alt="" />
                    All Bookings</a>
            </li>
             <li>
                <a href="cancelbooking.aspx">
                    <img src="images/icon/dbl5.png" alt="" />
                    Cancel Booking</a>
            </li>
            <li>
                <a href="myprofile.aspx">
                    <img src="images/icon/dbl6.png" alt="" />
                    My Profile</a>
            </li>
            <li>
                <a href="mypayment.aspx">
                    <img src="images/icon/dbl9.png" alt="" />
                    Payments</a>
            </li>
             <li>
                <a href="changepassword.aspx">
                    <img src="images/icon/dbl4.png" alt="" />
                   Change Password</a>
            </li>
             <li>
                
                 <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click"><img src="images/right-arrow.png" /> Logout</asp:LinkButton>
            </li>
        </ul>
    </div>
</div>
