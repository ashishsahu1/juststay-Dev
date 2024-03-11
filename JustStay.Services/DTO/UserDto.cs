using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace JustStay.Services.DTO
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int? UserTypeId { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public bool? IsPaid { get; set; }
        [DataMember]
        public DateTime? InsertedOn { get; set; }
        [DataMember]
        public DateTime? UpdatedOn { get; set; }
        [DataMember]
        public int? RoleId { get; set; }
        [DataMember]
        public bool? IsAdmin { get; set; }
        [DataMember]
        public int ATRCId { get; set; }
        [DataMember]
        public int ATRCStatus{ get; set; }
        [DataMember]
        public string UserType { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string ATRCName { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string Google_Id { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string DOB { get; set; }
        [DataMember]
        public string NewDOB { get; set; }
    }
}