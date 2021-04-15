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
        
    }
}

