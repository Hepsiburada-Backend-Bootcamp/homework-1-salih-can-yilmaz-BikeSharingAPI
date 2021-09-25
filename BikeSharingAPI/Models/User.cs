using BikeSharingAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EnumGender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateJoined { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public double? Balance { get; set; }
    }
}
