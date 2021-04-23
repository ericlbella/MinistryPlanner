using MinistryPlanner.Data;
using MinistryPlanner.Models;
using MinistryPlanner.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistryPlanner.WebMVC.Controllers
{
    [Authorize]
    public class ParishonerController : Controller
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();

        // GET: Parishoner
        public ActionResult Index()
        {
            var service = new ParishonerService();
            var model = service.GetParishoners();
            //var model = new ParishonerListItem[0];
            return View(model);

        }

        //private static ParishonerService NewMethod1()
        //{
        //    return CreateParishonerService();
        //}

        private static ParishonerService CreateParishonerService()
        {
            return new ParishonerService();
        }

        //private static ParishonerService NewMethod()
        //{
        //    return new ParishonerService();
        //}

        public ActionResult Create()
        {

            //var service = new ChurchService();
            //var model = service.GetChurches();

            ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");

            //ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
            //var model2 = new ParishonerCreate();
            //model2.Churches = model;       
            //foreach (int value in     in 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParishonerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateParishonerService();

            if (service.CreateParishoner(model))
            {
                TempData["SaveResult"] = "Your parishoner record was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Parishoner record could not be created.");
            return View(model);
        }
    }
}