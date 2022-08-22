using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;
using BackEndAPI.Entities;
using System.Linq.Expressions;

namespace BackEnd.DAL
{
    public class LogLoanDALImpl : ILogLoanDAL
    {
        proyectoCreditosContext context;

        public LogLoanDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public IEnumerable<LogLoan> GetAll()
        {
            try
            {
                IEnumerable<LogLoan> logLoan;
                using (UnidadDeTrabajo<LogLoan> unidad = new UnidadDeTrabajo<LogLoan>(context))
                {
                    logLoan = unidad.genericDAL.GetAll();
                }
                return logLoan.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Other Opctions Not Used

        public bool Add(LogLoan entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LogLoan> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogLoan> Find(Expression<Func<LogLoan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LogLoan Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(LogLoan entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LogLoan> entities)
        {
            throw new NotImplementedException();
        }

        public LogLoan SingleOrDefault(Expression<Func<LogLoan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(LogLoan entity)
        {
            throw new NotImplementedException();
        }
    }
}
