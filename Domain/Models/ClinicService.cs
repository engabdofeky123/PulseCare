using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ClinicService
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
