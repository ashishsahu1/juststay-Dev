<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Site1.Master" CodeBehind="view-booking.aspx.cs" Inherits="JustStayAdmin.Admin.view_booking" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cphviewbooking" runat="server">
    <style>
        .font-extra-bold {
            font-weight: bold;
        }
    </style>
    <div class="sb2-2">
        <div class="sb2-2-2">
            <ul>
                <li><a href="dashboard.aspx"><i class="fa fa-home" aria-hidden="true"></i>Dashboard</a>
                </li>
                <li class="active-bre"><a href="dashboard.aspx#tb">Todays Booking</a>
                </li>
                <li class="active-bre">View Booking
                </li>
                <li class="page-back">
                     <asp:LinkButton ID="lblheaderback" runat="server"  OnClick="lnkBack_Click"><i class="fa fa-backward" aria-hidden="true"></i> Back</asp:LinkButton>
                </li>
            </ul>
        </div>
        <div class="sb2-2-add-blog sb2-2-1">
            <h2>View Booking</h2>
            <asp:Label ID="lblDate" runat="server" style="float:right;"></asp:Label>
            <div class="row">
                <div class="input-field col s12">
                   <span><strong>ATRC Name:</strong></span>
                    <asp:Label ID="lblatrcname" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                   <span><strong>Address:</strong> </span>
                    <asp:Label ID="lbladdress" runat="server"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                   <span><strong>Mobile: </strong></span>
                    <asp:Label ID="lblmobile" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span><strong>Booking Number:</strong> </span>
                    <asp:Label ID="lblbookingnumber" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span><strong>Booking Date:</strong> </span>
                    <asp:Label ID="lblbookingdate" runat="server"></asp:Label>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <span><strong>Start Time: </strong></span>
                    <asp:Label ID="lblstarttime" runat="server"></asp:Label>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <span><strong>End Time: </strong></span>
                    <asp:Label ID="lblendtime" runat="server"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <span><strong>Hour:</strong> </span>
                    <asp:Label ID="lblhour" runat="server"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <span><strong>Number of Booked Chair:</strong> </span>
                    <asp:Label ID="lblnochair" runat="server"></asp:Label>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <span><strong>Booked Chairs:</strong></span>
                    <asp:Label ID="lblbookchair" runat="server"></asp:Label>
                </div>
            </div>
              <div class="row">
                <div class="input-field col s12">
                    <span><strong>Amount:</strong></span>
                    <asp:Label ID="lblamount" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <span><strong>Payment Mode:</strong></span>
                    <asp:Label ID="lblpaymentmode" runat="server"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <span><strong>Order-Id:</strong></span>
                    <asp:Label ID="lblorderid" runat="server"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <span><strong>Trasaction-Id:</strong></span>
                    <asp:Label ID="lblrazorpaymentid" runat="server"></asp:Label>
                </div>
            </div>
             <div class="row">
                <div class="input-field col s12">
                    <span><strong>Payment Status:</strong></span>
                    <asp:Label ID="lblpaymentstatus" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:LinkButton ID="lnkBack" runat="server" CssClass="btn btn-default" OnClick="lnkBack_Click"><i class="fa fa-arrow-left"></i> Back</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>