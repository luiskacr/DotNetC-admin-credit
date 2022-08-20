namespace BackEndAPI.Models
{
    public class LoansTypeInterestModel
    {
        public int IdloansTypeInterest { get; set; }
        public int IdloansType { get; set; }
        public int IdCurrencies { get; set; }
        public decimal InteresRate { get; set; }
        public int YearTime { get; set; }

    }
}
