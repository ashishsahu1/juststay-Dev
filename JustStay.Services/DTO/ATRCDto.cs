using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ATRCDto
    {
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public string ATRCName { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string OwnerName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int StateId { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Referral { get; set; }
        [DataMember]
        public int? LocationId { get; set; }
        [DataMember]
        public int? UserId { get; set; }
        [DataMember]
        public int? Status { get; set; }
        [DataMember]
        public string ATRCNumber { get; set; }
        [DataMember]
        public string CATEGORYNAMES { get; set; }
        [DataMember]
        public string REFERRALNAMES { get; set; }
        [DataMember]
        public string NAMEWITHCODE { get; set; }
        [DataMember]
        public string CITY { get; set; }
        [DataMember]
        public string LOCATION { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public int? DiningFacility { get; set; }
        [DataMember]
        public Nullable<System.TimeSpan> DiningFromTime { get; set; }
        [DataMember]
        public Nullable<System.TimeSpan> DiningToTime { get; set; }
        [DataMember]
        public Nullable<int> BookingCount { get; set; }
        [DataMember]
        public string ProfileImageName { get; set; }
        [DataMember]
        public string ProfileImageNewName { get; set; }
        [DataMember]
        public Nullable<decimal> Latitude { get; set; }
        [DataMember]
        public Nullable<decimal> Longitude { get; set; }
        [DataMember]
        public string highlights { get; set; }
        [DataMember]
        public string Cuisines { get; set; }
        [DataMember]
        public string Amenities { get; set; }
        [DataMember]
        public string GeoLocationName { get; set; }
        [DataMember]
        public int? ATRCTypeId { get; set; }
    }
}



 