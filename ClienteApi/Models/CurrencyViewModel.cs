using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class CurrencyViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int IdCurrencies { get; set; }

        [DisplayName("Nombre Moneda")]
        [Required(ErrorMessage = "El nombre de la Moneda es requerido")]
        public string CurrencyName { get; set; } = null!;

        [DisplayName("Iso Moneda")]
        [Required(ErrorMessage = "la Iso de la Moneda es requerido")]
        public string CurrencyIso { get; set; } = null!;
    }
}
