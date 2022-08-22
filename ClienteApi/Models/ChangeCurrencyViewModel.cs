using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models
{
    public class ChangeCurrencyViewModel
    {

        [DisplayName("Plazo")]
        [Required(ErrorMessage = "Se debe de indicar el nuevo Plazo del Credito")]
        public int Tiempo { get; set; }

        [DisplayName("Credito")]
        [Required(ErrorMessage = "Se debe de indicar el nuevo Plazo del Credito")]
        public int IdLoan { get; set; }

        [DisplayName("Cobros Bancarios")]
        [Required(ErrorMessage = "Se debe de indicar el nuevo Cobro Bancario")]
        public decimal BankFees { get; set; }

        [DisplayName("Moneda")]
        [Required(ErrorMessage = "Se debe de indicar la nueva Moneda")]
        public int Currency { get; set; }

        [DisplayName("Typo de Cambio")]
        [Required(ErrorMessage = "Se debe de indicar el tipo de Cambio")]
        public decimal Exchange { get; set; }

    }
}
