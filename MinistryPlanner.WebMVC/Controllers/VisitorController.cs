using MinistryPlanner.Models;
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
        // GET: Visitor
        public ActionResult Index()
        {
            var model = new VisitorListItem[0];
            return View(model);
        }
    }
}