using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ClinicSchedule
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Navigation
        public Doctor Doctor { get; set; } = null!;
    }
}