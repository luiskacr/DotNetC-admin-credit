using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansHistoryController : ControllerBase
    {
        private ILoansHistoryDAL loansHistoryDAL;

        public LoansHistoryController() {
            loansHistoryDAL = new LoansHistoryDALImpl();
        }

        // GET: api/<LoansHistoryController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<LoansHistory> loansHistories = loansHistoryDAL.GetAll().ToList();
                List<LoanHistoryModel> result = new List<LoanHistoryModel>();
                foreach (LoansHistory loansHistory in loansHistories)
                {
                    result.Add(objectToModelConvert(loansHistory));
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

        [Route("GetbyLoan/{id}")]
        [HttpGet]
        public JsonResult GetbyLoan(int id)
        {
            try
            {
                List<LoansHistory> loansHistories = loansHistoryDAL.GetbyLoan(id).ToList();
                List<LoanHistoryModel> result = new List<LoanHistoryModel>();
                foreach (LoansHistory loansHistory in loansHistories)
                {
                    result.Add(objectToModelConvert(loansHistory));
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

        // GET api/<LoansHistoryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                LoansHistory loansHistory = loansHistoryDAL.Get(id);
                if (loansHistory != null)
                {
                    return new JsonResult(objectToModelConvert(loansHistory))
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "The ID is not correct" })
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

        // POST api/<LoansHistoryController>
        [HttpPost]
        public JsonResult Post([FromBody] LoanHistoryModel loanHistory)
        {
            try
            {
                bool result = loansHistoryDAL.Add(ModelToObjectConvert(loanHistory));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loanHistory))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Loan History" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        // PUT api/<LoansHistoryController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] LoanHistoryModel loanHistory)
        {
            try
            {
                bool result = loansHistoryDAL.Update(ModelToObjectConvert(loanHistory));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loanHistory))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Loan History" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        // DELETE api/<LoansHistoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                LoansHistory loansHistory = new LoansHistory()
                {
                    IdLoansHistory = id
                };
                bool result = loansHistoryDAL.Remove(loansHistory);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Loans History" })
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        private LoanHistoryModel objectToModelConvert(LoansHistory loansHistory)
        {

            return new LoanHistoryModel
            {
                IdLoansHistory = (int)loansHistory.IdLoansHistory,
                LoadId = (int)loansHistory.LoadId,
                PaymentAmount = (decimal)loansHistory.PaymentAmount,
                PayDate = (DateTime)loansHistory.PayDate,
                PaymentType = (int)loansHistory.PaymentType
            };
        }

        private LoansHistory ModelToObjectConvert(LoanHistoryModel loanHistoryModel)
        {

            return new LoansHistory
            {
                IdLoansHistory = loanHistoryModel.IdLoansHistory,
                LoadId = loanHistoryModel.LoadId,
                PaymentAmount = loanHistoryModel.PaymentAmount,
                PayDate = loanHistoryModel.PayDate,
                PaymentType = loanHistoryModel.PaymentType
            };
        }
    }
}
