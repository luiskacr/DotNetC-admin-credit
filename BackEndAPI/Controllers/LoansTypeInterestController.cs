using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansTypeInterestController : ControllerBase
    {
        private ILoansTypeInterestDAL loanTypeInterestDAL;

        public LoansTypeInterestController() 
        {
            loanTypeInterestDAL = new LoansTypeInterestDALImpl();
        }


        // GET: api/<LoansTypeInterestController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<LoansTypeInterest> loansTypeInterests = loanTypeInterestDAL.GetAll().ToList();
                List<LoansTypeInterestModel> result = new List<LoansTypeInterestModel>();
                foreach (LoansTypeInterest loansTypeInterest in loansTypeInterests)
                {
                    result.Add(objectToModelConvert(loansTypeInterest));
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

        // GET api/<LoansTypeInterestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoansTypeInterestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoansTypeInterestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoansTypeInterestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private LoansTypeInterestModel objectToModelConvert(LoansTypeInterest loansTypeInterest)
        {

            return new LoansTypeInterestModel
            {
                IdloansTypeInterest = loansTypeInterest.IdloansTypeInterest,
                IdloansType = loansTypeInterest.IdloansType,
                IdCurrencies = loansTypeInterest.IdCurrencies,
                InteresRate = loansTypeInterest.InteresRate,
                YearTime = loansTypeInterest.YearTime 
            };
        }

        private LoansTypeInterest ModelToObjectConvert(LoansTypeInterestModel loansTypeInterestModel)
        {

            return new LoansTypeInterest
            {
                IdloansTypeInterest = loansTypeInterestModel.IdloansTypeInterest,
                IdloansType = loansTypeInterestModel.IdloansType,
                IdCurrencies = loansTypeInterestModel.IdCurrencies,
                InteresRate = loansTypeInterestModel.InteresRate,
                YearTime = loansTypeInterestModel.YearTime
            };
        }
    }
}
