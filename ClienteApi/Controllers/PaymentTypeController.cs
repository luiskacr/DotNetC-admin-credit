using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class PaymentTypeController : Controller
    {
        // GET: PaymentTypeController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/PaymentType");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.PaymentTypeViewModel> paymentTypes = JsonConvert.DeserializeObject<List<Models.PaymentTypeViewModel>>(content);

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(paymentTypes);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar el Tipo de Pago";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar el Tipo de Pago";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar el Tipo de Pago";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: PaymentTypeController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/PaymentType/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.PaymentTypeViewModel paymentTypeViewModel = response.Content.ReadAsAsync<Models.PaymentTypeViewModel>().Result;

                    return View(paymentTypeViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Pago";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Pago";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al eliminar el Tipo de Pago";
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: PaymentTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.PaymentTypeViewModel paymentType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/PaymentType/", paymentType);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado el Tipo de Pago con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear el Tipo de Pago";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al crear el Tipo de Pago";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear el Tipo de Pago";
                return View();
            }
        }

        // GET: PaymentTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/PaymentType/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.PaymentTypeViewModel paymentTypeViewModel = response.Content.ReadAsAsync<Models.PaymentTypeViewModel>().Result;
                    return View(paymentTypeViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Pago";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Pago";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al cargar el Tipo de Pago";

                return RedirectToAction("Index");
            }
        }

        // POST: PaymentTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.PaymentTypeViewModel paymentType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/PaymentType/" + paymentType.IdPaymentType.ToString(), paymentType);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Tipo de Pago";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Tipo de Pago";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Tipo de Pago";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar el Tipo de Pago";
                return View();
            }
        }

        // GET: PaymentTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.PaymentTypeViewModel paymentType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/PaymentType/" + paymentType.IdPaymentType.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Tipo de Pago";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Tipo de Pago no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar el Tipo de Pago";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar el Tipo de Pago";

                return RedirectToAction("Index");
            }
        }
    }
}
