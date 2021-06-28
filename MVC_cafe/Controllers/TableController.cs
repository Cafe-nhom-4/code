using MVC_cafe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_cafe.Controllers
{
    public class TableController : Controller
    {
        myCafeEntities db = new myCafeEntities();
        // GET: Table
        public ActionResult Index()
        {
            List<TableFood> list = db.TableFoods.ToList();

            return View(list);
        }
    }
}