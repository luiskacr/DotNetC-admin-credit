using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEndAPI.Models
{
    public class PaymentTypeModel
    {
        [Key]
        public int IdPaymentType { get; set; }

        [DisplayName("Payment Type Name")]
        [Required(ErrorMessage = "A Payment Type Name is required")]
        public string PaymentTypeName { get; set; } = null!;
    }
}
