using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class CustomerRequestDTO
    {
        [DataMember]
        public int CustomerRequestId { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
    }
}