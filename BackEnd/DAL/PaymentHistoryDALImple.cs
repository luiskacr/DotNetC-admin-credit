using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    internal class PaymentHistoryDALImple : IPaymentHistoryDAL
    {
        ProyectoCreditosContext context;
        public PaymentHistoryDALImple() {
            context = new ProyectoCreditosContext();
        }
        public bool Add(PaymentHistory entity)
        {
            try {
                using (UnidadDeTrabajo<PaymentHistory> UnidadDeTrabajo = new UnidadDeTrabajo<PaymentHistory>(context)) {
                    UnidadDeTrabajo.genericDAL.Add(entity);
                    return UnidadDeTrabajo.Complete();
                }
            }catch(Exception) { 
                return false;
            }
        }

        public void AddRange(IEnumerable<PaymentHistory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentHistory> Find(Expression<Func<PaymentHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public PaymentHistory Get(int id)
        {
            try
            {
                PaymentHistory paymentHistory;
                using (UnidadDeTrabajo<PaymentHistory> UnidadDeTrabajo = new UnidadDeTrabajo<PaymentHistory>(context)) {
                    paymentHistory = UnidadDeTrabajo.genericDAL.Get(id);
                    return paymentHistory;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public IEnumerable<PaymentHistory> GetAll()
        {
            try
            {
                IEnumerable<PaymentHistory> paymentHistories;
                using (UnidadDeTrabajo<PaymentHistory> UnidadDeTrabajo = new UnidadDeTrabajo<PaymentHistory>(context))
                {
                    paymentHistories = UnidadDeTrabajo.genericDAL.GetAll();
                }
                return paymentHistories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(PaymentHistory entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PaymentHistory> UnidadDeTrabajo = new UnidadDeTrabajo<PaymentHistory>(context))
                {
                    UnidadDeTrabajo.genericDAL.Remove(entity);
                    result = UnidadDeTrabajo.Complete();
                }
                return result;
            }
            catch (Exception) {
                return result;
            }
        }

        public void RemoveRange(IEnumerable<PaymentHistory> entities)
        {
            throw new NotImplementedException();
        }

        public PaymentHistory SingleOrDefault(Expression<Func<PaymentHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaymentHistory entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<PaymentHistory> UnidadDeTrabajo = new UnidadDeTrabajo<PaymentHistory>(context)) { 
                    UnidadDeTrabajo.genericDAL.Update(entity);
                    result = UnidadDeTrabajo.Complete();
                }
                return result;
            }
            catch (Exception) {
                return result;
            }
        }
    }
}
