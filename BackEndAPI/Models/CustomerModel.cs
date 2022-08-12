using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class CustomerModel
    {
      
        public int IdCustomers { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? UserAddress { get; set; }
        public int IdState { get; set; }
    }
}
