using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class RCBDto
    {
        [DataMember]
        public int RestChairBookingId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public DateTime BookingDate { get; set; }
        [DataMember]
        public int Hour { get; set; }
        [DataMember]
        public TimeSpan FromTime { get; set; }
        [DataMember]
        public TimeSpan ToTime { get; set; }
        [DataMember]
        public int Person { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string BookingNumber { get; set; }
        [DataMember]
        public bool IsCancel { get; set; }
        [DataMember]
        public bool IsRefund { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}