using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class PaymentHistoryModel
    {
        [Key]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Load is required")]
        [Display(Name = "Load")]
        public int LoadId { get; set; }


        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }


        [Required]
        [Display(Name = "Date of Payment")]
        public DateTime DatePayed { get; set; }

        //Uncomment when this model is created
        //public virtual Loan Load { get; set; } = null!;

    }
}
