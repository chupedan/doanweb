using QLGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace QLGO.Controllers
{
    public class LoaiSPsController : Controller
    {
        // GET: LoaiSPs
        private QLGOEntities1 db = new QLGOEntities1();
        public ActionResult Index()
        {
           
            HomeModels homeModel = new HomeModels();
            homeModel.lstLoaiSP = db.LOAISANPHAMs.ToList();
            homeModel.lstSP = db.SANPHAMs.ToList();
            return View(homeModel);
        }
        public ActionResult MatHangLoaiMH(string id)
        {
            HomeModels homeModel = new HomeModels();
            homeModel.lstLoaiSP = db.LOAISANPHAMs.ToList();
            homeModel.lstSP = db.SANPHAMs.Where(n => n.IDLSP.Equals(id)).ToList();

            return View(homeModel);
        }
    }
}