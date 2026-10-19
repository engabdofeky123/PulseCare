using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.ClinicSchedules
{
    public class ClinicScheduleDto
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;
    }
}
