using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class PaymentTypeViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int IdPaymentType { get; set; }

        [DisplayName("Nombre de Tipo de Cambio")]
        [Required(ErrorMessage ="Debe ingresar el tipo de cambio")]
        public string PaymentTypeName { get; set; } = null!;
    }
}
