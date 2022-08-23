using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LoansTypeInterestController : Controller
    {
        // GET: LoansTypeInterestController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansTypeInterest");
                HttpResponseMessage response2 = serviceObj.GetResponse("api/Currency");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/LoansType");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                var content2 = response2.Content.ReadAsStringAsync().Result;
                var content3 = response3.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.LoansTypeInterestViewModel> loansTypeInterests = JsonConvert.DeserializeObject<List<Models.LoansTypeInterestViewModel>>(content);
                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content2);
                    ViewBag.Loanstype = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content3);
                    

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(loansTypeInterests);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar los Tipos de Interes";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar los Tipos de Interes";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar los Tipos de Interes";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: LoansTypeInterestController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansTypeInterest/" + id.ToString());

                HttpResponseMessage response2 = serviceObj.GetResponse("api/Currency");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/LoansType");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();

                var content2 = response2.Content.ReadAsStringAsync().Result;
                var content3 = response3.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.LoansTypeInterestViewModel loansTypeInterest = response.Content.ReadAsAsync<Models.LoansTypeInterestViewModel>().Result;

                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content2);
                    ViewBag.Loanstype = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content3);

                    return View(loansTypeInterest);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Interes";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Interes";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al Mostar Tipo de Interes";
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: LoansTypeInterestController/Create
        public ActionResult Create()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Currency");
                HttpResponseMessage response2 = serviceObj.GetResponse("api/LoansType");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                var content2 = response2.Content.ReadAsStringAsync().Result;

                ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content);
                ViewBag.LoansType = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content2);

                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error Interno";
                return RedirectToAction("Index");
            }
        }

        // POST: LoansTypeInterestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.LoansTypeInterestViewModel interestType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/LoansTypeInterest/", interestType);
                response.EnsureSuccessStatusCode();

                if (interestType.InteresRate == 0) 
                {
                    return View();
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado el Tipo de Interes con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear el Tipo de Interes";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al crear el Tipo de Interes";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear el Pais";
                return View();
            }
        }

        // GET: LoansTypeInterestController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansTypeInterest/" + id.ToString());
                HttpResponseMessage response2 = serviceObj.GetResponse("api/Currency");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/LoansType");


                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();

                var content2 = response2.Content.ReadAsStringAsync().Result;
                var content3 = response3.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.LoansTypeInterestViewModel loansTypeInterest = response.Content.ReadAsAsync<Models.LoansTypeInterestViewModel>().Result;

                    ViewBag.Currency = JsonConvert.DeserializeObject<List<Models.CurrencyViewModel>>(content2);
                    ViewBag.LoansType = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content3);

                    return View(loansTypeInterest);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Pais";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Pais";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al cargar el Pais";

                return RedirectToAction("Index");
            }
        }

        // POST: LoansTypeInterestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.LoansTypeInterestViewModel loansTypeInterest)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/LoansTypeInterest/" + loansTypeInterest.IdloansTypeInterest.ToString(), loansTypeInterest);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Tipo de Interes";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Tipo de Interes";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Tipo de Interes";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar el Tipo de Interes";
                return View();
            }
        }

        // GET: LoansTypeInterestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoansTypeInterestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.LoansTypeInterestViewModel loansTypeInterest)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/LoansTypeInterest/" + loansTypeInterest.IdloansTypeInterest.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Tipo de Interes ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Tipo de Interes no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar el Tipo de Interes";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar el Tipo de Interes";

                return RedirectToAction("Index");
            }
        }
    }
}
