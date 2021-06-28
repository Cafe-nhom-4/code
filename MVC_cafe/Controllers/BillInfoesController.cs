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
    public class BillInfoesController : Controller
    {
        private myCafeEntities db = new myCafeEntities();

        // GET: BillInfoes
        public ActionResult Index()
        {
            var billInfoes = db.BillInfoes.Include(b => b.Account).Include(b => b.Bill).Include(b => b.Food).Include(b => b.TableFood);
            return View(billInfoes.ToList());
        }
        public ActionResult Member_hoadon()
        {
            var billInfoes = db.BillInfoes.Include(b => b.Account).Include(b => b.Bill).Include(b => b.Food).Include(b => b.TableFood);
            return View(billInfoes.ToList());
        }

        public ActionResult Order()
        {
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName");
            ViewBag.idBill = new SelectList(db.Bills, "Bill_id", "Bill_id");
            ViewBag.idFood = new SelectList(db.Foods, "Food_id", "Food_name");
            ViewBag.idTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order([Bind(Include = "BillInfo_id,idBill,idFood,idAccount,idTable,count")] BillInfo billInfo)
        {
            if (ModelState.IsValid)
            {
                db.BillInfoes.Add(billInfo);
                db.SaveChanges();
                return RedirectToAction("Member_hoadon");
            }

            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", billInfo.idAccount);
            ViewBag.idBill = new SelectList(db.Bills, "Bill_id", "Bill_id", billInfo.idBill);
            ViewBag.idFood = new SelectList(db.Foods, "Food_id", "Food_name", billInfo.idFood);
            ViewBag.idTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", billInfo.idTable);
            return View(billInfo);
        }
        // GET: BillInfoes/Create
        public ActionResult Create()
        {
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName");
            ViewBag.idBill = new SelectList(db.Bills, "Bill_id", "Bill_id");
            ViewBag.idFood = new SelectList(db.Foods, "Food_id", "Food_name");
            ViewBag.idTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name");
            return View();
        }

        // POST: BillInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillInfo_id,idBill,idFood,idAccount,idTable,count")] BillInfo billInfo)
        {
            if (ModelState.IsValid)
            {
                db.BillInfoes.Add(billInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", billInfo.idAccount);
            ViewBag.idBill = new SelectList(db.Bills, "Bill_id", "Bill_id", billInfo.idBill);
            ViewBag.idFood = new SelectList(db.Foods, "Food_id", "Food_name", billInfo.idFood);
            ViewBag.idTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", billInfo.idTable);
            return View(billInfo);
        }

        // GET: BillInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillInfo billInfo = db.BillInfoes.Find(id);
            if (billInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", billInfo.idAccount);
            ViewBag.idBill = new SelectList(db.Bills, "Bill_id", "Bill_id", billInfo.idBill);
            ViewBag.idFood = new SelectList(db.Foods, "Food_id", "Food_name", billInfo.idFood);
            ViewBag.idTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", billInfo.idTable);
            return View(billInfo);
        }

        // POST: BillInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillInfo_id,idBill,idFood,idAccount,idTable,count")] BillInfo billInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAccount = new SelectList(db.Accounts, "id", "UserName", billInfo.idAccount);
            ViewBag.idBill = new SelectList(db.Bills, "Bill_id", "Bill_id", billInfo.idBill);
            ViewBag.idFood = new SelectList(db.Foods, "Food_id", "Food_name", billInfo.idFood);
            ViewBag.idTable = new SelectList(db.TableFoods, "TableFood_id", "TableFood_name", billInfo.idTable);
            return View(billInfo);
        }

        // GET: BillInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillInfo billInfo = db.BillInfoes.Find(id);
            if (billInfo == null)
            {
                return HttpNotFound();
            }
            return View(billInfo);
        }

        // POST: BillInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillInfo billInfo = db.BillInfoes.Find(id);
            db.BillInfoes.Remove(billInfo);
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
