using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class atrcbillDto
    {
        [DataMember]
        public int ATRCBillId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public DateTime BillFrom { get; set; }
        [DataMember]
        public DateTime BillTo { get; set; }
        [DataMember]
        public string BillNo { get; set; }
        [DataMember]
        public DateTime BillDate { get; set; }
        [DataMember]
        public string PaymentBy { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal? TotalAmount { get; set; }
        [DataMember]
        public decimal PaidAmount { get; set; }
        [DataMember]
        public bool IsPaid { get; set; }
        [DataMember]
        public DateTime? PaidDate { get; set; }
        [DataMember]
        public DateTime InsertedOn { get; set; }
        [DataMember]
        public DateTime? UpdatedOn { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}

