using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class LoansTypeInterest
    {
       public int IdloansTypeInterest { get; set; }
       public int IdloansType { get; set; }
       public int IdCurrencies { get; set; }
       public decimal InteresRate { get; set; }
       public int YearTime { get; set; }

       public virtual ICollection<LoansType> IdloansTypeNavigation { get; set; } = null!;
       public virtual ICollection<Currency> CurrencyNavigation { get; set; } = null!;
    }
}
