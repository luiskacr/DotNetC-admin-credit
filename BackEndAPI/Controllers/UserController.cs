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
    public class UserController : ControllerBase
    {

        private UserDALImpl userDAL;

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
                IEnumerable<User> useries = userDAL.GetAll().ToList();
                List<UserModel> result = new List<UserModel>();
                foreach (User user in useries)
                {
                    UserModel userModel = ObjectToModelConvert(user);
                    result.Add(userModel);
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

     

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                User user = userDAL.Get(id);
                if (user != null)
                {
                    return new JsonResult(user)
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

        // POST api/<UserController>
        [HttpPost]
        public JsonResult Post([FromBody] UserModel userModel)
        {
            try
            {
                User user = ModelToObjectConvert(userModel);

                bool result = userDAL.Update(user);

                if (result)
                {
                    return new JsonResult(user)
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

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] UserModel userModel)
        {
            try
            {
                User user = ModelToObjectConvert(userModel);

                bool result = userDAL.Add(user);

                if (result)
                {
                    return new JsonResult(user)
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


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                User user = new User()
                {
                    UserId = id
                };

                bool result = userDAL.Remove(user);

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

        private UserModel ObjectToModelConvert(User user)
        {
            UserModel userModel = new UserModel()
            {
                UserId = user.UserId,
                UserRoles = user.UserRoles,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Telephone = user.Telephone,
                Email = user.Email,
                Paassword = user.Paassword,
                BirthDay = user.BirthDay,
                DocumentId = user.DocumentId,
                Adddress = user.Adddress
            };
            return userModel;
        }
        private User ModelToObjectConvert(UserModel userModel)
        {
            User user = new User()
            {
                UserId = userModel.UserId,
                UserRoles = userModel.UserRoles,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Telephone = userModel.Telephone,
                Email = userModel.Email,
                Paassword = userModel.Paassword,
                BirthDay = userModel.BirthDay,
                DocumentId = userModel.DocumentId,
                Adddress = userModel.Adddress
            };
            return user;
        }
    }
}
