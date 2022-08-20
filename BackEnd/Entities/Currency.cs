using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class Currency
    {
        public Currency()
        {
            Loans = new HashSet<Loan>();
        }


        public int IdCurrencies { get; set; }
        public string CurrencyName { get; set; } = null!;
        public string CurrencyIso { get; set; } = null!;
        public string Symbol { get; set; } = null!;

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
