using Microsoft.AspNet.Identity;
using MinistryPlanner.Models;
using MinistryPlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistryPlanner.WebMVC.Controllers
{
    [Authorize]
    public class ChurchController : Controller
    {
        // GET: Church
        public ActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new ChurchService(userId);
            var service = new ChurchService();
            var model = service.GetChurches();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChurchCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new ChurchService(userId);
            var service = CreateChurchService();

            if (service.CreateChurch(model))
            {
                TempData["SaveResult"] = "Your church record was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Church record could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateChurchService();
            var model = svc.GetChurchById(id);

            return View(model);
        }


        private static ChurchService CreateChurchService()
        {
            return new ChurchService();
        }

       
    }
}

