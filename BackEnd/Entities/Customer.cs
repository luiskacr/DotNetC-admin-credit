using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Loans = new HashSet<Loan>();
        }

   
        public int IdCustomers { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string? UserAddress { get; set; }
        public int IdState { get; set; }

        public virtual State IdStateNavigation { get; set; } = null!;
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
