using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class PaymentHistory
    {
        public int PaymentId { get; set; }
        public int LoadId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DatePayed { get; set; }

        public virtual Loan Load { get; set; } = null!;
    }
}
