using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteAPI.Models
{
    public class RegisterViewModel
    {
        [DisplayName("Nombre de Usuario")]
        [Required(ErrorMessage = "Debe ingresar el Nombre de Usuario")]
        public string Username { get; set; }


        [DisplayName("Correo Electronico")]
        [Required(ErrorMessage = "Debe ingresar el Correo")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Debe ingresar la Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Contraseñas no Coinciden")]
        [Required(ErrorMessage = "Debe Confirmar Contraseña")]
        public string ComfirmPassword { get; set; }
    }
}
