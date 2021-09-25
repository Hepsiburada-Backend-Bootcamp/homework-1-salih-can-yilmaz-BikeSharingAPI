using BikeSharingAPI.Enums;
using System;

namespace BikeSharingAPI.Models.DTOs.Sessions
{
    public class SessionCreateDTO
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public EnumLocation? StartLocation { get; set; }
        public EnumLocation? EndLocation { get; set; }
        public double? Temperature { get; set; }
        public bool IsHoliday { get; set; }
        public double? Cost { get; set; }
        public string UserComment { get; set; }
        public double? TotalDistance { get; set; }
        public int? UserRating { get; set; }
        public int? UserId { get; set; }
    }
}