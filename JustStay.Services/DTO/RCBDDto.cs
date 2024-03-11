using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class RCBDDto
    {
        [DataMember]
        public int RCBDetailId { get; set; }
        [DataMember]
        public int RestChairBookingId { get; set; }
        [DataMember]
        public int ChairId { get; set; }
        [DataMember]
        public DateTime InsertedOn { get; set; }
        [DataMember]
        public DateTime? UpdatedOn { get; set; }
    }
}