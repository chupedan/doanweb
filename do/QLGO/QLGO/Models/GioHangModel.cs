using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLGO.Models
{
    public class GioHangModel
    {
        public int SL { get; set; }
        public SANPHAM sp { get; set; }
        public DONDATHANG hd { get; set; }
    }
}