using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using BackEndAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogLoanController : ControllerBase
    {
        private ILogLoanDAL logLoanDALImple;

        public LogLoanController()
        {
            logLoanDALImple = new LogLoanDALImpl();
        }

        // GET: api/<LogLoanController>
        [HttpGet]
        public JsonResult Get()
        {

            try
            {
                List<LogLoan> logLoans = logLoanDALImple.GetAll().ToList();
                List<LogLoanModel> result = new List<LogLoanModel>();
                foreach (LogLoan logLoan in logLoans)
                {
                    result.Add(objectToModelConvert(logLoan));
                }

                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        private LogLoanModel objectToModelConvert(LogLoan logLoan)
        {

            return new LogLoanModel
            {
                Idlog = logLoan.Idlog,
                IdLoan = logLoan.IdLoan,
                Idcustomers = logLoan.Idcustomers,
                StarDate = logLoan.StarDate,
                EndDate = logLoan.EndDate,
                InteresRate = logLoan.InteresRate,
                LoanAmount = logLoan.LoanAmount,
                CurrentAmount = logLoan.CurrentAmount,
                MonthlyAmount = logLoan.MonthlyAmount,
                NextDueDate = logLoan.NextDueDate,
                BankFees = logLoan.BankFees,
                LoansDescription = logLoan.LoansDescription,
                IdloansType = logLoan.IdloansType,
                IdCurrencies = logLoan.IdCurrencies,
                IdLoansState = logLoan.IdLoansState,
                TypeChange = logLoan.TypeChange,
                ChangeDate = logLoan.ChangeDate,
            };
        }


        /*

        // GET api/<LogLoanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogLoanController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LogLoanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogLoanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        */
    }
}
