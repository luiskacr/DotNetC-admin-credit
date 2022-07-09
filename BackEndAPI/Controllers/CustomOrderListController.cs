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
    public class CustomOrderListController : ControllerBase
    {
        private CustomOrdenListDALImple customOrdenListDAL;

        public CustomOrderListController()
        {

            customOrdenListDAL = new CustomOrdenListDALImple();

        }


        // GET: api/<CustomOrderListController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<CustomOrderList> customOrderList = customOrdenListDAL.GetAll().ToList();
                List<CustomOrderListModel> result = new List<CustomOrderListModel>();
                foreach (CustomOrderList customOrder in customOrderList)
                {

                    CustomOrderListModel customOrderListModel = ObjectToModelConvert(customOrder);
                    result.Add(customOrderListModel);
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

        // GET api/<CustomOrderListController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                CustomOrderList customOrderList = customOrdenListDAL.Get(id);
                if (customOrderList != null)
                {
                    return new JsonResult(customOrderList)
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

        // POST api/<CustomOrderListController>
        [HttpPost]
        public JsonResult Post([FromBody] CustomOrderListModel customOrderListModel)
        {
            try
            {
                CustomOrderList customOrderList = ModelToObjectConvert(customOrderListModel);

                bool result = customOrdenListDAL.Update(customOrderList);

                if (result)
                {
                    return new JsonResult(customOrderList)
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

        // PUT api/<CustomOrderListController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] CustomOrderListModel customOrderListModel)
        {
            try
            {
                CustomOrderList customOrderList = ModelToObjectConvert(customOrderListModel);

                bool result = customOrdenListDAL.Add(customOrderList);

                if (result)
                {
                    return new JsonResult(customOrderList)
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

        // DELETE api/<CustomOrderListController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                CustomOrderList customOrderList = new CustomOrderList()
                {
                    CustomOrderListId = id
                };

                bool result = customOrdenListDAL.Remove(customOrderList);

                if (result)
                {
                    return new JsonResult("Ok: The data is deleted ")
                    {
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
                else
                {
                    return new JsonResult("Error: Information is not correct ")
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

        private CustomOrderListModel ObjectToModelConvert(CustomOrderList customOrderList)
        {

            CustomOrderListModel customOrderListModel = new CustomOrderListModel()
            {
                CustomOrderListId = customOrderList.CustomOrderListId,
                _01customOrderPosition = customOrderList._01customOrderPosition,
                _02customOrderPosition = customOrderList._02customOrderPosition,
                _03customOrderPosition = customOrderList._03customOrderPosition,
                _04customOrderPosition = customOrderList._03customOrderPosition,
                _05customOrderPosition = customOrderList._03customOrderPosition,
                _06customOrderPosition = customOrderList._06customOrderPosition,
                _07customOrderPosition = customOrderList._07customOrderPosition,
                _08customOrderPosition = customOrderList._08customOrderPosition,
                _09customOrderPosition = customOrderList._09customOrderPosition,
                _10customOrderPosition = customOrderList._10customOrderPosition,
                //Missing to include relationships

            };

            return customOrderListModel;
        }

        private CustomOrderList ModelToObjectConvert(CustomOrderListModel customOrderListModel)
        {

            CustomOrderList customOrderList = new CustomOrderList()
            {
                CustomOrderListId = customOrderListModel.CustomOrderListId,
                _01customOrderPosition = customOrderListModel._01customOrderPosition,
                _02customOrderPosition = customOrderListModel._02customOrderPosition,
                _03customOrderPosition = customOrderListModel._03customOrderPosition,
                _04customOrderPosition = customOrderListModel._03customOrderPosition,
                _05customOrderPosition = customOrderListModel._03customOrderPosition,
                _06customOrderPosition = customOrderListModel._06customOrderPosition,
                _07customOrderPosition = customOrderListModel._07customOrderPosition,
                _08customOrderPosition = customOrderListModel._08customOrderPosition,
                _09customOrderPosition = customOrderListModel._09customOrderPosition,
                _10customOrderPosition = customOrderListModel._10customOrderPosition,
                //Missing to include relationships

            };

            return customOrderList;
        }
    }
}
