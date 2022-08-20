using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class LoansTypeInterestDALImpl : ILoansTypeInterestDAL
    {

        proyectoCreditosContext context;

        public LoansTypeInterestDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(LoansTypeInterest entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LoansTypeInterest> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansTypeInterest> Find(Expression<Func<LoansTypeInterest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LoansTypeInterest Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansTypeInterest> GetAll()
        {
            try
            {
                IEnumerable<LoansTypeInterest> loansTypeInterest;
                using (UnidadDeTrabajo<LoansTypeInterest> unidad = new UnidadDeTrabajo<LoansTypeInterest>(context))
                {
                    loansTypeInterest = unidad.genericDAL.GetAll();
                }
                return loansTypeInterest.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LoansTypeInterest entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LoansTypeInterest> entities)
        {
            throw new NotImplementedException();
        }

        public LoansTypeInterest SingleOrDefault(Expression<Func<LoansTypeInterest, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(LoansTypeInterest entity)
        {
            throw new NotImplementedException();
        }
    }
}
