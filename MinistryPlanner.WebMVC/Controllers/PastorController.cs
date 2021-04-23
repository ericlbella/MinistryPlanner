using MinistryPlanner.Data;
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
    public class PastorController : Controller
    {
       private ApplicationDbContext DbContext = new ApplicationDbContext();

        // GET: Pastor
        public ActionResult Index()
        {
            var service = new PastorService();
            var model = service.GetPastors();

            return View(model);
        }
        
        public ActionResult Create()
        {
            //var service = new ChurchService();
            //var model = service.GetChurches();
            ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
            //ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
           // var model2 = new PastorCreate();
            //model2.Churches = model;       
            //foreach (int value in     in 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PastorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePastorService();

            if (service.CreatePastor(model))
            {
                TempData["SaveResult"] = "Your pastor record was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Pastor record could not be created.");
            return View(model);
        }

        private static PastorService CreatePastorService()
        {
            return new PastorService();
        }
    }
}