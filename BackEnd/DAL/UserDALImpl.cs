using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UserDALImpl : IUserDAL
    {
        ProyectoCreditosContext context;

        public UserDALImpl()
        {
            context = new ProyectoCreditosContext();
        }

        public bool Add(User entity)
        {
            try
            {
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
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

        public void AddRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            try
            {
                User userList;
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
                {
                    userList = unidad.genericDAL.Get(id);
                }
                return userList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        List<User> Get()
        {
            try
            {
                IEnumerable<User> userList;
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
                {
                    userList = unidad.genericDAL.GetAll();
                }
                return userList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                IEnumerable<User> userList;
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
                {
                    userList = unidad.genericDAL.GetAll();
                }
                return userList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(User entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
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

        public void RemoveRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public User SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
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
