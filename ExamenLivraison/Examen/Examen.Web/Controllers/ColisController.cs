using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class ColisController : Controller
    {
        readonly IService<Colis> colisService;
        readonly IService<Livreur> livreursService;
        readonly IService<Client> clientService;
        public ColisController(IService<Colis> colisServie, IService<Livreur> livreurService, IService<Client> clientService)
        {
            this.colisService = colisServie;
            this.livreursService = livreurService;
            this.clientService = clientService;
        }
        public ActionResult Index(DateTime? filter1)
        {
            if (filter1.HasValue)
                return View(colisService.GetAll().Where(f => f.DateLivraison == filter1.Value));
            return View(colisService.GetAll());
        }

        // GET: ColisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColisController/Create
        public ActionResult Create()
        {
            ViewBag.LivreurFK = new SelectList(livreursService.GetAll(), "CIN", "CIN");
            ViewBag.ClientFK = new SelectList(clientService.GetAll(), "Id", "Nom");
            return View();
        }

        // POST: ColisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Colis c)
        {
            try
            {
                colisService.Add(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColisController/Edit/5
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

        // GET: ColisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColisController/Delete/5
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
