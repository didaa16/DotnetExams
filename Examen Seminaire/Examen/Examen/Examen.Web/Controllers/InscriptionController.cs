using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace Examen.Web.Controllers
{
    public class InscriptionController : Controller
    {
        readonly IService<Inscription> _inscriptionService;
        readonly IService<Participant> _participantService;
        readonly IService<Seminaire> _seminaireService;
        public InscriptionController(IService<Inscription> inscriptionService, IService<Participant> participantService, IService<Seminaire> seminaireService)
        {
            _inscriptionService = inscriptionService;
            _participantService = participantService;
            _seminaireService = seminaireService;
        }
        // GET: InscriptionController
        public ActionResult Index(string? nom)
        {
            if (nom is null)
                return View(_inscriptionService.GetAll());
            else
                return View(_inscriptionService.GetAll().Where(i => i.Participant.Nom == nom));
        }

        // GET: InscriptionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InscriptionController/Create
        public ActionResult Create()
        {
            ViewBag.SeminaireFK = new SelectList(_seminaireService.GetAll(), "Code", "Intitule");
            ViewBag.ParticipantFK = new SelectList(_participantService.GetAll(), "Id", "nomCplet");
            return View();
        }

        // POST: InscriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Inscription i)
        {
            try
            {
                _inscriptionService.Add(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InscriptionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InscriptionController/Edit/5
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

        // GET: InscriptionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InscriptionController/Delete/5
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
