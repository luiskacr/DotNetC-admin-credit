using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class LoanHistoryModel
    {
   
        public int IdLoansHistory { get; set; }
        public int LoadId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PayDate { get; set; }
        public int PaymentType { get; set; }
    }
}
