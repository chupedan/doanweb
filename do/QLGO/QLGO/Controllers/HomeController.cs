using QLGO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLGO.Controllers
{
    public class HomeController : Controller
    {
        QLGOEntities1 db = new QLGOEntities1(); 
        
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string user, string password)
        {
            var userFromDb = db.NGUOIDUNGs.FirstOrDefault(u => u.IDND == user && u.MKDN == password);
            if (userFromDb != null)
            {
                Session["role"] = userFromDb.IDLND;
                Session["user"] = userFromDb.IDND;
                Session["hoten"] = userFromDb.TenDN;

                if (userFromDb.IDLND == "QL" || userFromDb.IDLND == "NV" || userFromDb.IDLND == "KT")
                {
                    return RedirectToAction("Index", "NGUOIDUNGs", new { area = "QLNV" });
                }
                else if (userFromDb.IDLND == "TN")
                {
                    return RedirectToAction("Index", "DONDATHANGADMINs", new { area = "QLDDH" });
                }
                else if (userFromDb.IDLND == "QLK")
                {
                    return RedirectToAction("Index", "SANPHAMAMINDs", new { area = "QLHH" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["error"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View();
            }
        }
        public ActionResult DangXuat()  
        {
            Session.Clear();
            return RedirectToAction("DangNhap", "Home");
        }

        public ActionResult Index()
        {
           // if (Session["user"] == null)
           //{
           //return RedirectToAction("DangNhap");

            //}
            HomeModels homeModel = new HomeModels();

            homeModel.lstLoaiSP = db.LOAISANPHAMs.ToList();
            homeModel.lstSP = db.SANPHAMs.ToList();
            return View(homeModel);
        }
        string LayMaND()
        {
            var maMax = db.NGUOIDUNGs.Any() ? db.NGUOIDUNGs.Select(n => n.IDND).Max() : "ND000";
            int maND = int.Parse(maMax.Substring(2)) + 1;
            string ND = String.Concat("000", maND.ToString());
            return "ND" + ND.Substring(maND.ToString().Length - 1);
        }
        // GET: QLNV/NGUOIDUNGs
        public ActionResult DangKy()
        {
            ViewBag.MaNV = LayMaND();
            ViewBag.IDLND = new SelectList(db.LOAINGUOIDUNGs, "IDLND", "TenLND");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy([Bind(Include = "IDND,MKDN,TenDN,HoND,TenND,SDTND,EmailND,GioiTinh,DiemThuong,NgaySinh,IDLND")] NGUOIDUNG nGUOIDUNG)
        {
            if (ModelState.IsValid)
            {
                nGUOIDUNG.IDND = LayMaND(); // Tạo mã người dùng tự động
                db.NGUOIDUNGs.Add(nGUOIDUNG);
                try
                {
                    // Thử lưu trữ dữ liệu vào cơ sở dữ liệu
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException ex)
                {
                    // Lấy thông tin chi tiết về các lỗi xảy ra trong quá trình lưu trữ
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            // Hiển thị thông tin về lỗi
                            Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                        }
                    }

                    // Đảm bảo bạn xử lý lỗi một cách thích hợp ở đây, ví dụ: hiển thị thông báo lỗi cho người dùng hoặc ghi vào log
                    throw; // Ném lại lỗi để nó được xử lý ở mức cao hơn
                }

            }

            ViewBag.IDLND = new SelectList(db.LOAINGUOIDUNGs, "IDLND", "TenLND", nGUOIDUNG.IDLND);

            return View(nGUOIDUNG);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}