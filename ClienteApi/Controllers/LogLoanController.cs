using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LogLoanController : Controller
    {
        // GET: LogLoanController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LogLoan");
                HttpResponseMessage response2 = serviceObj.GetResponse("api/Customer");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/LoansType");
                HttpResponseMessage response4 = serviceObj.GetResponse("api/Currency");
                HttpResponseMessage response5 = serviceObj.GetResponse("api/LoanState");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();
                response4.EnsureSuccessStatusCode();
                response4.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                var content2 = response2.Content.ReadAsStringAsync().Result;
                var content3 = response3.Content.ReadAsStringAsync().Result;
                var content4 = response4.Content.ReadAsStringAsync().Result;
                var content5 = response5.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.LogLoanViewModel> loans = JsonConvert.DeserializeObject<List<Models.LogLoanViewModel>>(content);

                    ViewBag.Customer = JsonConvert.DeserializeObject<List<Models.CustomerViewModel>>(content2);
                    ViewBag.LoansStype = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content3);
                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content4);
                    ViewBag.LoanState = JsonConvert.DeserializeObject<List<Models.LoanStateViewModel>>(content5);


                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(loans);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar el Log de Creditos";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar el Log de Creditos";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar el Log de Creditos";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }
        /*
        // GET: LogLoanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LogLoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogLoanController/Create
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

        // GET: LogLoanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LogLoanController/Edit/5
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

        // GET: LogLoanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LogLoanController/Delete/5
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
