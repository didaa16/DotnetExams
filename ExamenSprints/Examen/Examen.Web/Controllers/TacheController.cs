using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class TacheController : Controller
    {
        readonly IService<Tache> tacheService;
        public TacheController(IService<Tache> tacheService)
        {
            this.tacheService = tacheService;
        }
        // GET: TacheController
        public ActionResult Index()
        {
            return View(tacheService.GetAll()
                .Where(x => x.Etat == EtatTache.Ouverte)
                .OrderBy(x => x.Titre));
        }

        // GET: TacheController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult nomPrenom(string id)
        {
            return View(tacheService
                .GetAll()
                .Where(x => x.MembreKey == id)
                .Select(x => x.membre)
                .First());
        }

        // GET: TacheController/Create
        public ActionResult Create()
        {
            var x = tacheService.GetAll();
            ViewBag.etats = new SelectList(x, "Etat", "Etat");
            ViewBag.sprints = new SelectList(x, "SprintKey", "SprintKey");
            ViewBag.membres = new SelectList(x, "MembreKey", "MembreKey");
            return View();
        }

        // POST: TacheController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Tache t)
        {
            try
            {
                tacheService.Add(t);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TacheController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TacheController/Edit/5
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

        // GET: TacheController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TacheController/Delete/5
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
