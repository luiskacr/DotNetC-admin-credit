namespace BackEndAPI.Models
{
    public class DasboardModel
    {
        public int totalCustomers { get; set; }
        public int totalLoans { get; set; }
        public int activeLoans { get; set; }
        public int delayLoans { get; set; }
    }
}
