using BackEnd.Entities;
using BackEndAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class LoansTypeInterestDALImpl : ILoansTypeInterestDAL
    {

        proyectoCreditosContext context;

        public LoansTypeInterestDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(LoansTypeInterest entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<LoansTypeInterest> unidad = new UnidadDeTrabajo<LoansTypeInterest>(context))
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

   
        public LoansTypeInterest Get(int id)
        {
            try
            {
                LoansTypeInterest loansTypeInterest;
                using (UnidadDeTrabajo<LoansTypeInterest> unidad = new UnidadDeTrabajo<LoansTypeInterest>(context))
                {
                    loansTypeInterest = unidad.genericDAL.Get(id);
                }
                return loansTypeInterest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansTypeInterest> GetAll()
        {
            try
            {
                IEnumerable<LoansTypeInterest> loansTypeInterest;
                using (UnidadDeTrabajo<LoansTypeInterest> unidad = new UnidadDeTrabajo<LoansTypeInterest>(context))
                {
                    loansTypeInterest = unidad.genericDAL.GetAll();
                }
                return loansTypeInterest.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LoansTypeInterest entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansTypeInterest> unidad = new UnidadDeTrabajo<LoansTypeInterest>(context))
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

        public bool Update(LoansTypeInterest entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansTypeInterest> unidad = new UnidadDeTrabajo<LoansTypeInterest>(context))
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

        public void AddRange(IEnumerable<LoansTypeInterest> entities)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<LoansTypeInterest> Find(Expression<Func<LoansTypeInterest, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public void RemoveRange(IEnumerable<LoansTypeInterest> entities)
        {
            throw new NotImplementedException();
        }

        public LoansTypeInterest SingleOrDefault(Expression<Func<LoansTypeInterest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }
}
