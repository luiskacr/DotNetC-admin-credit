using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LoanController : Controller
    {
        // GET: LoanController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Loan");
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
                    List<Models.LoanViewModel> loans = JsonConvert.DeserializeObject<List<Models.LoanViewModel>>(content);
                   
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
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar los creditos";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar los creditos";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar los creditos";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();

                HttpResponseMessage response = serviceObj.GetResponse("api/Loan/" + id.ToString());
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
                    Models.LoanViewModel loans = response.Content.ReadAsAsync<Models.LoanViewModel>().Result;

                    ViewBag.Customer = JsonConvert.DeserializeObject<List<Models.CustomerViewModel>>(content2);
                    ViewBag.LoansStype = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content3);
                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content4);
                    ViewBag.LoanState = JsonConvert.DeserializeObject<List<Models.LoanStateViewModel>>(content5);

                    return View(loans);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar los creditos";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar los creditos";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al buscar los creditos";
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanController/Create
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

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();

                HttpResponseMessage response = serviceObj.GetResponse("api/Loan/" + id.ToString());
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
                    Models.LoanViewModel loans = response.Content.ReadAsAsync<Models.LoanViewModel>().Result;

                    ViewBag.Customer = JsonConvert.DeserializeObject<List<Models.CustomerViewModel>>(content2);
                    ViewBag.LoansStype = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content3);
                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content4);
                    ViewBag.LoanState = JsonConvert.DeserializeObject<List<Models.LoanStateViewModel>>(content5);

                    return View(loans);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar los creditos";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar los creditos";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al buscar los creditos";
                return RedirectToAction("Index");
                throw;
            }
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.LoanViewModel loan)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();

                HttpResponseMessage response1 = serviceObj.GetResponse("api/Loan/" + loan.IdLoan.ToString());
                response1.EnsureSuccessStatusCode();
                var content = response1.Content.ReadAsStringAsync().Result;
                Models.LoanViewModel oldLoan = response1.Content.ReadAsAsync<Models.LoanViewModel>().Result;

                loan.BankFees = oldLoan.BankFees;
                loan.CurrentAmount = oldLoan.CurrentAmount;
                loan.MonthlyAmount = oldLoan.MonthlyAmount;
                loan.LoanAmount = oldLoan.LoanAmount;
                loan.StarDate = oldLoan.StarDate;
                loan.EndDate = oldLoan.EndDate;
                loan.NextDueDate = oldLoan.NextDueDate;
                loan.InteresRate = oldLoan.InteresRate;


                HttpResponseMessage response = serviceObj.PutResponse("api/Loan/" + loan.IdLoan.ToString(), loan);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Credito ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Credito";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Credito";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar el Credito";
                return View();
            }
        }

        /*
        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        */

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Loan/AllDelete/" + id.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Credito ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Credito no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar el Credito";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar el Credito";

                return RedirectToAction("Index");
            }
        }
    }
}
