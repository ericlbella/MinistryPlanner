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
            var userId = Convert.ToString(User.Identity.GetUserId());
            //var service = new ChurchService(userId);
            var service = new ChurchService(userId);
            var model = service.GetChurches();

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new ChurchCreate());
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

        public ActionResult Edit(int id)
        {
            var service = CreateChurchService();
            var detail = service.GetChurchById(id);
            var model =
                new ChurchEdit
                {
                    ChurchId = detail.ChurchId,
                    Name = detail.Name,
                    NumberMembers = detail.NumberMembers,
                    Phone = detail.Phone,
                    Email = detail.Email,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State,
                    Zip = detail.Zip,
                    Denomination = detail.Denomination
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ChurchEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ChurchId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateChurchService();

            if (service.UpdateChurch(model))
            {
                TempData["SaveResult"] = "Your church record was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your church record could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateChurchService();
            var model = svc.GetChurchById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateChurchService();

            service.DeleteChurch(id);

            TempData["SaveResult"] = "Your church record was deleted";

            return RedirectToAction("Index");
        }

        private ChurchService CreateChurchService()
        {
            var userId = Convert.ToString(User.Identity.GetUserId());
            //var userId = Convert.ToInt32(User.Identity.GetUserId());
            //var service = new ChurchService(userId);
            var service = new ChurchService(userId);
            return service;
        }
    }
}

