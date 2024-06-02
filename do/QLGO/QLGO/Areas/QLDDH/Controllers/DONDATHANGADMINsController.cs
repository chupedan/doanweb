using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLGO.Models;

namespace QLGO.Areas.QLDDH.Controllers
{
    public class DONDATHANGADMINsController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();
        string LayMaDDH()
        {
            // Lấy danh sách mã đơn đặt hàng
            var listMaDDH = db.DONDATHANGs.Select(n => n.IDDDH).ToList();

            // Kiểm tra nếu không có đơn đặt hàng nào
            if (listMaDDH.Count == 0)
            {
                return "DH001";
            }

            // Lấy mã lớn nhất hiện tại
            var maMax = listMaDDH.Max();
            int maDH = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("00", maDH.ToString());
            return "DH" + NV.Substring(NV.Length - 3);
        }


        // GET: QLDDH/DONDATHANGADMINs
        public ActionResult Index()
        {
            var dONDATHANGs = db.DONDATHANGs.Include(d => d.LOAITHANHTOAN).Include(d => d.TINHTRANG).Include(d => d.NGUOIDUNG);
            return View(dONDATHANGs.ToList());
        }

        // GET: QLDDH/DONDATHANGADMINs/Details/5
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

        // GET: QLDDH/DONDATHANGADMINs/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaDDH();
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT");
            ViewBag.IDTT = new SelectList(db.TINHTRANGs, "IDTT", "TenTT");
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenDN");
            return View();
        }

        // POST: QLDDH/DONDATHANGADMINs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDDH,IDKH,IDLTT,IDTT,NgayDatHang,NgayGiaoHang,DiaChi,TenNguoiDH")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dONDATHANG.IDDDH = LayMaDDH();
                    dONDATHANG.NgayDatHang = DateTime.Now; // Gán thời gian hiện tại
                    db.DONDATHANGs.Add(dONDATHANG);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", dONDATHANG.IDLTT);
            ViewBag.IDTT = new SelectList(db.TINHTRANGs, "IDTT", "TenTT", dONDATHANG.IDTT);
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenDN", dONDATHANG.IDKH);
            return View(dONDATHANG);
        }

        // POST: QLDDH/DONDATHANGADMINs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDDH,IDKH,IDLTT,IDTT,NgayDatHang,NgayGiaoHang,DiaChi,TenNguoiDH")] DONDATHANG dONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLTT = new SelectList(db.LOAITHANHTOANs, "IDLTT", "TenLTT", dONDATHANG.IDLTT);
            ViewBag.IDTT = new SelectList(db.TINHTRANGs, "IDTT", "TenTT", dONDATHANG.IDTT);
            ViewBag.IDKH = new SelectList(db.NGUOIDUNGs, "IDND", "TenDN", dONDATHANG.IDKH);
            return View(dONDATHANG);
        }

        // GET: QLDDH/DONDATHANGADMINs/Delete/5
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

        // POST: QLDDH/DONDATHANGADMINs/Delete/5
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
