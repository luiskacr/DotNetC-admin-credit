using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class LoansTypeDALImpl : ILoansTypeDAL
    {
        proyectoCreditosContext context;

        public LoansTypeDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(LoansType entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<LoansType> unidad = new UnidadDeTrabajo<LoansType>(context))
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

        public LoansType Get(int loansTypeId)
        {
            try
            {
                LoansType loansType;
                using (UnidadDeTrabajo<LoansType> unidad = new UnidadDeTrabajo<LoansType>(context))
                {
                    loansType = unidad.genericDAL.Get(loansTypeId);
                }
                return loansType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansType> GetAll()
        {
            try
            {
                IEnumerable<LoansType> loansTypes;
                using (UnidadDeTrabajo<LoansType> unidad = new UnidadDeTrabajo<LoansType>(context))
                {
                    loansTypes = unidad.genericDAL.GetAll();
                }
                return loansTypes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LoansType entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansType> unidad = new UnidadDeTrabajo<LoansType>(context))
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

        public bool Update(LoansType entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansType> unidad = new UnidadDeTrabajo<LoansType>(context))
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

        public void AddRange(IEnumerable<LoansType> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansType> Find(Expression<Func<LoansType, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public void RemoveRange(IEnumerable<LoansType> entities)
        {
            throw new NotImplementedException();
        }

        public LoansType SingleOrDefault(Expression<Func<LoansType, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
