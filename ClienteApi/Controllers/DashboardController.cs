using ClienteApi.Models;
using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Dashboard");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.DasboardViewModel dasboards = JsonConvert.DeserializeObject<Models.DasboardViewModel>(content);

                    ViewBag.Dasboard = dasboards;
                }

                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("https://tipodecambio.paginasweb.cr/");

                HttpResponseMessage response2 = Client.GetAsync("api").Result;
                response2.EnsureSuccessStatusCode();
                var content2 = response2.Content.ReadAsStringAsync().Result;

                if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.ExchangeRateViewModel exchangeRate = JsonConvert.DeserializeObject<Models.ExchangeRateViewModel>(content2);

                    ViewBag.exchangeRate = exchangeRate;
                }

                return View();
            }
            catch (Exception e)

            {
                return View();
            }


        }

    }
}
