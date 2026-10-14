using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PatientMedicalHistory
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public MedicalHistoryType Type { get; set; }

        public string Description { get; set; } = string.Empty;

        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public Patient Patient { get; set; } = null!;

    }
}
