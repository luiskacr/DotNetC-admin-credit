using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ClienteApi.Models
{
    public class CustomerViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int IdCustomers { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El Nombre del cliente es requerido")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El apellido del cliente es requerido")]
        public string LastName { get; set; } = null!;

        [DisplayName("Cedula")]
        [Required(ErrorMessage = "La cedula del cliente es requerido")]
        public string DocumentId { get; set; } = null!;

        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El Correo  del cliente es requerido")]
        public string Email { get; set; } = null!;

        [DisplayName("Telefono")]
        [Required(ErrorMessage = "El Telefono  del cliente es requerido")]
        public string Telephone { get; set; } = null!;

        [DisplayName("Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La Fecha de Nacimiento del cliente es requerido")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Direccion")]
        public string? UserAddress { get; set; }

        [DisplayName("Provincia")]
        [Required(ErrorMessage = "La Provincia es un campo Obligatorio")]
        public int IdState { get; set; }


    }
}
