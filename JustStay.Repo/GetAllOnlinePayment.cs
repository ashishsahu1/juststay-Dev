
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
    
public partial class GetAllOnlinePayment
{

    public int ATRCId { get; set; }

    public int RestChairBookingId { get; set; }

    public int RCPaymentId { get; set; }

    public Nullable<System.DateTime> PaymentDate { get; set; }

    public Nullable<bool> IsSuccess { get; set; }

    public string BookingNumber { get; set; }

    public string ATRCName { get; set; }

    public string Name { get; set; }

    public string Mobile { get; set; }

    public string orderid { get; set; }

    public string razorpay_payment_id { get; set; }

    public Nullable<decimal> TotalAmount { get; set; }

    public Nullable<decimal> NetAmount { get; set; }

    public Nullable<decimal> Razor_Fess { get; set; }

    public Nullable<decimal> razor_gst { get; set; }

    public Nullable<decimal> TotalRazorFees { get; set; }

    public Nullable<decimal> PaidAmtfromRazor { get; set; }

    public Nullable<decimal> ATRCCommission { get; set; }

    public Nullable<decimal> JustStayCommission { get; set; }

    public Nullable<System.DateTime> BookingDate { get; set; }

}

}
