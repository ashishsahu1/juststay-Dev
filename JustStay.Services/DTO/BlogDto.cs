using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class BlogDto
    {
        [DataMember]
        public int BlogId { get; set; }
        [DataMember]
        public int BlogCategoryId { get; set; }
        [DataMember]
        public string BlogTitle { get; set; }
        [DataMember]
        public string BlogContent { get; set; }
        [DataMember]
        public System.DateTime BlogDate { get; set; }
        [DataMember]
        public string BlogImageName { get; set; }
        [DataMember]
        public string BlogImageNewName { get; set; }
        [DataMember]
        public System.DateTime InsertedOn { get; set; }
        [DataMember]
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        [DataMember]
        public string BlogFileUrl { get; set; }
    }

    public class BlogCatgoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
    }
}