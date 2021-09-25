using BikeSharingAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Models
{
    public class Session
    {
        public Guid Id { get; set; }
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
