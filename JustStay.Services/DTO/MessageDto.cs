using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class MessageDto
    {
        [DataMember]
        public int MessageId { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string EmailBody { get; set; }
        [DataMember]
        public Nullable<int> RefrenceId { get; set; }
        [DataMember]
        public int MessageSource { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
        [DataMember]
        public int InsertedBy { get; set; }
    }
}