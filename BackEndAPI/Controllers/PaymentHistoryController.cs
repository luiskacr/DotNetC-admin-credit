using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentHistoryController : ControllerBase
    {
        private PaymentHistoryDALImple paymentHistoryDAL;

        public PaymentHistoryController()
        {
            paymentHistoryDAL = new PaymentHistoryDALImple();
        }

        // GET: api/<PaymentHistoryController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<PaymentHistory> paymentHistories = paymentHistoryDAL.GetAll().ToList();
                List<PaymentHistoryModel> results = new List<PaymentHistoryModel>();
                foreach (PaymentHistory paymentHistory in paymentHistories)
                {
                    PaymentHistoryModel model = ObjectToModelConvert(paymentHistory);
                    results.Add(model);
                }
                return new JsonResult(results)
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

        // GET api/<PaymentHistoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                PaymentHistory paymentHistory = paymentHistoryDAL.Get(id);
                if (paymentHistory != null)
                {
                    return new JsonResult(paymentHistory)
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: The ID is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.NotFound
                    };
                }

            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }

        // POST api/<PaymentHistoryController>
        [HttpPost]
        public JsonResult Post([FromBody] PaymentHistoryModel paymentHistoryModel)
        {
            try
            {
                PaymentHistory paymentHistory = ModelToObjectConvert(paymentHistoryModel);

                bool result = paymentHistoryDAL.Update(paymentHistory);

                if (result)
                {
                    return new JsonResult(paymentHistory)
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: Information is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }

            }
            catch (Exception ex)
            {

                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }

        // PUT api/<PaymentHistoryController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] PaymentHistoryModel paymentHistoryModel)
        {
            try
            {
                PaymentHistory paymentHistory = ModelToObjectConvert(paymentHistoryModel);
                bool result = paymentHistoryDAL.Add(paymentHistory);

                if (result)
                {
                    return new JsonResult(paymentHistory);
                }
                else
                {
                    return new JsonResult("Error: Information is not correct")
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }

        // DELETE api/<PaymentHistoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            try
            {
                PaymentHistory paymentHistory = new PaymentHistory
                {
                    PaymentId = id
                };
                bool result = paymentHistoryDAL.Remove(paymentHistory);

                if (result)
                {
                    return new JsonResult("Ok: The data is deleted ")
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: Information is not correct ")
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }

        //Custom Class Converter 

        private PaymentHistory ModelToObjectConvert(PaymentHistoryModel paymentHistoryModel)
        {
            PaymentHistory paymentHistory = new PaymentHistory();
            paymentHistory.PaymentId = paymentHistoryModel.PaymentId;
            paymentHistory.LoadId = paymentHistoryModel.LoadId;
            paymentHistory.Amount = paymentHistoryModel.Amount;
            paymentHistory.DatePayed = paymentHistoryModel.DatePayed;
            //Uncomment when this model is created
            //paymentHistory.Loan = paymentHistoryModel.Loan;

            return paymentHistory;
        }

        private PaymentHistoryModel ObjectToModelConvert(PaymentHistory paymentHistory)
        {

            PaymentHistoryModel paymentHistoryModel = new PaymentHistoryModel();
            paymentHistoryModel.PaymentId = paymentHistory.PaymentId;
            paymentHistoryModel.LoadId = paymentHistory.LoadId;
            paymentHistoryModel.Amount = paymentHistory.Amount;
            paymentHistoryModel.DatePayed = paymentHistory.DatePayed;
            //Uncomment when this model is created
            //paymentHistoryModel.Loan = paymentHistory.Loan;
            return paymentHistoryModel;
        }
    }
}
