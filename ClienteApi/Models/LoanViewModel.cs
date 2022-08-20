using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models
{
    public class LoanViewModel
    {
        [Key]
        public int IdLoan { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "El Cliente es Requerido")]
        public int Idcustomers { get; set; }

        [DisplayName("Inicio")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La Fecha de inicio es Requerida")]
        public DateTime StarDate { get; set; }

        [DisplayName("Finalizacion")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La Fecha de Finalizacion es Requerida")]
        public DateTime EndDate { get; set; }

        [DisplayName("Interes")]
        [Range(0, 99.99)]
        [Required(ErrorMessage = "An Interes Rate is required")]
        public decimal InteresRate { get; set; }

        [DisplayName("Monto del Credito")]
        [Range(1, 9999999)]
        [Required(ErrorMessage = "El Monto del Credito es obligatorio")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Monto Actual")]
        [Range(1, 9999999.99)]
        public decimal? CurrentAmount { get; set; }

        [DisplayName("Mensualidad")]
        [Range(1, 9999999.99)]
        [Required(ErrorMessage = "La mensualidad es obligatoria")]
        public decimal MonthlyAmount { get; set; }

        [DisplayName("Siguente Fecha de Pago")]
        [DataType(DataType.Date)]
        public DateTime NextDueDate { get; set; }

        [DisplayName("Comision Bancaria")]
        [Range(1, 9999999.99)]
        [Required(ErrorMessage = "Se deben Indicar la Comision Bancaria ")]
        public decimal BankFees { get; set; }

        [DisplayName("Descripcion del Credito")]
        [Required(ErrorMessage = "Se deben Indicar la Descripcion del Credito")]
        public string? LoansDescription { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Se deben Indicar el tipo de Credito")]
        public int IdloansType { get; set; }

        [DisplayName("Moneda")]
        [Required(ErrorMessage = "Se deben Indicar el tipo de Moneda")]
        public int IdCurrencies { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Se deben Indicar el Estado del Credito")]
        public int IdLoansState { get; set; }
    }
}
