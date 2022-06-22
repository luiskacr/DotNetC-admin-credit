using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class PayOffStragedy
    {
        public PayOffStragedy()
        {
            DebtSnowballs = new HashSet<DebtSnowball>();
        }

        public int PayOffOrderId { get; set; }
        public string StragedyName { get; set; } = null!;

        public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
    }
}
