using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace ClienteApi.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Customer");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.CustomerViewModel> customer = JsonConvert.DeserializeObject<List<Models.CustomerViewModel>>(content);


                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(customer);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar los Clientes";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar los Clientes";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar los Clientes";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                
                HttpResponseMessage response = serviceObj.GetResponse("api/Customer/" + id.ToString());
                HttpResponseMessage response2 = serviceObj.GetResponse("api/State");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/Country");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                var content2 = response2.Content.ReadAsStringAsync().Result;

                var content3 = response3.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.CustomerViewModel customer = response.Content.ReadAsAsync<Models.CustomerViewModel>().Result;

                    ViewBag.State = JsonConvert.DeserializeObject<List<Models.StateViewModel>>(content2);

                    ViewBag.Country = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content3);

                    return View(customer);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar los Clientes";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar los Clientes";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al buscar los Clientes";
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/State");
                HttpResponseMessage response2 = serviceObj.GetResponse("api/Country");

                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                var content2 = response2.Content.ReadAsStringAsync().Result;

                ViewBag.States = JsonConvert.DeserializeObject<List<Models.StateViewModel>>(content);
                ViewBag.Country = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content2);

                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error Interno";
                return RedirectToAction("Index");
            }
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.CustomerViewModel customer)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Customer/", customer);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado la Provincia con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear la Provincia ";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al crear la Provincia ";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear la Provincia ";
                return RedirectToAction("Index");
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Customer/" + id.ToString());
                HttpResponseMessage response2 = serviceObj.GetResponse("api/State");
                HttpResponseMessage response3 = serviceObj.GetResponse("api/Country");


                response.EnsureSuccessStatusCode();
                response2.EnsureSuccessStatusCode();
                response3.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                var content2 = response2.Content.ReadAsStringAsync().Result;
                var content3 = response3.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.CustomerViewModel customer = response.Content.ReadAsAsync<Models.CustomerViewModel>().Result;

                    ViewBag.States = JsonConvert.DeserializeObject<List<Models.StateViewModel>>(content2);
                    ViewBag.Country = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content3);

                    return View(customer);
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

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.CustomerViewModel customer)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Customer/" + customer.IdCustomers.ToString(), customer);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Cliente con Exito ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Cliente";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Cliente";
                    return View();
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al modificar el Cliente";
                return RedirectToAction("Index");
            }
        }

        // GET: CustomerController/Delete/5
        /*
        public ActionResult Delete(int id)
        {
            return View();
        }
        */

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.CustomerViewModel customer)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Customer/" + customer.IdCustomers.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Cliente ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Clienteno se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar el Cliente";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar la Cliente ";

                return RedirectToAction("Index");
            }
        }
    }
}
