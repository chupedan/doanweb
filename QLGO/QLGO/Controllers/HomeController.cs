using QLGO.Models;
using System;
using System.Collections.Generic;
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
                Session["user"] = userFromDb.IDND;
                Session["role"] = userFromDb.IDLND;
                if (userFromDb.IDLND == "QL" || userFromDb.IDLND == "NV" || userFromDb.IDLND == "KT")
                {
                    return RedirectToAction("Index", "NGUOIDUNGs", new { area = "QLNV" });
                }
                else if (userFromDb.IDLND == "TN")
                {
                    return RedirectToAction("Index", "DONDATHANGs", new { area = "QLDDH" });
                }
                else if (userFromDb.IDLND == "QLK")
                {
                    return RedirectToAction("Index", "SANPHAMs", new { area = "QLHH" });
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

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap");

            }
            else
            {
                return View();
            }
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