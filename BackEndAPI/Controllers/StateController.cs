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
    public class StateController : ControllerBase
    {
        private IStatesDAL statesDAL;

        public StateController()
        {
            statesDAL = new StateDALImpl();
        }

        // GET: api/<StateController>
        //[Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<State> states = statesDAL.GetAll().ToList();
                List<StateModel> result = new List<StateModel>();
                foreach (State state in states)
                {
                    result.Add(objectToModelConvert(state));
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


        // GET api/<StateController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                State state = statesDAL.Get(id);
                if (state != null)
                {
                    return new JsonResult(objectToModelConvert(state))
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

        // POST api/<StateController>
        //[Authorize]
        [HttpPost]
        public JsonResult Post([FromBody] StateModel state)
        {
            try
            {
                bool result = statesDAL.Add(ModelToObjectConvert(state));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(state))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including State" })
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

        // PUT api/<StateController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] StateModel state)
        {
            try
            {
                bool result = statesDAL.Update(ModelToObjectConvert(state));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(state))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update State" })
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

        // DELETE api/<StateController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                State state = new State()
                {
                    IdState = id
                };
                bool result = statesDAL.Remove(state);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete State" })
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

        private StateModel objectToModelConvert(State state)
        {
            return new StateModel
            {
                IdState = state.IdState,
                StateName = state.StateName,
                IdCountry = state.IdCountry
            };
        }

        private State ModelToObjectConvert(StateModel stateModel)
        {
            return new State
            {
                IdState = stateModel.IdState,
                StateName = stateModel.StateName,
                IdCountry = stateModel.IdCountry
            };
        }
    }
}
