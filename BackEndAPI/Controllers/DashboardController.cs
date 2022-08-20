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
    public class DashboardController : ControllerBase
    {
        private DashboardDAL dashboardDAL;
        public DashboardController() 
        {
            dashboardDAL = new DashboardDAL();
        }

        // GET: api/<DashboardController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                Dashboard dashboard = dashboardDAL.Get();
                if (dashboard != null)
                {
                    DasboardModel dashboardModel = new DasboardModel
                    {
                        totalCustomers = dashboard.totalCustomers,
                        totalLoans = dashboard.totalLoans,
                        activeLoans = dashboard.activeLoans,
                        delayLoans = dashboard.delayLoans,
                    };

                    return new JsonResult(dashboardModel)
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

    }
}
