using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class CountryModel
    {
        [Key]
        [Required(ErrorMessage = "A Id is required")]
        public int IdCountry { get; set; }

        
        [DisplayName("Country Name")]
        [Required(ErrorMessage = "A Country Name is required")]
        public string CountryName { get; set; } = null!;
    }
}
