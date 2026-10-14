using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int AppointmentId { get; set; }

        public string ChiefComplaint { get; set; } = string.Empty;

        public string? Diagnosis { get; set; }

        public string? ExaminationNotes { get; set; }

        public string? TreatmentPlan { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public Patient Patient { get; set; } = null!;

        public Doctor Doctor { get; set; } = null!;

        public Appointment Appointment { get; set; } = null!;

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
