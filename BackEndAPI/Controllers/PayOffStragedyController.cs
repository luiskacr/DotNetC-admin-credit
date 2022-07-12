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
    public class PayOffStragedyController : ControllerBase
    {
        private PayOffStragedyDALImpl payOffStragedyDAL;

        public PayOffStragedyController()
        {
            payOffStragedyDAL = new PayOffStragedyDALImpl();
        }

        // GET: api/<PayOffStragedyController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<PayOffStragedy> payOffStragedies = payOffStragedyDAL.GetAll().ToList();
                List<PayOffStragedyModel> result = new List<PayOffStragedyModel>();
                foreach (PayOffStragedy payOffStragedy in payOffStragedies)
                {
                    PayOffStragedyModel payOffStragedyModel = ObjectToModelConvert(payOffStragedy);
                    result.Add(payOffStragedyModel);
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

        // GET api/<PayOffStragedyController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                PayOffStragedy payOffStragedy = payOffStragedyDAL.Get(id);
                if (payOffStragedy != null)
                {
                    return new JsonResult(payOffStragedy)
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

        // POST api/<PayOffStragedyController>
        [HttpPost]
        public JsonResult Post([FromBody] PayOffStragedyModel payOffStragedyModel)
        {
            try
            {
                PayOffStragedy payOffStragedy = ModelToObjectConvert(payOffStragedyModel);

                bool result = payOffStragedyDAL.Update(payOffStragedy);

                if (result)
                {
                    return new JsonResult(payOffStragedy)
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
                    StatusCode = (int) HttpStatusCode.InternalServerError
                };
            }
        }

        // PUT api/<PayOffStragedyController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] PayOffStragedyModel payOffStragedyModel)
        {
            try
            {
                PayOffStragedy payOffStragedy = ModelToObjectConvert(payOffStragedyModel);

                bool result = payOffStragedyDAL.Add(payOffStragedy);

                if (result)
                {
                    return new JsonResult(payOffStragedy)
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

        // DELETE api/<PayOffStragedyController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                PayOffStragedy payOffStragedy = new PayOffStragedy()
                {
                    PayOffOrderId = id
                };

                bool result = payOffStragedyDAL.Remove(payOffStragedy);

                if (result)
                {
                    return new JsonResult("Ok: The data is deleted")
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

        private PayOffStragedyModel ObjectToModelConvert(PayOffStragedy payOffStragedy)
        {
            PayOffStragedyModel payOffStragedyModel = new PayOffStragedyModel()
            {
                PayOffOrderId = payOffStragedy.PayOffOrderId,
                StragedyName = payOffStragedy.StragedyName
            };
            return payOffStragedyModel;
        }

        private PayOffStragedy ModelToObjectConvert(PayOffStragedyModel payOffStragedyModel)
        {
            PayOffStragedy payOffStragedy = new PayOffStragedy()
            {
                PayOffOrderId = payOffStragedyModel.PayOffOrderId,
                StragedyName = payOffStragedyModel.StragedyName
            };
            return payOffStragedy;
        }

       
    }
}
