using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class RatingDto
    {
        [DataMember]
        public int RatingId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public float Star { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public DateTime InsertedOn { get; set; }
    }
}