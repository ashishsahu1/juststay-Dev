using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class FAQDto
    {
        [DataMember]
        public int FAQId { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public string Answer { get; set; }
        [DataMember]
        public int Sequence { get; set; }
        [DataMember]
        public int FAQAudienceId { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}