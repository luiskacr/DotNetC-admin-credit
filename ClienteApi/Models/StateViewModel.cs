using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ClienteApi.Models
{
    public class StateViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int IdState { get; set; }

        [DisplayName("Provincia")]
        [Required(ErrorMessage = "El nombre de la Provincia es requerido")]
        public string StateName { get; set; } = null!;

        [DisplayName("Pais")]
        [Required(ErrorMessage = "El Pais es requerido")]
        public int IdCountry { get; set; }

    }
}
