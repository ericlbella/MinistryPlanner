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
    public class VisitorController : Controller
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();

        // GET: Visitor
        public ActionResult Index()
        {
            var service = new VisitorService();
            var model = service.GetVisitors();

            return View(model);
        }

        public ActionResult Create()
        {
            //var service = new ChurchService();
            //var model = service.GetChurches();
            ViewBag.Churches = new SelectList(DbContext.Churches, "ChurchId", "Name");
            //ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
            //var model2 = new VisitorCreate();
            //model2.Churches = model;       
            //foreach (int value in     in 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVisitorService();

            if (service.CreateVisitor(model))
            {
                TempData["SaveResult"] = "Your visitor record was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Visitor record could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateVisitorService();
            var model = svc.GetVisitorById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
            var service = CreateVisitorService();
            var detail = service.GetVisitorById(id);
            var model =
                new VisitorEdit
                {
                    IndividualId = detail.IndividualId,
                    ChurchId = detail.ChurchId,
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
                    DateVisited = detail.DateVisited
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VisitorEdit model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
                return View(model);
            }

            if (model.IndividualId != id)
            {
                ViewBag.Churches = new SelectList(DbContext.Churches.ToList(), "ChurchId", "Name");
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateVisitorService();

            if (service.UpdateVisitor(model))
            {
                TempData["SaveResult"] = "Your visitor record was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your visitor record could not be updated.");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVisitorService();

            service.DeleteVisitor(id);

            TempData["SaveResult"] = "Your visitor record was deleted";

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVisitorService();
            var model = svc.GetVisitorById(id);

            return View(model);
        }

        private static VisitorService CreateVisitorService()
        {
            return new VisitorService();
        }
    }
}