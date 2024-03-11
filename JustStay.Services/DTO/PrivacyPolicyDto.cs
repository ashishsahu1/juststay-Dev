using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class PrivacyPolicyDto
    {
        [DataMember]
        public int PrivacyPolicyId { get; set; }
        [DataMember]
        public string PrivacyPolicy { get; set; }
    }
}