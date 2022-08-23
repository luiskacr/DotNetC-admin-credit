using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class LoanStateDALImpl : ILoanStateDAL
    {
        proyectoCreditosContext context;

        public LoanStateDALImpl()
        {
            context = new proyectoCreditosContext();
        }
        public bool Add(LoansState entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<LoansState> unidad = new UnidadDeTrabajo<LoansState>(context))
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

        public LoansState Get(int loansStateId)
        {
            try
            {
                LoansState loansState;
                using (UnidadDeTrabajo<LoansState> unidad = new UnidadDeTrabajo<LoansState>(context))
                {
                    loansState = unidad.genericDAL.Get(loansStateId);
                }
                return loansState;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansState> GetAll()
        {
            try
            {
                IEnumerable<LoansState> loansStates;
                using (UnidadDeTrabajo<LoansState> unidad = new UnidadDeTrabajo<LoansState>(context))
                {
                    loansStates = unidad.genericDAL.GetAll();
                }
                return loansStates.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LoansState entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansState> unidad = new UnidadDeTrabajo<LoansState>(context))
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

        public bool Update(LoansState entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansState> unidad = new UnidadDeTrabajo<LoansState>(context))
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

        public void AddRange(IEnumerable<LoansState> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansState> Find(Expression<Func<LoansState, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public void RemoveRange(IEnumerable<LoansState> entities)
        {
            throw new NotImplementedException();
        }

        public LoansState SingleOrDefault(Expression<Func<LoansState, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
