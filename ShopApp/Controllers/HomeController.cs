using ShopApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopApp.Controllers
{
    public class HomeController : Controller
    {
        IGoodService service;

        public HomeController(IGoodService s)
        {
            service = s;
        }
        
        // GET: Home
        public ActionResult Index()
        {
            return View(service.GetAll());
        }
    }
}