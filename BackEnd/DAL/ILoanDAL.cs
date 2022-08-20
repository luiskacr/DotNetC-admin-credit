using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public  interface ILoanDAL : IDALGenerico<Loan>
    {
        public bool RemoveAll(int id);
    }
}
