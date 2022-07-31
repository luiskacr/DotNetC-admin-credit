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
    public class UserController : ControllerBase
    {
        private IUserDAL userDAL;

        public UserController()
        {
            userDAL = new UserDALImpl();
        }

        // GET: api/<UserController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<User> users = userDAL.GetAll().ToList();
                List<UserModel> result = new List<UserModel>();
                foreach (User user in users)
                {
                    result.Add(objectToModelConvert(user));
                }
                return new JsonResult(result)
                {
                    StatusCode = (int)HttpStatusCode.OK,
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

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                User user = userDAL.Get(id);
                if (user != null)
                {
                    return new JsonResult(objectToModelConvert(user))
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

        // POST api/<UserController>
        [HttpPost]
        public JsonResult Post([FromBody] UserModel user)
        {
            try
            {
                bool result = userDAL.Add(ModelToObjectConvert(user));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(user))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error including User" })
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

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] UserModel user)
        {
            try
            {
                bool result = userDAL.Update(ModelToObjectConvert(user));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(user))
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Update User" })
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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                User user = new User()
                {
                    IdUser = id
                };
                bool result = userDAL.Remove(user);
                if (result)
                {
                    return new JsonResult(new { message = "The data is deleted" })
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult(new { message = "Error to Delete User" })
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

        private UserModel objectToModelConvert(User user)
        {

            return new UserModel
            {
                IdUser = user.IdUser,
                UserName = user.UserName,
                UserPassword = user.UserName,
                UserRole = user.UserRole,
                IdCustomers = user.IdCustomers,
            };
        }

        private User ModelToObjectConvert(UserModel userModel)
        {

            return new User
            {
                IdUser = userModel.IdUser,
                UserName = userModel.UserName,
                UserPassword = userModel.UserName,
                UserRole = userModel.UserRole,
                IdCustomers = userModel.IdCustomers,
            };
        }
    }
}
