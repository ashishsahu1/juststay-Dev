using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class AmenityDto
    {
        [DataMember]
        public int AmenityId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string IconName { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string IconFileName { get; set; }
        [DataMember]
        public string IconFileUrl { get; set; }
    }
}