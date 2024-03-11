using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class HighlightDto
    {
        [DataMember]
        public int HighlightId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}