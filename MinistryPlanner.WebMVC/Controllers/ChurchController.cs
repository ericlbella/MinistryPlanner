using MinistryPlanner.Models;
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
            var model = new ChurchListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);

        }
    }
}

