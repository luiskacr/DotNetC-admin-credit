using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        [Key]
        public int IdCountry { get; set; }

        [DisplayName("Country Name")]
        [Required(ErrorMessage = "A Country Name is required")]
        public string CountryName { get; set; } = null!;

        public virtual ICollection<State> States { get; set; }
    }
}
