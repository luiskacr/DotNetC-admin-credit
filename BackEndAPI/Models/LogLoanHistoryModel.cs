namespace BackEndAPI.Models
{
    public class LogLoanHistoryModel
    {
        public int Idlog { get; set; }
        public int IdLoansHistory { get; set; }
        public int LoadId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PayDate { get; set; }
        public int PaymentType { get; set; }
        public string TypeChange { get; set; } = null!;
        public DateTime ChangeDate { get; set; }
    }
}
