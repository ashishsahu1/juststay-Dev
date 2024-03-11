using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ATRCRestChairDTO
    {
        [DataMember]
        public int ATRCRestChairId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int RestChairProfileId { get; set; }
        [DataMember]
        public string ChairName { get; set; }
        [DataMember]
        public int TypeId { get; set; }
        [DataMember]
        public int ChairCount { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Amenities { get; set; }
      
    }
}