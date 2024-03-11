using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class OfferDto
    {
        [DataMember]
        public int OfferId { get; set; }
        [DataMember]
        public string Heading { get; set; }
        [DataMember]
        public string SubHeading { get; set; }
        [DataMember]
        public string ShortDetail { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public string OfferImage { get; set; }
        [DataMember]
        public string OfferImgNewName { get; set; }
        [DataMember]
        public System.DateTime StartDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> EndDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> InsertedOn { get; set; }
    }
}