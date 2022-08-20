using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class DashboardDAL
    {
        proyectoCreditosContext context;
        LoanDALImpl loanDALImpl;
        CustomerDALImpl customerDALImpl;

        public DashboardDAL() 
        {
            context = new proyectoCreditosContext();
            loanDALImpl = new LoanDALImpl();
            customerDALImpl = new CustomerDALImpl();
        }

        public Dashboard Get()
        {
            Dashboard dashboard;
            IEnumerable<Customer> Customer ;
            IEnumerable<Loan> Loans;

            try
            {
                Customer = customerDALImpl.GetAll();

                int totalCustomers = Customer.Count();

                Loans = loanDALImpl.GetAll();

                int totalLoans = Loans.Count();

                int activeLoans = 0;
                int delayLoans = 0;

                foreach (Loan loan in Loans) 
                {
                    if (loan.IdLoansState == 4)
                    {
                        activeLoans = activeLoans + 1;
                    } else if (loan.IdLoansState == 8) 
                    {
                        delayLoans = delayLoans + 1;
                    }
                }

                dashboard = new Dashboard()
                {
                    totalCustomers = totalCustomers,
                    totalLoans = totalLoans,
                    activeLoans = activeLoans,
                    delayLoans = delayLoans,
                };

                return dashboard;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
