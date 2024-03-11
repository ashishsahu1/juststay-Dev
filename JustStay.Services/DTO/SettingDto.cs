using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class SettingDto
    {
        [DataMember]
        public int SettingId { get; set; }
        [DataMember]
        public string SmsUrl { get; set; }
        [DataMember]
        public string SmsUsername { get; set; }
        [DataMember]
        public string SmsPassword { get; set; }
        [DataMember]
        public string SmsSenderId { get; set; }
        [DataMember]
        public string SMSBalanceUrl { get; set; }
        [DataMember]
        public string privacy { get; set; }
    }
}