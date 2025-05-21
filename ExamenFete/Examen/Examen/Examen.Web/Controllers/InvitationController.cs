using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class InvitationController : Controller
    {
        readonly IService<Invitation> invitationService;
        readonly IService<Fete> feteService; 
        readonly IService<Invite> inviteService;
        public InvitationController(IService<Invitation> invitationService, IService<Fete> feteService, IService<Invite> inviteService)
        {
            this.invitationService = invitationService;
            this.feteService = feteService;
            this.inviteService = inviteService;
        }

        // GET: InvitationController
        public ActionResult Index(DateTime? filter1)
        {
            if (filter1.HasValue)
                return View(feteService.GetAll().Where(f => f.DateFete == filter1.Value));
            return View(feteService.GetAll().OrderBy(f => f.DateFete));
        }

        // GET: InvitationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvitationController/Create
        public ActionResult Create()
        {
            ViewBag.FeteFK = new SelectList(feteService.GetAll(), "IdFete", "Description");
            ViewBag.InviteFK = new SelectList(inviteService.GetAll(), "IdInvite", "Prenom");
            return View();
        }

        // POST: InvitationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Invitation i)
        {
            try
            {
                invitationService.Add(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvitationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvitationController/Edit/5
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

        // GET: InvitationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvitationController/Delete/5
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
