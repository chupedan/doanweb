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
    public class DONDATHANGsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLDDH/DONDATHANGs
        public ActionResult Index()
        {
            var dONDATHANGs = db.DONDATHANGs.Include(d => d.LOAITHANHTOAN).Include(d => d.NGUOIDUNG).Include(d => d.NGUOIDUNG1);
            return View(dONDATHANGs.ToList());
        }

        // GET: QLDDH/DONDATHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // GET: QLDDH/DONDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT");
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND");
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND");
            return View();
        }

        // POST: QLDDH/DONDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDDH,IDKH,IDNV,IDLTT,TinhTrang,NgayDatHang,NgayGiaoHang,DiaChi")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONDATHANGs.Add(dONDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", dONDATHANG.IDLTT);
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", dONDATHANG.IDKH);
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", dONDATHANG.IDNV);
            return View(dONDATHANG);
        }

        // GET: QLDDH/DONDATHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", dONDATHANG.IDLTT);
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", dONDATHANG.IDKH);
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", dONDATHANG.IDNV);
            return View(dONDATHANG);
        }

        // POST: QLDDH/DONDATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDDH,IDKH,IDNV,IDLTT,TinhTrang,NgayDatHang,NgayGiaoHang,DiaChi")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", dONDATHANG.IDLTT);
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", dONDATHANG.IDKH);
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", dONDATHANG.IDNV);
            return View(dONDATHANG);
        }

        // GET: QLDDH/DONDATHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            if (dONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONDATHANG);
        }

        // POST: QLDDH/DONDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONDATHANG dONDATHANG = db.DONDATHANGs.Find(id);
            db.DONDATHANGs.Remove(dONDATHANG);
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
