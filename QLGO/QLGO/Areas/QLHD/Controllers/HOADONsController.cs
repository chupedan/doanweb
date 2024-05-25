using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Areas.QLHD.Controllers
{
    public class HOADONsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLHD/HOADONs
        public ActionResult Index()
        {
            var hOADONs = db.HOADONs.Include(h => h.NGUOIDUNG).Include(h => h.LOAITHANHTOAN).Include(h => h.NGUOIDUNG1);
            return View(hOADONs.ToList());
        }

        // GET: QLHD/HOADONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: QLHD/HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND");
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT");
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND");
            return View();
        }

        // POST: QLHD/HOADONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHD,NgayXuatHD,IDNV,IDKH,IDLTT")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADONs.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", hOADON.IDKH);
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", hOADON.IDLTT);
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", hOADON.IDNV);
            return View(hOADON);
        }

        // GET: QLHD/HOADONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", hOADON.IDKH);
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", hOADON.IDLTT);
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", hOADON.IDNV);
            return View(hOADON);
        }

        // POST: QLHD/HOADONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHD,NgayXuatHD,IDNV,IDKH,IDLTT")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", hOADON.IDKH);
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", hOADON.IDLTT);
            ViewBag.IDNV = new SelectList(db.NGUOIDUNGs, "IDND", "TenND", hOADON.IDNV);
            return View(hOADON);
        }

        // GET: QLHD/HOADONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADONs.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: QLHD/HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADON hOADON = db.HOADONs.Find(id);
            db.HOADONs.Remove(hOADON);
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
