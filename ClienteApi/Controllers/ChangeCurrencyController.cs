using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class ChangeCurrencyController : Controller
    {


        // GET: ChangeCurrencyController/Create
        public ActionResult Create(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();

                HttpResponseMessage response = serviceObj.GetResponse("api/Loan/" + id.ToString());
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;

                HttpClient Client = new HttpClient();
                Client.BaseAddress = new Uri("https://tipodecambio.paginasweb.cr/");

                HttpResponseMessage response2 = Client.GetAsync("api").Result;
                response2.EnsureSuccessStatusCode();
                var content2 = response2.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    ViewBag.Loans  = response.Content.ReadAsAsync<Models.LoanViewModel>().Result;

                    Models.ExchangeRateViewModel exchangeRate = JsonConvert.DeserializeObject<Models.ExchangeRateViewModel>(content2);
                    ViewBag.exchangeRate = exchangeRate;

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al cargar el cambio de Moneda";
                    return RedirectToAction("Index", "Loan");
                }
                else
                {
                    TempData["error"] = "Hubo un error al cargar el cambio de Moneda";
                    return RedirectToAction("Index", "Loan");
                }
            }
            catch (Exception e) 
            {

                TempData["error"] = "Hubo un error al cargar el cambio de Moneda ";
                return RedirectToAction("Index", "Loan");

            }

            return View();
        }

        // POST: ChangeCurrencyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.ChangeCurrencyViewModel changeCurrency)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("/api/Loan/ChangeLoanCurrency", changeCurrency);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha realizado el cambio de Moneda";

                    return RedirectToAction("Index", "Loan");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al realizar el cambio de Moneda";
                    return RedirectToAction("Index", "Loan");
                }
                else
                {
                    ViewBag.error = "Hubo un error al realizar el cambio de Moneda";
                    return RedirectToAction("Index", "Loan");
                }
                
            }
            catch
            {
                TempData["error"] = "Hubo un error al realizar el cambio de Moneda ";
                return RedirectToAction("Index", "Loan");
            }
        }

        /*

        // GET: ChangeCurrencyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChangeCurrencyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

         // GET: ChangeCurrencyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChangeCurrencyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.ChangeCurrencyViewModel changeCurrency)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChangeCurrencyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChangeCurrencyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
