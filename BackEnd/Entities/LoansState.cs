using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public partial class LoansState
    {
        public LoansState()
        {
            Loans = new HashSet<Loan>();
        }

        public int LoansStatesId { get; set; }
        public string LoansStateName { get; set; } = null!;

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
