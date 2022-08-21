using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Authentication
{
    public class RegisterModel
    {
        public string Username { get; set; }
        
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
