using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class LoansTypeInterestViewModel
    {
        [DisplayName("Id")]
        public int IdloansTypeInterest { get; set; }

        [DisplayName("Tipo de Credito")]
        [Required(ErrorMessage = "El Tipo de Credito es Requerido")]
        public int IdloansType { get; set; }

        [DisplayName("Moneda")]
        [Required(ErrorMessage = "La Moneda es Requerida")]
        public int IdCurrencies { get; set; }

        [DisplayName("Comision Bancaria")]
        [Range(1, 60.99)]
        [Required(ErrorMessage = "Se deben Indicar la Comision Bancaria ")]
        public decimal InteresRate { get; set; }

        [DisplayName("Duracion")]
        [Range(1, 35)]
        [Required(ErrorMessage = "Se deben Indicar la Duracion del Credito ")]
        public int? YearTime { get; set; }

    }
}
