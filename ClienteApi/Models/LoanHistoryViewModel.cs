using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClienteApi.Models
{
    public class LoanHistoryViewModel
    {
        [Key]
        [DisplayName("Numero de Referencia")]
        public int IdLoansHistory { get; set; }

        [DisplayName("Tipo de Credito")]
        [Required(ErrorMessage = "El Credito es Requerido")]
        public int LoadId { get; set; }

        [DisplayName("Monto del Pago")]
        [Range(1, 9999999)]
        [Required(ErrorMessage = "El Monto del Pago es obligatorio")]
        public decimal PaymentAmount { get; set; }

        [DisplayName("Fecha de Pago")]
        [DataType(DataType.Date)]
        public DateTime PayDate { get; set; }

        [DisplayName("Tipo de Pago")]
        [Required(ErrorMessage = "El Tipo de Pago es Requerido")]
        public int PaymentType { get; set; }
    }
}
