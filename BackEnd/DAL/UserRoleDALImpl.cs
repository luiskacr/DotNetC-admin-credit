using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UserRoleDALImpl : IUserRoleDAL
    {
        ProyectoCreditosContext context;

        public UserRoleDALImpl()
        {
            context = new ProyectoCreditosContext();
        }

        public bool Add(UserRole entity)
        {
            try
            {
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
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

        public void AddRange(IEnumerable<UserRole> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> Find(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public UserRole Get(int id)
        {
            try
            {
                UserRole userRoleList;
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
                {
                    userRoleList = unidad.genericDAL.Get(id);
                }
                return userRoleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<UserRole> Get()
        {
            try
            {
                IEnumerable<UserRole> userRoleList;
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
                {
                    userRoleList = unidad.genericDAL.GetAll();
                }
                return userRoleList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<UserRole> GetAll()
        {
            try
            {
                IEnumerable<UserRole> userRoleList;
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
                {
                    userRoleList = unidad.genericDAL.GetAll();
                }
                return userRoleList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(UserRole entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
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

        public void RemoveRange(IEnumerable<UserRole> entities)
        {
            throw new NotImplementedException();
        }

        public UserRole SingleOrDefault(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserRole entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
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
