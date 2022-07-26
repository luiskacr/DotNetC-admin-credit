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
    public class UserRoleController : ControllerBase
    {

        private UserRoleDALImpl userRoleDAL;

        public UserRoleController()
        {
            userRoleDAL = new UserRoleDALImpl();
        }

        // GET: api/<UserRoleController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<UserRole> userRolies = userRoleDAL.GetAll().ToList();
                List<UserRoleModel> result = new List<UserRoleModel>();
                foreach (UserRole userRole in userRolies)
                {
                    UserRoleModel userRoleModel = ObjectToModelConvert(userRole);
                    result.Add(userRoleModel);
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

    

        // GET api/<UserRoleController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                UserRole userRole = userRoleDAL.Get(id);
                if (userRole != null)
                {
                    return new JsonResult(userRole)
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
        // POST api/<UserRoleController>
        [HttpPost]
        public JsonResult Post([FromBody] UserRoleModel userRoleModel)
        {
            try
            {
                UserRole userRole = ModelToObjectConvert(userRoleModel);

                bool result = userRoleDAL.Update(userRole);

                if (result)
                {
                    return new JsonResult(userRole)
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

        // PUT api/<UserRoleController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] UserRoleModel userRoleModel)
        {
            try
            {
                UserRole userRole = ModelToObjectConvert(userRoleModel);

                bool result = userRoleDAL.Add(userRole);

                if (result)
                {
                    return new JsonResult(userRole)
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


        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                UserRole userRole = new UserRole()
                {
                    IduserRoles = id
                };

                bool result = userRoleDAL.Remove(userRole);

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

        private UserRoleModel ObjectToModelConvert(UserRole userRole)
        {
            UserRoleModel userRoleModel = new UserRoleModel()
            {
                IduserRoles = userRole.IduserRoles,
                RoleName = userRole.RoleName
            };
            return userRoleModel;
        }

        private UserRole ModelToObjectConvert(UserRoleModel userRoleModel)
        {
            UserRole userRole = new UserRole()
            {
                IduserRoles = userRoleModel.IduserRoles,
                RoleName = userRoleModel.RoleName
            };
            return userRole;
        }
    }
}
