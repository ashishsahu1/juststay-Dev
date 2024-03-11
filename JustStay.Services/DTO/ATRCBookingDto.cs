using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ATRCBookingDto
    {
        [DataMember]
        public int BookingId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public int ATRCCategoryId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public System.DateTime BookingDate { get; set; }
        [DataMember]
        public System.DateTime FromTime { get; set; }
        [DataMember]
        public System.DateTime ToTime { get; set; }
        [DataMember]
        public int Persons { get; set; }
        [DataMember]
        public int Hours { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
    }
}