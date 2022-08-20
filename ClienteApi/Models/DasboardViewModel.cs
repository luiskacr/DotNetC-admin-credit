namespace ClienteApi.Models
{
    public class DasboardViewModel
    {
        public int totalCustomers { get; set; }
        public int totalLoans { get; set; }
        public int activeLoans { get; set; }
        public int delayLoans { get; set; }
    }
}
