using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Models
{
    public class LoginViewModel
    {


        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El Usuario es un campo Requerido")]
        public string UserName { get; set; }



        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La Contraseña es un campo Requerido")]
        public string Password { get; set; }

       


    }
}
