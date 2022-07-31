using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class CurrencyDALImpl : ICurrencyDAL
    {
        proyectoCreditosContext context;

        public CurrencyDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(Currency entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<Currency> unidad = new UnidadDeTrabajo<Currency>(context))
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


        public Currency Get(int currencyId)
        {
            try
            {
                Currency currency;
                using (UnidadDeTrabajo<Currency> unidad = new UnidadDeTrabajo<Currency>(context))
                {
                    currency = unidad.genericDAL.Get(currencyId);
                }
                return currency;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Currency> GetAll()
        {
            try
            {
                IEnumerable<Currency> currency;
                using (UnidadDeTrabajo<Currency> unidad = new UnidadDeTrabajo<Currency>(context))
                {
                    currency = unidad.genericDAL.GetAll();
                }
                return currency.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Currency entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Currency> unidad = new UnidadDeTrabajo<Currency>(context))
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

        public bool Update(Currency entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Currency> unidad = new UnidadDeTrabajo<Currency>(context))
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

        public void AddRange(IEnumerable<Currency> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Currency> Find(Expression<Func<Currency, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public void RemoveRange(IEnumerable<Currency> entities)
        {
            throw new NotImplementedException();
        }

        public Currency SingleOrDefault(Expression<Func<Currency, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
