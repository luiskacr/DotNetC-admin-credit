using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class LogLoanViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int Idlog { get; set; }

        [DisplayName("Credito")]
        public int IdLoan { get; set; }

        [DisplayName("Cliente")]
        public int Idcustomers { get; set; }

        [DisplayName("Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime StarDate { get; set; }

        [DisplayName("Fecha Final")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [DisplayName("Interes")]
        public decimal InteresRate { get; set; }

        [DisplayName("Monto del Prestamo")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Ultimo Monto")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? CurrentAmount { get; set; }

        [DisplayName("Mensualidad")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal MonthlyAmount { get; set; }

        [DisplayName("Ultima Fecha de Pago")]
        [DataType(DataType.Date)]
        public DateTime? NextDueDate { get; set; }

        [DisplayName("Cobros Bancarios")]
        public decimal BankFees { get; set; }

        [DisplayName("Description del Credito")]
        public string? LoansDescription { get; set; }

        [DisplayName("Tipo de Credito")]
        public int IdloansType { get; set; }

        [DisplayName("Moneda")]
        public int IdCurrencies { get; set; }

        [DisplayName("Ultimo Estado del Credito")]
        public int IdLoansState { get; set; }

        [DisplayName("Tipo de Cambio ")]
        public string TypeChange { get; set; } = null!;

        [DisplayName("Fecha del Cambio")]
        [DataType(DataType.Date)]
        public DateTime ChangeDate { get; set; }
    }
}
