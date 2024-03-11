using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class CompanyDto
    {
        [DataMember]
        public int CompanyId { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Subheading { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public int? PinCode { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string GSTIN { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Website { get; set; }
        [DataMember]
        public DateTime? InsertedOn { get; set; }
        [DataMember]
        public DateTime? UpdatedOn { get; set; }
        [DataMember]
        public string CIN { get; set; }
        [DataMember]
        public string PAN { get; set; }
        [DataMember]
        public string LandLine { get; set; }
    }
}