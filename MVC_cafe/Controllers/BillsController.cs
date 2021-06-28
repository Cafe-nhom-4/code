using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_cafe.Models;

namespace MVC_cafe.Controllers
{
    public class BillsController : Controller
    {
        private myCafeEntities db = new myCafeEntities();

        // GET: Bills
        public ActionResult Info()
        {
            var bills = db.Bills.Include(b => b.Account).Include(b => b.TableFood);
            return View(bills.ToList());
        }

        public ActionResult Index()
        {
            var bills = db.Bills.Include(b => b.Account).Include(b => b.TableFood);
            return View(bills.ToList());
        }

        // GET: Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName");
            ViewBag.inTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bill_id,DateChekIn,DateChekOut,inTable,idAccount,status")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", bill.idAccount);
            ViewBag.inTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", bill.inTable);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", bill.idAccount);
            ViewBag.inTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", bill.inTable);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bill_id,DateChekIn,DateChekOut,inTable,idAccount,status")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", bill.idAccount);
            ViewBag.inTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", bill.inTable);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
