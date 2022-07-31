using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class StateModel
    {
        [Key]
        public int IdState { get; set; }

        [DisplayName("State Name")]
        [Required(ErrorMessage = "A State Name is required")]
        public string StateName { get; set; } = null!;

        [Required(ErrorMessage = "A Country is required")]
        [ForeignKey("IdCountry")]
        public int IdCountry { get; set; }
    }
}
