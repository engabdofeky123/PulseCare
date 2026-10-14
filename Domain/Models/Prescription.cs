using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Prescription
    {
        public int Id { get; set; }

        public int MedicalRecordId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? GeneralInstructions { get; set; }

        // Navigation
        public MedicalRecord MedicalRecord { get; set; } = null!;

        public ICollection<PrescriptionItem> Items { get; set; }
            = new List<PrescriptionItem>();

    }
}
