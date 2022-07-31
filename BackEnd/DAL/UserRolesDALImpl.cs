using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public  class UserRolesDALImpl : IUserRolesDAL 
    {

        proyectoCreditosContext context;

        public UserRolesDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(UserRole entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
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

        public UserRole Get(int UserRoleId)
        {
            try
            {
                UserRole userRole;
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
                {
                    userRole = unidad.genericDAL.Get(UserRoleId);
                }
                return userRole;
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
                IEnumerable<UserRole> userRoles;
                using (UnidadDeTrabajo<UserRole> unidad = new UnidadDeTrabajo<UserRole>(context))
                {
                    userRoles = unidad.genericDAL.GetAll();
                }
                return userRoles.ToList();
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
                return false;
            }
            return result;
        }

        //Other Opctions Not Used

        public void AddRange(IEnumerable<UserRole> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> Find(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<UserRole> entities)
        {
            throw new NotImplementedException();
        }

        public UserRole SingleOrDefault(Expression<Func<UserRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
