using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class PaymentTypeDALImpl : IPaymentTypeDAL
    {
        proyectoCreditosContext context;

        public PaymentTypeDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(PaymentType entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<PaymentType> unidad = new UnidadDeTrabajo<PaymentType>(context))
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

        public PaymentType Get(int paymentTypeId)
        {
            try
            {
                PaymentType paymentType;
                using (UnidadDeTrabajo<PaymentType> unidad = new UnidadDeTrabajo<PaymentType>(context))
                {
                    paymentType = unidad.genericDAL.Get(paymentTypeId);
                }
                return paymentType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PaymentType> GetAll()
        {
            try
            {
                IEnumerable<PaymentType> paymentType;
                using (UnidadDeTrabajo<PaymentType> unidad = new UnidadDeTrabajo<PaymentType>(context))
                {
                    paymentType = unidad.genericDAL.GetAll();
                }
                return paymentType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(PaymentType entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PaymentType> unidad = new UnidadDeTrabajo<PaymentType>(context))
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

        public bool Update(PaymentType entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PaymentType> unidad = new UnidadDeTrabajo<PaymentType>(context))
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

        public void AddRange(IEnumerable<PaymentType> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentType> Find(Expression<Func<PaymentType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<PaymentType> entities)
        {
            throw new NotImplementedException();
        }

        public PaymentType SingleOrDefault(Expression<Func<PaymentType, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
