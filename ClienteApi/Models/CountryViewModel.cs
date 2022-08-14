using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class CountryViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int IdCountry { get; set; }

        [DisplayName("Nombre Pais")]
        [Required(ErrorMessage = "El nombre del Pais es requerido")]
        public string CountryName { get; set; } = null!;
    }
}
