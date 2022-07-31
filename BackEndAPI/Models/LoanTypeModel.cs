using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEndAPI.Models
{
    public class LoanTypeModel
    {
        [Key]
        public int IdloansType { get; set; }

        [DisplayName("Loans Type Name")]
        [Required(ErrorMessage = "A Loans Type Name is required")]
        public string LoansTypeName { get; set; } = null!;
    }
}
