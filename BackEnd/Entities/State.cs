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

        [Key]
        public int IdState { get; set; }

        [DisplayName("State Name")]
        [Required(ErrorMessage = "A State Name is required")]
        public string StateName { get; set; } = null!;

        [DisplayName("Country")]
        [Required(ErrorMessage = "A Country is required")]
        [ForeignKey("IdCountry")]
        public int IdCountry { get; set; }

        public virtual Country IdCountryNavigation { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
