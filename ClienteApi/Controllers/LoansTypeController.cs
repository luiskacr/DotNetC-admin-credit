using ClienteAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteApi.Controllers
{
    public class LoansTypeController : Controller
    {
        // GET: LoanTypeController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansType");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<Models.LoanTypeViewModel> loanTypes = JsonConvert.DeserializeObject<List<Models.LoanTypeViewModel>>(content);

                    if (TempData["exito"] != null)
                    {
                        ViewBag.exito = TempData["exito"];
                    }

                    if (TempData["error"] != null)
                    {
                        ViewBag.error = TempData["error"];
                    }

                    return View(loanTypes);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    TempData["error"] = "Hubo un error Interno no se pueden mostrar los Tipos de Préstamos";

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["error"] = "Hubo un error al Cargar los Tipos de Préstamos";

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al Cargar los Tipos de Préstamos";
                return RedirectToAction("Index", "Dashboard");

                throw;
            }
        }

        // GET: LoanTypeController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansType/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.LoanTypeViewModel loanTypeViewModel = response.Content.ReadAsAsync<Models.LoanTypeViewModel>().Result;

                    return View(loanTypeViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Préstamos";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Préstamos";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Hubo un error al eliminar el Tipo de Préstamos";
                return RedirectToAction("Index");
                throw;
            }
        }

        // GET: LoanTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.LoanTypeViewModel loanType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/LoansType/", loanType);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se creado el Tipo de Préstamo con exito";

                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al crear el Tipo de Préstamo";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al crear el Tipo de Préstamo";
                    return View();
                }

            }
            catch
            {
                ViewBag.error = "Hubo un error al crear el Tipo de Préstamo";
                return View();
            }
        }

        // GET: LoanTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/LoansType/" + id.ToString());
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Models.LoanTypeViewModel loanTypeViewModel = response.Content.ReadAsAsync<Models.LoanTypeViewModel>().Result;
                    return View(loanTypeViewModel);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Préstamo";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al buscar el Tipo de Préstamo";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                TempData["error"] = "Hubo un error al cargar el Tipo de Préstamo";

                return RedirectToAction("Index");
            }
        }

        // POST: LoanTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.LoanTypeViewModel loanType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/LoansType/" + loanType.IdloansType.ToString(), loanType);
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    TempData["exito"] = "Se ha Modificado el Tipo de Préstamo ";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ViewBag.error = "Hubo un error al editar el Tipo de Préstamo";
                    return View();
                }
                else
                {
                    ViewBag.error = "Hubo un error al editar el Tipo de Préstamo";
                    return View();
                }
            }
            catch
            {
                ViewBag.error = "Hubo un error al editar el Tipo de Préstamo";
                return View();
            }
        }

        // GET: LoanTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoanTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.LoanTypeViewModel loanType)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/LoansType/" + loanType.IdloansType.ToString());
                //bool delete = response.Content.ReadAsAsync<bool>().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["exito"] = "Se ha Eliminado el Tipo de Préstamo";
                    return RedirectToAction("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    TempData["error"] = "El Tipo de Préstamo no se puede eliminar";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Hubo un error al eliminar el Tipo de Préstamo";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["error"] = "Hubo un error al eliminar el Tipo de Préstamo";

                return RedirectToAction("Index");
            }
        }
    }
}
