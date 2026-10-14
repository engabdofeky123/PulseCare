using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public AppointmentType Type { get; set; }

        public AppointmentStatus Status { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public Patient Patient { get; set; } = null!;

        public Doctor Doctor { get; set; } = null!;

        public MedicalRecord? MedicalRecord { get; set; }

        public Invoice? Invoice { get; set; }

    }
}
