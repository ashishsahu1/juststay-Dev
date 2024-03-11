using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class TaxDto
    {
        [DataMember]
        public int TaxId { get; set; }
        [DataMember]
        public string TaxName { get; set; }
        [DataMember]
        public decimal CGST { get; set; }
        [DataMember]
        public decimal SGST { get; set; }
        [DataMember]
        public decimal MinAmount { get; set; }
        [DataMember]
        public decimal MaxAmount { get; set; }
    }
}