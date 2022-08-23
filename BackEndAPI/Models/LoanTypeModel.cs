using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEndAPI.Models
{
    public class LoanTypeModel
    {
      
        public int IdloansType { get; set; }
        public string LoansTypeName { get; set; } = null!;
    }
}
