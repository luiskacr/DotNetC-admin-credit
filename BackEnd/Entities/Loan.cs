using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Loan
    {
        public Loan()
        {
            CustomOrderList_01customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_02customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_03customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_04customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_05customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_06customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_07customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_08customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_09customOrderPositionNavigations = new HashSet<CustomOrderList>();
            CustomOrderList_10customOrderPositionNavigations = new HashSet<CustomOrderList>();
            PaymentHistories = new HashSet<PaymentHistory>();
        }

        public int LoansId { get; set; }
        public int UserId { get; set; }
        public int CorrencyId { get; set; }
        public int LoansStatesId { get; set; }
        public string Description { get; set; } = null!;
        public decimal LoanAmount { get; set; }
        public decimal MontlyPayment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double InterestRate { get; set; }
        public decimal BankFees { get; set; }
        public DateTime NextDueDate { get; set; }

        public virtual Corrency Corrency { get; set; } = null!;
        public virtual LoansState LoansStates { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<CustomOrderList> CustomOrderList_01customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_02customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_03customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_04customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_05customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_06customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_07customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_08customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_09customOrderPositionNavigations { get; set; }
        public virtual ICollection<CustomOrderList> CustomOrderList_10customOrderPositionNavigations { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
    }
}
