using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackEnd.Entities
{
    [Keyless]
    public class sp_DeleteAllLoans_Result
    {
        public bool Return { get; set; }
    }
}
