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
    public class LoansTypeController : ControllerBase
    {
        private ILoansTypeDAL loansTypeDAL;

        public LoansTypeController() {
            loansTypeDAL = new LoansTypeDALImpl();
        }

        // GET: api/<LoansTypeController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<LoansType> loansTypes = loansTypeDAL.GetAll().ToList();
                List<LoanTypeModel> result = new List<LoanTypeModel>();
                foreach (LoansType loansType in loansTypes)
                {
                    result.Add(objectToModelConvert(loansType));
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

        // GET api/<LoansTypeController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                LoansType loansType = loansTypeDAL.Get(id);
                if (loansType != null)
                {
                    return new JsonResult(objectToModelConvert(loansType))
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

        // POST api/<LoansTypeController>
        [HttpPost]
        public JsonResult Post([FromBody] LoanTypeModel loanType)
        {
            try
            {
                bool result = loansTypeDAL.Add(ModelToObjectConvert(loanType));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loanType))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Loan Type" })
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

        // PUT api/<LoansTypeController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] LoanTypeModel loanType)
        {
            try
            {
                bool result = loansTypeDAL.Update(ModelToObjectConvert(loanType));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loanType))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Loan Type" })
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

        // DELETE api/<LoansTypeController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                LoansType loansType = new LoansType()
                {
                    IdloansType = id
                };
                bool result = loansTypeDAL.Remove(loansType);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Loans Type" })
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

        private LoanTypeModel objectToModelConvert(LoansType loansType)
        {

            return new LoanTypeModel
            {
                IdloansType = loansType.IdloansType,
                LoansTypeName = loansType.LoansTypeName
            };
        }

        private LoansType ModelToObjectConvert(LoanTypeModel loanTypeModel)
        {

            return new LoansType
            {
                IdloansType = loanTypeModel.IdloansType,
                LoansTypeName = loanTypeModel.LoansTypeName
            };
        }
    }
}
