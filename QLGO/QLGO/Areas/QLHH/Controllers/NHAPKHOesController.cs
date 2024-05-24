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
    public class NHAPKHOesController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLHH/NHAPKHOes
        public ActionResult Index()
        {
            var nHAPKHOes = db.NHAPKHOes.Include(n => n.NGUOIDUNG).Include(n => n.NHACUNGCAP);
            return View(nHAPKHOes.ToList());
        }

        // GET: QLHH/NHAPKHOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAPKHO nHAPKHO = db.NHAPKHOes.Find(id);
            if (nHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nHAPKHO);
        }

        // GET: QLHH/NHAPKHOes/Create
        public ActionResult Create()
        {
            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND");
            ViewBag.IDNCC = new SelectList(db.NHACUNGCAPs, "IDNCC", "TenNCC");
            return View();
        }

        // POST: QLHH/NHAPKHOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhieuNhap,NgayNhapKho,IDNCC,IDND")] NHAPKHO nHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.NHAPKHOes.Add(nHAPKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", nHAPKHO.IDND);
            ViewBag.IDNCC = new SelectList(db.NHACUNGCAPs, "IDNCC", "TenNCC", nHAPKHO.IDNCC);
            return View(nHAPKHO);
        }

        // GET: QLHH/NHAPKHOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAPKHO nHAPKHO = db.NHAPKHOes.Find(id);
            if (nHAPKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", nHAPKHO.IDND);
            ViewBag.IDNCC = new SelectList(db.NHACUNGCAPs, "IDNCC", "TenNCC", nHAPKHO.IDNCC);
            return View(nHAPKHO);
        }

        // POST: QLHH/NHAPKHOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhieuNhap,NgayNhapKho,IDNCC,IDND")] NHAPKHO nHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHAPKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDND = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", nHAPKHO.IDND);
            ViewBag.IDNCC = new SelectList(db.NHACUNGCAPs, "IDNCC", "TenNCC", nHAPKHO.IDNCC);
            return View(nHAPKHO);
        }

        // GET: QLHH/NHAPKHOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAPKHO nHAPKHO = db.NHAPKHOes.Find(id);
            if (nHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nHAPKHO);
        }

        // POST: QLHH/NHAPKHOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHAPKHO nHAPKHO = db.NHAPKHOes.Find(id);
            db.NHAPKHOes.Remove(nHAPKHO);
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
