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
    public class LoadStateController : ControllerBase
    {
        private ILoanStateDAL loanStateDAL;

        public LoadStateController()
        {
            loanStateDAL = new LoanStateDALImpl();
        }

        // GET: api/<LoadStateController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<LoansState> loansStates = loanStateDAL.GetAll().ToList();
                List<LoadStateModel> result = new List<LoadStateModel>();
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

        // GET api/<LoadStateController>/5
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

        // POST api/<LoadStateController>
        [HttpPost]
        public JsonResult Post([FromBody] LoadStateModel loadState)
        {
            try
            {
                bool result = loanStateDAL.Add(ModelToObjectConvert(loadState));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loadState))
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

        // PUT api/<LoadStateController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] LoadStateModel loadState)
        {
            try
            {
                bool result = loanStateDAL.Update(ModelToObjectConvert(loadState));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(loadState))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Load State" })
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

        // DELETE api/<LoadStateController>/5
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

        private LoadStateModel objectToModelConvert(LoansState loansState)
        {

            return new LoadStateModel
            {
                LoansStatesId = loansState.LoansStatesId,
                LoansStateName = loansState.LoansStateName
            };
        }

        private LoansState ModelToObjectConvert(LoadStateModel loadStateModel)
        {

            return new LoansState
            {
                LoansStatesId = loadStateModel.LoansStatesId,
                LoansStateName = loadStateModel.LoansStateName
            };
        }
    }
}
