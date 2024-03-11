using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class CuisineDto
    {
        [DataMember]
        public int CuisineId { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}