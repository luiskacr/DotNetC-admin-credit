using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class CountryModel
    {

        public int IdCountry { get; set; }
        public string CountryName { get; set; } = null!;
    }
}
