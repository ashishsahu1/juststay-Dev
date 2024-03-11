using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    [Serializable]
    public class ATRCChairDto
    {
        [DataMember]
        public int ChairId { get; set; }
        [DataMember]
        public int ATRCRestChairId { get; set; }
        [DataMember]
        public string ChairNumber { get; set; }
        [DataMember]
        public bool ChairSaved { get; set; }
    }
}