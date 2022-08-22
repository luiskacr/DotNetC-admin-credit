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
    public class LoanStateController : ControllerBase
    {
        private ILoanStateDAL loanStateDAL;

        public LoanStateController()
        {
            loanStateDAL = new LoanStateDALImpl();
        }

        // GET: api/<LoadStateController>
        //[Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<LoansState> loansStates = loanStateDAL.GetAll().ToList();
                List<LoanStateModel> result = new List<LoanStateModel>();
                foreach (LoansState loansState in loansStates)
                {
                    result.Add(objectToModelConvert(loansState));
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

        // GET api/<LoanStateController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                LoansState loansState = loanStateDAL.Get(id);
                if (loansState != null)
                {
                    return new JsonResult(objectToModelConvert(loansState))
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

        // POST api/<LoanStateController>
        //[Authorize]
        [HttpPost]
        public JsonResult Post([FromBody] LoanStateModel loanState)
        {
            try
            {
                bool result = loanStateDAL.Add(ModelToObjectConvert(loanState));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loanState))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Load State" })
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

        // PUT api/<LoanStateController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] LoanStateModel loanState)
        {
            try
            {
                bool result = loanStateDAL.Update(ModelToObjectConvert(loanState));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loanState))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Loan State" })
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

        // DELETE api/<LoanStateController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                LoansState loansState = new LoansState()
                {
                    LoansStatesId = id
                };
                bool result = loanStateDAL.Remove(loansState);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Loans State" })
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

        private LoanStateModel objectToModelConvert(LoansState loansState)
        {

            return new LoanStateModel
            {
                LoansStatesId = loansState.LoansStatesId,
                LoansStateName = loansState.LoansStateName
            };
        }

        private LoansState ModelToObjectConvert(LoanStateModel loanStateModel)
        {

            return new LoansState
            {
                LoansStatesId = loanStateModel.LoansStatesId,
                LoansStateName = loanStateModel.LoansStateName
            };
        }
    }
}
