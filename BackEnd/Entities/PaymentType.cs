using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEnd.Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            LoansHistories = new HashSet<LoansHistory>();
        }

        [Key]
        public int IdPaymentType { get; set; }

        [DisplayName("Payment Type Name")]
        [Required(ErrorMessage = "A Payment Type Name is required")]
        public string PaymentTypeName { get; set; } = null!;

        public virtual ICollection<LoansHistory> LoansHistories { get; set; }
    }
}
