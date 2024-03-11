using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class RCPDto
    {
        [DataMember]
        public int RCPaymentId { get; set; }
        [DataMember]
        public int RestChairBookingId { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public int Discount { get; set; }
        [DataMember]
        public decimal NetAmount { get; set; }
        [DataMember]
        public decimal CGST { get; set; }
        [DataMember]
        public decimal SGST { get; set; }
        [DataMember]
        public string MerchantTxnId { get; set; }
        [DataMember]
        public DateTime PaymentDate { get; set; }
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public string PaymentMode { get; set; }
        [DataMember]
        public string OTP { get; set; }
        [DataMember]
        public string order_id { get; set; }
        [DataMember]
        public string razorpay_payment_id { get; set; }
        [DataMember]
        public string razorpay_signature { get; set; }
    }
}