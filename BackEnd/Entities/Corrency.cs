using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Corrency
    {
        public Corrency()
        {
            Loans = new HashSet<Loan>();
        }

        public int CorrencyId { get; set; }
        public string CorrencyName { get; set; } = null!;

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
