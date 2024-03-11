using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class ATRCAccountDto
    {
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public int ATRCAccountId { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string IFSC { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public DateTime InsertedOn { get; set; }
        [DataMember]
        public DateTime UpdatedOn { get; set; }
    }
}