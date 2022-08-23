using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DAL
{
    public class LoansHistoryDALImpl : ILoansHistoryDAL
    {
        proyectoCreditosContext context;

        public LoansHistoryDALImpl()
        {
            context = new proyectoCreditosContext();
        }

        public bool Add(LoansHistory entity)
        {
            try
            {
                LoanDALImpl loanDALImpl = new LoanDALImpl();

                Loan CurrenLoan = loanDALImpl.Get((int)entity.LoadId);

                entity.PayDate = DateTime.UtcNow;

                if ((decimal)CurrenLoan.MonthlyAmount == (decimal)entity.PaymentAmount)
                {
                    entity.PaymentType = 1;
                    return insert(entity);
                }
                else if ((decimal)CurrenLoan.MonthlyAmount < (decimal)entity.PaymentAmount)
                {
                    decimal? diference = entity.PaymentAmount - CurrenLoan.MonthlyAmount;

                    entity.PaymentType = 1;
                    entity.PaymentAmount = (decimal)CurrenLoan.MonthlyAmount;

                    bool MonthlyPay = insert(entity);

                    entity.PaymentType = 2;
                    entity.PaymentAmount = (decimal)diference;

                    bool ExtraordinaryPay = insert(entity);

                    if (MonthlyPay & ExtraordinaryPay)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }

                }
                else 
                {
                    entity.PaymentType = 2;
                    return insert(entity);
                }

                //Business Logic

                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
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

        private bool insert(LoansHistory entity) 
        {
            try
            {
                String sqlScript = "INSERT INTO loansHistories (loadId,paymentAmount,paymentType) values(@loadId,@paymentAmount,@paymentType)";
                var parament = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@loadId",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.LoadId
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@paymentAmount",
                        SqlDbType = System.Data.SqlDbType.Decimal,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.PaymentAmount
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@paymentType",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = entity.PaymentType
                    },
                };

                var result = context.Database.ExecuteSqlRaw(sqlScript, parament);

                if (result == 1)
                {
                    return true;
                }
                else {
                    return false;
                }

            }
            catch (Exception e) 
            {
                throw;
            }
        }

        public LoansHistory Get(int loansHistoryId)
        {
            try
            {
                LoansHistory loansHistory;
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
                {
                    loansHistory = unidad.genericDAL.Get(loansHistoryId);
                }
                return loansHistory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansHistory> GetbyLoan(int loansId)
        {
            try
            {
                IEnumerable<LoansHistory> loansHistories;
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
                {
                    loansHistories = unidad.genericDAL.GetAll().Where(m => m.LoadId == loansId);
                }
                return loansHistories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LoansHistory> GetAll()
        {
            try
            {
                IEnumerable<LoansHistory> loansHistories;
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
                {
                    loansHistories = unidad.genericDAL.GetAll();
                }
                return loansHistories.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(LoansHistory entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
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

        public bool Update(LoansHistory entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<LoansHistory> unidad = new UnidadDeTrabajo<LoansHistory>(context))
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

        public void AddRange(IEnumerable<LoansHistory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoansHistory> Find(Expression<Func<LoansHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LoansHistory> entities)
        {
            throw new NotImplementedException();
        }

        public LoansHistory SingleOrDefault(Expression<Func<LoansHistory, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
