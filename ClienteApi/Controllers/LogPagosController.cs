using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LogPagosController : Controller
    {
        // GET: LogPagosController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LogLoanHistoryModel");
                HttpResponseMessage response2 = serviceObj.GetResponse("api/PaymentType");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/Loan");
                HttpResponseMessage response4 = serviceObj.GetResponse("api/Currency");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();
                response4.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                var content2 = response2.Content.ReadAsStringAsync().Result;
                var content3 = response3.Content.ReadAsStringAsync().Result;
                var content4 = response4.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.LogLoanHistoryViewModel> logHistory = JsonConvert.DeserializeObject<List<Models.LogLoanHistoryViewModel>>(content);

                    ViewBag.PaymentType = JsonConvert.DeserializeObject<List<Models.PaymentTypeViewModel>>(content2);
                    ViewBag.Loans = JsonConvert.DeserializeObject<List<Models.LoanViewModel>>(content3);
                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content4);

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(logHistory);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar el Log de Pagos";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar el Log de Pagos";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar el Log de Pagos";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }



        /*
        // GET: LogPagosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LogPagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogPagosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LogPagosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogPagosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LogPagosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogPagosController/Delete/5
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
