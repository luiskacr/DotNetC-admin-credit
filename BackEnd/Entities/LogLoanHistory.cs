using System;
using System.Collections.Generic;

namespace BackEndAPI.Entities
{
    public partial class LogLoanHistory
    {
        public int Idlog { get; set; }
        public int IdLoansHistory { get; set; }
        public int LoadId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PayDate { get; set; }
        public int PaymentType { get; set; }
        public string TypeChange { get; set; } = null!;
        public DateTime ChangeDate { get; set; }
    }
}
