using BackEndAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public partial class LoansType
    {
        public LoansType()
        {
            Loans = new HashSet<Loan>();
        }

        public int IdloansType { get; set; }
        public string LoansTypeName { get; set; } = null!;

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<LoansTypeInterest> LoansTypeInterest { get; set; }
    }
}
