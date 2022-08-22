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
    public class CurrencyController : ControllerBase
    {
        private ICurrencyDAL currencyDAL;

        public CurrencyController()
        {
            currencyDAL = new CurrencyDALImpl();
        }

        // GET: api/<CurrencyController>
        //[Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Currency> currencies = currencyDAL.GetAll().ToList();
                List<CurrencyModel> result = new List<CurrencyModel>();
                foreach (Currency currency in currencies)
                {
                    result.Add(objectToModelConvert(currency));
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

        // GET api/<CurrencyController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Currency currency = currencyDAL.Get(id);
                if (currency != null)
                {
                    return new JsonResult(objectToModelConvert(currency))
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

        // POST api/<CurrencyController>
        //[Authorize]
        [HttpPost]
        public JsonResult Post([FromBody] CurrencyModel currency)
        {
            try
            {
                bool result = currencyDAL.Add(ModelToObjectConvert(currency));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(currency))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Currency" })
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

        // PUT api/<CurrencyController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] CurrencyModel currency)
        {
            try
            {
                bool result = currencyDAL.Update(ModelToObjectConvert(currency));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(currency))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Currency" })
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

        // DELETE api/<CurrencyController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Currency currency = new Currency()
                {
                    IdCurrencies = id
                };
                bool result = currencyDAL.Remove(currency);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Currency" })
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

        private CurrencyModel objectToModelConvert(Currency currency)
        {

            return new CurrencyModel
            {
                IdCurrencies = currency.IdCurrencies,
                CurrencyName = currency.CurrencyName,
                CurrencyIso = currency.CurrencyIso,
                Symbol = currency.Symbol
            };
        }

        private Currency ModelToObjectConvert(CurrencyModel currencyModel)
        {

            return new Currency
            {
                IdCurrencies = currencyModel.IdCurrencies,
                CurrencyName = currencyModel.CurrencyName,
                CurrencyIso = currencyModel.CurrencyIso,
                Symbol = currencyModel.Symbol
            };
        }
    }
}
