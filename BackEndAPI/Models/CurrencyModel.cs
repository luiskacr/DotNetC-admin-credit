using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class CurrencyModel
    {
   
        public int IdCurrencies { get; set; }
        public string CurrencyName { get; set; } = null!;
        public string CurrencyIso { get; set; } = null!;
    }
}
