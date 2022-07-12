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
    public class DebtSnowballController : ControllerBase
    {
        private DebtSnowballDALImpl debtSnowballDAL;

        public DebtSnowballController()
        {
            debtSnowballDAL = new DebtSnowballDALImpl();
        }

        // GET: api/<DebtSnowballController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<DebtSnowball> debtSnowballs = debtSnowballDAL.GetAll().ToList();
                List<DebtSnowballModel> result = new List<DebtSnowballModel>();
                foreach (DebtSnowball debtSnowball in debtSnowballs)
                {
                    DebtSnowballModel debtSnowballModel = ObjectToModelConvert(debtSnowball);
                    result.Add(debtSnowballModel);
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

        // GET api/<DebtSnowballController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                DebtSnowball debtSnowball = debtSnowballDAL.Get(id);
                if (debtSnowball != null)
                {
                    return new JsonResult(debtSnowball)
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

        // POST api/<DebtSnowballController>
        [HttpPost]
        public JsonResult Post([FromBody] DebtSnowballModel debtSnowballModel)
        {
            try
            {
                DebtSnowball debtSnowball = ModelToObjectConvert(debtSnowballModel);

                bool result = debtSnowballDAL.Update(debtSnowball);

                if (result)
                {
                    return new JsonResult(debtSnowball)
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

        // PUT api/<DebtSnowballController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] DebtSnowballModel debtSnowballModel)
        {
            try
            {
                DebtSnowball debtSnowball = ModelToObjectConvert(debtSnowballModel);

                bool result = debtSnowballDAL.Add(debtSnowball);

                if (result)
                {
                    return new JsonResult(debtSnowball)
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

        // DELETE api/<DebtSnowballController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                DebtSnowball debtSnowball = new DebtSnowball()
                {
                    DebtSnowballId = id
                };

                bool result = debtSnowballDAL.Remove(debtSnowball);

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

        private DebtSnowballModel ObjectToModelConvert(DebtSnowball debtSnowball)
        {
            DebtSnowballModel debtSnowballModel = new DebtSnowballModel()
            {
                DebtSnowballId = debtSnowball.DebtSnowballId,
                UserId = debtSnowball.UserId,
                PayOffOrder = debtSnowball.PayOffOrder,
                CustomOrderListId = debtSnowball.CustomOrderListId,
                ExtraMonthlyPayment = debtSnowball.ExtraMonthlyPayment,
                MonlyPayment = debtSnowball.MonlyPayment
            };
            return debtSnowballModel;
        }

        private DebtSnowball ModelToObjectConvert(DebtSnowballModel debtSnowballModel)
        {
            DebtSnowball debtSnowball = new DebtSnowball()
            {
                DebtSnowballId = debtSnowballModel.DebtSnowballId,
                UserId = debtSnowballModel.UserId,
                PayOffOrder = debtSnowballModel.PayOffOrder,
                CustomOrderListId = debtSnowballModel.CustomOrderListId,
                ExtraMonthlyPayment = debtSnowballModel.ExtraMonthlyPayment,
                MonlyPayment = debtSnowballModel.MonlyPayment
            };
            return debtSnowball;
        }
    }
}
