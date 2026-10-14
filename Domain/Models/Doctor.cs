using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Specialty { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public decimal ConsultationFee { get; set; }

        public bool IsActive { get; set; } = true;

        public string? UserId { get; set; }

        // Relationships
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<ClinicSchedule> Schedules { get; set; } = new List<ClinicSchedule>();

        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    }
}
