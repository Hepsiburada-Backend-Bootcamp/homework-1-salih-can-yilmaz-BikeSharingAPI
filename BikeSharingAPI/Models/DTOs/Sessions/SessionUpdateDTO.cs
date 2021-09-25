using BikeSharingAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BikeSharingAPI.Models.DTOs.Sessions
{
    public class SessionUpdateDTO
    {
        [Required]
        [RegularExpression("[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?")]
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [RegularExpression("(KARTAL|MALTEPE|PENDIK|KADIKOY)")]
        public EnumLocation? StartLocation { get; set; }
        [RegularExpression("(KARTAL|MALTEPE|PENDIK|KADIKOY)")]
        public EnumLocation? EndLocation { get; set; }
        [Range(-50, 50)]
        public double? Temperature { get; set; }
        public bool IsHoliday { get; set; }
        [Range(0, Double.MaxValue)]
        public double? Cost { get; set; }
        public string UserComment { get; set; }
        [Range(0, Double.MaxValue)]
        public double? TotalDistance { get; set; }
        public int? UserRating { get; set; }
        [Required]
        public int? UserId { get; set; }
    }
}