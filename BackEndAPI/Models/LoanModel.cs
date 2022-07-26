using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class LoanModel
    {

        [Key]
        public int LoansId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        [Display(Name = "")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "CorrencyId  is required")]
        [Display(Name = "")]
        public int CorrencyId { get; set; }

        [Required(ErrorMessage = "LoansStatesID is required")]
        [Display(Name = "")]
        public int LoansStatesId { get; set; }

        [Required(ErrorMessage = "Descripcion is required")]
        [Display(Name = "Descripcion")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "LoanAmount is required")]
        [Display(Name = "Loan Amount")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "MontlyPayment is required")]
        [Display(Name = "MontlyPayment")]
        public decimal MontlyPayment { get; set; }

        [Required]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "InterestRate is required")]
        [Display(Name = "InterestRate")]
        public double InterestRate { get; set; }

        [Required(ErrorMessage = "BankFees is required")]
        [Display(Name = "BankFees")]
        public decimal BankFees { get; set; }

        [Required]
        [Display(Name = "NextDueDate")]
        public DateTime NextDueDate { get; set; }



        // public virtual Corrency Corrency { get; set; } = null!;
        // public virtual LoansState LoansStates { get; set; } = null!;
        //  public virtual User User { get; set; } = null!;
        // public virtual ICollection<CustomOrderList> CustomOrderList_01customOrderPositionNavigations { get; set; }
        //  public virtual ICollection<CustomOrderList> CustomOrderList_02customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_03customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_04customOrderPositionNavigations { get; set; }
        //  public virtual ICollection<CustomOrderList> CustomOrderList_05customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_06customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_07customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_08customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_09customOrderPositionNavigations { get; set; }
        // public virtual ICollection<CustomOrderList> CustomOrderList_10customOrderPositionNavigations { get; set; }
        // public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
    }
}
