using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Areas.QLHH.Controllers
{
    public class XUUATKHOesController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLHH/XUUATKHOes
        public ActionResult Index()
        {
            var xUUATKHOes = db.XUUATKHOes.Include(x => x.NGUOIDUNG);
            return View(xUUATKHOes.ToList());
        }

        // GET: QLHH/XUUATKHOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUUATKHO xUUATKHO = db.XUUATKHOes.Find(id);
            if (xUUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(xUUATKHO);
        }

        // GET: QLHH/XUUATKHOes/Create
        public ActionResult Create()
        {
            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND");
            return View();
        }

        // POST: QLHH/XUUATKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuXuat,NgayXuatKho,IDND")] XUUATKHO xUUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.XUUATKHOes.Add(xUUATKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", xUUATKHO.IDND);
            return View(xUUATKHO);
        }

        // GET: QLHH/XUUATKHOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUUATKHO xUUATKHO = db.XUUATKHOes.Find(id);
            if (xUUATKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", xUUATKHO.IDND);
            return View(xUUATKHO);
        }

        // POST: QLHH/XUUATKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuXuat,NgayXuatKho,IDND")] XUUATKHO xUUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xUUATKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", xUUATKHO.IDND);
            return View(xUUATKHO);
        }

        // GET: QLHH/XUUATKHOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUUATKHO xUUATKHO = db.XUUATKHOes.Find(id);
            if (xUUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(xUUATKHO);
        }

        // POST: QLHH/XUUATKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XUUATKHO xUUATKHO = db.XUUATKHOes.Find(id);
            db.XUUATKHOes.Remove(xUUATKHO);
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
