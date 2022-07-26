using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "")]
        public int UserRoles { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Telephone is required")]
        [Display(Name = "First Name")]
        public string Telephone { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Paassword { get; set; } = null!;

        [Required]
        [Display(Name = "BirthDay")]
        public DateTime BirthDay { get; set; }

        [Required]
        [Display(Name = "")]
        public int DocumentId { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Adddress { get; set; } = null!;

        //public virtual UserRole UserRolesNavigation { get; set; } = null!;
        //public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
        //public virtual ICollection<Loan> Loans { get; set; }
    }
}
