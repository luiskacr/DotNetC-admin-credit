using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEndAPI.Models
{
    public class PaymentTypeModel
    {
  
        public int IdPaymentType { get; set; }
        public string PaymentTypeName { get; set; } = null!;
    }
}
