using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace ClienteApi.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: CurrencyController
        public ActionResult Index()
        {
            try 
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Currency");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.CurrencyViewModel> currencyes = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content);

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(currencyes);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar las Monedas";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar las Monedas";

                    return RedirectToAction("Index", "Dashboard");
                }

            } catch (Exception e) 
            {
                TempData["error"] = "Hubo un error al Cargar las Monedas";
                return RedirectToAction("Index", "Dashboard");

                throw;

            }
        }

        // GET: CurrencyController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Currency/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.CurrencyViewModel currencyViewModel = response.Content.ReadAsAsync<Models.CurrencyViewModel>().Result;
                    return View(currencyViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar la Moneda";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar la Moneda";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al cargar la Moneda";

                return RedirectToAction("Index");
            }
        }

        // GET: CurrencyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.CurrencyViewModel currency)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Currency/", currency);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado la moneda con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear la moneda";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al crear la moneda";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear la moneda";
                return View();
            }
        }

        // GET: CurrencyController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Currency/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.CurrencyViewModel currencyViewModel = response.Content.ReadAsAsync<Models.CurrencyViewModel>().Result;
                    return View(currencyViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar la Moneda";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar la Moneda";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al cargar la Moneda";

                return RedirectToAction("Index");
            }
        }

        // POST: CurrencyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.CurrencyViewModel currency)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Currency/" + currency.IdCurrencies.ToString(), currency);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Pais ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Pais";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Pais";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar el Pais";
                return View();
            }
        }

        // GET: CurrencyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CurrencyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.CurrencyViewModel currency)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Currency/" + currency.IdCurrencies.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado la Moneda";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "La Moneda no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar la Moneda";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar la Moneda";

                return RedirectToAction("Index");
            }
        }
    }
}
