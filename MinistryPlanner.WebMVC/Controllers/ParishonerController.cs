using MinistryPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinistryPlanner.WebMVC.Controllers
{
    [Authorize]
    public class ParishonerController : Controller
    {
        // GET: Parishoner
        public ActionResult Index()
        {
            var model = new ParishonerListItem[0];
            return View(model);
        }
    }
}