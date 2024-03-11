using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class AttachmentDto
    {
        [DataMember]
        public int AttachmentId { get; set; }
        [DataMember]
        public int MasterTableId { get; set; }
        [DataMember]
        public string TableName { get; set; }
        [DataMember]
        public string DocName { get; set; }
        [DataMember]
        public string DocNewName { get; set; }
    }
}