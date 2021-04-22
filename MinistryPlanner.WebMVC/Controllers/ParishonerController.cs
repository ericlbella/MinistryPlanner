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
        ApplicationDbContext DbContext = new ApplicationDbContext();

        // GET: Parishoner
        public ActionResult Index()
        {
            var service = new ParishonerService();
            var model = service.GetParishoners();
            //var model = new ParishonerListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            var service = new ChurchService();
            var model = service.GetChurches();

            ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
            var model2 = new ParishonerCreate();
            //model2.Churches = model;       
            //foreach (int value in     in 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParishonerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new ParishonerService();
            service.CreateParishoner(model);

            return RedirectToAction("Index");
        }
    }
}