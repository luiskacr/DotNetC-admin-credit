using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class LoansHistory
    {

        public int? IdLoansHistory { get; set; } = null!;
        public int? LoadId { get; set; }
        public decimal? PaymentAmount { get; set; } = null!;
        public DateTime? PayDate { get; set; } = null!;
        public int? PaymentType { get; set; } = null!;

        public virtual Loan Load { get; set; } = null!;
        public virtual PaymentType PaymentTypeNavigation { get; set; } = null!;
    }
}
