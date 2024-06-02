using QLGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLGO.Controllers
{
    public class GioHangController : Controller
    {
        private QLGOEntities1 db = new QLGOEntities1();
        // GET: GioHang
        public ActionResult Index()
        {
            return View((List<GioHangModel>)Session["cart"]);
        }
        public ActionResult ThemMatHang(String id, int SL)
        {

            if (Session["cart"] == null)
            {
                List<GioHangModel> cart = new List<GioHangModel>();
                cart.Add(new GioHangModel { sp = db.SANPHAMs.Find(id), SL = SL });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = tonTai(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].SL += SL;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new GioHangModel { sp = db.SANPHAMs.Find(id), SL = SL });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        private int tonTai(String id)
        {
            List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].sp.IDSP.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult XoaMatHang(String Id)
        {
            List<GioHangModel> cart = (List<GioHangModel>)Session["cart"];
            cart.RemoveAll(x => x.sp.IDSP == Id);
            Session["cart"] = cart;
            if (Convert.ToInt32(Session["count"]) > 0)
                Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
    }
}