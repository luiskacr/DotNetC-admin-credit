using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class LoanDALImpl : ILoanDAL
    {
        proyectoCreditosContext context;

        public LoanDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(Loan entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Loan Get(int loanId)
        {
            try
            {
                Loan loan;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loan = unidad.genericDAL.Get(loanId);
                }
                return loan;
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
                IEnumerable<Loan> loans;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loans = unidad.genericDAL.GetAll();
                }
                return loans.ToList();
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
                return false;
            }
            return result;
        }

        //Other Opctions Not Used

        public void AddRange(IEnumerable<Loan> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> Find(Expression<Func<Loan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Loan> entities)
        {
            throw new NotImplementedException();
        }

        public Loan SingleOrDefault(Expression<Func<Loan, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
