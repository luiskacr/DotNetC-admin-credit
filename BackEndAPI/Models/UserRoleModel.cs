using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UserRoleModel
    {
        [Key]
        public int IdUserRole { get; set; }

        [DisplayName("Role Name")]
        [Required(ErrorMessage = "A Role Name is required")]
        public string RoleName { get; set; } = null!;
    }
}
