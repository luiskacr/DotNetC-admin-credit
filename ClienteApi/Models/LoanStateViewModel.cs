using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class LoanStateViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int LoansStatesId { get; set; }

        [DisplayName("Estado de Préstamo")]
        [Required(ErrorMessage ="Debe ingresar el estado del préstamo")]
        public string LoansStateName { get; set; } = null!;
    }
}
