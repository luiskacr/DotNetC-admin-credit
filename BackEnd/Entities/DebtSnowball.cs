using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class DebtSnowball
    {
        public int DebtSnowballId { get; set; }
        public int UserId { get; set; }
        public int PayOffOrder { get; set; }
        public int CustomOrderListId { get; set; }
        public int ExtraMonthlyPayment { get; set; }
        public int MonlyPayment { get; set; }

        public virtual CustomOrderList CustomOrderList { get; set; } = null!;
        public virtual PayOffStragedy PayOffOrderNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
