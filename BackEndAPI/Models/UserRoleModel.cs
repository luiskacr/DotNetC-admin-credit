using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UserRoleModel
    {
        [Key]
        public int IduserRoles { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; } = null!;

        // public virtual ICollection<User> Users { get; set; }
    }
}
