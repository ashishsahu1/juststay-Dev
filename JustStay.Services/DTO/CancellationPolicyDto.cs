using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class CancellationPolicyDto
    {
        [DataMember]
        public int PolicyId { get; set; }
        [DataMember]
        public string PolicyName { get; set; }
        [DataMember]
        public byte PolicyType { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public string FromTime { get; set; }
        [DataMember]
        public string ToTime { get; set; }
        [DataMember]
        public bool ApplyAfterBooking { get; set; }
        [DataMember]
        public bool ApplyBeforeCheckIn { get; set; }
        [DataMember]
        public decimal RefundPercentage { get; set; }
    }
}