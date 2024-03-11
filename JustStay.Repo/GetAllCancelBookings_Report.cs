
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace JustStay.Repo
{

using System;
    
public partial class GetAllCancelBookings_Report
{

    public Nullable<int> UserId { get; set; }

    public int CustomerId { get; set; }

    public int ATRCId { get; set; }

    public int RestChairBookingId { get; set; }

    public string BookingDetails { get; set; }

    public string ATRCDetails { get; set; }

    public string CustDetails { get; set; }

    public string PayStatus { get; set; }

    public Nullable<System.DateTime> BookingDate { get; set; }

    public Nullable<System.TimeSpan> FromTime { get; set; }

    public Nullable<System.TimeSpan> ToTime { get; set; }

    public Nullable<bool> IsSuccess { get; set; }

    public string PaymentMode { get; set; }

    public int RCPaymentId { get; set; }

    public Nullable<decimal> NetAmount { get; set; }

    public Nullable<decimal> TotalAmount { get; set; }

    public string order_id { get; set; }

    public string razorpay_payment_id { get; set; }

    public Nullable<bool> IsRefund { get; set; }

    public Nullable<bool> IsCancel { get; set; }

    public Nullable<bool> IsDeleted { get; set; }

    public Nullable<decimal> RefundAmt { get; set; }

    public Nullable<decimal> TotalRazorFees { get; set; }

    public Nullable<decimal> PaidAmtfromRazor { get; set; }

    public Nullable<decimal> ATRCCommission { get; set; }

    public Nullable<decimal> JustStayCommission { get; set; }

}

}
