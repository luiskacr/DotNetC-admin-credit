using Microsoft.AspNetCore.Mvc;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using BackEndAPI.Entities;
using System.Diagnostics.Metrics;

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
        public JsonResult Get(int id)
        {
            try
            {
                LoansTypeInterest loansTypeInterest = loanTypeInterestDAL.Get(id);
                if (loansTypeInterest != null)
                {
                    return new JsonResult(objectToModelConvert(loansTypeInterest))
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

        // POST api/<LoansTypeInterestController>
        [HttpPost]
        public JsonResult Post([FromBody] LoansTypeInterestModel loansTypeInterest)
        {
            try
            {
                bool result = loanTypeInterestDAL.Add(ModelToObjectConvert(loansTypeInterest));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loansTypeInterest))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including " })
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

        // PUT api/<LoansTypeInterestController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] LoansTypeInterestModel loansTypeInterest)
        {
            try
            {
                bool result = loanTypeInterestDAL.Update(ModelToObjectConvert(loansTypeInterest));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loansTypeInterest))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update " })
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

        // DELETE api/<LoansTypeInterestController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                LoansTypeInterest loansTypeInterest = new LoansTypeInterest()
                {
                    IdloansTypeInterest = id
                };
                bool result = loanTypeInterestDAL.Remove(loansTypeInterest);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete " })
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
