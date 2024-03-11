using JustStay.CommonHub;
using JustStayAdmin.RCBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStayAdmin.Admin
{
    public partial class view_booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBooking();
            }
        }
        private void BindBooking()
        {
            RestChairBookingServiceClient RCbooking = new RestChairBookingServiceClient();
            try
            {
                JSEDS objjseds = new JSEDS();
                if (!string.IsNullOrEmpty(Request.QueryString["bid"]) && !string.IsNullOrEmpty(Request.QueryString["aid"]))
                {
                    GetBookingDetailsByBookingId booking = new GetBookingDetailsByBookingId();
                    booking = RCbooking.GetBookingDetails(Convert.ToInt32(objjseds.Decrypt(Request.QueryString["bid"])), Convert.ToInt32(objjseds.Decrypt(Request.QueryString["aid"])));
                    if (booking == null) return;

                    lblatrcname.Text = Convert.ToString(booking.ATRCName);
                    lblbookingnumber.Text = Convert.ToString(booking.BookingNumber);
                    lblbookingdate.Text = Convert.ToString(booking.BookingDate.Value.ToShortDateString());
                    lblstarttime.Text = Convert.ToString(booking.FromTime);
                    lblendtime.Text = Convert.ToString(booking.ToTime);
                    lblhour.Text = Convert.ToString(booking.Hour);
                    lblpaymentstatus.Text = Convert.ToString(booking.IsSuccess);
                    lbladdress.Text = Convert.ToString(booking.Address);
                    lblmobile.Text = Convert.ToString(booking.Mobile);
                    lblamount.Text = Convert.ToString(booking.TotalAmount);
                    lblpaymentmode.Text = Convert.ToString(booking.PaymentMode);
                    lblbookchair.Text = Convert.ToString(booking.BookedChair);
                    lblnochair.Text = Convert.ToString(booking.BookedChairNumber);
                    lblorderid.Text = Convert.ToString(booking.order_id);
                    lblrazorpaymentid.Text = Convert.ToString(booking.razorpay_payment_id);
                    RCbooking.Close();
                }
            }
            catch (Exception ex)
            {
                RCbooking.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Admin", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            finally { RCbooking.Close(); }
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            JSEDS objjseds = new JSEDS();
            if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
            {
                Response.Redirect("restchairbooking.aspx?Id=" + objjseds.Encrypt(Convert.ToString(Request.QueryString["cid"])), false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("dashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}