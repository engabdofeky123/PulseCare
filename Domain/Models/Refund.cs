using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Refund
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }

        public decimal Amount { get; set; }

        public RefundStatus Status { get; set; }

        public string? Reason { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        // Navigation
        public Payment Payment { get; set; } = null!;

    }
}
