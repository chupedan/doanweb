using QLGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLGO.Areas.BCTK.Models;

namespace QLGO.Areas.BCTK.Controllers
{
    public class ThongKeController : Controller
    {
        QLGOEntities1 db = new QLGOEntities1();
        public ActionResult DoanhThu()
        {
            var doanhThu = db.DONDATHANGs
            .Join(db.CTDONDATHANGs, ddh => ddh.IDDDH, ctd => ctd.IDDDH, (ddh, ctd) => new { ddh, ctd })
            .Join(db.SANPHAMs, d => d.ctd.IDSP, sp => sp.IDSP, (d, sp) => new { d.ddh, d.ctd, sp })
            .AsEnumerable()
            .GroupBy(g => new { ThangNam = g.ddh.NgayDatHang.ToString("yyyy-MM") })
            .Select(s => new DoanhThuViewModel
            {
                ThangNam = s.Key.ThangNam,
                DoanhThu = s.Sum(x => (x.sp.GiaGiam > 0 ? x.sp.GiaGiam : x.sp.GiaBan) * x.ctd.SLDat)
            })
            .OrderBy(o => o.ThangNam)
            .ToList();

            return View(doanhThu);
        }

        public ActionResult HangBan()
        {
            var hangBan = db.DONDATHANGs
                .Join(db.CTDONDATHANGs, ddh => ddh.IDDDH, ctd => ctd.IDDDH, (ddh, ctd) => new { ddh, ctd })
                .Join(db.SANPHAMs, d => d.ctd.IDSP, sp => sp.IDSP, (d, sp) => new { d.ddh, d.ctd, sp })
                .AsEnumerable()
                .GroupBy(g => new { ThangNam = g.ddh.NgayDatHang.ToString("yyyy-MM"), g.sp.TenSP })
                .Select(s => new HangBanViewModel
                {
                    ThangNam = s.Key.ThangNam,
                    TenSP = s.Key.TenSP,
                    SoLuongBan = s.Sum(x => x.ctd.SLDat)
                })
                .OrderBy(o => o.ThangNam)
                .ToList();

            return View(hangBan);
        }
    }
}