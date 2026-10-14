using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MedicalFile
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string StorageKey { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public long FileSizeBytes { get; set; }

        public DateTime UploadedAt { get; set; }

        public string? Description { get; set; }

        // Navigation
        public Patient Patient { get; set; } = null!;
    }
}
