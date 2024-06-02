using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Areas.QLDDH.Controllers
{
    public class CTDONDATHANGsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLDDH/CTDONDATHANGs
        public ActionResult Index()
        {
            var cTDONDATHANGs = db.CTDONDATHANGs.Include(c => c.DONDATHANG).Include(c => c.SANPHAM);
            return View(cTDONDATHANGs.ToList());
        }

        // GET: QLDDH/CTDONDATHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDONDATHANG cTDONDATHANG = db.CTDONDATHANGs.Find(id);
            if (cTDONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cTDONDATHANG);
        }

        // GET: QLDDH/CTDONDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.IDDDH = new SelectList(db.DONDATHANGs, "IDDDH", "IDKH");
            ViewBag.IDSP = new SelectList(db.SANPHAMs, "IDSP", "TenSP");
            return View();
        }

        // POST: QLDDH/CTDONDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDDH,IDSP,SLDat")] CTDONDATHANG cTDONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.CTDONDATHANGs.Add(cTDONDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDDH = new SelectList(db.DONDATHANGs, "IDDDH", "IDKH", cTDONDATHANG.IDDDH);
            ViewBag.IDSP = new SelectList(db.SANPHAMs, "IDSP", "TenSP", cTDONDATHANG.IDSP);
            return View(cTDONDATHANG);
        }

        // GET: QLDDH/CTDONDATHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDONDATHANG cTDONDATHANG = db.CTDONDATHANGs.Find(id);
            if (cTDONDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDDH = new SelectList(db.DONDATHANGs, "IDDDH", "IDKH", cTDONDATHANG.IDDDH);
            ViewBag.IDSP = new SelectList(db.SANPHAMs, "IDSP", "TenSP", cTDONDATHANG.IDSP);
            return View(cTDONDATHANG);
        }

        // POST: QLDDH/CTDONDATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDDH,IDSP,SLDat")] CTDONDATHANG cTDONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDDH = new SelectList(db.DONDATHANGs, "IDDDH", "IDKH", cTDONDATHANG.IDDDH);
            ViewBag.IDSP = new SelectList(db.SANPHAMs, "IDSP", "TenSP", cTDONDATHANG.IDSP);
            return View(cTDONDATHANG);
        }

        // GET: QLDDH/CTDONDATHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDONDATHANG cTDONDATHANG = db.CTDONDATHANGs.Find(id);
            if (cTDONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cTDONDATHANG);
        }

        // POST: QLDDH/CTDONDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CTDONDATHANG cTDONDATHANG = db.CTDONDATHANGs.Find(id);
            db.CTDONDATHANGs.Remove(cTDONDATHANG);
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
