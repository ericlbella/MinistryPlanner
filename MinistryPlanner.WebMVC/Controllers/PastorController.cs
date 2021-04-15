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
    }
}