using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class CustomerDALImpl : ICustomerDAL
    {
        proyectoCreditosContext context;

        public CustomerDALImpl() {
            context = new proyectoCreditosContext();
        }


        public bool Add(Customer entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
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

        public Customer Get(int CustomerId)
        {
            try
            {
                Customer customer;
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
                {
                    customer = unidad.genericDAL.Get(CustomerId);
                }
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                IEnumerable<Customer> Customers;
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
                {
                    Customers = unidad.genericDAL.GetAll();
                }
                return Customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Customer entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
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

        public bool Update(Customer entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Customer> unidad = new UnidadDeTrabajo<Customer>(context))
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

        public void AddRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public Customer SingleOrDefault(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
