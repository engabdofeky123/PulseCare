using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public decimal Subtotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public InvoiceStatus Status { get; set; }
            = InvoiceStatus.Unpaid;

        public DateTime CreatedAt { get; set; }

        // Navigation
        public Appointment Appointment { get; set; } = null!;

        public ICollection<InvoiceItem> Items { get; set; }
            = new List<InvoiceItem>();

        public ICollection<Payment> Payments { get; set; }
            = new List<Payment>();

    }
}
