using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    [Keyless]
    public class Change_loan_currency_util
    {

        public int Tiempo { get; set; }
        public int IdLoan { get; set; }
        public decimal BankFees { get; set; }

        public int Currency { get; set; }

        public decimal Exchange { get; set; }

    }
}
