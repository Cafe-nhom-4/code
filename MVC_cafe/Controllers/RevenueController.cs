using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_cafe.Models;

namespace MVC_cafe.Controllers
{
    public class RevenueController : Controller
    {
        // GET: Revenue
        myCafeEntities db = new myCafeEntities();
        public ActionResult Index()
        {
            
            return View();
        }

    }
}