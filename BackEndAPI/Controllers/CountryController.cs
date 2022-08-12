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
    public class CountryController : ControllerBase
    {
        private ICountryDAL countryDAL;

        public CountryController()
        {
            countryDAL = new CountryDALImpl();
        }

        // GET: api/<CountryController>
        //Agregar [Authorize] a cada metodo que quiero ponerle seguridad
        [Authorize]
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Country> countries = countryDAL.GetAll().ToList();
                List<CountryModel> result = new List<CountryModel>();
                foreach (Country country in countries)
                {
                    result.Add(objectToModelConvert(country));
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

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Country country = countryDAL.Get(id);
                if (country != null)
                {
                    return new JsonResult(objectToModelConvert(country))
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

        // POST api/<CountryController>
        [HttpPost]
        public JsonResult Post([FromBody] CountryModel country)
        {
            try
            {
                bool result = countryDAL.Add(ModelToObjectConvert(country));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(country))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Country" })
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

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] CountryModel country)
        {
            try
            {
                bool result = countryDAL.Update(ModelToObjectConvert(country));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(country))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Country" })
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

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Country country = new Country()
                {
                    IdCountry = id
                };
                bool result = countryDAL.Remove(country);
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

        private CountryModel objectToModelConvert(Country country)
        {

            return new CountryModel
            {
                IdCountry = country.IdCountry,
                CountryName = country.CountryName
            };
        }

        private Country ModelToObjectConvert(CountryModel countryModel)
        {

            return new Country
            {
                IdCountry = countryModel.IdCountry,
                CountryName = countryModel.CountryName
            };
        }
    }
}
