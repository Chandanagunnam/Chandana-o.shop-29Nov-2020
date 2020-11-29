using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace OShop.Models
{
    [DataContract]

    public class login
    {
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
    }
}