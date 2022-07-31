using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class CurrencyModel
    {
        [Key]
        public int IdCurrencies { get; set; }

        [DisplayName("Currency Name")]
        [Required(ErrorMessage = "A Currency Name is required")]
        public string CurrencyName { get; set; } = null!;

        [DisplayName("Currency Iso")]
        [Required(ErrorMessage = "A Currency Iso is required")]
        public string CurrencyIso { get; set; } = null!;
    }
}
