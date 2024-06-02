using QLGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLGO.Controllers
{
    public class SanPhamsController : Controller
    {
        // GET: SanPhams
        private QLGOEntities1 db = new QLGOEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM matHang = db.SANPHAMs.Find(id);
            if (matHang == null)
            {
                return HttpNotFound();
            }
            return View(matHang);
        }
    }
}