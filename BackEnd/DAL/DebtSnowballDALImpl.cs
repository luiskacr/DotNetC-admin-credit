using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class DebtSnowballDALImpl : IDebtSnowballDAL
    {
        ProyectoCreditosContext context;

        public DebtSnowballDALImpl()
        {
            context = new ProyectoCreditosContext();
        }

        public bool Add(DebtSnowball entity)
        {
            try
            {
                using (UnidadDeTrabajo<DebtSnowball> unidad = new UnidadDeTrabajo<DebtSnowball>(context))
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

        public void AddRange(IEnumerable<DebtSnowball> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DebtSnowball> Find(Expression<Func<DebtSnowball, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DebtSnowball Get(int id)
        {
            try
            {
                DebtSnowball debtSnowball;
                using (UnidadDeTrabajo<DebtSnowball> unidad = new UnidadDeTrabajo<DebtSnowball>(context))
                {
                    debtSnowball = unidad.genericDAL.Get(id);
                }
                return debtSnowball;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<DebtSnowball> Get()
        {
            try
            {
                IEnumerable<DebtSnowball> debtSnowballs;
                using (UnidadDeTrabajo<DebtSnowball> unidad = new UnidadDeTrabajo<DebtSnowball>(context))
                {
                    debtSnowballs = unidad.genericDAL.GetAll();
                }
                return debtSnowballs.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<DebtSnowball> GetAll()
        {
            try
            {
                IEnumerable<DebtSnowball> debtSnowballs;
                using (UnidadDeTrabajo<DebtSnowball> unidad = new UnidadDeTrabajo<DebtSnowball>(context))
                {
                    debtSnowballs = unidad.genericDAL.GetAll();
                }
                return debtSnowballs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(DebtSnowball entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<DebtSnowball> unidad = new UnidadDeTrabajo<DebtSnowball>(context))
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

        public void RemoveRange(IEnumerable<DebtSnowball> entities)
        {
            throw new NotImplementedException();
        }

        public DebtSnowball SingleOrDefault(Expression<Func<DebtSnowball, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(DebtSnowball entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<DebtSnowball> unidad = new UnidadDeTrabajo<DebtSnowball>(context))
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
