using JustStay.CommonHub;
using JustStay.Services.DTO;
using JustStay.Web.BusinessLogic;
using JustStay.Web.RCBookingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustStay.Web
{
    public partial class view_booking : BasePage
    {
        public static string stratrcname, strbookingnumber, strbookingdate, strstarttime, strendtime, strpaymentmode,
            strhour, strpaymentstatus, stratrcaddress, stratrcmobile, strchairnumbers, strchircount, strtotalcost;

        protected void lnkprofile_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request.QueryString["aid"]))
            {
                Response.Redirect("~/profile.aspx?aid=" + Convert.ToString(Request.QueryString["aid"]), false);
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.Page_Load(sender, e);
                JSEDS objsecurity = new JSEDS();
                if (!string.IsNullOrEmpty(Request.QueryString["m"]))
                {
                    if (Convert.ToString(Request.QueryString["m"]) == "b")
                    {
                        sectionbooking.Style.Add("display", "none");
                    }
                }
                Verification();
                BindBooking();
            }
            catch(Exception ex)
            {
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        private void Verification()
        {
            RestChairBookingServiceClient RCbooking = new RestChairBookingServiceClient();
            GetBookingDetailsByBookingId booking = new GetBookingDetailsByBookingId();
            try
            {
                JSEDS objjseds = new JSEDS();
                if (!string.IsNullOrEmpty(Request.QueryString["bid"]) && !string.IsNullOrEmpty(Request.QueryString["aid"]))
                {
                    if (string.IsNullOrEmpty(Request.QueryString["m"]))
                    {
                        booking = RCbooking.GetBookingDetails(Convert.ToInt32(objjseds.Decrypt(Request.QueryString["bid"])), Convert.ToInt32(objjseds.Decrypt(Request.QueryString["aid"])));
                        if (booking == null) return;
                        string generated_signature = Helper.getActualSignature(booking.order_id + "|" + booking.razorpay_payment_id, Helper.RazorSecret);

                        if (generated_signature == booking.razorpay_signature)
                        {
                            lblresponse.Text = "Your online payment is successful. Thank you for choosing us to take rest for short period.";
                            lblresponse.ForeColor = System.Drawing.Color.Green;

                            RCPDto rcpdt = new RCPDto
                            {
                                IsSuccess = true,
                                RCPaymentId = booking.RCPaymentId
                            };
                            RCbooking.UpdatePaymentSuccess(rcpdt);
                        }
                        else
                        {
                            lblresponse.Text = "Your online payment is fail. Please try again.... Thank you for choosing us to take rest for short period.";
                            lblresponse.ForeColor = System.Drawing.Color.Red;
                            RCPDto rcpdt = new RCPDto
                            {
                                IsSuccess = false,
                                RCPaymentId = booking.RCPaymentId
                            };
                            RCbooking.UpdatePaymentSuccess(rcpdt);
                        }
                        RCbooking.Close();
                    }
                }
                RCbooking.Close();
            }
            catch(Exception ex)
            {
                RCbooking.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
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

                    if (objjseds.Decrypt(Request.QueryString["m"]) == "pyat")
                    {
                        lblresponse.Text = "Thank you for booking Rest Chair and choosing us to take rest for short period.";
                        lblresponse.ForeColor = System.Drawing.Color.Green;
                        stratrcname = Convert.ToString(booking.ATRCName);
                        strbookingnumber = Convert.ToString(booking.BookingNumber);
                        strbookingdate = Convert.ToString(booking.BookingDate.Value.ToShortDateString());
                        strstarttime = Convert.ToString(booking.FromTime);
                        strendtime = Convert.ToString(booking.ToTime);
                        strhour = Convert.ToString(booking.Hour);
                        if (booking.IsSuccess != null)
                            strpaymentstatus = Convert.ToString(booking.IsSuccess);
                        else
                            strpaymentstatus = "Pending";
                        stratrcaddress = Convert.ToString(booking.Address);
                        stratrcmobile = Convert.ToString(booking.Mobile);
                        strtotalcost = Convert.ToString(booking.TotalAmount);
                        strpaymentmode = Convert.ToString(booking.PaymentMode);
                        strchairnumbers = Convert.ToString(booking.BookedChair);
                        strchircount = Convert.ToString(booking.BookedChairNumber);
                    }
                    else if (objjseds.Decrypt(Request.QueryString["m"]) == "Ab")
                    {
                        stratrcname = Convert.ToString(booking.ATRCName);
                        strbookingnumber = Convert.ToString(booking.BookingNumber);
                        strbookingdate = Convert.ToString(booking.BookingDate.Value.ToShortDateString());
                        strstarttime = Convert.ToString(booking.FromTime);
                        strendtime = Convert.ToString(booking.ToTime);
                        strhour = Convert.ToString(booking.Hour);
                        if (booking.IsSuccess != null)
                            strpaymentstatus = Convert.ToString(booking.IsSuccess);
                        else
                            strpaymentstatus = "Pending";
                        stratrcaddress = Convert.ToString(booking.Address);
                        stratrcmobile = Convert.ToString(booking.Mobile);
                        strtotalcost = Convert.ToString(booking.TotalAmount);
                        strpaymentmode = Convert.ToString(booking.PaymentMode);
                        strchairnumbers = Convert.ToString(booking.BookedChair);
                        strchircount = Convert.ToString(booking.BookedChairNumber);
                    }
                    else
                    {
                            stratrcname = Convert.ToString(booking.ATRCName);
                            strbookingnumber = Convert.ToString(booking.BookingNumber);
                            strbookingdate = Convert.ToString(booking.BookingDate.Value.ToShortDateString());
                            strstarttime = Convert.ToString(booking.FromTime);
                            strendtime = Convert.ToString(booking.ToTime);
                            strhour = Convert.ToString(booking.Hour);
                            strpaymentstatus = Convert.ToString(booking.IsSuccess);
                            stratrcaddress = Convert.ToString(booking.Address);
                            stratrcmobile = Convert.ToString(booking.Mobile);
                            strtotalcost = Convert.ToString(booking.TotalAmount);
                            strpaymentmode = Convert.ToString(booking.PaymentMode);
                            strchairnumbers = Convert.ToString(booking.BookedChair);
                            strchircount = Convert.ToString(booking.BookedChairNumber);
                    }
                    RCbooking.Close();
                }
            }
            catch(Exception ex)
            {
                RCbooking.Close();
                Helper.SaveError(DateTime.Now, Convert.ToString(ex.Message), "Web", Convert.ToString(Helper.GetCurrentPageName()), System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}