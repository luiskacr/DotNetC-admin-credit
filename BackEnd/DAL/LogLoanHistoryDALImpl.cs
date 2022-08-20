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
    public class LogLoanHistoryDALImpl : lLogLoanHistoryDAL
    {

        proyectoCreditosContext context;

        public LogLoanHistoryDALImpl() 
        {
            context = new proyectoCreditosContext();
        }

        public IEnumerable<LogLoanHistory> GetAll()
        {
            try
            {
                IEnumerable<LogLoanHistory> logLoanHistory;
                using (UnidadDeTrabajo<LogLoanHistory> unidad = new UnidadDeTrabajo<LogLoanHistory>(context))
                {
                    logLoanHistory = unidad.genericDAL.GetAll();
                }
                return logLoanHistory.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Other Opctions Not Used

        public bool Add(LogLoanHistory entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LogLoanHistory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogLoanHistory> Find(Expression<Func<LogLoanHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LogLoanHistory Get(int id)
        {
            throw new NotImplementedException();
        }

       

        public bool Remove(LogLoanHistory entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LogLoanHistory> entities)
        {
            throw new NotImplementedException();
        }

        public LogLoanHistory SingleOrDefault(Expression<Func<LogLoanHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(LogLoanHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
