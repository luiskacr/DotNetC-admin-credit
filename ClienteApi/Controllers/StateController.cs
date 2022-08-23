using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;
using ClienteApi.Models;

namespace ClienteApi.Controllers
{
    public class StateController : Controller
    {
        // GET: StateController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/State");

                response.EnsureSuccessStatusCode();

                HttpResponseMessage response2 = serviceObj.GetResponse("api/Country");

                response2.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                
                var content2 = response2.Content.ReadAsStringAsync().Result;


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.StateViewModel> states = JsonConvert.DeserializeObject<List<Models.StateViewModel>>(content);

                    List<Models.CountryViewModel> countrys = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content2);

                    States_CountryViewModel newStateModel = new States_CountryViewModel();

                    newStateModel.state = states;
                    newStateModel.country = countrys;

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(newStateModel);
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

        // GET: StateController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/State/" + id.ToString());

                response.EnsureSuccessStatusCode();

                HttpResponseMessage response2 = serviceObj.GetResponse("api/Country");

                response2.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                var content2 = response2.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.StateViewModel state = response.Content.ReadAsAsync<Models.StateViewModel>().Result;

                    List<Models.StateViewModel> states = new List<StateViewModel>();

                    states.Add(state);

                    List<Models.CountryViewModel> countrys = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content2);

                    States_CountryViewModel newStateModel = new States_CountryViewModel();

                    newStateModel.state = states;
                    newStateModel.country = countrys;

                    return View(newStateModel);
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

        // GET: StateController/Create
        public ActionResult Create()
        {
            try 
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Country");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                ViewBag.Countries = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content);

                return View();
            }
            catch (Exception e) 
            {
                TempData["error"] = "Hubo un error Interno";
                return RedirectToAction("Index");
            }

        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.StateViewModel state)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/State/", state);
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

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/State/" + id.ToString());

                response.EnsureSuccessStatusCode();

                HttpResponseMessage response2 = serviceObj.GetResponse("api/Country");

                response2.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                var content2 = response2.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.StateViewModel state = response.Content.ReadAsAsync<Models.StateViewModel>().Result;

                    ViewBag.Countries = JsonConvert.DeserializeObject<List<Models.CountryViewModel>>(content2);

                    return View(state);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar la Provincia";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar la Provincia";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al eliminar la Provincia";
                return RedirectToAction("Index");
                throw;
            }
        }

        // POST: StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.StateViewModel state)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/State/" + state.IdState.ToString(), state);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado la Provincia ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar la Provincia";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar la Provincia";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar la Provincia";
                return View();
            }
        }

        /*
        // GET: StateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        */

        // POST: StateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/State/" + id.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado la Provincia ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "La Provincia no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar la Provincia ";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar la Provincia ";

                return RedirectToAction("Index");
            }
        }
    }
}
