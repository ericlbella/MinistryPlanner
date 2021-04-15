using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistryPlanner.WebMVC.Controllers
{
    [Authorize]
    public class IndividualController : Controller
    {
        // GET: Individual
        public ActionResult Index()
        {
            var model = new IndividualListItem[0];
            return View(model);
        }
    }
}