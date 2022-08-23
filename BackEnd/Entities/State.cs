using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Entities
{
    public partial class State
    {
        public State()
        {
            Customers = new HashSet<Customer>();
        }

   
        public int IdState { get; set; }
        public string StateName { get; set; } = null!;
        public int IdCountry { get; set; }

        public virtual Country IdCountryNavigation { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
