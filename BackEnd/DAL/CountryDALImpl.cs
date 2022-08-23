using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class CountryDALImpl : ICountryDAL
    {
        proyectoCreditosContext context;

        public CountryDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(Country entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<Country> unidad = new UnidadDeTrabajo<Country>(context))
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

        public Country Get(int CountryId)
        {
            try
            {
                Country country;
                using (UnidadDeTrabajo<Country> unidad = new UnidadDeTrabajo<Country>(context))
                {
                    country = unidad.genericDAL.Get(CountryId);
                }
                return country;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Country> GetAll()
        {
            try
            {
                IEnumerable<Country> countries;
                using (UnidadDeTrabajo<Country> unidad = new UnidadDeTrabajo<Country>(context))
                {
                    countries = unidad.genericDAL.GetAll();
                }
                return countries.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Country entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Country> unidad = new UnidadDeTrabajo<Country>(context))
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

        public bool Update(Country entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Country> unidad = new UnidadDeTrabajo<Country>(context))
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
        public void RemoveRange(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }

        public Country SingleOrDefault(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Country> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> Find(Expression<Func<Country, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
