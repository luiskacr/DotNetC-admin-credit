using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public partial class LoansType
    {
        public LoansType()
        {
            Loans = new HashSet<Loan>();
        }

        [Key]
        public int IdloansType { get; set; }

        [DisplayName("Loans Type Name")]
        [Required(ErrorMessage = "A Loans Type Name is required")]
        public string LoansTypeName { get; set; } = null!;

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
