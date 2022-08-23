using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class LogLoanHistoryViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int Idlog { get; set; }

        [DisplayName("Numero de Referencia")]
        public int IdLoansHistory { get; set; }

        [DisplayName("Tipo de Credito")]
        public int LoadId { get; set; }

        [DisplayName("Monto del Pago")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Range(1, 9999999)]
        public decimal PaymentAmount { get; set; }

        [DisplayName("Fecha de Pago")]
        [DataType(DataType.Date)]
        public DateTime PayDate { get; set; }

        [DisplayName("Tipo de Pago")]
        public int PaymentType { get; set; }

        [DisplayName("Tipo de Cambio")]
        public string TypeChange { get; set; } = null!;

        [DisplayName("Fecha de Cambios")]
        [DataType(DataType.Date)]
        public DateTime ChangeDate { get; set; }
    }
}
