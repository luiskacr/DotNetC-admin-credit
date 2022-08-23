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
    public class PaymentTypeController : ControllerBase
    {
        private IPaymentTypeDAL paymentTypeDAL;

        public PaymentTypeController()
        {
            paymentTypeDAL = new PaymentTypeDALImpl();
        }

        // GET: api/<PaymentTypeController>
        //[Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<PaymentType> paymentTypes = paymentTypeDAL.GetAll().ToList();
                List<PaymentTypeModel> result = new List<PaymentTypeModel>();
                foreach (PaymentType paymentType in paymentTypes)
                {
                    result.Add(objectToModelConvert(paymentType));
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

        // GET api/<PaymentTypeController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                PaymentType paymentType = paymentTypeDAL.Get(id);
                if (paymentType != null)
                {
                    return new JsonResult(objectToModelConvert(paymentType))
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

        // POST api/<PaymentTypeController>
        //[Authorize]
        [HttpPost]
        public JsonResult Post([FromBody] PaymentTypeModel paymentType)
        {
            try
            {
                bool result = paymentTypeDAL.Add(ModelToObjectConvert(paymentType));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(paymentType))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Payment Type" })
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

        // PUT api/<PaymentTypeController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] PaymentTypeModel paymentType)
        {
            try
            {
                bool result = paymentTypeDAL.Update(ModelToObjectConvert(paymentType));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(paymentType))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Payment Type" })
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

        // DELETE api/<PaymentTypeController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                PaymentType paymentType = new PaymentType()
                {
                    IdPaymentType = id
                };
                bool result = paymentTypeDAL.Remove(paymentType);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Country" })
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

        private PaymentTypeModel objectToModelConvert(PaymentType paymentType)
        {

            return new PaymentTypeModel
            {
                IdPaymentType = paymentType.IdPaymentType,
                PaymentTypeName = paymentType.PaymentTypeName
            };
        }

        private PaymentType ModelToObjectConvert(PaymentTypeModel paymentTypeModel)
        {

            return new PaymentType
            {
                IdPaymentType = paymentTypeModel.IdPaymentType,
                PaymentTypeName = paymentTypeModel.PaymentTypeName
            };
        }
    }
}
