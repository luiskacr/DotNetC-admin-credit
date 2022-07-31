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
    public class CustomerController : ControllerBase
    {

        private ICustomerDAL customerDAL;

            public CustomerController() {
            customerDAL = new CustomerDALImpl();
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<Customer> customers = customerDAL.GetAll().ToList();
                List<CustomerModel> result = new List<CustomerModel>();
                foreach (Customer customer in customers)
                {
                    result.Add(objectToModelConvert(customer));
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

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Customer customer = customerDAL.Get(id);
                if (customer != null)
                {
                    return new JsonResult(objectToModelConvert(customer))
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

        // POST api/<CustomerController>
        [HttpPost]
        public JsonResult Post([FromBody] CustomerModel customer)
        {
            try
            {
                bool result = customerDAL.Add(ModelToObjectConvert(customer));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(customer))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including Customer" })
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

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] CustomerModel customer)
        {
            try
            {
                bool result = customerDAL.Update(ModelToObjectConvert(customer));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(customer))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update Customer" })
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

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Customer customer = new Customer()
                {
                    IdCustomers = id
                };
                bool result = customerDAL.Remove(customer);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete Customer" })
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

        private CustomerModel objectToModelConvert(Customer customer)
        {
            return new CustomerModel
            {
                IdCustomers = customer.IdCustomers,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentId = customer.DocumentId,
                Email = customer.Email,
                Telephone = customer.Telephone,
                BirthDate = customer.BirthDate,
                UserAddress = customer.UserAddress,
                IdState = customer.IdState
            };
        }

        private Customer ModelToObjectConvert(CustomerModel customerModel)
        {
            return new Customer
            {
                IdCustomers = customerModel.IdCustomers,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                DocumentId = customerModel.DocumentId,
                Email = customerModel.Email,
                Telephone = customerModel.Telephone,
                BirthDate = customerModel.BirthDate,
                UserAddress = customerModel.UserAddress,
                IdState = customerModel.IdState
            };
        }
    }
}
