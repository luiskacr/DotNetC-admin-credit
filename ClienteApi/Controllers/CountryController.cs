using ClienteAPI.Helpers;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace ClienteApi.Controllers
{
    public class CountryController : Controller
    {

        // GET: CountryController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Country");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.CountryViewModel> countrys = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content);

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(countrys);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar los Paises";

                    return RedirectToAction("Index", "Dashboard");
                }
                else 
                {
                    TempData["error"] = "Hubo un error al Cargar los Paises";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {
               
                TempData["error"] = "Hubo un error al Cargar los Paises";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Country/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.CountryViewModel countryViewModel = response.Content.ReadAsAsync<Models.CountryViewModel>().Result;

                    return View(countryViewModel);
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
                TempData["error"] = "Hubo un error al eliminar el Pais";
                return RedirectToAction("Index");
                throw;
            }

        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.CountryViewModel country)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Country/", country);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado el Pais con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear el Pais";
                    return View();
                }
                else 
                {
                    ViewBag.error = "Hubo un error al crear el Pais";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear el Pais";
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Country/" + id.ToString());
                response.EnsureSuccessStatusCode();
 
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.CountryViewModel countryViewModel = response.Content.ReadAsAsync<Models.CountryViewModel>().Result;
                    return View(countryViewModel);
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

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.CountryViewModel country)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Country/" + country.IdCountry.ToString(), country);
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

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.CountryViewModel country)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Country/" + country.IdCountry.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Pais ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Pais no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else 
                {
                    TempData["error"] = "Hubo un error al eliminar el Pais";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar el Pais";

                return RedirectToAction("Index");
            }
        }
    }
}
