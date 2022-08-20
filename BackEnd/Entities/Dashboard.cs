using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public  class Dashboard
    {
        public int totalCustomers { get; set; }
        public int totalLoans{ get; set; }
        public int activeLoans { get; set; }
        public int delayLoans { get; set; }
    }
}
