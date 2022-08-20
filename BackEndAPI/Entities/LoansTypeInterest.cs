using System;
using System.Collections.Generic;

namespace BackEndAPI.Entities
{
    public partial class LoansTypeInterest
    {
        public int IdloansTypeInterest { get; set; }
        public int IdloansType { get; set; }
        public int IdCurrencies { get; set; }
        public decimal InteresRate { get; set; }
        public int? YearTime { get; set; }

        public virtual Currency IdCurrenciesNavigation { get; set; } = null!;
        public virtual LoansType IdloansTypeNavigation { get; set; } = null!;
    }
}
