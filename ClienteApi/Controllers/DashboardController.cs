using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public ActionResult Index()
        {
            if (TempData["exito"] != null)
            {
                ViewBag.exito = TempData["exito"];
            }

            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];
            }

            return View();
        }

    }
}
