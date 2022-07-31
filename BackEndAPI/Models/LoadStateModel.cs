using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEndAPI.Models
{
    public class LoadStateModel
    {
        [Key]
        public int LoansStatesId { get; set; }

        [DisplayName("Loans State Name")]
        [Required(ErrorMessage = "A Loans State Name is required")]
        public string LoansStateName { get; set; } = null!;
    }
}
