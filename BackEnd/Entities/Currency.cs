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

        [Key]
        public int IdCurrencies { get; set; }

        [DisplayName("Currency Name")]
        [Required(ErrorMessage = "A Currency Name is required")]
        public string CurrencyName { get; set; } = null!;

        [DisplayName("Currency Iso")]
        [Required(ErrorMessage = "A Currency Iso is required")]
        public string CurrencyIso { get; set; } = null!;

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
