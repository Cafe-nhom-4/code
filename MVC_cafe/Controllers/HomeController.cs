using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_cafe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
                return View();
            else
                return RedirectToAction("Index", "Login");
        }
        public ActionResult Member()
        {
            if (Session["UserName"] != null)
                return View();
            else
                return RedirectToAction("Index", "Login");
        }

    }
}