using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ErrorLogDto
    {
        [DataMember]
        public int Logid { get; set; }
        [DataMember]
        public DateTime? date { get; set; }
        [DataMember]
        public string error { get; set; }
        [DataMember]
        public string pagename { get; set; }
        [DataMember]
        public string eventname { get; set; }
        [DataMember]
        public string ErrorFrom { get; set; }
       
    }
}