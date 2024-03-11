using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class BannerDto
    {
        [DataMember]
        public int BannerId { get; set; }
        [DataMember]
        public string Heading { get; set; }
        [DataMember]
        public string SubHeading { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ImageName { get; set; }
        [DataMember]
        public string ImageNewName { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
    }
}