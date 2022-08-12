using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackEndAPI.Models
{
    public class LoanModel
    {
      
        public int IdLoan { get; set; }
        public int Idcustomers { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InteresRate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal? CurrentAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public DateTime NextDueDate { get; set; }
        public decimal BankFees { get; set; }
        public string? LoansDescription { get; set; }
        public int IdloansType { get; set; }
        public int IdCurrencies { get; set; }
        public int IdLoansState { get; set; }
    }
}
