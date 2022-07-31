﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class UserDALImpl : IUserDAL
    {
        proyectoCreditosContext context;

        public UserDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(User entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
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

        public User Get(int userId)
        {
            try
            {
                User user;
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
                {
                    user = unidad.genericDAL.Get(userId);
                }
                return user;
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
                IEnumerable<User> countries;
                using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(context))
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
                return false;
            }
            return result;
        }

        //Other Opctions Not Used

        public void AddRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public User SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
