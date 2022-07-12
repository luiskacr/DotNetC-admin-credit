using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class DebtSnowballModel
    {

        [Key]
        public int DebtSnowballId { get; set; }

        [Required]
        [Display(Name = "")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "")]
        public int PayOffOrder { get; set; }

        [Required]
        [Display(Name = "")]
        public int CustomOrderListId { get; set; }

        [Display(Name = "")]
        public int ExtraMonthlyPayment { get; set; }

        [Display(Name = "")]
        public int MonlyPayment { get; set; }

        //public virtual CustomOrderList CustomOrderList { get; set; } = null!;
        //public virtual PayOffStragedy PayOffOrderNavigation { get; set; } = null!;
        //public virtual User User { get; set; } = null!;
    }
}
