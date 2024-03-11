using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class CustomerDto
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public Nullable<int> UserId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> InsertedOn { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        [DataMember]
        public bool IsGuest { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DOB { get; set; }
        [DataMember]
        public string Gender { get; set; }
    }
}