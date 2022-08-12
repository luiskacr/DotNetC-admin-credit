using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class LoansHistory
    {
  
        public int IdLoansHistory { get; set; }
        public int LoadId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PayDate { get; set; }
        public int PaymentType { get; set; }

        public virtual Loan Load { get; set; } = null!;
        public virtual PaymentType PaymentTypeNavigation { get; set; } = null!;
    }
}
