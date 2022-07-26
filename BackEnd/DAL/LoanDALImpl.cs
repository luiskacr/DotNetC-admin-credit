using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class LoanDALImpl : ILoanDAL
    {
        ProyectoCreditosContext context;

        public LoanDALImpl()
        {
            context = new ProyectoCreditosContext();
        }

        public bool Add(Loan entity)
        {
            try
            {
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddRange(IEnumerable<Loan> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> Find(Expression<Func<Loan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Loan Get(int id)
        {
            try
            {
                Loan loanList;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loanList = unidad.genericDAL.Get(id);
                }
                return loanList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<Loan> Get()
        {
            try
            {
                IEnumerable<Loan> loanList;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loanList = unidad.genericDAL.GetAll();
                }
                return loanList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Loan> GetAll()
        {
            try
            {
                IEnumerable<Loan> loanList;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loanList = unidad.genericDAL.GetAll();
                }
                return loanList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Loan entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<Loan> entities)
        {
            throw new NotImplementedException();
        }

        public Loan SingleOrDefault(Expression<Func<Loan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Loan entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
