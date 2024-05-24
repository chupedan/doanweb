using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Controllers
{
    public class LOAINGUOIDUNGsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: LOAINGUOIDUNGs
        public ActionResult Index()
        {
            return View(db.LOAINGUOIDUNGs.ToList());
        }

        // GET: LOAINGUOIDUNGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAINGUOIDUNG lOAINGUOIDUNG = db.LOAINGUOIDUNGs.Find(id);
            if (lOAINGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(lOAINGUOIDUNG);
        }

        // GET: LOAINGUOIDUNGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAINGUOIDUNGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLND,TenLND,Luong")] LOAINGUOIDUNG lOAINGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.LOAINGUOIDUNGs.Add(lOAINGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAINGUOIDUNG);
        }

        // GET: LOAINGUOIDUNGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAINGUOIDUNG lOAINGUOIDUNG = db.LOAINGUOIDUNGs.Find(id);
            if (lOAINGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(lOAINGUOIDUNG);
        }

        // POST: LOAINGUOIDUNGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLND,TenLND,Luong")] LOAINGUOIDUNG lOAINGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAINGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAINGUOIDUNG);
        }

        // GET: LOAINGUOIDUNGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAINGUOIDUNG lOAINGUOIDUNG = db.LOAINGUOIDUNGs.Find(id);
            if (lOAINGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(lOAINGUOIDUNG);
        }

        // POST: LOAINGUOIDUNGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAINGUOIDUNG lOAINGUOIDUNG = db.LOAINGUOIDUNGs.Find(id);
            db.LOAINGUOIDUNGs.Remove(lOAINGUOIDUNG);
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
