using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndAPI.Models
{
    public class StateModel
    {
      
        public int IdState { get; set; }
        public string StateName { get; set; } = null!;
        public int IdCountry { get; set; }
    }
}
