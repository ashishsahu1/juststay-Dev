using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ATRCAmenityDto
    {
        [DataMember]
        public int AmenityId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public bool Parking { get; set; }
        [DataMember]
        public bool Wifi { get; set; }
        [DataMember]
        public bool Restaurant { get; set; }
        [DataMember]
        public bool CleanBathRoom { get; set; }
    }
}