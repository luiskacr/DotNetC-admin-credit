using ClienteApi.Models;
using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LoanHistoryController : Controller
    {
        // GET: LoanHistoryController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexDetail(int id) 
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansHistory/GetbyLoan/" + id.ToString() );
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
                    List<Models.LoanHistoryViewModel> loansHistory = JsonConvert.DeserializeObject<List<LoanHistoryViewModel>>(content);

                    ViewBag.PaymentType = JsonConvert.DeserializeObject<List<Models.PaymentTypeViewModel>>(content2);
                    ViewBag.Loans = JsonConvert.DeserializeObject<List<Models.LoanViewModel>>(content3);
                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content4);
                    ViewBag.LoanId = id;

                    return View(loansHistory);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar el Historial del credito";

                    return RedirectToAction("Index", "Loan");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar el historial del credito";

                    return RedirectToAction("Index", "Loan");
                }

            }
            catch (Exception e) 
            {
                TempData["error"] = "Hubo un error al Cargar los creditos";
                return RedirectToAction("Index", "Loan");

                throw;
            }
        }

        // GET: LoanHistoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoanHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanHistoryController/Create
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

        // GET: LoanHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoanHistoryController/Edit/5
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

        // GET: LoanHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanHistoryController/Delete/5
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
    }
}
