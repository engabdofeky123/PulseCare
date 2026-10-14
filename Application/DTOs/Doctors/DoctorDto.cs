using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Doctors
{
    public class DoctorDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Specialty { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public decimal ConsultationFee { get; set; }

        public bool IsActive { get; set; } = true;

        public string? UserId { get; set; }
    }
}