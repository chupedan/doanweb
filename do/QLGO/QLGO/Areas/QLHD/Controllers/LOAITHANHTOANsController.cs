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
    public class LOAITHANHTOANsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();

        // GET: QLHD/LOAITHANHTOANs
        public ActionResult Index()
        {
            return View(db.LOAITHANHTOANs.ToList());
        }

        // GET: QLHD/LOAITHANHTOANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAITHANHTOAN lOAITHANHTOAN = db.LOAITHANHTOANs.Find(id);
            if (lOAITHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(lOAITHANHTOAN);
        }

        // GET: QLHD/LOAITHANHTOANs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QLHD/LOAITHANHTOANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLTT,TenLTT")] LOAITHANHTOAN lOAITHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.LOAITHANHTOANs.Add(lOAITHANHTOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAITHANHTOAN);
        }

        // GET: QLHD/LOAITHANHTOANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAITHANHTOAN lOAITHANHTOAN = db.LOAITHANHTOANs.Find(id);
            if (lOAITHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(lOAITHANHTOAN);
        }

        // POST: QLHD/LOAITHANHTOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLTT,TenLTT")] LOAITHANHTOAN lOAITHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAITHANHTOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAITHANHTOAN);
        }

        // GET: QLHD/LOAITHANHTOANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAITHANHTOAN lOAITHANHTOAN = db.LOAITHANHTOANs.Find(id);
            if (lOAITHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(lOAITHANHTOAN);
        }

        // POST: QLHD/LOAITHANHTOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOAITHANHTOAN lOAITHANHTOAN = db.LOAITHANHTOANs.Find(id);
            db.LOAITHANHTOANs.Remove(lOAITHANHTOAN);
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
