using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class ClientController : Controller
    {
        readonly IService<Client> _clientService;
        readonly IService<Conseiller> _conseillerService;
        private readonly ILogger<ClientController> _logger;
        public ClientController(IService<Client> clientService, IService<Conseiller> conseillerService, ILogger<ClientController> logger)
        {
            this._clientService = clientService;
            this._conseillerService = conseillerService;
            this._logger = logger;
        }
        // GET: ClientController
        public ActionResult Index(string? nom)
        {
            if (nom is null)
                return View(_clientService.GetAll());
            else
                return View(_clientService.GetAll().Where(i => i.Login == nom));
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(_conseillerService.GetById(id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.ConseillerFK = new SelectList(_conseillerService.GetAll(), "ConseillerId", "Nom");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client collection, IFormFile photo)
        {
            try
            {
                if (photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot", "uploads", photo.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    photo.CopyTo(stream);

                    collection.Photo = photo.FileName;

                }
                _clientService.Add(collection);
                _clientService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
               return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
