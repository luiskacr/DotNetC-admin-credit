using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class LoansHistoryDALImpl : ILoansHistoryDAL
    {
        proyectoCreditosContext context;

        public LoansHistoryDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(LoansHistory entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
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

        public LoansHistory Get(int loansHistoryId)
        {
            try
            {
                LoansHistory loansHistory;
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
                {
                    loansHistory = unidad.genericDAL.Get(loansHistoryId);
                }
                return loansHistory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansHistory> GetbyLoan(int loansId)
        {
            try
            {
                IEnumerable<LoansHistory> loansHistories;
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
                {
                    loansHistories = unidad.genericDAL.GetAll().Where(m => m.LoadId == loansId);
                }
                return loansHistories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansHistory> GetAll()
        {
            try
            {
                IEnumerable<LoansHistory> loansHistories;
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
                {
                    loansHistories = unidad.genericDAL.GetAll();
                }
                return loansHistories.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LoansHistory entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
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

        public bool Update(LoansHistory entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
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

        public void AddRange(IEnumerable<LoansHistory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansHistory> Find(Expression<Func<LoansHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LoansHistory> entities)
        {
            throw new NotImplementedException();
        }

        public LoansHistory SingleOrDefault(Expression<Func<LoansHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
