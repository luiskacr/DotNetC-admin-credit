using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LoanStateController : Controller
    {
        // GET: LoanStateController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoanState");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.LoanStateViewModel> loanStates = JsonConvert.DeserializeObject<List<Models.LoanStateViewModel>>(content);

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(loanStates);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar los Estados de Préstamos";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar los Estados de Préstamos";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar los Estados de Préstamos";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: LoanStateController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoanState/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.LoanStateViewModel loanStateViewModel = response.Content.ReadAsAsync<Models.LoanStateViewModel>().Result;

                    return View(loanStateViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Estado de Préstamos";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Estado de Préstamos";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al eliminar el Estado de Préstamos";
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: LoanStateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanStateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.LoanStateViewModel loanState)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/LoanState/", loanState);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado el Estado de Préstamo con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear el Estado de Préstamo";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al crear el Estado de Préstamo";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear el Estado de Préstamo";
                return View();
            }
        }

        // GET: LoanStateController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoanState/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.LoanStateViewModel loanStateViewModel = response.Content.ReadAsAsync<Models.LoanStateViewModel>().Result;
                    return View(loanStateViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Estado de Préstamo";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Estado de Préstamo";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al cargar el Estado de Préstamo";

                return RedirectToAction("Index");
            }
        }

        // POST: LoanStateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.LoanStateViewModel loanState)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/LoanState/" + loanState.LoansStatesId.ToString(), loanState);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Estado de Préstamo ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Estado de Préstamo";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Estado de Préstamo";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar el Estado de Préstamo";
                return View();
            }
        }

        // GET: LoanStateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanStateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.LoanStateViewModel loanState)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/LoanState/" + loanState.LoansStatesId.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Estado de Préstamo";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Estado de Préstamo no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar el Estado de Préstamo";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar el Estado de Préstamo";

                return RedirectToAction("Index");
            }
        }
    }
}
