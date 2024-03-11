using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class MessageRecipientDto
    {
        [DataMember]
        public int MessageRecipientId { get; set; }
        [DataMember]
        public int MessageId { get; set; }
        [DataMember]
        public string ReceiverType { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool UnRead { get; set; }
        [DataMember]
        public bool Trashed { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}