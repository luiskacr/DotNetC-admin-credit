using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackEndAPI.Models
{
    public class LoanModel
    {
        [Key]
        public int IdLoan { get; set; }

        [DisplayName("Id customers")]
        [ForeignKey("IdCustomers")]
        public int Idcustomers { get; set; }

        [DisplayName("Star Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "A Star Date is required")]
        public DateTime StarDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "A End Date is required")]
        public DateTime EndDate { get; set; }

        [DisplayName("Interes Rate")]
        [Range(0, 99.99)]
        [Required(ErrorMessage = "An Interes Rate is required")]
        public decimal InteresRate { get; set; }

        [DisplayName("Loan Amount")]
        [Range(1, 9999999)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "A Loan Amount is required")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Current Amount")]
        [Range(1, 9999999.99)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "A Current Amount is required")]
        public decimal? CurrentAmount { get; set; }

        [DisplayName("Monthly Amount")]
        [Range(1, 9999999.99)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "A Monthly Amount is required")]
        public decimal MonthlyAmount { get; set; }

        [DisplayName("Next Due Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "A Next Due Date is required")]
        public DateTime NextDueDate { get; set; }

        [DisplayName("Bank Fees")]
        [Range(1, 9999999.99)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "A Bank Fees is required")]
        public decimal BankFees { get; set; }

        [DisplayName("Loans Description")]
        public string? LoansDescription { get; set; }

        [ForeignKey("IdloansType")]
        [DisplayName("Id Loans Type")]
        [Required(ErrorMessage = "An Id Loans Type is required")]
        public int IdloansType { get; set; }

        [ForeignKey("IdCurrencies")]
        [DisplayName("Id Currencies")]
        [Required(ErrorMessage = "An Id Currencies is required")]
        public int IdCurrencies { get; set; }

        [ForeignKey("IdLoansState")]
        [DisplayName("Id Loans State")]
        [Required(ErrorMessage = "An Loans State is required")]
        public int IdLoansState { get; set; }
    }
}
