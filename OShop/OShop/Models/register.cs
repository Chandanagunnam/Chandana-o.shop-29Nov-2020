using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OShop.Models
{
    [DataContract]

    public class register
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime CreatedOn { get; set; }
    }
}