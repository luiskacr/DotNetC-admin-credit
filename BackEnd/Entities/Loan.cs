using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class Loan
    {
        public Loan()
        {
            LoansHistories = new HashSet<LoansHistory>();
        }


        public int IdLoan { get; set; }
        public int Idcustomers { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InteresRate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal? CurrentAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public DateTime NextDueDate { get; set; }
        public decimal BankFees { get; set; }
        public string? LoansDescription { get; set; }
        public int IdloansType { get; set; }
        public int IdCurrencies { get; set; }
        public int IdLoansState { get; set; }

        public virtual Currency IdCurrenciesNavigation { get; set; } = null!;
        public virtual LoansState IdLoansStateNavigation { get; set; } = null!;
        public virtual Customer IdcustomersNavigation { get; set; } = null!;
        public virtual LoansType IdloansTypeNavigation { get; set; } = null!;
        public virtual ICollection<LoansHistory> LoansHistories { get; set; }
    }
}
