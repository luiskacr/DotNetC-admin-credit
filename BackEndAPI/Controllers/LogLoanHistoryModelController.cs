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
    public class LogLoanHistoryModelController : ControllerBase
    {

        private lLogLoanHistoryDAL logLoanHistoryDAL;


        public LogLoanHistoryModelController() 
        {
            logLoanHistoryDAL = new LogLoanHistoryDALImpl();
        }

        // GET: api/<LogLoanHistoryModelController>
        //[Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<LogLoanHistory> logLoanHistories = logLoanHistoryDAL.GetAll().ToList();
                List<LogLoanHistoryModel> result = new List<LogLoanHistoryModel>();
                foreach (LogLoanHistory logLoanHistory in logLoanHistories)
                {
                    result.Add(objectToModelConvert(logLoanHistory));
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

        private LogLoanHistoryModel objectToModelConvert(LogLoanHistory logLoanHistory)
        {

            return new LogLoanHistoryModel
            {
                Idlog = logLoanHistory.Idlog,
                IdLoansHistory = logLoanHistory.IdLoansHistory,
                LoadId = logLoanHistory.LoadId,
                PaymentAmount = logLoanHistory.PaymentAmount,
                PayDate = logLoanHistory.PayDate,
                PaymentType = logLoanHistory.PaymentType,
                TypeChange = logLoanHistory.TypeChange,
                ChangeDate = logLoanHistory.ChangeDate,
            };
        }


        /*

        // GET api/<LogLoanHistoryModelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogLoanHistoryModelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LogLoanHistoryModelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogLoanHistoryModelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
