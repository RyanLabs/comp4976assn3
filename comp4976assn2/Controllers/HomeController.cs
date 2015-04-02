using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace comp4976assn2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our Mission and Mandate.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "The Good Samaritan";

            return View();
        }
    }
}