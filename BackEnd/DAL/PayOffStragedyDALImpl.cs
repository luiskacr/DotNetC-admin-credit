using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class PayOffStragedyDALImpl : IPayOffStragedyDAL
    {
        ProyectoCreditosContext context;

        public PayOffStragedyDALImpl()
        {
            context = new ProyectoCreditosContext();
        }

        public bool Add(PayOffStragedy entity)
        {
            try
            {
                using (UnidadDeTrabajo<PayOffStragedy> unidad = new UnidadDeTrabajo<PayOffStragedy>(context))
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

        public void AddRange(IEnumerable<PayOffStragedy> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PayOffStragedy> Find(Expression<Func<PayOffStragedy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public PayOffStragedy Get(int id)
        {
            try
            {
                PayOffStragedy payOffStragedy;
                using (UnidadDeTrabajo<PayOffStragedy> unidad = new UnidadDeTrabajo<PayOffStragedy>(context))
                {
                    payOffStragedy = unidad.genericDAL.Get(id);
                }
                return payOffStragedy;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<PayOffStragedy> Get()
        {
            try
            {
                IEnumerable<PayOffStragedy> payOffStragedies;
                using (UnidadDeTrabajo<PayOffStragedy> unidad = new UnidadDeTrabajo<PayOffStragedy>(context))
                {
                    payOffStragedies = unidad.genericDAL.GetAll();
                }
                return payOffStragedies.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PayOffStragedy> GetAll()
        {
            try
            {
                IEnumerable<PayOffStragedy> payOffStragedies;
                using (UnidadDeTrabajo<PayOffStragedy> unidad = new UnidadDeTrabajo<PayOffStragedy>(context))
                {
                    payOffStragedies = unidad.genericDAL.GetAll();
                }
                return payOffStragedies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(PayOffStragedy entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PayOffStragedy> unidad = new UnidadDeTrabajo<PayOffStragedy>(context))
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

        public void RemoveRange(IEnumerable<PayOffStragedy> entities)
        {
            throw new NotImplementedException();
        }

        public PayOffStragedy SingleOrDefault(Expression<Func<PayOffStragedy, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(PayOffStragedy entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PayOffStragedy> unidad = new UnidadDeTrabajo<PayOffStragedy>(context))
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
