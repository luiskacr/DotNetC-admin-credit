using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public partial class PayOffStragedy
    {
        public PayOffStragedy()
        {
            DebtSnowballs = new HashSet<DebtSnowball>();
        }

        [Key]
        public int PayOffOrderId { get; set; }

        [Required]
        [Display(Name = "")]
        public string StragedyName { get; set; } = null!;

        public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
    }
}
