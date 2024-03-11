using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class CityDto
    {
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public DateTime? InsertedOn { get; set; }
        [DataMember]
        public DateTime? UpdatedOn { get; set; }
        [DataMember]
        public decimal? latitude { get; set; }
        [DataMember]
        public decimal? longitude { get; set; }
    }
}