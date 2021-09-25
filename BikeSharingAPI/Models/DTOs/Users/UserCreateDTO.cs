using System;
using System.ComponentModel.DataAnnotations;
using BikeSharingAPI.Enums;

namespace BikeSharingAPI.Models.DTOs.Users
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public EnumGender? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateJoined { get; set; }
        public string EMail { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Range(0, Double.MaxValue)]
        public double? Balance { get; set; }
    }
}