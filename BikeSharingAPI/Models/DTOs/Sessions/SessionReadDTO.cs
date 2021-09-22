using System;
using BikeSharingAPI.Enums;

namespace BikeSharingAPI.Models.DTOs.Sessions
{
    public class SessionReadDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EnumLocation StartLocation { get; set; }
        public EnumLocation EndLocation { get; set; }
        public float Temperature { get; set; }
        public bool IsHoliday { get; set; }
        public double Cost { get; set; }//TODO decimal?
        public string Comment { get; set; }
        public double TotalDistance { get; set; }
        public int UserRating { get; set; }
        public int UserId { get; set; }
    }
}