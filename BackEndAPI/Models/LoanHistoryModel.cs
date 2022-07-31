using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class LoanHistoryModel
    {
        [Key]
        public int IdLoansHistory { get; set; }

        [DisplayName("Load Id")]
        [ForeignKey("IdLoan")]
        [Required(ErrorMessage = "A Load Id is required")]
        public int LoadId { get; set; }

        [DisplayName("Payment Amount")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "A Payment Amount is required")]
        public decimal PaymentAmount { get; set; }

        [DisplayName("Pay Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "A Pay Date is required")]
        public DateTime PayDate { get; set; }

        [DisplayName("Payment Type")]
        [ForeignKey("IdPaymentType")]
        [Required(ErrorMessage = "A Payment Type is required")]
        public int PaymentType { get; set; }
    }
}
