using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class PayOffStragedyModel
    {
        //public PayOffStragedy(){DebtSnowballs = new HashSet<DebtSnowball>();}

        [Key]
        public int PayOffOrderId { get; set; }

        [Required]
        [Display(Name = "")]
        public string StragedyName { get; set; } = null!;

        //public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
    }
}
