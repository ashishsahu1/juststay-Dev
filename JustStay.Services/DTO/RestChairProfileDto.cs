using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class RestChairProfileDto
    {
        [DataMember]
        public int RestChairProfileId { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public string ManagerName { get; set; }
        [DataMember]
        public string ManagerMobile { get; set; }
        [DataMember]
        public string ATRCTelephone { get; set; }
        [DataMember]
        public System.DateTime StartDate { get; set; }
        [DataMember]
        public System.DateTime EndDate { get; set; }
        [DataMember]
        public System.TimeSpan CheckInTime { get; set; }
        [DataMember]
        public System.TimeSpan CheckOutTime { get; set; }
        [DataMember]
        public string ATRCPolicy { get; set; }
        [DataMember]
        public string CancellationPolicy { get; set; }
        [DataMember]
        public string CancellationPolicies { get; set; }
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}