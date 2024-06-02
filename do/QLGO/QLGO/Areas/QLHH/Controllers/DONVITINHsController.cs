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
    public class DONVITINHsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLHH/DONVITINHs
        public ActionResult Index()
        {
            return View(db.DONVITINHs.ToList());
        }

        // GET: QLHH/DONVITINHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            if (dONVITINH == null)
            {
                return HttpNotFound();
            }
            return View(dONVITINH);
        }

        // GET: QLHH/DONVITINHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLHH/DONVITINHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDVT,TenDVT")] DONVITINH dONVITINH)
        {
            if (ModelState.IsValid)
            {
                db.DONVITINHs.Add(dONVITINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dONVITINH);
        }

        // GET: QLHH/DONVITINHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            if (dONVITINH == null)
            {
                return HttpNotFound();
            }
            return View(dONVITINH);
        }

        // POST: QLHH/DONVITINHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDVT,TenDVT")] DONVITINH dONVITINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONVITINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dONVITINH);
        }

        // GET: QLHH/DONVITINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            if (dONVITINH == null)
            {
                return HttpNotFound();
            }
            return View(dONVITINH);
        }

        // POST: QLHH/DONVITINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONVITINH dONVITINH = db.DONVITINHs.Find(id);
            db.DONVITINHs.Remove(dONVITINH);
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
