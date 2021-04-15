using MinistryPlanner.Models;
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
        // GET: Pastor
        public ActionResult Index()
        {
            var model = new PastorListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PastorCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

    }
}