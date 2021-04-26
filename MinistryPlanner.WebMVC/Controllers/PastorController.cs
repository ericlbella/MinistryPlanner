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

        public ActionResult Details(int id)
        {
            var svc = CreatePastorService();
            var model = svc.GetPastorById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
            var service = CreatePastorService();
            var detail = service.GetPastorById(id);
            var model =
                new PastorEdit
                {
                    FirstName = detail.FirstName,
                    MiddleName = detail.MiddleName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    HomePhone = detail.HomePhone,
                    CellPhone = detail.CellPhone,
                    DateOfBirth = detail.DateOfBirth,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State,
                    Zip = detail.Zip,
                    SeniorPastor = detail.SeniorPastor,
                    AssistantPastor = detail.AssistantPastor,
                    YouthPastor = detail.YouthPastor,
                    SongLeader = detail.SongLeader
                }; 
            return View(model);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PastorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IndividualId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePastorService();

            if (service.UpdatePastor(model))
            {
                TempData["SaveResult"] = "Your pastor record was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your pastor record could not be updated.");
            return View(model);
        }

        private static PastorService CreatePastorService()
        {
            return new PastorService();
        }
    }
}