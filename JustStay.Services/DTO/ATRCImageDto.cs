using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ATRCImageDto
    {
        [DataMember]
        public int ATRCImageId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public string ImageName { get; set; }
        [DataMember]
        public string ContentType { get; set; }
        [DataMember]
        public string NewImageName { get; set; }
        [DataMember]
        public DateTime InsertedOn { get; set; }
        [DataMember]
        public string SDDec { get; set; }
        [DataMember]
        public string SDName { get; set; }
        [DataMember]
        public bool? IsSD { get; set; }
        [DataMember]
        public string ATRCName { get; set; }
        [DataMember]
        public string DiningFromTime { get; set; }
        [DataMember]
        public string DiningToTime { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public bool? IsProfile { get; set; }
    }
}
 