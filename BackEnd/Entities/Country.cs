﻿using System;
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

    
        public int IdCountry { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<State> States { get; set; }
    }
}
