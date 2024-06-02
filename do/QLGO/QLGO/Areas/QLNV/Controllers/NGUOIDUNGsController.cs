using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Areas.QLNV.Controllers
{
    public class NGUOIDUNGsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();
        string LayMaND()
        {
            var maMax = db.NGUOIDUNGs.Any() ? db.NGUOIDUNGs.Select(n => n.IDND).Max() : "ND000";
            int maND = int.Parse(maMax.Substring(2)) + 1;
            string ND = String.Concat("000", maND.ToString());
            return "ND" + ND.Substring(maND.ToString().Length - 1);
        }



        // GET: QLNV/NGUOIDUNGs
        public ActionResult Index()
        {
            var nGUOIDUNGs = db.NGUOIDUNGs.Include(n => n.LOAINGUOIDUNG);
            return View(nGUOIDUNGs.ToList());
        }

        // GET: QLNV/NGUOIDUNGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // GET: QLNV/NGUOIDUNGs/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaND();
            ViewBag.IDLND = new SelectList(db.LOAINGUOIDUNGs, "IDLND", "TenLND");
            return View();
        }

        // POST: QLNV/NGUOIDUNGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDND,MKDN,TenDN,HoND,TenND,SDTND,EmailND,GioiTinh,DiemThuong,NgaySinh,IDLND")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                nGUOIDUNG.IDND = LayMaND(); // Tạo mã người dùng tự động
                db.NGUOIDUNGs.Add(nGUOIDUNG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLND = new SelectList(db.LOAINGUOIDUNGs, "IDLND", "TenLND", nGUOIDUNG.IDLND);

            return View(nGUOIDUNG);
        }

        // GET: QLNV/NGUOIDUNGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLND = new SelectList(db.LOAINGUOIDUNGs, "IDLND", "TenLND", nGUOIDUNG.IDLND);

            return View(nGUOIDUNG);
        }

        // POST: QLNV/NGUOIDUNGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDND,MKDN,TenDN,HoND,TenND,SDTND,EmailND,GioiTinh,DiemThuong,NgaySinh,IDLND")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLND = new SelectList(db.LOAINGUOIDUNGs, "IDLND", "TenLND", nGUOIDUNG.IDLND);

            return View(nGUOIDUNG);
        }

        // GET: QLNV/NGUOIDUNGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNG);
        }

        // POST: QLNV/NGUOIDUNGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nGUOIDUNG);
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
