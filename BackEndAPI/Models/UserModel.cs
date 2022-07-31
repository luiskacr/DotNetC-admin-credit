using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "An User Name is required")]
        public string UserName { get; set; } = null!;

        [DisplayName("User Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "An User Password is required")]
        public string UserPassword { get; set; } = null!;

        [DisplayName("User Role")]
        [Required(ErrorMessage = "An User Role is required")]
        [ForeignKey("IdUserRole")]
        public int UserRole { get; set; }

        [DisplayName("User Customers")]
        [ForeignKey("IdCustomers")]
        public int? IdCustomers { get; set; }
    }
}
