using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BackEndAPI.Models
{
    public class LoanStateModel
    {
      
        public int LoansStatesId { get; set; }
        public string LoansStateName { get; set; } = null!;
    }
}
