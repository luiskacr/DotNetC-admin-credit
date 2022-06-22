using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class CustomOrderList
    {
        public CustomOrderList()
        {
            DebtSnowballs = new HashSet<DebtSnowball>();
        }

        public int CustomOrderListId { get; set; }
        public int _01customOrderPosition { get; set; }
        public int _02customOrderPosition { get; set; }
        public int _03customOrderPosition { get; set; }
        public int _04customOrderPosition { get; set; }
        public int _05customOrderPosition { get; set; }
        public int _06customOrderPosition { get; set; }
        public int _07customOrderPosition { get; set; }
        public int _08customOrderPosition { get; set; }
        public int _09customOrderPosition { get; set; }
        public int _10customOrderPosition { get; set; }

        public virtual Loan _01customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _02customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _03customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _04customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _05customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _06customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _07customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _08customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _09customOrderPositionNavigation { get; set; } = null!;
        public virtual Loan _10customOrderPositionNavigation { get; set; } = null!;
        public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
    }
}
