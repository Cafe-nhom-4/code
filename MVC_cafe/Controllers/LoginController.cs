using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using MVC_cafe.Models;

namespace MVC_cafe.Controllers
{
    public class LoginController : Controller
    {
        myCafeEntities db = new myCafeEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account _user)
        {
            if (ModelState.IsValid)
            {
                var chek = db.Accounts.FirstOrDefault(s => s.UserName == _user.UserName);
                if (chek == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Accounts.Add(_user);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username đá có người đăng kí!";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Authen()
        {
            return View();
        }

        //login admin
        [HttpPost]      
        public ActionResult Authen(Account _user)
        {
            var check = db.Accounts.Where(s => s.UserName.Equals(_user.UserName) && s.PassWord.Equals(_user.PassWord)).FirstOrDefault();
            //phân quyền------------
            if (check != null)
            {
                Session["id"] = _user.id;
                Session["UserName"] = _user.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _user.LoginErrorMessage = "Sai tài khoản hoặc mật khẩu! Vui lòng thử lại!";
                return View("Index", _user);
            }
        }
        //login staff

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Start()
        {
            return View();
        }
    }
}