<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="view-booking.aspx.cs" Inherits="JustStay.Web.view_booking" %>
<%@ Register Src="~/userMenuBar.ascx" TagName="UserleftMenu" TagPrefix="ULMenu" %>
<asp:Content ID="chpbook" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <section id="sectionbooking" runat="server">
        <div class="search-top">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="search-form">
						<asp:Label ID="lblresponse" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="db">
           <ULMenu:UserleftMenu runat="server" id="UserleftMenu"/>  
            <div class="db-2">
				<div class="db-2-com db-2-main">
					<h4>Rest Chair Booking Details</h4>
                        <asp:LinkButton ID="lnkprofile" runat="server" CssClass="waves-effect waves-light full-btn waves-input-wrapper" Text="Go TO ATRC Profile >>" OnClick="lnkprofile_Click"></asp:LinkButton>

					<div class="db-2-main-com db-2-main-com-table">
						<table class="responsive-table">
							<tbody>
								<tr>
									<td>ATRC Name</td>
									<td>:</td>
									<td><%=stratrcname %></td>
								</tr>
								<tr>
									<td>Booking Number</td>
									<td>:</td>
									<td><%=strbookingnumber %></td>
								</tr>
								<tr>
									<td>Booking Date</td>
									<td>:</td>
									<td><%=strbookingdate %></td>
								</tr>
								<tr>
									<td>Start Time</td>
									<td>:</td>
									<td><%=strstarttime %></td>
								</tr>
								<tr>
									<td>End Time</td>
									<td>:</td>
									<td><%=strendtime %></td>
								</tr>
								<tr>
									<td>Hour</td>
									<td>:</td>
									<td><%=strhour %></td>
								</tr>
                                 <tr>
									<td>Number of Booked Chair</td>
									<td>:</td>
									<td><%=strchircount %></td>
								</tr>
                                <tr>
									<td>Booked Chairs</td>
									<td>:</td>
									<td><%=strchairnumbers %></td>
								</tr>
								<tr>
									<td>Payment Mode</td>
									<td>:</td>
									<td><span class="db-not-done"><%=strpaymentmode %></span>
									</td>
								</tr>
                                <tr>
									<td>Payment Status</td>
									<td>:</td>
									<td><span class="db-not-done"><%=strpaymentstatus %></span>
									</td>
								</tr>
							</tbody>
						</table>
					</div>
				</div>
			</div>
        </div>
    </section>
</asp:Content>
