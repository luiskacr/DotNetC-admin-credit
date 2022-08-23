using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class LoanTypeViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int IdloansType { get; set; }

        [DisplayName("Tipo de Préstamo")]
        [Required(ErrorMessage ="Debe ingresar el tipo de préstamo")]
        public string LoansTypeName { get; set; } = null!;
    }
}
