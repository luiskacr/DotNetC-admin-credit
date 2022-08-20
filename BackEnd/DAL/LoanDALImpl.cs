using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DAL
{
    public class LoanDALImpl : ILoanDAL
    {
        proyectoCreditosContext context;

        public LoanDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(Loan entity)
        {
            try
            {
                //Business Logic

                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
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

        public Loan Get(int loanId)
        {
            try
            {
                Loan loan;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loan = unidad.genericDAL.Get(loanId);
                }
                return loan;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Loan> GetAll()
        {
            try
            {
                IEnumerable<Loan> loans;
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
                {
                    loans = unidad.genericDAL.GetAll();
                }
                return loans.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Loan entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
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

        public bool RemoveAll(int Id) 
        {
            bool result = false;
            
            try
            {
                List<sp_DeleteAllLoans_Result> results;
                string sql = " EXEC sp_delete_loans_all @idLoan " ;
                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@idLoan",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = Id
                    }
                };
                results = context.sp_DeleteAllLoans_Result.FromSqlRaw(sql, param).ToListAsync().Result;

                if (results[0].Return) 
                {
                    result = true;
                }
            }
            catch (Exception) 
            {
                result = false;
            }
            return result;
        }


        public bool Update(Loan entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Loan> unidad = new UnidadDeTrabajo<Loan>(context))
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

        public void AddRange(IEnumerable<Loan> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> Find(Expression<Func<Loan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Loan> entities)
        {
            throw new NotImplementedException();
        }

        public Loan SingleOrDefault(Expression<Func<Loan, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
