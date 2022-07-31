using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class CustomerModel
    {
        [Key]
        public int IdCustomers { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "A First Name is required")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "A Last Name is required")]
        public string LastName { get; set; } = null!;

        [DisplayName("Identification Document")]
        [Required(ErrorMessage = "A Identification Document is required")]
        public string DocumentId { get; set; } = null!;

        [DisplayName("Email")]
        [Required(ErrorMessage = "A Email is required")]
        public string Email { get; set; } = null!;

        [DisplayName("Telephone")]
        [Required(ErrorMessage = "A Telephone is required")]
        public string Telephone { get; set; } = null!;

        [DisplayName("Birth Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "A Birth Date is required")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "An Address is required")]
        public string? UserAddress { get; set; }

        [ForeignKey("IdState")]
        [DisplayName("State")]
        [Required(ErrorMessage = "A State is required")]
        public int IdState { get; set; }
    }
}
