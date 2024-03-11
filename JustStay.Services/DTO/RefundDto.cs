using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class RefundDto
    {
        [DataMember]
        public int RCRefundPaymentId { get; set; }
        [DataMember]
        public int RestChairBookingId { get; set; }
        [DataMember]
        public int RCPaymentId { get; set; }
        [DataMember]
        public DateTime RefundDate { get; set; }
        [DataMember]
        public decimal RefundAmount { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public DateTime InsertedOn { get; set; }
        [DataMember]
        public DateTime UpdatedOn { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string razor_refund_id { get; set; }
    }

    
}