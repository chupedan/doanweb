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
    public class LOAISANPHAMsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLHH/LOAISANPHAMs
        public ActionResult Index()
        {
            return View(db.LOAISANPHAMs.ToList());
        }

        // GET: QLHH/LOAISANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // GET: QLHH/LOAISANPHAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLHH/LOAISANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLSP,TenLSP")] LOAISANPHAM lOAISANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.LOAISANPHAMs.Add(lOAISANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAISANPHAM);
        }

        // GET: QLHH/LOAISANPHAMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // POST: QLHH/LOAISANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLSP,TenLSP")] LOAISANPHAM lOAISANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAISANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAISANPHAM);
        }

        // GET: QLHH/LOAISANPHAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            if (lOAISANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(lOAISANPHAM);
        }

        // POST: QLHH/LOAISANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAISANPHAM lOAISANPHAM = db.LOAISANPHAMs.Find(id);
            db.LOAISANPHAMs.Remove(lOAISANPHAM);
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
