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
    public class SANPHAMAMINDsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();
        string LayMaSP()
        {
            var listMaSP = db.SANPHAMs.Select(n => n.IDSP).ToList();

            if (listMaSP.Count == 0)
            {
                return "SP001";
            }

            // Lấy mã lớn nhất hiện tại
            var maMax = listMaSP.Max();
            int maSP = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("00", maSP.ToString());
            return "SP" + NV.Substring(NV.Length - 3);
        }

        // GET: QLHH/SANPHAMs
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.DONVITINH).Include(s => s.LOAISANPHAM);
            return View(sANPHAMs.ToList());
        }

        // GET: QLHH/SANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: QLHH/SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaSP();

            ViewBag.IDDVT = new SelectList(db.DONVITINHs, "IDDVT", "TenDVT");
            ViewBag.IDLSP = new SelectList(db.LOAISANPHAMs, "IDLSP", "TenLSP");
            return View();
        }

        // POST: QLHH/SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSP,SL,GiaBan,HinhanhSP,IDLSP,IDDVT,TenSP")] SANPHAM sANPHAM)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgSP = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("~/Images/" + postedFileName);
            imgSP.SaveAs(path);
            if (ModelState.IsValid)
            {
                sANPHAM.IDSP = LayMaSP();
                sANPHAM.HinhanhSP = postedFileName;
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDVT = new SelectList(db.DONVITINHs, "IDDVT", "TenDVT", sANPHAM.IDDVT);
            ViewBag.IDLSP = new SelectList(db.LOAISANPHAMs, "IDLSP", "TenLSP", sANPHAM.IDLSP);
            return View(sANPHAM);
        }

        // GET: QLHH/SANPHAMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDVT = new SelectList(db.DONVITINHs, "IDDVT", "TenDVT", sANPHAM.IDDVT);
            ViewBag.IDLSP = new SelectList(db.LOAISANPHAMs, "IDLSP", "TenLSP", sANPHAM.IDLSP);
            return View(sANPHAM);
        }

        // POST: QLHH/SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSP,SL,GiaBan,HinhanhSP,IDLSP,IDDVT,TenSP")] SANPHAM sANPHAM)
        {
            var imgSP = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgSP.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("~/Images/" + postedFileName);
                imgSP.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDVT = new SelectList(db.DONVITINHs, "IDDVT", "TenDVT", sANPHAM.IDDVT);
            ViewBag.IDLSP = new SelectList(db.LOAISANPHAMs, "IDLSP", "TenLSP", sANPHAM.IDLSP);
            return View(sANPHAM);
        }

        // GET: QLHH/SANPHAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: QLHH/SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
