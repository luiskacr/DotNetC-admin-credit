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
    public class UserRoleController : ControllerBase
    {

        private IUserRolesDAL userRolesDAL;

        public UserRoleController()
        {
            userRolesDAL = new UserRolesDALImpl();
        }

        // GET: api/<UserRoleController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<UserRole> userRoles = userRolesDAL.GetAll().ToList();
                List<UserRoleModel> result = new List<UserRoleModel>();
                foreach (UserRole userRole in userRoles)
                {
                    result.Add(objectToModelConvert(userRole));
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
                UserRole userRole = userRolesDAL.Get(id);
                if (userRole != null)
                {
                    return new JsonResult(objectToModelConvert(userRole))
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

        // POST api/<UserRoleController>
        [HttpPost]
        public JsonResult Post([FromBody] UserRoleModel userRole)
        {
            try
            {
                bool result = userRolesDAL.Add(ModelToObjectConvert(userRole));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(userRole))
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

        // PUT api/<UserRoleController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] UserRoleModel userRole)
        {
            try
            {
                bool result = userRolesDAL.Update(ModelToObjectConvert(userRole));
                if (result)
                {
                    return new JsonResult(ModelToObjectConvert(userRole))
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

        // DELETE api/<UserRoleController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                UserRole userRole = new UserRole()
                {
                    IdUserRole = id
                };
                bool result = userRolesDAL.Remove(userRole);
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

        private UserRoleModel objectToModelConvert(UserRole userRole)
        {
            return new UserRoleModel
            {
                IdUserRole = userRole.IdUserRole,
                RoleName = userRole.RoleName,
            };
        }

        private UserRole ModelToObjectConvert(UserRoleModel userRoleModel)
        {
            return new UserRole
            {
                IdUserRole = userRoleModel.IdUserRole,
                RoleName = userRoleModel.RoleName,
            };
        }
    }
}
