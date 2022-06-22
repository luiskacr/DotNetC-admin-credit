using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class User
    {
        public User()
        {
            DebtSnowballs = new HashSet<DebtSnowball>();
            Loans = new HashSet<Loan>();
        }

        public int UserId { get; set; }
        public int UserRoles { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Paassword { get; set; } = null!;
        public DateTime BirthDay { get; set; }
        public int DocumentId { get; set; }
        public string Adddress { get; set; } = null!;

        public virtual UserRole UserRolesNavigation { get; set; } = null!;
        public virtual ICollection<DebtSnowball> DebtSnowballs { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
