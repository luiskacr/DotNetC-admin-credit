using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class CustomOrderListModel
    {
        //public CustomOrderList(){ DebtSnowballs = new HashSet<DebtSnowball>();}

        [Key]
        public int CustomOrderListId { get; set; }


        [Required]
        [Display(Name = "")]
        public int _01customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _02customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _03customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _04customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _05customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _06customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _07customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _08customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _09customOrderPosition { get; set; }

        [Required]
        [Display(Name = "")]
        public int _10customOrderPosition { get; set; }

        //public virtual Loan _01customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _02customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _03customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _04customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _05customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _06customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _07customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _08customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _09customOrderPositionNavigation { get; set; } = null!;
        //public virtual Loan _10customOrderPositionNavigation { get; set; } = null!;
        //public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
    }
}
